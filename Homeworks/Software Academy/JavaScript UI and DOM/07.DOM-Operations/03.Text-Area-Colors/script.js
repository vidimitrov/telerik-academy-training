window.onload = function(){
    var foregroundSelector = document.getElementById('foreground-color');
    var backgroundSelector = document.getElementById('background-color');
    
    var textArea = document.getElementsByTagName('textarea')[0];
    
    foregroundSelector.addEventListener('change', function(){
        var foregroundColor = foregroundSelector.value;
        
        textArea.style.color = foregroundColor;
    });
    
    backgroundSelector.addEventListener('change', function(){
        var backgroundColor = backgroundSelector.value;
        
        textArea.style.backgroundColor = backgroundColor;
    });
    
}