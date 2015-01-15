window.onload = function(){
    var colorPicker = document.getElementById('color-picker');
    
    colorPicker.onchange = function(){
        var color = colorPicker.value;
        document.body.style.backgroundColor = color;
    }
};