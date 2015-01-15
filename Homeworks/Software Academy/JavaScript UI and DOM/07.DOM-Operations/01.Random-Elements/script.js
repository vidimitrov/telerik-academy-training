window.onload = function(){
    var numberField = document.getElementsByTagName('input')[0];
    var generateButton = document.getElementsByTagName('button')[0];
    generateButton.addEventListener('click', function(){
        var divsToGenerateCount = numberField.value;
        
        for(var i = 0; i < divsToGenerateCount; i++){
            generateRandomDiv();
        }
    });
    
    function generateRandomDiv(){
        var BORDER_STYLE = 'solid';
        var DIV_POSITION = 'absolute';
        var TEXT_ALIGN = 'center';
        
        var dFrag = document.createDocumentFragment();
        var strongElement = document.createElement('strong');
        strongElement.textContent = 'div';
        
        var div = document.createElement('div');
        div.appendChild(strongElement);
        
        div.style.position = DIV_POSITION;
        div.style.borderStyle = BORDER_STYLE;
        div.style.textAlign = TEXT_ALIGN;
        
        div.style.width = getRandomWidthHeight() + 'px';
        div.style.height = getRandomWidthHeight() + 'px';
        div.style.color = getRandomColor(); 
        div.style.top = getRandomTopPosition() + 'px';
        div.style.left = getRandomLeftPosition() + 'px';
        div.style.borderWidth = getRandomBorderWidth() + 'px';
        div.style.borderColor = getRandomColor(); 
        div.style.borderRadius = getRandomBorderRadius() + 'px';
        
        dFrag.appendChild(div);
        document.body.appendChild(dFrag);
    }
    
    function getRandomWidthHeight(){
        var widthHeight,
            min = 20,
            max = 100;
        
        widthHeight = max * Math.random() | min;
        
        return widthHeight;
    }
    
    function getRandomColor(){
        var color,
            red,
            green,
            blue,
            min = 0,
            max = 255;
        
        red = max * Math.random() | min;
        green = max * Math.random() | min;
        blue = max * Math.random() | min;
        
        color = 'rgb('+red+','+green+','+blue+')';
        
        return color;
    }
    
    function getRandomTopPosition(){
        var postition,
            max = window.innerHeight,
            min = 0;
        
        postition = max * Math.random() | min;
        
        return postition;
    }
    
    function getRandomLeftPosition(){
        var postition,
            max = window.innerWidth,
            min = 0;
        
        postition = max * Math.random() | min;
        
        return postition;
    }
    
    function getRandomBorderWidth(){
        var width,
            min = 1,
            max = 20;
        
        width =  max * Math.random() | min;
        
        return width;
    }
    
    function getRandomBorderRadius(){
        var radius,
            min = 0,
            max = 50;
        
        radius =  max * Math.random() | min;
        
        return radius;
    }
}