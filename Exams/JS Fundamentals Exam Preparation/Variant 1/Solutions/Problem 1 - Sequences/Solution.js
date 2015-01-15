function Solve(params) {
	var N = parseInt(params[0]),
        answer = 0,
        i;
    
    for(i = 0; i <= N; i++){
        params[i] = parseInt(params[i]);
    }
    
    for(i = 1; i <= N; i++){
        if(params[i + 1] < params[i] || params[i + 1] === undefined){
            answer++;
        }
    }
    
	return answer;
}

var input1 = ['7','1','2','-3','4','4','0','1'];
var input2 = ['6','1','3','-5','8','7','-6'];
var input3 = ['9','1','8','8','7','6','5','7','7','6'];
var input4 = ['3','1','8','10'];
var input5 = ['3','1','0','-1'];

console.log(Solve(input1));
console.log(Solve(input2));
console.log(Solve(input3));
console.log(Solve(input4));
console.log(Solve(input5));