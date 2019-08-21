var curProgress = 1;
var maxPlayCards = 0;
var isPlaying = false, playFavoritesOnly = false;
var playingCard;
var playingNav;
var favorites = [], allCards = [];

function LoadCounter(container, index = 0) {
    var animz = bodymovin.loadAnimation({
        container: $(container).parent().find(".progress_small")[0], // Required
        path: window.location.origin + '/images/anim/trail_loading.json', //baseUrl + 'images/anim/trail_loading.json', // Required
        renderer: 'svg', // Required
        loop: true, // Optional
        autoplay: true, // Optional
        name: "" // Name for future reference. Optional.
    });

    $.ajax({
        url: "/Home/GetTopCounter?index=" + index,
        type: "GET",
        async: true,
        success: function (htmlData) {
            $(container).html(htmlData);
        },
        error: function () {
            $(container).parent().find(".containerProgress").hide();
        },
        complete: function () {
            $(container).parent().find(".containerProgress").hide();
        }
    });
}

function OpenModal(elem) {
    $(elem).modal('toggle');
}

function ApplyFlipCard_Manual() {
    $(".custom-card").flip({
        axis: 'y',
        trigger: 'manual',
        autoSize: false
    });
}

function FlipCard(thisCard) {
    $(thisCard).flip('toggle');
}

function ApplyMagnificPopup() {
    //Image popup

    $('.img-container').magnificPopup({ //.image-popup-no-margins
        delegate: '.image-popup-no-margins',
        type: 'image',
        closeOnContentClick: true,
        closeBtnInside: false,
        fixedContentPos: true,
        mainClass: 'mfp-no-margins mfp-with-zoom', // class to remove default margin from left and right side
        image: {
            verticalFit: true
        },
        zoom: {
            enabled: true,
            duration: 300 // don't foget to change the duration also in CSS
        },
        callbacks: {
            open: function () {
                // Will fire when this exact popup is opened
                // this - is Magnific Popup object
            },
            close: function () {
                // Will fire when popup is closed

            }
        }
    });
}

function NavigateCards(isRight = false) {
    //console.log(allCards);

    if (!playFavoritesOnly) {
        // Hide current card
        if (curProgress > 0 && curProgress <= maxPlayCards - 1) {
            for (var x = 0; x < allCards.length; x++) {
                $(allCards[x]).removeClass("show");
                $(allCards[x]).addClass("hide");   
            }
        }

        // Increment Progress
        if (isRight) curProgress += curProgress < maxPlayCards - 1 ? 1 : 0;
        else curProgress -= curProgress > 1 ? 1 : 0;
        
        var idx = curProgress - 1;
        // Show Card
        $(allCards[idx]).addClass("show");
        $(allCards[idx]).removeClass("hide");

        // Animation here...
        $(allCards[idx]).css('left', '150px');
        $(allCards[idx]).css('opacity', 0);
        $(allCards[idx]).animate({ left: '0px', opacity: 1 });
    }
    else {
        // Hide current card
        if (curProgress > 0 && curProgress <= favorites.length) {
            $(favorites[curProgress - 1]).removeClass("show");
            $(favorites[curProgress - 1]).addClass("hide");
        }

        // Increment Progress
        if (isRight) curProgress += curProgress < favorites.length ? 1 : 0;
        else curProgress -= curProgress > 1 ? 1 : 0;

        // Show Card
        $(favorites[curProgress - 1]).addClass("show");
        $(favorites[curProgress - 1]).removeClass("hide");

        // Animation here...
        $(favorites[curProgress - 1]).css('left', '150px');
        $(favorites[curProgress - 1]).css('opacity', 0);
        $(favorites[curProgress - 1]).animate({ left: '0px', opacity: 1 });
    }

    $("#cardProgress").attr("value", curProgress);
    $("#progCounter").text(curProgress);
}

