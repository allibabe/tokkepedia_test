$(document).ready(function () {

    //set the difficulty if what button is clicked, Moderate ,EASY, Challenging,Difficult

    var getLevel = "";
    //---------------------------------------------------------------

    //letters creator --------------------------------------------
    var tempLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    var TimerStops = false;

    // set variable that checks if the answer is correct default is false

    var answerChecker = false;

    // variable that sets the round ----------------

    var level = 1;
    //---------------------------------------------------------

    // variables for answers function
    // variable letter to mix in the answer and will be shuffled
    var letterTomix = "";

    // variables
    var lettersTobeShulled = "";
    var firtsLetterAnswer = "";
    var answerTempShuffled = "";

    // variables to set the questions array temporary / questions should be on a database/ for the meantime the answers are on the file ->answers.js/
    var arrQuestions = [0, 1];
    var Question = "";

    // variable that will hold the answer that  has been fetched in the answer.js file
    var answerTemp = "";
    //-------------------------------------------------------------------------------

    // variable that will hold the answer and will be mixed  and shulled
    var lettersTobeShulledLast = "";
    //-----------------------------------------------------------------------------

    var lettersTobeShulledBefore = "";

    // function that will run when button quotes,button sayings is clicked
    // this function will run other functions to set the (questions), Buttons on the grid, and answer box on the grid as well as the text Questions or phrase
    var GameMusic = new Audio();

    GameMusic.src = "../sounds/Game music (Tok Blitz).wav";


    function setAll() {
        // set the timer seconds if easy or moderate
        if (getLevel == 1) {
            sec = 15;

        } else if (getLevel == 2) {

            sec = 20;

        } else if (getLevel == 3) {

            sec = 25;

        } else if (getLevel == 4) {

            sec = 30;

        }
        //------------------------------------------------------------------------------

        // temporary letters that will be shuffled
        tempLetters = tempLetters.shuffle();
        // this function will set the questions that has been fetched in answer.js file
        //setterQuestions();

        // get1 function is the one responsible to get the first correct letter in the answer to put in the answer box as given
        get1();

        //
        addletterShuffle();
        // getlettersTobeshuffledlast function is the one that will shuffle when the varaible is already set to be inserted in the buttons
        getlettersTobeShulledLast();

        lettersTobeShulledLast = answerTempShuffled + lettersTobeShulledBefore;
        ShuffledAnswer = lettersTobeShulledLast.shuffle();
        // function that will create the buttons on the word bank
        btncreate();
        // function that will create the boxes on the answerbox
        createBox();

        /// this is to pop up the gamplay modal because the game is basically in modal form with minimal animations
        $('#gameplayMOdal').css({ "display": "block" });
        // $('#gametypeMOdal').css("display", "block");
        onTimer();

        for (u = 0; u < class_Item.length; u++) {
            var a = class_Item[u].id;
            var b = document.getElementById(a);
            var c = 1000;
            var d = c;
            $(b).slideDown(d);
            c = c + 1000;

        }

        // this will just trigger the sounds of the buttons
        // var btnsound = new Audio();
        //btnsound.src = "../sounds/dropsound.wav";
        dropsound.play();


        GameMusic.play();

        btnsoundMain.pause();


        $('#questionid').addClass('w3-animate-leftAlli');
        $('#boardId').addClass('w3-animate-rightAlli');

    }

    // this function will just randomized the numbers from 0 or 1 that will be used to get the answer in answer.js file
    function shuffleQuestion(array) {
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

    // answer shuffler function------------------------------------
    String.prototype.shuffle = function () {
        var a = this.split(""),
            n = a.length;

        for (var i = n - 1; i > 0; i--) {
            var j = Math.floor(Math.random() * (i + 1));
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
        return a.join("");
    }


    //setterQuestions();
    function setterQuestions() {




    }



    // function that glows the text in modal popup id the answer is correct or wrong it shrinks and it goes bigger every .5 interval

    var countGlow = 0;
    function glow() {

        if (countGlow % 2 == 0) {
            document.getElementById('remarksId').style.transform = "scale(1.2, 1.2)";

        } else {

            document.getElementById('remarksId').style.transform = "scale(1, 1)";

        }
        countGlow++;
    }

    setInterval(glow, 300);

    // funtion that glows the thunder button when the time is 10 seconds only to alert the user to use the thuder
    var countGlowThunder = 0;
    function glowThunder() {

        if (countGlowThunder % 2 == 0) {
            document.getElementById('thunderId').style.transform = "scale(1.2, 1.2)";

        } else {

            document.getElementById('thunderId').style.transform = "scale(1, 1)";

        }
        countGlowThunder++;
    }



    // get  the first letter of the answer
    function get1() {

        //firtsLetter = answerTemp;
        firtsLetter = answer;
        //firtsLetter.charAt(0);
        // initilize the firtsletter varible get the substring of answer text and disregard the first letter
        firtsLetter = firtsLetter.substr(1);
        // initialize firtsLetterAnswer variable get the first letter of the answer
        //firtsLetterAnswer = answerTemp[0];
        firtsLetterAnswer = answer[0];
        //initilize the firtsletter varible get the substring of answer text and disregard the first letter
        answerTempShuffled = firtsLetter;

    }


    //addletterShuffle();
    // shuflle templetters and make sure its different from the answer text

    function addletterShuffle() {
        for (i = 0; i < tempLetters.length; i++) {
            var temp = tempLetters[i];

            if (answer.includes(temp) === false) {
                letterTomix = letterTomix + temp;

            }

        }

    }


    //getlettersTobeShulledLast();
    //function that will put a value in lettersTobeSuffled depending on the length of the string
    // if easy, it will only have 6 boxes , moderate, 9 boxes
    function getlettersTobeShulledLast() {

        if (getLevel == 1) {
            setCounterloop = 6;
        } else if (getLevel == 2) {
            setCounterloop = 9;

        } else if (getLevel == 3) {
            setCounterloop = 12;

        } else if (getLevel == 4) {
            setCounterloop = 18;

        }


        var counterLoop = setCounterloop - answer.length
        for (i = 0; i <= counterLoop; i++) {

            lettersTobeShulledBefore = lettersTobeShulledBefore + letterTomix[i];
        }
    }


    var count = 0;
    var ShuffledAnswer = "";

    // set the ShuffledAnswer variable that will be used in creating buttons with text
    // ShuffledAnswer =   lettersTobeShulledLast.shuffle();

    var resetSound = new Audio();
    resetSound.src = "../sounds/resetsound.wav";

    // function play button click sounds
    function playbtnClick() {

        resetSound.play();


    }

    var thunderShock = new Audio();
    thunderShock.src = "../sounds/thunder shock sound.wav";
    thunderShock.preload = "auto";
    var buzzer = new Audio();
    buzzer.src = "../sounds/Family%20feud-buzzer.wav";
    // do this when  button timer is clicked
    $('.Timer').on("click", function TimerOff() {
        // the if statement will just alarm a sound if the thundercount is less than 5 seconds and the button is disabled
        // else, it will stop the timer and decrease the thunderCount 5 points

        if (thunderCount < 5) {

            buzzer.play();


            return false;

        } else {

            playThunderSound();

            topPosition = document.getElementById('clockId').offsetTop;
            leftPosition = document.getElementById('clockId').offsetLeft;
            animateThunderFunction(topPosition, leftPosition);

            clearTimeout(timersetter);
            thunderCount = thunderCount - 5;
            $('#thunderCount').html(thunderCount);
            //$('.Timer').off("click");
            TimerStops = true;


        }




    })


    //initialize elements to create

    var grid_container2 = new Array();
    var class_Item = new Array();
    var grid_Item = new Array();
    var answer_Box = new Array();
    var trialNumber = 0;

    var scoreId = 0;
    var roundId = 1;
    var guessId = 1;

    var remainingGuessId = 0;

    var thunderCount = 20;

    $('#scoreid').html(scoreId);
    $('#roundid').html(roundId);
    $('#guessid').html(guessId);

    $('#userGuess').html(guessId);
    $('#userRound').html(roundId);
    $('#userScore').html(scoreId);


    // functions that creates object

    // btncreate();
    function btncreate() {

        document.getElementById('thunderCount').innerHTML = thunderCount;
        var getLetterLenght = Question.split(" ");
        //alert(getLetterLenght.length);

        var questionBarList = new Array();
        var getbar = document.getElementById("questionid");
        getbar.classList.add('grid-containerQ');
        var BarList = new Array();

        for (t = 0; t < getLetterLenght.length; t++) {
            BarList[t] = document.createElement('DIV');
            BarList[t].classList.add('grid-Q');
            var spanner = document.createElement('span');
            if (t == positionOfAnswer) {
                spanner.innerText = "____";
                BarList[t].appendChild(spanner);
                getbar.appendChild(BarList[t]);
            } else {

                spanner.innerText = getLetterLenght[t];
                BarList[t].appendChild(spanner);
                getbar.appendChild(BarList[t]);

            }

        }




        var btnMain = document.getElementById('btnMain');
        btnMain.classList.add('grid-container2');


        if (getLevel == 2) {
            btnMain.style.grid = "auto/  auto auto auto auto auto auto auto auto auto ";
            btnMain.style.width = "100%";
            btnMain.style.position = "absolute";
            btnMain.style.bottom = "15%";
            btnMain.style.left = "0%";
            btnMain.style.borderRadius = "12px";
            var ansbox = document.getElementById('answerBoxMain');
            ansbox.style.top = "60%";

        } else if (getLevel == 1) {
            btnMain.style.grid = "auto/  auto auto auto auto auto auto ";
            btnMain.style.width = "100%";
            btnMain.style.position = "absolute";
            btnMain.style.bottom = "15%";
            btnMain.style.left = "0%";
            btnMain.style.borderRadius = "12px";

        } else if (getLevel == 3) {
            btnMain.style.grid = "auto /  auto auto auto auto auto auto ";
            btnMain.style.width = "100%";
            btnMain.style.position = "absolute";
            btnMain.style.bottom = "10%";
            btnMain.style.left = "0%";
            btnMain.style.borderRadius = "12px";

        } else if (getLevel == 4) {
            btnMain.style.grid = "auto /  auto auto auto auto auto auto auto auto auto ";
            btnMain.style.width = "100%";
            btnMain.style.position = "absolute";
            btnMain.style.bottom = "10%";
            btnMain.style.left = "0%";
            btnMain.style.borderRadius = "12px";

        }





        for (p = 0; p < ShuffledAnswer.length; p++) {


            class_Item[p] = document.createElement("Div");
            class_Item[p].classList.add('classItem1');
            class_Item[p].id = "btn" + [p] + ShuffledAnswer[p];
            class_Item[p].style.display = "none";

            grid_Item[p] = document.createElement("Div");
            grid_Item[p].classList.add('grid-item');

            grid_Item[p].id = [p] + "_" + ShuffledAnswer[p];
            grid_Item[p].innerText = ShuffledAnswer[p].toUpperCase();
            //grid_Item[p].name = ShuffledAnswer[p];
            grid_Item[p].addEventListener('click', btnselect);
            grid_Item[p].addEventListener('click', playbtnClick);


            class_Item[p].appendChild(grid_Item[p]);
            btnMain.appendChild(class_Item[p]);

        }

    }
    var getBox = document.getElementById('answerBoxMain');
    //function that creates answerbox
    // createBox();
    function createBox() {

        getBox.classList.add('grid-container2');


        //var setClass = "class"+answerTemp.length+"Box";

        //getBox.classList.add('class3Box');


        if (answer.length == 12) {
            getBox.style.width = "98%";
            getBox.style.left = "1%";

            getBox.style.grid = "50px/  auto auto auto auto auto auto auto auto auto auto auto auto";
            getBox.style.top = "64%";

        }





        if (answer.length == 11) {
            getBox.style.width = "98%";
            getBox.style.left = "1%";

            getBox.style.grid = "50px/  auto auto auto auto auto auto auto auto auto auto auto";
            getBox.style.top = "64%";

        }



        if (answer.length == 10) {
            getBox.style.width = "98%";
            getBox.style.left = "1%";

            getBox.style.grid = "50px/  auto auto auto auto auto auto auto auto auto auto";
            getBox.style.top = "64%";

        }



        if (answer.length == 9) {
            getBox.style.width = "96%";
            getBox.style.left = "2%";

            getBox.style.grid = "50px/  auto auto auto auto auto auto auto auto auto";
            getBox.style.top = "64%";

        }

        if (answer.length == 8) {
            getBox.style.width = "90%";
            getBox.style.left = "5%";

            getBox.style.grid = "50px/  auto auto auto auto auto auto auto auto";
            getBox.style.top = "64%";

        }


        if (answer.length == 7) {
            getBox.style.width = "90%";
            getBox.style.left = "5%";

            getBox.style.grid = "50px/  auto auto auto auto auto auto auto";
            getBox.style.top = "64%";
        }


        if (answer.length == 6) {
            getBox.style.width = "80%";
            getBox.style.left = "10%";


            getBox.style.grid = "auto/  auto auto auto auto auto auto";

        }

        if (answer.length == 5) {
            getBox.style.width = "80%";
            getBox.style.left = "10%";

            getBox.style.grid = "auto/ auto auto auto auto auto";

        }

        if (answer.length == 4) {


            getBox.style.width = "60%";
            getBox.style.left = "20%";

            getBox.style.grid = "auto/ auto auto auto auto";


        } if (answer.length == 3) {
            getBox.style.width = "50%";
            getBox.style.left = "25%";


            getBox.style.grid = "auto/  auto auto auto";


        }


        for (i = 0; i < answer.length; i++) {

            if (i == 0) {

                var divTemp = document.createElement("Div");
                divTemp.classList.add('grid-item');
                divTemp.style.backgroundImage = "url('')";
                divTemp.innerText = firtsLetterAnswer;

                answer_Box[i] = document.createElement("Div");
                answer_Box[i].classList.add('grid-itemBox');
                answer_Box[i].id = "box" + i;
                answer_Box[i].appendChild(divTemp);
                answer_Box[i].style.border = "solid white 2px";
                answer_Box[i].style.borderRadius = "4px";
                answer_Box[i].style.backgroundColor = "white";
                getBox.appendChild(answer_Box[i]);


            } else {
                answer_Box[i] = document.createElement("Div");
                answer_Box[i].classList.add('grid-itemBox');
                answer_Box[i].id = "box" + i;
                if (i == 1) {
                    answer_Box[i].classList.add('blink');

                }

                getBox.appendChild(answer_Box[i]);
                answer_Box[i].style.border = "solid red 2px";
                answer_Box[i].style.borderRadius = "4px";
                answer_Box[i].style.backgroundColor = "red";
            }

        }

    }

    // funtion that adds blinker

    function putBlinker() {

        for (loop = 0; loop < answer_Box.length; loop++) {
            if (answer_Box[loop].childElementCount == 0) {

                answer_Box[loop].classList.add('blink');
                answer_Box[loop - 1].classList.remove('blink');

                break;
            }
        }

    }


    // remove the blinker 

    function removeBlinker() {

        for (loop2 = 0; loop2 < answer_Box.length; loop2++) {

            answer_Box[loop2].classList.remove('blink');

        }

    }

    //run funtion when button in the answer bank is clicked--------------
    function btnselect(event) {


        var a = document.getElementById(event.target.id);

        for (t = answer_Box.length - 1; t >= 0; t--) {

            //var getter = "box" + i;
            //var b = document.getElementById(getter);
            if (answer_Box[t].childElementCount == 0) {
                a.style.backgroundImage = "url('')";
                a.style.padding = "0px";
                answer_Box[t].style.padding = "0px";
                //answer_Box[t].classList.add('blink');
                answer_Box[t].appendChild(a);

            }

        }


        a.removeEventListener("click", btnselect);
        a.addEventListener('click', revert1);
        removeBlinker();
        putBlinker();

        answerCheck();


    }
    var correctSound = new Audio();
    correctSound.src = "../sounds/Game-show-correct-answer.mp3";
    correctSound.preload = "auto";
    //checks if the answer is correct --------------------------

    function answerCheck() {
        var checkBox = false;
        var checkBox2 = false;

        var i = 0;
        while (i < answer_Box.length) {

            if (answer_Box[i].childElementCount == 0) {
                checkBox = false;
                break;
            } else {
                checkBox = true;

            }
            i++;

        }

        if (checkBox == true) {
            //stops the timer when the answerbox is complete
            clearTimeout(onTimer);

            clearTimeout(timersetter);
            timersetter = false;
            TimerStops = true;


            var j = 0;
            while (j < answer_Box.length) {

                //var getter2 = "box" + j;
                //var b2 = document.getElementById(getter2);

                var test1 = answer_Box[j].children[0];
                if (typeof (test1) != 'undefined' && test1 != null) {

                    if (answer_Box[j].children[0].innerText == answer[j]) {

                        checkBox2 = true;
                    } else {

                        checkBox2 = false;
                        break;

                    }

                } else {

                    return false;
                }

                j++;
            }

            // do this if the answer is correct
            if (checkBox2 == true) {

                $('#questionid').hide("fast");

                answerChecker = true;


                correctSound.play();

                var w = document.getElementById('remarksId').innerHTML = "Good Job";
                document.getElementById("remarksId").style.color = "#0AFC57";

                document.getElementById('gameMOdalpopUp').style.display = "block";

                checkBox = false;
                checkBox2 = false;

                $('#roundpopid').html(roundId);
                roundId = roundId + 1;
                $('#roundid').html(roundId);

                if (trialNumber == 0) {
                    scoreId = scoreId + 100;
                    $('#scoreid').html(scoreId);
                    $('#scorepopid').html(scoreId);
                    $('#guesspopid').html(remainingGuessId);

                } else if (trialNumber == 1) {
                    scoreId = scoreId + 50;
                    $('#scoreid').html(scoreId);
                    $('#scorepopid').html(scoreId);
                    //remainingGuessId = remainingGuessId - 1;
                    //guessId = guessId + 1;
                    $('#guessid').html(guessId);

                    $('#guesspopid').html(remainingGuessId);


                } else if (trialNumber == 2) {
                    scoreId = scoreId + 25;
                    $('#scoreid').html(scoreId);
                    $('#scorepopid').html(scoreId);

                    //remainingGuessId = remainingGuessId - 1;
                    //guessId = guessId + 1;
                    $('#guessid').html(guessId);
                    $('#guesspopid').html(remainingGuessId);


                }
                $('#corrrectPopUpText').html(Question);
                $('#corrrectPopUpText').fadeIn(2000);



                // do this if the answer is incorrect
            } else if (checkBox2 == false) {

                // function that willl be called if the answer is wrong or if the user runs out of time
                // ->wrongOrOutTime();
                wrongOrOutTime();





            }

        }

    }

    //revert back all buttons and answer one letter when the answer is wrong

    function revertback() {
        //var one = 1;
        //alert(trialNumber);
        for (k = 0; k < trialNumber; k++) {

            for (r = 0; r < grid_Item.length; r++) {
                var set1 = grid_Item[r].id;
                var set2 = set1.split("_");
                if (set2[1] == answer[k + 1]) {
                    var t = document.getElementById(set1);
                    t.removeEventListener('click', revert1);
                    t.removeEventListener('click', btnselect);
                    t.style.backgroundImage = "url('')";

                    answer_Box[k + 1].appendChild(t);
                    answer_Box[k + 1].style.border = "solid 2px white";
                    answer_Box[k + 1].style.backgroundColor = "white";

                    //answer_Box[k + 1].style.backgroundColor = "red";
                    break;
                }
            }


        }

        removeBlinker();
        putBlinker();
    }

    // function that reverts every button back all at once
    var wrongSound = new Audio();
    wrongSound.src = "../sounds/wrongsound.wav";
    wrongSound.preload = "auto";
    var btnsoundMain = new Audio();
    btnsoundMain.src = "../sounds/Main Menu (Tok Blitz).wav";
    btnsoundMain.preload = "auto";

    var dropsound = new Audio();
    dropsound.src = "../sounds/dropsound.wav";
    dropsound.preload = "auto";
    function revertAll() {



        wrongSound.play();

        for (b = 0; b < ShuffledAnswer.length; b++) {
            var get1 = grid_Item[b].id;
            var get2 = document.getElementById(get1);

            get2.removeEventListener('click', revert1);
            get2.addEventListener('click', btnselect);
            var getter2 = class_Item[b].id;
            var g = document.getElementById(getter2);
            get2.style.backgroundImage = "url('../Images/frame.png')";

            g.appendChild(get2);



        }


    }



    /// revert the button back to its normal position ------------------------------
    function revert1(event) {

        var set1 = event.target.id.split('_');

        var getter = "btn" + set1[0] + set1[1];
        var q = document.getElementById(getter);
        v = document.getElementById(event.target.id);
        v.removeEventListener("click", revert1);
        v.addEventListener('click', btnselect);
        v.style.backgroundImage = "url('../Images/frame.png')";

        q.appendChild(v);

        removeBlinker();
        putBlinker();
    }


    // function that stops the clock when clock is clicked and decrease the number of smashes



    //-------------------timer function--------------------------

    // clearTimeout(onTimer);

    var timersetter;
    var sec = 0;



    // function that willl be caled if the answer is wrrong or if the user runs out of time

    function wrongOrOutTime() {
        // we will ad one to trialnumber variable becoz once that it reaches 3 for easy and 4 for moderate, it will go to the next level

        trialNumber = trialNumber + 1;
        //------------------------------
        // if level1 or easy do this
        if (getLevel == 1) {
            //--- setting the timer off
            clearTimeout(onTimer);
            clearTimeout(timersetter);
            timersetter = false;
            //-------------------------------
            // if answer in the box is less than four, the user can only have two guesses

            // set the round number and score for modal popup
            scoreId = scoreId;
            $('#scoreid').html(scoreId);
            $('#scorepopid').html(scoreId);
            remainingGuessId = remainingGuessId - 1;
            guessId = guessId + 1;
            $('#guessid').html(guessId);

            $('#userGuess').html(guessId);


            $('#guesspopid').html(remainingGuessId);

            $('#roundpopid').html(roundId);


            if (answer.length < 4) {
                if (trialNumber == 2) {
                    trialNumber = trialNumber + 1;
                    // set the round number and score for modal popup
                    scoreId = scoreId;
                    $('#scoreid').html(scoreId);
                    $('#scorepopid').html(scoreId);
                    $('#roundpopid').html(roundId);

                    /// setting the answerCheck variable to true so that it will go to the next round
                    answerChecker = true;

                }
            }
            /// setting the answerCheck variable to true so that it will go to the next round

            if (trialNumber == 3) {
                // set the round number and score for modal popup
                scoreId = scoreId;
                $('#scoreid').html(scoreId);
                $('#scorepopid').html(scoreId);

                $('#roundpopid').html(roundId);


                answerChecker = true;

            }
            // if the trialNumber is not yet 3 , then revert all the buttons and answer one box
            revertAll();
            revertback();
            // this will just pop up the  modal that will alert the user if the answer is correct or wrong
            document.getElementById('remarksId').innerHTML = "Wrong Answer";
            document.getElementById("remarksId").style.color = "red";
            document.getElementById('gameMOdalpopUp').style.display = "block";
            checkBox = false;
            checkBox2 = false;

        } else if (getLevel == 2 || getLevel == 3 || getLevel == 4) {
            // set the round number and score for modal popup
            scoreId = scoreId;
            $('#scoreid').html(scoreId);
            $('#scorepopid').html(scoreId);
            remainingGuessId = remainingGuessId - 1;
            guessId = guessId + 1;
            $('#guessid').html(guessId);
            $('#userGuess').html(guessId);

            $('#guesspopid').html(remainingGuessId);

            $('#roundpopid').html(roundId);


            //--- setting the timer off
            clearTimeout(onTimer);
            clearTimeout(timersetter);
            timersetter = false;
            //-------------------------------
            /// setting the answerCheck variable to true so that it will go to the next round

            if (trialNumber == 4) {
                // set the round number and score for modal popup
                scoreId = scoreId;
                $('#scoreid').html(scoreId);
                $('#scorepopid').html(scoreId);
                $('#roundpopid').html(roundId);

                answerChecker = true;

            }
            // if the trialNumber is not yet 4 , then revert all the buttons and answer one box
            revertAll();
            revertback();
            // this will just pop up the  modal that will alert the user if the answer is correct or wrong
            document.getElementById('remarksId').innerHTML = "Wrong Answer";
            document.getElementById("remarksId").style.color = "red";
            document.getElementById('gameMOdalpopUp').style.display = "block";
            checkBox = false;
            checkBox2 = false;

        }



        $('#wrongpopBox').slideDown('slow');
    }


    function onTimer() {
        // if the the Timer variable is true then stop the timer function  , timerStops variable can will be true if the timer is clicked
        if (TimerStops) {
            clearTimeout(timersetter);
            return false;
        }
        //-----------------------------------------------------------
        // --- when seconds variable reaches ZERO, do this,
        if (sec <= 0) {
            // set the Time to zero
            document.getElementById('timeId').innerHTML = sec;
            // setting of the Timer
            clearTimeout(timersetter);
            // adding ! to trial number means that the Time has expired and trial has been consumed
            trialNumber = trialNumber + 1;
            // reverting every buttons back
            revertAll();
            revertback();
            // pop up the modal if the answer is correct or wrong
            document.getElementById('remarksId').innerHTML = "Time's Up!";
            document.getElementById("remarksId").style.color = "red";
            document.getElementById('gameMOdalpopUp').style.display = "block";

            if (getLevel == 1) {
                scoreId = scoreId;
                $('#scoreid').html(scoreId);
                $('#scorepopid').html(scoreId);

                remainingGuessId = remainingGuessId - 1;
                guessId = guessId + 1;

                $('#guessid').html(guessId);
                $('#guesspopid').html(remainingGuessId);

                $('#roundpopid').html(roundId);


                if (answer.length < 4) {
                    $('#guesspopid').html("");
                    if (trialNumber == 2) {
                        scoreId = scoreId;
                        $('#scoreid').html(scoreId);
                        $('#scorepopid').html(scoreId);
                        guessId = guessId + 1;
                        $('#guessid').html(guessId);
                        $('#guesspopid').html("");
                        $('#roundpopid').html(roundId);
                        answerChecker = true;

                    }

                }

                if (trialNumber == 3) {
                    scoreId = scoreId;
                    $('#scoreid').html(scoreId);
                    $('#scorepopid').html(scoreId);

                    //remainingGuessId = remainingGuessId - 1;
                    guessId = guessId + 1;

                    $('#guessid').html(guessId);
                    $('#guesspopid').html("");

                    $('#roundpopid').html(roundId);
                    answerChecker = true;

                }

            } else if (getLevel == 2 || getLevel == 3 || getLevel == 4) {
                scoreId = scoreId;
                $('#scoreid').html(scoreId);
                $('#scorepopid').html(scoreId);

                remainingGuessId = remainingGuessId - 1;
                guessId = guessId + 1;

                $('#guessid').html(guessId);
                $('#guesspopid').html(remainingGuessId);

                $('#roundpopid').html(roundId);

                if (trialNumber == 4) {
                    scoreId = scoreId;
                    $('#scoreid').html(scoreId);
                    $('#scorepopid').html(scoreId);

                    //remainingGuessId = remainingGuessId - 1;
                    guessId = guessId + 1;

                    $('#guessid').html(guessId);
                    $('#guesspopid').html("");

                    $('#roundpopid').html(roundId);
                    answerChecker = true;

                }


            }


            $('#wrongpopBox').slideDown('fast');




            //outTime();

            return false;
            //onTimer();

        } else {
            document.getElementById('timeId').innerHTML = sec;

            sec--;

        }

        // if the seconds on timer is ten or less, glow the hummer thunder----------
        // if (sec == 6) {
        //   setThunderGlow = setInterval(glowThunder, 300);

        //    }

        timersetter = setTimeout(onTimer, 1000);
    }
    //---------------------------------------------------------------------------







    // answer one letter and runs the function for out of time----------------------

    var setThunderGlow;
    var counter = 0;



    function playThunderSound() {


        if (thunderShock.paused) {
            thunderShock.currentTime = 0
            thunderShock.play();
        } else {
            thunderShock.currentTime = 0
            thunderShock.play();
        }

    }


    
    $('.thunder').on('click', function () {
        clearTimeout(setThunderGlow);
        countGlowThunder = 0;

        if (thunderCount <= 0) {
            //var btnsound = new Audio();
            //btnsound.src = "../sounds/Family%20feud-buzzer.wav";
            buzzer.play();


            return false;
        }

        //var btnsound = new Audio();
        //btnsound.src = "../sounds/thunder shock sound.wav";
        playThunderSound();
        //thunderShock.play();
        // setImageThunder();

        thunderCount--;

        document.getElementById('thunderCount').innerHTML = thunderCount;

        for (counter = counter; counter < ShuffledAnswer.length; counter++) {
            var toy = grid_Item[counter].id;
            var rget = document.getElementById(toy);

            if ($.inArray(rget.innerText, answer) > -1) {

            } else {


                var disappear = grid_Item[counter].id;
                var dis = class_Item[counter].id;
                var te = document.getElementById(dis);
                getpos = document.getElementById(disappear);

                var g = te.offsetTop;

                topPosition = document.getElementById('btnMain').offsetTop;
                leftPosition = document.getElementById(disappear).offsetLeft;
                //btnpos =  getpos.getBoundingClientRect();
                //var trya =  getpos.style.top;
                var thunderString = "thunder"
                animateThunderFunction(topPosition, leftPosition);
                $('#' + disappear).fadeOut(1000);
                //  grid_Item[counter].style.display = "none";
                //class_Item[counter].style.backgroundColor = "red";
                counter = counter + 1;

                break;
            }


        }

        var setIntervalvar;
        function setImageThunder() {

            $('#thunderImageId').css("display", "block");
            $('#thunderImageId2').css("display", "block");

            setIntervalvar = setInterval(setImageThunderGone, 2000);
            return false;
        }

        function setImageThunderGone() {
            $('#thunderImageId').css("display", "none");

            $('#thunderImageId2').css("display", "none");

            clearTimeout(setInterval);

        }

    });

    // runst the set all function when the quotes button is clicked
    var category;
    $('#quotesId').on('click', function () {

        $('#gametypeMOdal').fadeOut('fast');
        category = "quote";
        getData("Quote");
        document.getElementById('gameMOdalpopUpLoader').style.display = 'block';


    });

    $('#sayingsId').on('click', function () {
        $('#gametypeMOdal').fadeOut('fast');
        category = "saying";
        getData("Saying");
        document.getElementById('gameMOdalpopUpLoader').style.display = 'block';
    });





    // do this if button easy is clicked
    $('#btneasy').on('click', function () {

        getLevel = 1;
        remainingGuessId = 3;
        document.getElementById('gametypeMOdal').style.display = 'block';

        dropsound.play();
        btnsoundMain.play();

    });

    // do this if button moderate is clicked
    $('#btnmoderate').on('click', function () {
        remainingGuessId = 4;
        getLevel = 2;

        document.getElementById('gametypeMOdal').style.display = 'block';

        // btnsound.play();
        dropsound.play();

        btnsoundMain.play();

    });

    // do this if button moderate is clicked
    $('#btnchallenging').on('click', function () {
        remainingGuessId = 4;
        getLevel = 3;

        document.getElementById('gametypeMOdal').style.display = 'block';
        dropsound.play();

        btnsoundMain.play();

    });


    // do this if button difficult is clicked
    $('#btndifficult').on('click', function () {
        remainingGuessId = 4;
        getLevel = 4;

        document.getElementById('gametypeMOdal').style.display = 'block';

        dropsound.play();

        btnsoundMain.play();

    });


    // do this when the button tryagain is clicked

    $('#btnTryAgain').on('click', function () {
        // var btnsound = new Audio();
        //dropsound.src = "../sounds/dropsound.wav";
        dropsound.play();

        btnsoundMain.play();
        $('#loaderImage').fadeIn('slow');
        $('#loaderMessage').html('Loading Toks...');
        if (category == "quote") {
            getData();

        }

        if (category == "saying") {
            getData2();


        }


        $('#btnCancel').fadeOut('slow');
        $('#btnTryAgain').fadeOut('slow');

    });

    $('#btnCancel').on('click', function () {

        document.getElementById('gameMOdalpopUpLoader').style.display = 'none';

        //  var btnsound = new Audio();
        //  btnsound.src = "../sounds/dropsound.wav";
        dropsound.play();

        btnsoundMain.play();
        $('#loaderImage').fadeIn('fast');
        $('#loaderMessage').html('Loading Toks...');

    });



    /// run when continue button is clicked
    $('#continueId').on('click', function () {
        //set the timer on

        // do this if easy level
        if (getLevel == 1) {
            // if trial number one make the seconds to ten
            if (trialNumber == 1) {
                TimerStops = false;
                sec = 10;
                onTimer();

            } else if (trialNumber == 2) {
                TimerStops = false;
                sec = 5;
                onTimer();
                //-- if the trial number is three then do this , add round number and make the guess back to normal again as it goes to the next round
            } else if (trialNumber == 3) {
                roundId = roundId + 1;
                $('#roundid').html(roundId);

                guessId = 1;
                remainingGuessId = 3;
                trialNumber = 0;
                $('#scoreid').html(scoreId);
                $('#guessid').html(guessId);

                $('#userGuess').html(guessId);
                $('#userRound').html(roundId);

            }

            // do this when the user is in moderate  mode
        } else if (getLevel == 2) {
            // if trial number one make the seconds to ten
            if (trialNumber == 1) {
                TimerStops = false;
                sec = 15;
                onTimer();

            } else if (trialNumber == 2) {
                TimerStops = false;
                sec = 10;
                onTimer();
            }
            else if (trialNumber == 3) {
                TimerStops = false;
                sec = 5;
                onTimer();
            }
            //-- if the trial number is 4 then do this , add round number and make the guess back to normal again as it goes to the next round
            else if (trialNumber == 4) {
                roundId = roundId + 1;
                $('#roundid').html(roundId);

                guessId = 1;
                remainingGuessId = 3;
                trialNumber = 0;
                $('#scoreid').html(scoreId);
                $('#guessid').html(guessId);
                $('#userGuess').html(guessId);
                $('#userRound').html(roundId);

            }

        } else if (getLevel == 3) {
            // if trial number one make the seconds to ten
            if (trialNumber == 1) {
                TimerStops = false;
                sec = 20;
                onTimer();

            } else if (trialNumber == 2) {
                sec = 15;
                onTimer();
            }
            else if (trialNumber == 3) {
                TimerStops = false;
                sec = 10;
                onTimer();
            }
            //-- if the trial number is 4 then do this , add round number and make the guess back to normal again as it goes to the next round
            else if (trialNumber == 4) {
                roundId = roundId + 1;
                $('#roundid').html(roundId);

                guessId = 1;
                remainingGuessId = 3;
                trialNumber = 0;
                $('#scoreid').html(scoreId);
                $('#guessid').html(guessId);
                $('#userGuess').html(guessId);
                $('#userRound').html(roundId);


            }

        } else if (getLevel == 4) {
            // if trial number one make the seconds to ten
            if (trialNumber == 1) {
                TimerStops = false;
                sec = 25;
                onTimer();

            } else if (trialNumber == 2) {
                sec = 20;
                onTimer();
            }
            else if (trialNumber == 3) {
                TimerStops = false;
                sec = 15;
                onTimer();
            }
            //-- if the trial number is 4 then do this , add round number and make the guess back to normal again as it goes to the next round
            else if (trialNumber == 4) {
                roundId = roundId + 1;
                $('#roundid').html(roundId);

                guessId = 1;
                remainingGuessId = 3;
                trialNumber = 0;
                $('#scoreid').html(scoreId);
                $('#guessid').html(guessId);
                $('#userGuess').html(guessId);
                $('#userRound').html(roundId);

            }

        }



        // this will just hide the modal pop up onece that clicked
        var t = document.getElementById('gameMOdalpopUp').style.display = 'none';



        $('#corrrectPopUpText').fadeOut('fast');
        $('#wrongpopBox').fadeOut('fast');




        //var btnsound = new Audio();
        // btnsound.src = "../sounds/resetsound.wav";
        resetSound.play();

        if (answerChecker) {

            if (getLevel == 1) {
                remainingGuessId = 3;

            } else if (getLevel == 2 || getLevel == 3 || getLevel == 4) {
                remainingGuessId = 4;


            }
            guessId = 1;
            trialNumber = 0;
            $('#guessid').html(guessId);
            $('#userGuess').html(guessId);
            $('#userRound').html(roundId);
            $('#userScore').html(scoreId);
            destroyer();
        }

    });


    $('#award').addClass('w3-animate-left');

    runstars();

    function runstars() {

        $('#star1').slideDown('slow', function () {
            $('#star2').slideDown('slow', function () {
                $('#star5').slideDown('slow');

            });

        });
    }


    setInterval(function () {
        removestars();
        runstars();

    }, 7000);

    function removestars() {
        $('#star1').fadeOut('slow');
        $('#star2').fadeOut('slow');
        $('#star5').fadeOut('slow');

    }

    //function that destroys every element when the answer is correct and calls the function that will create a new one
    function destroyer() {
        TimerStops = false;



        //stops and reload becoz the level is good only up to 4 rounds for the mean time.
        if (roundId == 6) {
            window.location.reload();
        }

        var parent = document.getElementById("btnMain");
        var parent2 = document.getElementById("answerBoxMain");
        document.getElementById('questionid').innerText = "";
        level = level + 1;
        guessId = 1;
        //deletes all the element and create a new ones
        while (parent.firstChild) {
            parent.removeChild(parent.firstChild);
        }

        while (parent2.firstChild) {
            parent2.removeChild(parent2.firstChild);
        }


        clearTimeout(onTimer);
        clearTimeout(timersetter);
        timersetter = false;
        if (getLevel == 1) {
            sec = 15;

        } else if (getLevel == 2) {
            sec = 20;

        } else if (getLevel == 3) {
            sec = 25;

        } else if (getLevel == 4) {
            sec = 30;

        }


        onTimer();

        // clears every variable in answers and button
        lettersTobeShulledLast = "";
        answerTemp = "";
        letterTomix = "";
        ShuffledAnswer = "";
        lettersTobeShulledBefore = "";


        $('#corrrectPopUpText').fadeOut('fast');
        $('#wrongpopBox').fadeOut('fast');

        answer_Box.length = 0;
        GameMusic.pause();
        run = "";
        answer = "";
        positionOfAnswer = "";



        setClass = "";
        questionsFromDataBase = shuffleQuestions(questionsFromDataBase);
        //randNumberGet();

        if (category == "quote") {

            getToks();
            setAll();
        }
        if (category == "saying") {

            getToksSaying();

            setAll();
        }





        for (u = 0; u < class_Item.length; u++) {
            var a = class_Item[u].id;
            var b = document.getElementById(a);
            var c = 1000;
            var d = c;
            $(b).slideDown(d);
            c = c + 1000;

        }

        //createBox();



        answerChecker = false;
        $('#questionid').slideDown("slow");
        $('#boardId').addClass('w3-animate-rightAlli');
        counter = 0;

        clearTimeout(setThunderGlow);


    }


    var questionsFromDataBase = new Array();
    var categoryFromDatabase = new Array();
    var secondFieldFromDatabase = new Array();
    var categorySelected;
    var secondFieldSelected;

    var getDataCount = 0;
    function TimeFunction() {

        getDataCount++;
        if (getDataCount == 30) {
            $('#btnCancel').fadeIn('slow');
            $('#btnTryAgain').fadeIn('slow');
            $('#loaderImage').fadeOut('fast');
            $('#loaderMessage').html('Server error please try again!');
            getDataCount = 0;
            clearTimeout(myVar);
            return false;
        }
    }

    function getData(tokgroup = "") {
        myVar = setInterval(TimeFunction, 1000);
        $.ajax({
            type: "GET",
            url: "/Tok/GetTokBlitzData?tokGroup=" + tokgroup,
            dataType: "json",
            success: function (responseText) {                
                if (typeof (responseText) == 'undefined') {
                    $('#btnCancel').fadeIn('slow');
                    $('#btnTryAgain').fadeIn('slow');
                    $('#loaderImage').fadeOut('fast');
                    $('#loaderMessage').html('Server error please try again!');
                }

                for (k in responseText) {
                    //console.log(responseText);

                    questionsFromDataBase[k] = responseText[k];
                    document.getElementById('gameMOdalpopUpLoader').style.display = 'none';
                    // document.getElementById('gametypeMOdal').style.display = 'block';
                }

                questionsFromDataBase = shuffleQuestions(questionsFromDataBase);

                getToks();
                setAll();

            }, failure: function (responseText) {
                alert(responseText);
                document.getElementById('gameMOdalpopUpLoader').style.display = 'none';
            }, //End of AJAX failure function  
            error: function (data) {
                alert(responseText);
                document.getElementById('gameMOdalpopUpLoader').style.display = 'none';

            } //End of AJAX error function  

        });


    }


    function getData2() {
        myVar = setInterval(TimeFunction, 1000);
        // var str = "";
        $.ajax({
            type: "GET",
            url: "/Home/GetGameToksAsync2",
            //data: str,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (responseText) {
                //alert(JSON.stringify(data).length);                  
                if (typeof (responseText) == 'undefined') {
                    $('#btnCancel').fadeIn('slow');
                    $('#btnTryAgain').fadeIn('slow');
                    $('#loaderImage').fadeOut('fast');
                    $('#loaderMessage').html('Server error please try again!');

                }

                for (k in responseText) {

                    //console.log(responseText);

                    questionsFromDataBase[k] = responseText[k];
                    document.getElementById('gameMOdalpopUpLoader').style.display = 'none';
                    // document.getElementById('gametypeMOdal').style.display = 'block';


                }

                questionsFromDataBase = shuffleQuestions(questionsFromDataBase);

                getToksSaying();
                setAll();

            }, failure: function (responseText) {
                alert(responseText);
                document.getElementById('gameMOdalpopUpLoader').style.display = 'none';
            }, //End of AJAX failure function  
            error: function (data) {
                alert(responseText);
                document.getElementById('gameMOdalpopUpLoader').style.display = 'none';

            } //End of AJAX error function  

        });


    }


    var run;
    var answer;
    var positionOfAnswer;
    var test = false;


    // getToks for quotes
    function getToks() {
        if (getLevel == 1) {
            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked
            for (v = 0; v < questionsFromDataBase.length; v++) {
                thequestionpicked = questionsFromDataBase[v]["primary_text"];
                categorySelected = questionsFromDataBase[v]["category"];
                secondFieldSelected = questionsFromDataBase[v]["secondary_text"];

                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 15) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = secondFieldSelected;


                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 3 || answer.length > 4) {
                        for (i = 0; i < setQuestion.length; i++) {
                            answer = setQuestion[i].toUpperCase();
                            positionOfAnswer = i;
                            if (answer.length >= 3 && answer.length <= 4) {
                                break;
                            } else {


                            }


                        }
                    } else {

                        break;
                    }
                }


            }
        }


        //do this if moderate level
        if (getLevel == 2) {

            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked;
            for (f = 0; f < questionsFromDataBase.length; f++) {

                thequestionpicked = questionsFromDataBase[f]["primary_text"];
                categorySelected = questionsFromDataBase[f]["category"];
                secondFieldSelected = questionsFromDataBase[f]["secondary_text"];

                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 21) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = secondFieldSelected;
                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 5 || answer.length > 6) {
                        for (r = 0; r < setQuestion.length; r++) {
                            answer = setQuestion[r].toUpperCase();
                            positionOfAnswer = r;
                            if (answer.length >= 5 && answer.length <= 6) {
                                break;
                            } else {

                            }

                        }
                    } else {

                        break;


                    }
                }


            }
        }

        // do this if level 3 or challenging

        if (getLevel == 3) {

            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked;
            for (e = 0; e < questionsFromDataBase.length; e++) {

                thequestionpicked = questionsFromDataBase[e]["primary_text"];
                categorySelected = questionsFromDataBase[e]["category"];
                secondFieldSelected = questionsFromDataBase[e]["secondary_text"];

                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 28) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = secondFieldSelected;
                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 7 || answer.length > 9) {
                        for (l = 0; l < setQuestion.length; l++) {
                            answer = setQuestion[l].toUpperCase();
                            positionOfAnswer = l;
                            if (answer.length >= 7 && answer.length <= 9) {
                                break;
                            } else {

                            }

                        }
                    } else {

                        break;


                    }
                }


            }


        }





        // do this if level 4 or difficult

        if (getLevel == 4) {

            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked;
            for (w = 0; w < questionsFromDataBase.length; w++) {
                thequestionpicked = questionsFromDataBase[w]["primary_text"];
                categorySelected = questionsFromDataBase[w]["category"];
                secondFieldSelected = questionsFromDataBase[w]["secondary_text"];

                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 28) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = secondFieldSelected;
                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 10 || answer.length > 12) {
                        for (d = 0; d < setQuestion.length; d++) {
                            answer = setQuestion[d].toUpperCase();
                            positionOfAnswer = d;
                            if (answer.length >= 10 && answer.length <= 12) {
                                break;
                            } else {

                            }

                        }
                    } else {

                        break;


                    }
                }


            }

        }


        Question = finalQ.toUpperCase();


    }








    // getToks for sayings
    function getToksSaying() {
        if (getLevel == 1) {
            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked
            for (v = 0; v < questionsFromDataBase.length; v++) {
                thequestionpicked = questionsFromDataBase[v]["primary_text"];
                categorySelected = questionsFromDataBase[v]["category"];
                // secondFieldSelected = questionsFromDataBase[v]["secondary_text"];

                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 15) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = "";


                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 3 || answer.length > 4) {
                        for (i = 0; i < setQuestion.length; i++) {
                            answer = setQuestion[i].toUpperCase();
                            positionOfAnswer = i;
                            if (answer.length >= 3 && answer.length <= 4) {
                                break;
                            } else {


                            }


                        }
                    } else {

                        break;
                    }
                }


            }
        }


        //do this if moderate level
        if (getLevel == 2) {

            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked;
            for (f = 0; f < questionsFromDataBase.length; f++) {

                thequestionpicked = questionsFromDataBase[f]["primary_text"];
                categorySelected = questionsFromDataBase[f]["category"];
                //secondFieldSelected = questionsFromDataBase[f]["secondary_text"];

                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 21) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = "";
                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 5 || answer.length > 6) {
                        for (r = 0; r < setQuestion.length; r++) {
                            answer = setQuestion[r].toUpperCase();
                            positionOfAnswer = r;
                            if (answer.length >= 5 && answer.length <= 6) {
                                break;
                            } else {

                            }

                        }
                    } else {

                        break;


                    }
                }


            }
        }

        // do this if level 3 or challenging

        if (getLevel == 3) {

            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked;
            for (e = 0; e < questionsFromDataBase.length; e++) {

                thequestionpicked = questionsFromDataBase[e]["primary_text"];
                categorySelected = questionsFromDataBase[e]["category"];
                //secondFieldSelected = questionsFromDataBase[v]["secondary_text"];


                secondFieldSelected = "";
                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 28) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = "";
                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 7 || answer.length > 9) {
                        for (l = 0; l < setQuestion.length; l++) {
                            answer = setQuestion[l].toUpperCase();
                            positionOfAnswer = l;
                            if (answer.length >= 7 && answer.length <= 9) {
                                break;
                            } else {

                            }
                        }
                    } else {
                        break;
                    }
                }
            }
        }

        // do this if level 4 or difficult

        if (getLevel == 4) {

            var lentcheck;
            var setQuestion;
            var finalQ;
            var thequestionpicked;
            for (w = 0; w < questionsFromDataBase.length; w++) {

                thequestionpicked = questionsFromDataBase[w]["primary_text"];
                categorySelected = questionsFromDataBase[w]["category"];
                //secondFieldSelected = questionsFromDataBase[v]["secondary_text"];


                lentcheck = thequestionpicked;
                setQuestion = lentcheck.split(" ");
                if (setQuestion.length > 3 && setQuestion.length <= 28) {
                    finalQ = thequestionpicked;
                    document.getElementById('categoryIDtext').innerText = categorySelected;
                    document.getElementById('secondFieldIDtext').innerText = "";
                    run = Math.floor(Math.random() * setQuestion.length);
                    answer = setQuestion[run].toUpperCase();
                    positionOfAnswer = run;

                    if (answer.length < 10 || answer.length > 12) {
                        for (d = 0; d < setQuestion.length; d++) {
                            answer = setQuestion[d].toUpperCase();
                            positionOfAnswer = d;
                            if (answer.length >= 10 && answer.length <= 12) {
                                break;

                            } else {

                            }
                        }
                    } else {
                        break;
                    }
                }
            }
        }
        Question = finalQ.toUpperCase();
    }

    function shuffleQuestions(arrayQ) {
        var currentIndex = arrayQ.length, temporaryValue, randomIndex;

        // While there remain elements to shuffle...
        while (0 !== currentIndex) {

            // Pick a remaining element...
            randomIndex = Math.floor(Math.random() * currentIndex);
            currentIndex -= 1;

            // And swap it with the current element.
            temporaryValue = arrayQ[currentIndex];
            arrayQ[currentIndex] = arrayQ[randomIndex];
            arrayQ[randomIndex] = temporaryValue;
        }

        return arrayQ;
    }



    var counterPosition = 0;
    var BooleanStop = false;

    var animationThunder = document.getElementById('animateThunder');
    //var btn = document.getElementById('btn');

    var clock;
    var btnthunder = document.getElementById('thunderId');

    var btnthunderCount = document.getElementById('thunderCount');

    var checkcountThunder = 0;

    // function to do when the thunder / smash is clicked
    function animateThunderFunction(topPosition, leftPosition) {


        booleanStop = false;
        counterPosition = 0;
        animationThunder.style.left = leftPosition + "px";
        animationThunder.style.height = "300px";
        animationThunder.style.display = "block";


        clock = setInterval(test2, 1);

        //btnthunderCount.disabled = true;

        //btn.disabled = true;

    }

    // this function is being called in setinterval for animation
    function test2() {

        counterPosition = counterPosition + 2;
        //animationThunder.style.top = counterPosition+"px";


        if (counterPosition >= 30 && counterPosition < 70) {

            animationThunder.src = "../images/Smash/09_Smash0002.png";

            animationThunder.style.height = (topPosition + 200) + "px";
            animationThunder.style.overflowY = "hidden";
        }
        if (counterPosition >= 70 && counterPosition < 90) {

            animationThunder.src = "../images/Smash/09_Smash0003.png";
        }
        if (counterPosition >= 90 && counterPosition < 120) {

            animationThunder.src = "../images/Smash/09_Smash0004.png";

        }
        if (counterPosition >= 120 && counterPosition < 140) {

            animationThunder.src = "../images/Smash/09_Smash0005.png";


        } if (counterPosition >= 140 && counterPosition < 170) {

            animationThunder.src = "../images/Smash/09_Smash0006.png";
            //animationThunder.style.height="100px";

        }

        if (counterPosition >= 170 && counterPosition < 200) {

            animationThunder.src = "../images/Smash/09_Smash0007.png";
            //animationThunder.style.height="100px";

        } if (counterPosition >= 200 && counterPosition < 240) {

            animationThunder.src = "../images/Smash/09_Smash0008.png";
            //animationThunder.style.height="100px";

        } if (counterPosition >= 240 && counterPosition < 270) {

            animationThunder.src = "../images/Smash/09_Smash0009.png";
            //animationThunder.style.height="100px";

        } if (counterPosition >= 270 && counterPosition < 300) {

            animationThunder.src = "../images/Smash/09_Smash0010.png";
            //animationThunder.style.height="100px";

        } if (counterPosition >= 300 && counterPosition < 330) {

            animationThunder.src = "../images/Smash/09_Smash0011.png";
            //animationThunder.style.height="100px";

        } if (counterPosition >= 330 && counterPosition < 360) {

            animationThunder.src = "../images/Smash/09_Smash0012.png";
            //animationThunder.style.height="100px";

        } if (counterPosition >= 360 && counterPosition < Math.round(topPosition)) {

            animationThunder.src = "../images/Smash/09_Smash0013.png";
            //animationThunder.style.height="100px";

        }

        if (counterPosition >= Math.round(topPosition)) {
            animationThunder.src = "../images/Smash/09_Smash0014.png";
            animationThunder.style.display = "none";
            booleanStop = true;
            counterPosition = 0;
            clearTimeout(clock);
        }
        if (booleanStop) {

            clearTimeout(clock);
            //btn.disabled = false;
            return false;
        }
    }
});