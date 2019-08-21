var level = 1, gameMode = 0;
var finalscore = 0;
var coin = 50;
var score = 0, maxRound = 0, cardCount = 0, ansCounter = 0, cardCountPerRound = 0;
var id = "", dataType = 0, dataCounter = 0, loadType = 1;
var isDragging = false;
var checkedRounds = [];
var ansDragged;
var offlineToks = [];

function Init(mode = 1, loadtype = 1) {
    coin = 50;
    score = 0;
    finalscore = 0;
    level = 1;
    ansCounter = 0;
    gameMode = mode;
    loadType = loadtype;
    $("#cardContainer").html('');
    
    switch (gameMode) {
        case "2":
            $("#txtScoreSection").css("display", "none");
            $(window).keydown(function (e) {
                switch (e.keyCode) {
                    case 39: // Right Arrow
                        navigate(1);
                        break;
                    case 37: // Left Arrow
                        navigate(-1);
                        break;
                }
            });
            break;
        case "1":
        default:
            break;
    }

    //console.log(maxRound);
    for (var i = 1; i <= maxRound; i++) {
        renderRound(i);
    }
    
    $('#coinValue').text(coin);
    navigate(0);
}

function next() {
    if (level <= maxRound) {
        level = level + 1;
        switch (score) {
            case 1:
                coin += 10;
                break;
            case 2:
                coin += 20;
                break;
            case 3:
                coin += 50;
                break;
            default:
                coin += 0;
                break;
        }

        $('#coinValue').text(coin); // Set Coins

        navigate(0); // Navigate to Next Round

        score = 0;
        $(".custom-card > .front").find("div").css("display", "");
        $(".custom-card").flip(false);
        document.getElementById('sidePopup').style.display = "none";

        var btndiv = document.querySelector('.btnsendreset');
        btndiv.style.display = "block";
    }
}

function VerifyCards() {
    cardCountPerRound = 0;
    ansCounter = 0;
    $(".cardColumn").each(function () {
        var rnd = $(this).attr("data-round");
        if (rnd == level) { // Same Round
            cardCountPerRound += 1;
            if ($(this).find(".front > .answerHolder").length > 0) {
                ansCounter += 1;
            }
        }
    });
}

function flip(btn) {
    for (var i = 0; i < checkedRounds.length; i++) {
        if (checkedRounds[i] == level) {
            // Unflips only the current level/round
            $(".cardColumn").each(function () {
                var rnd = $(this).attr("data-round");
                if (rnd == level) {
                    $(this).find(".answerHolder").each(function () {
                        this.addEventListener('dragstart', dragStart);
                        this.addEventListener('dragend', dragEnd);
                    });

                    $(this).find(".answerContainer").each(function () {
                        this.addEventListener('dragover', dragOver);
                        this.addEventListener('drop', dragDrop);
                    });

                    $(this).find(".custom-card").flip(false);
                }
            });

            checkedRounds.splice(i, 1);
            $(btn).text("CHECK");
            $(btn).append("<img src='/images/tokmatch/check.png' class='w3-left' style='max-height:20px;max-width:20px;' />");
            return;
        }
    }

    VerifyCards();

    if (ansCounter >= cardCountPerRound) {
        remark();
        switch (score) {
            case 0:
                var bgSoundfailed = new Audio("../sounds/wrongsound.wav");
                bgSoundfailed.play();
                break;
            case 1:
                var bgSoundcorrect = new Audio("../sounds/goodsound.wav");
                bgSoundcorrect.play();
                break;
            case 3:
                var bgSoundcorrect = new Audio("../sounds/correctsound1.wav");
                bgSoundcorrect.play();
                break;
            default:
        }

        // Flips only the current level/round
        $(".cardColumn").each(function () {
            var rnd = $(this).attr("data-round");
            if (rnd == level) {
                $(this).find(".answerHolder").each(function () {
                    this.removeEventListener('dragstart', dragStart);
                    this.removeEventListener('dragend', dragEnd);
                });

                $(this).find(".answerContainer").each(function () {
                    this.removeEventListener('dragover', dragOver);
                    this.removeEventListener('drop', dragDrop);
                });

                $(this).find(".custom-card").flip(true);
            }
        });

        finalscore = finalscore + score;
        $('#score').text(parseInt(finalscore));

        if (gameMode != "2") { // Buttons can only be hidden in normal mode
            var btndiv = document.querySelector('.btnsendreset');
            btndiv.style.display = "none";
        }
        else if (gameMode == "2") {
            checkedRounds.push(level);
            $(btn).text("UNCHECK");
            $(btn).append("<img src='/images/tokmatch/check.png' class='w3-left' style='max-height:20px;max-width:20px;' />");
        }

        if (level == maxRound) {
            if (gameMode != "2") { // If normal mode
                endGame();
            }
        } else {
            if (gameMode != "2") { // Do not show in education mode
                // Show Popup
                document.getElementById('sidePopup').style.display = "block";
            }
            ansCounter = 0;

            var bgSound = new Audio("../sounds/gamesound1.wav");
            bgSound.loop = true;
            //bgSound.play();

            var reset = new Audio();
            reset.src = "../sounds/resetsound.wav";
            reset.play();
            //bgSound.play();
        }
    }
}