function AddToFavorites(thisCard) {

    if ($(thisCard).find(".front").hasClass("favorite")) {
        $(thisCard).find(".tokkepedia-favorite").removeClass("active");
        $(thisCard).find(".front").removeClass("favorite");
        $(thisCard).find(".back").removeClass("favorite");

        // Remove from array
        favorites.splice(favorites.indexOf($(thisCard)), 1);
    }
    else {
        $(thisCard).find(".tokkepedia-favorite").addClass("active");
        $(thisCard).find(".front").addClass("favorite");
        $(thisCard).find(".back").addClass("favorite");

        // Add to favorites array
        favorites.push($(thisCard));
    }

}

function FlipAllCards() {
    $(".custom-card").flip('toggle');
}

function InitCards(container) {
    var cards = $(container).find(".custom-card");
    for (var i = 0; i < cards.length; i++) {
        if (i == 0) {
            $(cards[i]).addClass("show");
        }
        else {
            $(cards[i]).addClass("hide");
        }
        allCards.push(cards[i]); // Push cards to array
    }
}

function ShuffleCards(container) {
    if (!playFavoritesOnly) {
        if (allCards.length > 0) {
            var cards = $(container).find(".custom-card");
            var indexes = [];
            for (var i = 0; i < cards.length; i++) {
                indexes.push(i); // Push indexes to array
            }

            var res = ShuffleNumbers(indexes);
            if (res.length > 0) {
                // Clear Array
                allCards = [];
                for (var i = 0; i < res.length; i++) {
                    allCards.push(cards[res[i]]); // Push cards to array
                }

                curProgress = 1; // Back to 1
                RefreshCards(container);
            }
        }
    }
    else {
        if (favorites.length > 0) {
            var indexes = [];
            for (var i = 0; i < favorites.length; i++) {
                indexes.push(i); // Push indexes to array
            }

            var res = ShuffleNumbers(indexes);
            if (res.length > 0) {
                // Clear Array
                var tempFavs = favorites;
                favorites = [];
                for (var i = 0; i < res.length; i++) {
                    favorites.push(tempFavs[res[i]]); // Push cards to array
                }

                curProgress = 1; // Back to 1
                RefreshCards(container);
                // Hide default
                $(allCards[0]).addClass("hide");
                $(allCards[0]).removeClass("show");

                for (var i = 0; i < favorites.length; i++) {
                    $(favorites[i]).removeClass("hide");
                    $(favorites[i]).removeClass("show");

                    if (i == 0) $(favorites[i]).addClass("show");
                    else $(favorites[i]).addClass("hide");
                }
            }
        }
    }
}

function RefreshCards(container) {
    var cards = $(container).find(".custom-card");
    for (var i = 0; i < cards.length; i++) {
        $(allCards[i]).removeClass("hide");
        $(allCards[i]).removeClass("show");

        if (i == 0) $(allCards[i]).addClass("show");
        else $(allCards[i]).addClass("hide");

        ApplyFlipCard_Manual();
        ApplyMagnificPopup();
    }
    
    $("#cardProgress").attr("value", curProgress);
    $("#progCounter").text(curProgress);
}

function RemoveFavorites(container) {
    var cards = $(container).find(".custom-card");
    
    $(cards).find(".tokkepedia-favorite").removeClass("active");
    $(cards).find(".front").removeClass("favorite");
    $(cards).find(".back").removeClass("favorite");
    favorites = [];

    RefreshCards(container);

    curProgress = 1;
    $("#cardProgress").attr("value", 1);
    $("#progCounter").text(1);
    $("#cardProgress").attr("max", maxPlayCards - 1);
    $("#progMax").text(maxPlayCards - 1);

    playFavoritesOnly = false;
    $("#chkFavoritesOnlyOption").removeAttr("checked");
}

function ShuffleNumbers(o) {
    for (var j, x, i = o.length; i; j = parseInt(Math.random() * i), x = o[--i], o[i] = o[j], o[j] = x);
    return o;
};

