window.onload = function(){
    var div = document.createElement('div');
    div.style.border = '1px solid black';
    div.style.radius = '50px';
    div.style.backgroundColor = 'blue';
    div.style.position = 'absolute';
    div.style.width = '10px';
    div.style.height = '10px';
    
    var NUMBER_OF_DIVS = 5;
    var acceleration = 1;
    
    var divs = [];
    
    main();
    
    function main(){
        for(var i = 0; i < NUMBER_OF_DIVS; i++){
            var clonedNode = div.cloneNode(true);
            clonedNode.style.top = '100px';
            clonedNode.style.left = (i * 15) + 'px';
            divs.push(clonedNode);
        }
        
        var loop = function() {
            update();
            render();
            window.setInterval(loop, 100);
        }
        loop();
        //window.setInterval(loop, 100);
    }
    
    function update(){
        for(var i = 0; i < divs.length; i++){
            var oldValue = divs[i].style.left.split('px')[0];
            oldValue = parseInt(oldValue);
            oldValue += 10;
            if(oldValue > 500 || oldValue < 0){
                acceleration *= -1;
            }
            divs[i].style.left = (oldValue + acceleration) + 'px';
        }
    }
    
    function render(){
        for(var i = 0; i < divs.length; i++){
            document.body.appendChild(divs[i]);
        }
    }
}