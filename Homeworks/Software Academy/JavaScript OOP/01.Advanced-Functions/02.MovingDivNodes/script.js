window.onload = function () {
    var movingShapes = (function () {
        var self = this;
        var WIDTH = '50px';
        var HEIGHT = '50px';
        var BORDER_STYLE = 'solid';
        var BORDER_WIDTH = '1px';
        var POSITION = 'absolute';
        
        function generateRandomDiv () {
            var randomDiv = document.createElement('div');
            
            randomDiv.style.width = WIDTH;
            randomDiv.style.height = HEIGHT;
            randomDiv.style.borderStyle = BORDER_STYLE;
            randomDiv.style.borderWidth = BORDER_WIDTH;
            randomDiv.style.position = POSITION;
            randomDiv.style.top = generateRandomInt(0, window.innerHeight) + 'px';
            randomDiv.style.left = generateRandomInt(0, window.innerWidth) + 'px';
            randomDiv.style.backgroundColor = generateRandomColor();
            randomDiv.style.color = generateRandomColor();
            randomDiv.style.borderColor = generateRandomColor();
            
            return randomDiv;
        }
        
        function generateRandomColor() {
            var red = generateRandomInt(0, 255);
            var green = generateRandomInt(0, 255);
            var blue = generateRandomInt(0, 255);
            
            return 'rgb(' + red + ',' + green + ', ' + blue + ')';
        }
        
        function generateRandomInt (min, max) {
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }
        
        function add (movement) {
            var container = document.getElementById('container');
            
            switch (movement) {
                case 'rect': 
                    var randomDiv = generateRandomDiv();
                    randomDiv.className = 'rect';
                    container.appendChild(randomDiv);
                    
                    break;
                case 'ellipse':
                    var randomDiv = generateRandomDiv();
                    randomDiv.className = 'ellipse';
                    container.appendChild(randomDiv);
                    
                    break;
            }
        }
        
        function updateContainer () {
            var container = document.getElementById('container');
            
            var divs = document.getElementsByTagName('div');
            var angle = 0;
            var circle = {
                x: window.innerWidth / 2 - 50,
                y: window.innerHeight / 2 - 50,
                r: window.innerHeight / 3,
            };
            
            frame();

            function frame() {
                //TODO use the appended class to separate divs
                
                rotateEllipseMovingDivs(divs, circle, angle);
                //TODO rotate rect moving divs
                
                angle += 0.1;
                
                requestAnimationFrame(frame);
            }

            function rotateEllipseMovingDivs(nodeList, trajectory, startPhase) {
                var currentPhase = 0;

                for (var i = 0, count = nodeList.length; i < count; i++) {
                    currentPhase = startPhase + (2 * Math.PI * i) / count;
                    nodeList[i].style.top = (trajectory.y + Math.sin(currentPhase) * trajectory.r) + 'px';
                    nodeList[i].style.left = (trajectory.x + Math.cos(currentPhase) * trajectory.r) + 'px';
                }
            }
            
            //TODO function rotateRectMovingDivs with some formula for the movement
        }
        
        return {
            add: add,
            updateContainer: updateContainer
        }
    })();
    
    var addEllipseMovingDivButton = document.getElementById('ellipse-gen');
    addEllipseMovingDivButton.addEventListener('click', function () {
        movingShapes.add('ellipse');
        movingShapes.updateContainer();
    });
    
    var addRectMovingDivButton = document.getElementById('rect-gen');
    addRectMovingDivButton.addEventListener('click', function () {
        movingShapes.add('rect');
        movingShapes.updateContainer();
    });
}
































