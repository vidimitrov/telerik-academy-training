function solve(params) {
    var rows = parseInt(params[0].split(' ')[0]),
        cols = parseInt(params[0].split(' ')[1]),
        startPositionRow = rows - 1,
        startPositionCol = cols - 1,
        numberOfPoints = 0,
        numberOfJumps = 0,
        currentRow = startPositionRow,
        currentCol = startPositionCol,
        nextMoveRow,
        nextMoveCol;
        
    var answer = 0;
    
    var board = new Array(rows),
        mask = new Array(rows),
        points = new Array(rows);
    
    for(var i = 0; i < rows; i++){
        board[i] = new Array(cols);
        mask[i] = new Array(cols);
        //points[i] = new Array(cols);
        
        board[i] = params[i + 1].split('');
        
        for(var j = 0; j < cols; j++){
            board[i][j] = parseInt(board[i][j]);
            mask[i][j] = false;
            //points[i][j] = Math.pow(2, i) - j;
        }
    }
    
    mask[currentRow][currentCol] = true;
    
    while(true){        
        numberOfPoints += Math.pow(2, currentRow) - currentCol;//points[currentRow][currentCol];
        
        var nextMove = makeMove(board[currentRow][currentCol], currentRow, currentCol);
        nextMoveRow = nextMove['newRow'];
        nextMoveCol = nextMove['newCol'];
        
        if((nextMoveRow >= 0) && (nextMoveRow < rows) && (nextMoveCol >= 0) && (nextMoveCol < cols)){
            currentRow = nextMoveRow;
            currentCol = nextMoveCol;
            
            numberOfJumps++;
        }
        else{
            return 'Go go Horsy! Collected ' + numberOfPoints + ' weeds';
        }
        
        if(mask[currentRow][currentCol] === true){
            return 'Sadly the horse is doomed in ' + numberOfJumps + ' jumps';
        }
        
        mask[currentRow][currentCol] = true;
    }
    
    function makeMove(direction, currRow, currCol){
        var newRow, newCol;
        switch(direction){
            case 1:{
                newRow = currRow - 2;
                newCol = currCol + 1;
            };break;
            case 2:{
                newRow = currRow - 1;
                newCol = currCol + 2;
            };break;
            case 3:{
                newRow = currRow + 1;
                newCol = currCol + 2;
            };break;
            case 4:{
                newRow = currRow + 2;
                newCol = currCol + 1;
            };break;
            case 5:{
                newRow = currRow + 2;
                newCol = currCol - 1;
            };break;
            case 6:{
                newRow = currRow + 1;
                newCol = currCol - 2;
            };break;
            case 7:{
                newRow = currRow - 1;
                newCol = currCol - 2;
            };break;
            case 8:{
                newRow = currRow - 2;
                newCol = currCol - 1;
            };break;
        }
        
        return {
                    newRow : newRow, 
                    newCol : newCol
               };
    }
}


var input1 = ['3 5', '54561', '43328', '52388'];
var input2 = ['3 5', '54361', '43326', '52188'];
var input3 = [];
var input4 = [];
var input5 = [];

console.log(solve(input1));
console.log(solve(input2));