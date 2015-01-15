window.onload = function () {
    var stage = new Kinetic.Stage({
        container: 'canvas-container',
        width: 450,
        height:350
    });
    
    var layer = new Kinetic.Layer();
    
    var rect = new Kinetic.Rect({
        fill: 'black',
        stroke: 'green',
        strokeWidth: 3,
        x: 10,
        y: 10,
        width: 100,
        height: 100
    });
    
    layer.add(rect);
    stage.add(layer);
}