function remark() {
    var msg = "";
    switch (score) {
        case 0:
            msg = "Failed!";
            break;
        case 1:
        case 2:
            msg = "Good!";
            break;
        case 3:
            msg = "Excellent!";
            break;
    }
    
    $("#remarks").text(msg);
}

function reset() {
    var reset = new Audio();
    reset.src = "../sounds/resetsound.wav";
    reset.play();

    ansCounter = 0;

    // Revert the check button
    for (var i = 0; i < checkedRounds.length; i++) {
        if (checkedRounds[i] == level) {
            $("#btnCheck").text("CHECK");
            $("#btnCheck").append("<img src='/images/tokmatch/check.png' class='w3-left' style='max-height:20px;max-width:20px;' />");
            checkedRounds.splice(i,1);
            break;
        }
    }

    // Return all non-hidden cards back to answer
    $(".cardColumn").each(function () {
        var rnd = $(this).attr("data-round");
        if (rnd == level) {
            var ansBlock = $(this).find(".custom-card > .front").find(".answerHolder");
            var tokId_ans = ansBlock.attr("data-matchid");
            
            // Show all content again
            $(this).find(".custom-card > .front").find(".description").css("display", "");

            // Return answer block to its container
            $(".cardColumn").find(".answerContainer").each(function () {
                var tokId = $(this).attr("data-tokid");
                if (tokId == tokId_ans) {
                    $(this).find(".backImage").addClass("hide");
                    $(this).append(ansBlock);
                }
            });


            $(this).find(".answerHolder").each(function () {
                this.addEventListener('dragstart', dragStart);
                this.addEventListener('dragend', dragEnd);
            });

            $(this).find(".answerContainer").each(function () {
                this.addEventListener('dragover', dragOver);
                this.addEventListener('drop', dragDrop);
            });

            ansBlock.find(".img-container").removeClass("hide");
            ansBlock.addClass("empty2");
            ansBlock.css("position", "relative");
            ansBlock.parent().css("border", "");
            ansBlock.parent().css("margin-top", "");
            $(this).find(".custom-card").flip(false); // Unflip the flipped card
        }
    });
}

// Drag Functions
function dragStart(ans) {
    isDragging = true;
    ansDragged = ans;
}

function dragEnd(ev) {
    if (isDragging) {
        var container = ev.path[1];
        var holder = ev.path[0];
        var isCard = $(container).attr("data-iscard") == "1";
        var isAnswer = $(container).attr("data-iscontainer") == "1";

        if (isCard) {
            //$(container).find(".description").css("display", "none");
            //$(holder).removeClass("hold");

            $(container).style("border-width", "");
            $(container).style("border-style", "");
            $(container).style("border-color", "");
        }
        else if (isAnswer) {
            $(container).css("border", "");
            $(container).css("margin-top", "");
            $(container).css("border-radius:", "");
        }
    }

    isDragging = false;
}