function Play(durationInSec = 1.0) {
    if (isPlaying) {
        isPlaying = false; // Stop
        clearTimeout(playingNav);
        clearInterval(playingCard);
        console.log("Stop");
        $("#btnPlay").html("<i class='fas fa-play'></i> Play");
        $("#btnPlay").addClass("btn-primary");
        $("#btnPlay").removeClass("btn-danger");
        return;
    }

    console.log("Play");
    $("#btnPlay").html("<i class='fas fa-stop'></i> Stop");
    $("#btnPlay").removeClass("btn-primary");
    $("#btnPlay").addClass("btn-danger");
    isPlaying = true;
    playingCard = setInterval(function () {
        // Flip Card
        if(playFavoritesOnly)
            $(favorites[curProgress - 1]).flip('toggle');
        else
            $(allCards[curProgress - 1]).flip('toggle');

        // Next
        playingNav = setTimeout(function () {
            if (curProgress >= maxPlayCards - 1 && !playFavoritesOnly) {
                curProgress = 1;
                RefreshCards($(".card-container"));
            }
            else if (curProgress >= favorites.length && playFavoritesOnly) {
                curProgress = 1;
                // Hide default
                $(allCards[0]).addClass("hide");
                $(allCards[0]).removeClass("show");

                for (var i = 0; i < favorites.length; i++) {
                    $(favorites[i]).removeClass("hide");
                    $(favorites[i]).removeClass("show");

                    if (i == 0) $(favorites[i]).addClass("show");
                    else $(favorites[i]).addClass("hide");
                }

                $("#cardProgress").attr("value", 1);
                $("#progCounter").text(1);
            }
            else 
                NavigateCards(true);
        }, durationInSec * 1000);
    }, (durationInSec * 1000) * 2); 
}

function ShowImages(sender, container) {
    var isEnabled = $(sender).is(":checked");
    //console.log(isEnabled);

    if (isEnabled) {
        $(container).find(".img-container").css("display", "block");
        //$(container).find(".custom-card > .back").removeClass("center-content");
    }
    else {
        $(container).find(".img-container").css("display", "none");
        //$(container).find(".custom-card > .back").addClass("center-content");
    }
}

function FavoritesOnly(sender, container) {
    playFavoritesOnly = $(sender).is(':checked');

    if (playFavoritesOnly) {
        // Hide Non-favorite cards
        //console.log(favorites.length);
        //console.log(favorites);

        RefreshCards(container);
        // Hide default
        $(allCards[0]).addClass("hide");
        $(allCards[0]).removeClass("show");

        for (var i = 0; i < favorites.length; i++) {
            $(favorites[i]).removeClass("hide");
            $(favorites[i]).removeClass("show");

            if (i == 0) $(favorites[i]).addClass("show");
            else $(favorites[i]).addClass("hide");
        }

        curProgress = 1;
        $("#cardProgress").attr("value", 1);
        $("#progCounter").text(1);
        $("#progMax").text(favorites.length);
        $("#cardProgress").attr("max", favorites.length);
    }
    else {
        RefreshCards(container);

        curProgress = 1;
        $("#cardProgress").attr("value", 1);
        $("#progCounter").text(1);
        $("#cardProgress").attr("max", maxPlayCards - 1);
        $("#progMax").text(maxPlayCards - 1);
    }
}

function AddImageToComment(sender, id) {
    //console.log(sender);
    //console.log(id);
    var container = document.querySelector("#txtCommentEditor_" + id);
    var quill = Quill.find(container);
    var range = quill.getSelection();
    var toggleFlag = $("#txtToggleTokmoji_" + id).attr("data-flag");

    if (range) {
        var idx = range.index;
        if (toggleFlag == 1) {
            quill.insertEmbed(idx, 'image', $(sender).attr("src"));
        }
        else {
            quill.insertText(idx, ":"+$(sender).attr("data-tokmojiId")+":");
        }
        quill.setSelection(idx + 1);
    } else {
        if (toggleFlag == 1) {
            quill.insertEmbed(quill.getLength() - 1, 'image', $(sender).attr("src"));
        }
        else {
            quill.insertText(quill.getLength() - 1, ":" + $(sender).attr("data-tokmojiId") + ":");
        }
    }
    //console.log(quill);
    $(container).find("img").css("height", "32px");
    $(container).find("img").attr("data-toggle", "tooltip");
    $(container).find("img").attr("title", $(sender).attr("data-tokmojiId"));
    // Bootstrap Tooltip
    $(function () {
        $('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="modal"][title]').tooltip();
    })
}

