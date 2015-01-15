window.onload = function(){
    console.log(getDivsByQuerySelector());
    
    console.log(getDivsByGetElement());
};

function getDivsByQuerySelector(){
    var allDivs = document.querySelectorAll("div");
    
    return returnAllDivInsideDivs(allDivs);
}

function getDivsByGetElement(){
    var allDivs = document.getElementsByTagName("div");
    
    return returnAllDivInsideDivs(allDivs);
}

function returnAllDivInsideDivs(divs){
    var allDivsInDivs = [];
    
    for(var i = 0; i < divs.length; i++){
        if(divs[i].parentElement instanceof HTMLDivElement){
            allDivsInDivs.push(divs[i]);
        }
    }
    
    return allDivsInDivs;
}