function dragOver(e) {
    e.preventDefault();
    var isAnswer = $(this).attr("data-iscontainer") == "1";

    if (!isAnswer) {
        $(this).style("border-width", "3px", "important");
        $(this).style("border-style", "dashed", "important");
        $(this).style("border-color", "#FFF753", "important");
    }
}

function dragEnter(e) {
    e.preventDefault();
    $(this).style("border-width", "3px", "important");
    $(this).style("border-style", "dashed", "important");
    $(this).style("border-color", "#FFF753", "important");
}

function dragLeave() {
    $(this).style("border-width", "");
    $(this).style("border-style", "");
    $(this).style("border-color", "");
}

function dragDrop() {
    var beep = new Audio();
    var isCard = $(this).attr("data-iscard") == "1";
    var isAnswer = $(this).attr("data-iscontainer") == "1";

    beep.src = "../sounds/dropsound.wav";
    beep.play();
    //console.log(card.find(".answer").length);

    if (isCard) {
        var card = $(this).find("div");
        //console.log(card);
        if (card.find(".answer").length == 0) {
            $(ansDragged).removeClass("empty2");
            //$(ansDragged).removeClass("w3-animate-leftAlli");
            $(ansDragged).css("position", "");
            if ($(ansDragged).parent().attr("data-iscontainer") == "1") {
                $(ansDragged).parent().css("border", "2px dashed white");
                $(ansDragged).parent().css("margin-top", "20px");
                $(ansDragged).parent().css("border-radius:", "20px");
                $(ansDragged).parent().find(".backImage").removeClass("hide");
            }

            $(ansDragged).find(".img-container").addClass("hide");
            this.appendChild(ansDragged);
            checkAnswer(ansDragged);
        }
        else if (card.find(".answer").length == 1) {
            var swapAns = card.find(".answer").parent();
            var newSwapContainer = $(ansDragged).parent();

            if ($(newSwapContainer).attr("data-iscontainer") == "1") {
                return;
            } else {
                $(ansDragged).removeClass("empty2");
                $(ansDragged).css("position", "");
                $(ansDragged).find(".img-container").addClass("hide");

                $(newSwapContainer).append(swapAns);

                this.appendChild(ansDragged);
                checkAnswer(ansDragged);
            }
        }
    }
    else if (isAnswer) {
        var ans = $(this);
        if (ans.find(".answer").length == 0) {
            var tokId = ans.attr("data-tokid");
            var tokId_ans = $(ansDragged).attr("data-matchid");
            console.log(tokId + " == " + tokId_ans);
            if (tokId == tokId_ans) {
                $(ansDragged).addClass("empty2");
                $(ansDragged).css("position", "relative");
                ans.css("border", "");
                ans.css("margin-top", "");
                ans.css("border-radius:", "");
                ans.find(".backImage").addClass("hide");
                $(ansDragged).find(".img-container").removeClass("hide");

                this.appendChild(ansDragged);
            }
        }
    }
}

// shuffle the the questions and answers
function shuffle(array) {
    var currentIndex = array.length, temporaryValue, randomIndex;

    // While there remain elements to shuffle...
    while (0 !== currentIndex) {

        // Pick a remaining element...
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex -= 1;

        // And swap it with the current element.
        temporaryValue = array[currentIndex];
        array[currentIndex] = array[randomIndex];
        array[randomIndex] = temporaryValue;
    }

    return array;
}

function shuffleAnswer() {
    var indexes = [], answers = [], answerContainers = [];
    var i = 0;
    $(".cardColumn").each(function () {
        var rnd = $(this).attr("data-round");
        if (rnd == level && jQuery.inArray(level, checkedRounds) == -1) {
            indexes.push(i); // Push indexes to array

            var ans = $(this).find(".answerContainer");
            var contr = $(this).find(".shuffleContainer");
            answers.push(ans); // Push answer container to array
            answerContainers.push(contr); // Push containers to array for shuffling

            i++;
        }
    });

    //console.log(indexes);
    //console.log(answers);

    if (indexes.length > 0) {
        var res = ShuffleNumbers(indexes);
        //console.log(res);
        if (res.length > 0) {
            for (var i = 0; i < res.length; i++) {
                var idx = res[i];
                $(answerContainers[i]).append(answers[idx]);
            }
        }
    }
}

