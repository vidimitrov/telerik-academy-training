window.onload = function () {
    var canvas = document.getElementById('the-canvas');
    var ctx = canvas.getContext('2d');
    
    var x = 10,
        y = 10,
        fieldWidth = 900,
        fieldHeight= 500,
        ballRadius = 5,
        ballColor = 'blue',
        ballStroke = 'red',
        xAcceleration = 5,
        yAcceleration = 5;
    
    setInterval(render, 30);
    
    function update(xCoord, yCoord){
        if(xCoord >= fieldWidth || xCoord <= 0){
            xAcceleration *= -1;
        }
        
        if(yCoord >= fieldHeight || yCoord <= 0){
            yAcceleration *= -1;
        }
        
        return {
           updatedX: xCoord + xAcceleration,
           updatedY: yCoord + yAcceleration
        }
    }
    
    function render(){
        ctx.clearRect(0, 0, 900, 500);
        
        updatedCoords = update(x, y);
        x = updatedCoords.updatedX;
        y = updatedCoords.updatedY;
        ctx.beginPath();
        ctx.arc(x, y, ballRadius, 0, 2 * Math.PI);
        ctx.strokeStyle = ballStroke;
        ctx.fillStyle = ballColor;
        ctx.stroke();
        ctx.fill();
    }
}