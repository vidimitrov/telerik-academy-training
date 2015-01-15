window.onload = function () {
    var paper = Raphael(10, 10, 500, 500);

    var leftPartText = paper.text(50, 30, 'You');
    leftPartText.attr({
        'font-size': 40
    });
    var rect = paper.rect(90, 5, 98, 50, 10);
    rect.attr({
        fill: 'red',
        stroke: 'red'
    });

    var rightPartText = paper.text(138, 30, 'Tube');
    rightPartText.attr({
        'font-size': 40,
        fill: 'white'
    });
};