function solve(params) {
	var n = parseInt(params),
        nF = 1,
        tTNF = 1,
        nPOF = 1,
        t = n;
    while (t > 1){
        nF *= t;
        t--;
    }
    t = 2 * n;
    while (t > 1){
        tTNF *= t;
        t--;
    }
    t = n + 1;
    while (t > 1){
        nPOF *= t;
        t--;
    }
    return (tTNF / (nPOF * nF)) / 2;
}

var input1 = 5;

solve(input1);