window.onload = function () {
    var canvas = document.getElementById('canvas-container');
    var ctx = canvas.getContext('2d');
    
    var ShapesCreator = (function (context){
        var Shape = (function (){
            function Shape (x, y) {
                this.x = x;
                this.y = y;
            }
            
            return Shape;
        })();
                
        var Rect = (function(){
            function Rect (x, y, width, height) {
                Shape.call(this, x, y);
                
                this.width = width;
                this.height = height;
            }
            
            Rect.prototype = new Shape();
            Rect.prototype.draw = function () {
                context.beginPath();
                context.fillStyle = 'blue';
                context.fillRect(this.x, this.y, this.width, this.height);
                context.closePath();
            }
            
            return Rect;
        })();
        
        var Circle = (function(){
            function Circle (x, y, radius) {
                Shape.call(this, x, y);
                
                this.radius = radius;
            }
            
            Circle.prototype = new Shape();
            Circle.prototype.draw = function () {
                context.beginPath();
                context.fillStyle = 'red';
                context.arc(this.x, this.y, this.radius, 0, 2*Math.PI);
                context.fill();
                context.closePath();
            }
            
            return Circle;
        })();
        
        var Line = (function(){
            function Line(x1, y1, x2, y2) {
                Shape.call(this, x1, y1);
                
                this.x2 = x2;
                this.y2 = y2;
            }
            
            Line.prototype = new Shape();
            Line.prototype.draw = function () {
                context.beginPath();
                context.strokeStyle = 'green';
                context.moveTo(this.x, this.y);
                context.lineTo(this.x2, this.y2);
                context.stroke();
                context.closePath();
            }
            
            return Line;
        })();
        
        return {
            Rect: Rect,
            Circle: Circle,
            Line: Line
        }
    })(ctx);
    
    var rect = new ShapesCreator.Rect(50, 100, 150, 200);
    rect.draw();
    
    var circle = new ShapesCreator.Circle(400, 100, 80);
    circle.draw();
    
    var line = new ShapesCreator.Line(200, 350, 500, 350);
    line.draw();
}