function checkAnswer() {
    //console.log("checking...");
    var cols = $(".cardColumn");
    score = 0;

    cols.each(function () {
        var rnd = $(this).attr("data-round");
        if (rnd == level) // Only visible cards 
        {
            var ans = $(this).find(".answerHolder");
            var p = $(ans).parent();

            if (typeof p != 'undefined') {
                var mId = p.attr("data-matchid");
                var mId2 = $(ans).attr("data-matchid");

                if (mId == mId2) { // If id matches
                    p.parent().find("img#answerBack").attr("src", "../images/tokmatch/checkgif.jpg");
                    //p.parent().find("h5#backtxt").text("Correct!");
                    score += 1;

                    //console.log("Correct!");
                }
                else {
                    p.parent().find("img#answerBack").attr("src", "../images/tokmatch/x.png");
                    //p.parent().find("h5#backtxt").text("Wrong!");

                    //console.log("Mismatch!");
                }
            }
            else {
                p.parent().find("img#answerBack").attr("src", "../images/tokmatch/x.png");
                //p.parent().find("h5#backtxt").text("Wrong!");
                //console.log("Wrong!");
            }
        }
    });
}

function bigImg(x) {
    x.style.transform = "scale(1.1, 1.2)";
}

function normalImg(x) {
    x.style.transform = "scale(1, 1)";
}

function renderRound(curRound = 1) {
    var url = loadType == 1 ? "/Tok/GetTokMatchRound?id=" + id + "&round=" + curRound + "&type=" + dataType : "/Tok/GetTokMatchRound?round=" + curRound;
    $.ajax({
        url: url,
        type: loadType == 1 ? "GET" : "POST",
        data: loadType == 1 ? null : { toks: offlineToks},
        async: true,
        beforeSend: function () {
            $(".containerProgress").css("display", "");
        },
        success: function (htmlData) {
            $(".containerProgress").css("display", "none");
            $("#cardContainer").append(htmlData);
        },
        error: function () {
            $(".containerProgress").css("display", "none");
        },
        complete: function (e) {
            $(".containerProgress").css("display", "none");

            switch (gameMode) {
                case "1":
                    $("#btnPrevious").addClass("hide");
                    $("#btnNext").addClass("hide");
                    break;
                case "2":
                    $("#btnPrevious").removeClass("hide");
                    $("#btnNext").removeClass("hide");
                    break;
            }
            
            $(".custom-card").flip({
                axis: 'y',
                trigger: 'manual',
                autoSize: false
            });
            
            $(".cardColumn").each(function () {
                var rnd = $(this).attr("data-round");

                if (rnd == curRound) {
                    if (!$(this).hasClass("hide")) {
                        $(this).addClass("hide");
                    }

                    // Show First Card
                    if (curRound == 1) {
                        $(this).removeClass("hide");

                        // Shuffle Answer
                        shuffleAnswer();
                    }

                    var cards = $(this).find(".custom-card > .front");
                    var answers = $(this).find(".answerHolder");
                    var answerContainers = $(this).find(".answerContainer");

                    // Fill listeners
                    answers.each(function () {
                        this.addEventListener('dragstart', dragStart);
                        this.addEventListener('dragend', dragEnd);
                        //this.addEventListener('click', revert1);
                    });

                    answerContainers.each(function () {
                        this.addEventListener('dragover', dragOver);
                        this.addEventListener('drop', dragDrop);
                    });

                    // Loop through empty boxes and add listeners
                    for (const card of cards) {
                        // Add Drag and Drop Listeners
                        card.addEventListener('dragover', dragOver);
                        card.addEventListener('dragenter', dragEnter);
                        card.addEventListener('dragleave', dragLeave);
                        card.addEventListener('drop', dragDrop);
                    }
                }
            });

            var btndiv = document.querySelector('.btnsendreset');
            btndiv.style.display = "block";
        }
    });
}

