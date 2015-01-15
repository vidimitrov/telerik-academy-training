function Solve(params) {
	var answer = 0,
        isDefinition = false,
        isInBrackets = false,
        isAction = false,
        currentAction = '',
        currentSymbol = '',
        currentVariable = '',
        variables = {},
        list = [];
        
    for(var i = 0; i < params.length; i++){
        for(var j = 0; j < params[i].length; j++){
            currentSymbol = params[i][j];
            
            if(currentSymbol == ' ' && !isInBrackets){
                if((currentAction !== '') || isDefinition){
                    if (isDefinition){
                        isDefinition = false;
                        variables[currentVariable] = 0;
                    }
                    else{
                        isDefinition = true;
                        currentAction = '';
                    }
                }
                continue;
            }
            else if (currentSymbol == '['){
                isInBrackets = true;
            }
            else if (currentSymbol == ']'){
                isInBrackets = false;
                
                if(list.length == 1){
                    return list[0];
                }
                else if(currentAction !== ''){
                    switch(currentAction){
                        case 'sum': {
                            for(var ii = 0; ii < list.length; ii++){
                                variables[currentVariable] += list[ii];
                            }
                        };break;
                        case 'avg': {
                            var sum = 0;
                            
                            for(var ii = 0; ii < list.length; ii++){
                                sum += list[ii];
                            }
                            
                            variables[currentVariable] = parseInt(sum / list.length);
                        };break;
                        case 'min': {
                            var min = Number.MAX_VALUE;
                            
                            for(var ii = 0; ii < list.length; ii++){
                                if(list[ii] < min){
                                    min = list[ii];
                                };
                            }
                            
                            variables[currentVariable] = min;
                        };break;
                        case 'max': {
                            var max = Number.MIN_VALUE;
                            
                            for(var ii = 0; ii < list.length; ii++){
                                if(list[ii] > max){
                                    max = list[ii];
                                };
                            }
                            
                            variables[currentVariable] = max;
                        };break;
                    }
                }
                else{
                    variables[currentVariable] = list;
                }
                
                //If the list contain one element, log its value,
                //else calculate it with the current action
            }
            else if (isDefinition){
                currentVariable += currentSymbol;
            }
            else if (isInBrackets){
                if(!isNaN(currentSymbol) && currentSymbol !== ' '){
                    list.push(parseInt(currentSymbol));
                }
            }
            else {
                currentAction += currentSymbol;
            }
        }
        //Reset all the values without variables
        
        //console.log(currentVariable + "--->" + variables[currentVariable]);
        
        if (i == params.length - 1){
            //return the result
        }
        
        currentAction = '';
        currentVariable = '';
        isDefinition = false;
        isInBrackets = false;
        isAction = false;
        list = [];
    }
    
	return answer;
}

var input1 = [ //42
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    //'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]'
//    'def func6 sum[func2, func3, func4 ]',
//    'sum[func6, func4]'
];
var input2 = [ //111
    'def func sum[1, 2, 3, -6]',
    //'def newList [func, 10, 1]',
    //'def newFunc sum[func, 100, newList]',
    //' [newFunc]'
    ' [func]'
];
var input3 = [];
var input4 = [];
var input5 = [];

//console.log(Solve(input1));
console.log(Solve(input2));
//console.log(Solve(input3));
//console.log(Solve(input4));
//console.log(Solve(input5));