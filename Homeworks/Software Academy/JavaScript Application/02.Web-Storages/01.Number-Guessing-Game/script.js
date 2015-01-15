window.onload = function() {
    var abcd = getRandomNum(1000, 9999);
    var xyzw;
    
    
    var guessNumberInput = document.getElementById('guess-number');
    var guessNumber;
    guessNumberInput.addEventListener('focus', function(ev) {
        guessNumber = guessNumberInput.value;
        
        if (guessNumber === 'Enter number here...') {
            guessNumberInput.value = '';
        }        
    });
    guessNumberInput.addEventListener('blur', function(ev) {
        guessNumber = guessNumberInput.value;
        
        if (guessNumber === '') {
            guessNumberInput.value = 'Enter number here...';
        }
    });
    
    var moves = 0;
    
    var highScoreBoard = document.getElementById('highscores-table');
    loadHighScores(highScoreBoard);
    
    var guessButton = document.getElementById('guess-button');
    guessButton.addEventListener('click', function(ev) {        
        
        var inputValue = guessNumberInput.value;
        if (validateInput(inputValue)) {
            xyzw = parseInt(inputValue);
                        
            var abcdAsArray = abcd.toString().split('');
            var xyzwAsArray = xyzw.toString().split('');
            
            var match = calculateMatch(abcdAsArray, xyzwAsArray);
            printMatchResult(match);
            moves++;
            
            if (match.rams === 4) {
                saveScore(moves);
                abcd = getRandomNum(1000, 9999);
                moves = 0;
            }
            
            guessNumberInput.value = '';
        }
    });
    
    function printMatchResult(match) {
        var currentResultBox = document.getElementById('current-result');
        
        var resultAsString = match.sheeps + ' Sheeps and ' + match.rams + ' Rams';
        
        currentResultBox.children[0].innerHTML = resultAsString;        
    }
    
    function calculateMatch(generatedNumAsArray, userInputAsArray) {
        var match = {
            sheeps: 0, 
            rams: 0
        };
        
        var i, 
            j,
            count = 4;
        
        //Iterate over the generated number
        for (i = 0; i < count; i++) {
            //Iterate over the user input
            for (j = 0; j < count; j++) {
                if (generatedNumAsArray[i] === userInputAsArray[j]) {
                    if (i === j) {
                        match.rams++;
                    }
                    else {
                        match.sheeps++;
                    }
                }
            }
        }
        
        return match;
    }
    
    function validateInput(value) {
        var valueAsNumber = parseInt(value);
        
        if (valueAsNumber) {
            if (valueAsNumber >= 1000 && valueAsNumber <= 9999) {
                return true;
            }
            else {
                console.error('The input number must be a four digit number and the first digit must not be 0! Enter again...');
                return false;
            }
        }
        
        console.error('The input must be a number!');
        return false;
    }
    
    function saveScore(moves) {
        var userNickName = prompt('You guessed the number. Enter your nick name: ');
        var maxScore = 100;
        var score = parseInt(maxScore / moves);
        
        localStorage.setItem(userNickName, score);

        highScoreBoard.value += userNickName + ' - ' + 
            localStorage.getItem(userNickName) + ' points\n';
    }
    
    function loadHighScores(board) {
        for (var user in localStorage) {
            board.value += user + ' - ' + localStorage[user] + 'points\n';
        }
    }
    
    function getRandomNum(min, max) {
        return parseInt(Math.random() * (max - min) + min);
    }
};