function endGame() {
    $("#txtFinalScore").text(finalscore);

    $('#gameOverModal').modal('show');
}

function showMore(btn) {
    var icon = $(btn).find(".showMoreIcon");
    var sp = $(btn).parent().find("span");
    var cp = $(btn).parent().parent();
    if (sp.hasClass("hide")) {
        sp.removeClass("hide");
        $(btn).parent().removeClass("center-content");
        $(btn).css("position", "unset");
        icon.removeClass("fa-angle-double-down");
        icon.addClass("fa-angle-double-up");
        cp.css("display", "block");
    }
    else {
        sp.addClass("hide");
        if(sp.length > 0) $(sp[0]).removeClass("hide");
        $(btn).parent().addClass("center-content");
        $(btn).css("position", "absolute");
        icon.removeClass("fa-angle-double-up");
        icon.addClass("fa-angle-double-down");
        cp.css("display", "flex");
    }
}

function navigate(idx = 1) {
    level += idx;
    console.log(level);
    if (level <= 0) level = 1;
    else if (level > maxRound) level = 1; // Back to level/round 1

    $(".cardColumn").each(function () {
        var rnd = $(this).attr("data-round");

        $(this).addClass("hide"); // Hide first
        if (rnd == level) { // then unhide the current round
            $(this).removeClass("hide");
        }
    });

    //console.log("Shuffling...");
    // Shuffle Answer
    shuffleAnswer();

    // Change Check Button
    for (var i = 0; i < checkedRounds.length; i++) {
        if (checkedRounds[i] == level) {
            $("#btnCheck").text("UNCHECK");
            $("#btnCheck").append("<img src='/images/tokmatch/check.png' class='w3-left' style='max-height:20px;max-width:20px;' />");
            break;
        }
        else {
            $("#btnCheck").text("CHECK");
            $("#btnCheck").append("<img src='/images/tokmatch/check.png' class='w3-left' style='max-height:20px;max-width:20px;' />");
        }
    }
}

// JQuery Customize Function
(function ($) {
    if ($.fn.style) {
        return;
    }

    // Escape regex chars with \
    var escape = function (text) {
        return text.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, "\\$&");
    };

    // For those who need them (< IE 9), add support for CSS functions
    var isStyleFuncSupported = !!CSSStyleDeclaration.prototype.getPropertyValue;
    if (!isStyleFuncSupported) {
        CSSStyleDeclaration.prototype.getPropertyValue = function (a) {
            return this.getAttribute(a);
        };
        CSSStyleDeclaration.prototype.setProperty = function (styleName, value, priority) {
            this.setAttribute(styleName, value);
            var priority = typeof priority != 'undefined' ? priority : '';
            if (priority != '') {
                // Add priority manually
                var rule = new RegExp(escape(styleName) + '\\s*:\\s*' + escape(value) +
                    '(\\s*;)?', 'gmi');
                this.cssText =
                    this.cssText.replace(rule, styleName + ': ' + value + ' !' + priority + ';');
            }
        };
        CSSStyleDeclaration.prototype.removeProperty = function (a) {
            return this.removeAttribute(a);
        };
        CSSStyleDeclaration.prototype.getPropertyPriority = function (styleName) {
            var rule = new RegExp(escape(styleName) + '\\s*:\\s*[^\\s]*\\s*!important(\\s*;)?',
                'gmi');
            return rule.test(this.cssText) ? 'important' : '';
        }
    }

    // The style function
    $.fn.style = function (styleName, value, priority) {
        // DOM node
        var node = this.get(0);
        // Ensure we have a DOM node
        if (typeof node == 'undefined') {
            return this;
        }
        // CSSStyleDeclaration
        var style = this.get(0).style;
        // Getter/Setter
        if (typeof styleName != 'undefined') {
            if (typeof value != 'undefined') {
                // Set style property
                priority = typeof priority != 'undefined' ? priority : '';
                style.setProperty(styleName, value, priority);
                return this;
            } else {
                // Get style property
                return style.getPropertyValue(styleName);
            }
        } else {
            // Get CSSStyleDeclaration
            return style;
        }
    };
})(jQuery);