function AddComment(sender, id) {
    var idText = "#txtCommentEditor_" + id;
    var catId = $(sender).attr("data-categoryId");
    var typeId = $(sender).attr("data-tokTypeId");
    var ownerId = $(sender).attr("data-itemUser");
    var actId = $(sender).attr("data-activityId");
    var container = document.querySelector(idText);
    var quill = Quill.find(container);
    var cmsg = ""; 
    var content = quill.getContents();
    console.log(quill.getContents());

    if (content.ops.length > 0) {
        for (var i = 0; i < content.ops.length; i++) {
            var val = content.ops[i];
            if (!isString(val.insert)) {
                //console.log(val.insert.image);
                cmsg += ":" + val.insert.image + ":";
            }
            else {
                cmsg += val.insert;
            }
        }
    }

    console.log(cmsg);
    var ReactionOptions = {};
    ReactionOptions.url = "/Reaction/React";
    ReactionOptions.type = "POST";
    ReactionOptions.data = JSON.stringify({
        label: "reaction",
        activity_id: actId,
        kind: "comment",
        ReactionKind: "Comment",
        owner_id: ownerId,
        category_id: catId,
        tok_type_id: typeId,
        text: cmsg,
        item_id: id
    });
    ReactionOptions.datatype = "html";
    ReactionOptions.contentType = "application/json";
    ReactionOptions.success = function (Data) {
        //$("#TokFeed").prepend(Data);
        //alert("Comment added")
        location.reload();
    };
    ReactionOptions.error = function () {

    };
    $.ajax(ReactionOptions);
} 

function isJSON(data) {
    var ret = true;
    try {
        JSON.parse(data);
    } catch (e) {
        ret = false;
    }
    return ret;
}

// Returns if a value is a string
function isString(value) {
    return typeof value === 'string' || value instanceof String;
}

function ToggleTokmojis(id) {
    var idText = "#txtCommentEditor_" + id;
    var flag = $("#txtToggleTokmoji_" + id).attr("data-flag");
    var container = document.querySelector(idText);
    var quill = Quill.find(container);
    var cmsg = "";
    var content = quill.getContents();
    //console.log(quill.getContents());

    if (content.ops.length > 0) {
        for (var i = 0; i < content.ops.length; i++) {
            var val = content.ops[i];
            if (!isString(val.insert)) {
                //console.log(val.insert.image);
                cmsg += ":" + val.insert.image + ":";
            }
            else {
                cmsg += val.insert;
            }
        }
    }

    console.log(cmsg);
    var Options = {};
    Options.url = "/Reaction/ToggleImage";
    Options.type = "POST";
    Options.data = JSON.stringify({
        text: cmsg.trim(),
        showImage: flag == 0,
    });
    Options.datatype = "html";
    Options.contentType = "application/json";
    Options.success = function (data) {
        //console.log(data);

        $(idText).find(".ql-editor > p").html(data);
        $("#txtToggleTokmoji_" + id).attr("data-flag", (flag == 0 ? 1 : 0));
        $("#txtToggleTokmoji_" + id).text((flag == 0 ? "Hide Tokmoji" : "Show Tokmoji"));

        // Bootstrap Tooltip
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
            $('[data-toggle="modal"][title]').tooltip();
        })
    };
    Options.error = function () {

    };
    $.ajax(Options);
}