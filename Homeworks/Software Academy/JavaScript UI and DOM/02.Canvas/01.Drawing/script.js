window.onload = function () {
    var canvas = document.getElementById('the-canvas');
    var ctx = canvas.getContext('2d');
    
    ctx.beginPath();
    ctx.arc(100, 150, 50, 2*Math.PI, 0);
    ctx.strokeStyle = 'rgb(0, 0, 255)';
    ctx.fillStyle = 'rgba(0, 150, 255, 0.5)';
    ctx.stroke();
    ctx.fill();
    
    ctx.save();
    ctx.scale(2, 1);
    ctx.strokeStyle = 'rgba(0, 0, 100, 1)';
    ctx.beginPath();
    ctx.arc(55, 130, 5, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.beginPath();
    ctx.arc(40, 130, 5, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.restore();
    
    ctx.beginPath();
    ctx.arc(105, 130, 3, 2*Math.PI, 0);
    ctx.fillStyle = 'rgba(0, 0, 100, 1)';
    ctx.fill();
    
    ctx.beginPath();
    ctx.arc(75, 130, 3, 2*Math.PI, 0);
    ctx.fillStyle = 'rgba(0, 0, 100, 1)';
    ctx.fill();
    
    ctx.moveTo(90, 150);
    ctx.lineTo(80, 150);
    ctx.lineTo(95, 130);
    ctx.stroke();
    
    ctx.strokeStyle = 'rgba(0, 0, 100, 1)';    
    ctx.fillStyle = 'rgba(0, 100, 150, 1)';
    
    ctx.save();
    ctx.scale(4, 1);
    ctx.beginPath();
    ctx.arc(25, 100, 15, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.fill();
    ctx.restore();
    
    ctx.save();
    ctx.scale(2, 1);
    ctx.beginPath();
    ctx.arc(50, 50, 15, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.fill();
    ctx.restore();
    
    ctx.strokeStyle = 'rgba(0, 0, 100, 1)';
    ctx.moveTo(70, 50);
    ctx.lineTo(70, 95);
    ctx.quadraticCurveTo(100, 115, 130, 95);
    ctx.lineTo(130, 50);
    ctx.stroke();
    ctx.closePath();
    ctx.fill();
    
    ctx.save();
    ctx.rotate(10*Math.PI/180);
    ctx.scale(3, 1);
    ctx.beginPath();
    ctx.arc(40, 150, 5, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.restore();
    
    ctx.beginPath();
    ctx.arc(100, 400, 50, 2*Math.PI, 0);
    ctx.arc(250, 400, 50, 2*Math.PI, 0);
    ctx.fillStyle = 'rgba(0, 150, 255, 0.5)';
    ctx.fill();
    
    ctx.beginPath();
    ctx.moveTo(150, 375);
    ctx.lineTo(195, 420);
    ctx.stroke();
    
    ctx.save();
    ctx.beginPath();
    ctx.arc(175, 400, 15, 2*Math.PI, 0);
    ctx.closePath();
    ctx.stroke();
    ctx.restore();
    
    ctx.beginPath();
    ctx.moveTo(100, 400);
    ctx.lineTo(175, 400);
    ctx.lineTo(240, 330);
    ctx.lineTo(150, 330);
    ctx.lineTo(100, 400);
    ctx.moveTo(150, 330);
    ctx.lineTo(140, 310);
    ctx.moveTo(130, 310);
    ctx.lineTo(150, 310);
    ctx.moveTo(250, 400);
    ctx.lineTo(240, 330);
    ctx.lineTo(237, 310);
    ctx.lineTo(257, 300);
    ctx.moveTo(237, 310);
    ctx.lineTo(217, 315);
    ctx.moveTo(150, 330);
    ctx.lineTo(175, 400);
    ctx.closePath();
    ctx.stroke();
    
    ctx.beginPath();
    ctx.fillStyle = 'rgb(200, 70, 50)';
    ctx.strokeStyle = 'black';
    ctx.moveTo(400, 150);
    ctx.lineTo(400, 300);
    ctx.lineTo(550, 300);
    ctx.lineTo(550, 150);
    ctx.lineTo(475, 100);
    ctx.lineTo(400, 150);
    ctx.fill();
    ctx.lineTo(550, 150);
    ctx.stroke();
    ctx.beginPath();
    ctx.moveTo(523, 140);
    ctx.lineTo(523, 100);
    ctx.moveTo(510, 140);
    ctx.lineTo(510, 100);
    ctx.lineTo(523, 100);
    ctx.lineTo(523, 140);
    ctx.closePath();
    ctx.fill();
    ctx.stroke();
    
    ctx.save();
    ctx.scale(2, 1);
    ctx.beginPath();
    ctx.arc(258, 100, 3, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.fill();
    ctx.restore();
    
    ctx.beginPath();
    ctx.fillStyle = 'black';
    ctx.strokeStyle = 'rgb(200, 70, 50)';
    ctx.fillRect(410, 160, 60, 55);
    ctx.fillRect(480, 160, 60, 55);
    ctx.fillRect(480, 225, 60, 55);
    ctx.moveTo(410, 185);
    ctx.lineTo(540, 185);
    ctx.moveTo(410, 250);
    ctx.lineTo(540, 250);
    ctx.moveTo(440, 160);
    ctx.lineTo(440, 240);
    ctx.moveTo(510, 160);
    ctx.lineTo(510, 280);
    ctx.stroke();
    
    ctx.beginPath();
    ctx.strokeStyle = 'black';
    ctx.moveTo(410, 300);
    ctx.lineTo(410, 260);
    ctx.quadraticCurveTo(430, 240, 450, 260);
    ctx.lineTo(450, 300);
    ctx.moveTo(430, 300);
    ctx.lineTo(430, 250);
    ctx.stroke();  
    
    ctx.save();
    ctx.beginPath();
    ctx.arc(420, 280, 2, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.beginPath();
    ctx.arc(440, 280, 2, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.restore();
}