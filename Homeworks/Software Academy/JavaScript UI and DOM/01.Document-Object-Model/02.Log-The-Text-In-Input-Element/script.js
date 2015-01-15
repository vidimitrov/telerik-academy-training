window.onload = function(){
    var button = document.getElementById('printButton');
    button.onclick = function(){
        var textfield = document.getElementsByTagName('input')[0];
        console.log(textfield.value);
    }
};