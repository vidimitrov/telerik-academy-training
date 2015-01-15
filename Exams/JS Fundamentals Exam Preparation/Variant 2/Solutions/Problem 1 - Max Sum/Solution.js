function Solve(params) {
	var N = parseInt(params[0]),
        answer = 0,
        i;
    
    //-----------------------------------------------------------------------
    
    var arr = [];

    for (var i = 1; i <= N; i++)
    {
        arr.push(parseInt(params[i]));
    }

    //For testing:
    //int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

    var maxSum = 0,
        sum = 0,
        startedPos = 0,
        endedPos = 0;

    for (var i = 0; i < arr.length; i++)
    {
        for (var j = i + 1; j < arr.length; j++)
        {
            for (var k = i; k <= j; k++)
            {
                sum += arr[k];
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                startedPos = i;
                endedPos = j;
            }

            sum = 0;
        }
    }
    
    //---------------------------------------------------------------
    
    if(maxSum == 0){
       maxSum = arr[0];
       for(var i = 0; i < arr.length; i++){
           if(arr[i] > maxSum){
               maxSum = arr[i];
           }
       }
    }
    
    
    answer = maxSum;
	return answer;
}

var input1 = ['8','1','6','-9','4','4','-2','10','-1'];
var input2 = ['6','1','3','-5','8','7','-6'];
var input3 = ['9','-9','-8','-8','-7','-6','-5','-1','-7','-6'];
var input4 = [];
var input5 = [];

console.log(Solve(input1));
console.log(Solve(input2));
console.log(Solve(input3));
//console.log(Solve(input4));
//console.log(Solve(input5));