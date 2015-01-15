function Solve(params) {
	var configParams = params[0].split(' '),
        n = parseInt(configParams[0]),
        m = parseInt(configParams[1]),
        j = parseInt(configParams[2]),
        startPosConfig = params[1].split(' '),
        startRow = parseInt(startPosConfig[0]),
        startCol = parseInt(startPosConfig[1]),
        sumOfNumbers = 0,
        numberOfJumps = 0,
        answer = '',
        i;
    
    var field = twoDimensionArray(n, m);
    var mask = twoDimensionArray(n, m);
    
    initializeField(field);
    initializeMask(mask);
        
    var currRowPos = startRow,
        currColPos = startCol,
        jumps = [];
    
    sumOfNumbers = field[currRowPos][currColPos];
    mask[startRow][startCol] = true;
    
    for(var i = 2; i < 2 + j; i++){
        jumps.push(returnJump(params[i]));
    }
    
    var jump = 0;
    
    while(true){
        currRowPos += jumps[jump][0];
        currColPos += jumps[jump][1];
        
        numberOfJumps++;
        
        if(field[currRowPos] === undefined){
            answer = 'escaped ' + sumOfNumbers; 
            return answer;
        }
        else if(field[currRowPos][currColPos] === undefined){
            answer = 'escaped ' + sumOfNumbers; 
            return answer;
        }
        
        if(mask[currRowPos][currColPos]){
            answer = 'caught ' + numberOfJumps; 
            return answer;
        }

        mask[currRowPos][currColPos] = true;
        
        sumOfNumbers += field[currRowPos][currColPos];
        
        if(jump === j - 1){
            jump = 0;
        }
        else{
            jump++;
        }
    }
    
    
    function initializeMask(mask){
        var rowLength = mask.length,
            colLength = mask[0].length;
        
        for(var i = 0; i < rowLength; i++){
            for(var j = 0; j < colLength; j++){
                mask[i][j] = false;
            }
        }
    }
    
    function initializeField(field){
        var rowLength = field.length,
            colLength = field[0].length,
            initializer = 1;
        
        for(var i = 0; i < rowLength; i++){
            for(var j = 0; j < colLength; j++){
                field[i][j] = initializer;
                initializer++;
            }
        }
    }
    
    function twoDimensionArray(rows, cols){
        var arr = new Array(rows);
        
        for(var i = 0; i < arr.length; i++){
            arr[i] = new Array(cols);
        }
        
        return arr;
    }
    
    function returnJump(jumpsAsString){
        var jumpCoords = jumpsAsString.split(' '),
            jumpRow = parseInt(jumpCoords[0]),
            jumpCol = parseInt(jumpCoords[1]);
        
        return [jumpRow, jumpCol];
    }
    
	return answer;
}


//Test inputs

var input1 = ['6 7 3', 
              '0 0', 
              '2 2', 
              '-2 2', 
              '3 -1'];
var input2 = ['4 4 2', 
              '0 0', 
              '1 1', 
              '-1 -1'];
var input3 = ['500 500 1',
              '0 0',
              '1 1'];
var input4 = [];
var input5 = [];

console.log(Solve(input1));
console.log(Solve(input2));
console.log(Solve(input3));
//console.log(Solve(input4));
//console.log(Solve(input5));