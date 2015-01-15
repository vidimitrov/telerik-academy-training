//*** You can run this code with every js console like Google Chrome, Node or with VS.
//*** For example Ctrl + C the code and Ctrl + V it in the F12 console window in Google Chrome.

//Task 01.Assign all the possible JavaScript literals to different variables.

var numberLiteral = 123245,
    stringLiteral = "Hello",
    arrayLiteral = [1, 2, '5', {}],
    objectLiteral = {name: "Pesho", age: 12},
    boolLiteral = false;
    
//Task 02.Create a string variable with quoted text in it. 
//        For example: "How you doin'?", Joey said.

var stringVariable = "The stranger told \"Hello, guys.\"";

//Task 03.Try typeof on all variables you created.

var strVarType = typeof(stringVariable),
    numLitType = typeof(numberLiteral),
    objLitType = typeof(objectLiteral);

console.log(strVarType + " " + numLitType + " " + objLitType + "...");

//Task 04.Create null, undefined variables and try typeof on them

var undefinedVar,
    nullVar = null,
    undefinedVarType = typeof(undefinedVar),
    nullVarType = typeof(nullVar);

console.log(undefinedVarType + " " + nullVarType + "...");