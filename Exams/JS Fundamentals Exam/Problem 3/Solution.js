function Solve(params) {
	var numberOfModels = params[0],
        numberOfRows = params[numberOfModels + 1],
        models = {};
    
    for(var i = 1; i <= numberOfModels; i++){
        var model = params[i].split('-');
        
        models[model[0]] = model[1];
    }
    
    for(var i = numberOfModels + 1; i < params.length; i++){
        
    }
    
    
	return answer;
}

var input1 = [
    0,
    4,
    '<div>',
    '<h1>',
    '{{<nk-model>title</nk-model>}}',
    '</h1>',
    '<div>'
];

var input2 = [
    2,
    'title-Telerik Academy',
    'subtitle-Free training',
    6,
    '<div>',
    '<span><nk-model>title</nk-model></span>',
    '<span>',
    '<nk-model>subtitle</nk-model>',
    '</span>',
    '</div>'
];

//solve(input1);
solve(input2);