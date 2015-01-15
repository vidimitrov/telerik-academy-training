window.onload = function () {
    var paper = Raphael(10, 10, 500, 500);

    var telerikLogo = paper.path('M23 39 39 23 79 63 56 85 33 63 73 23 89 39');
    telerikLogo.attr({
        'stroke-width': 10,
        stroke: '#5CE600'
    });

    var telerikText = paper.text(230, 62, 'Telerik');
    telerikText.attr({
        'font-size': 80,
        'font-weight': 'bold',
        'font-family': 'Arial'
    });

    var circle = paper.circle(370, 58, 8);
    circle.attr({
        'stroke-width': 2
    });

    var registeredtrademarkR = paper.text(370, 58, 'R');
    registeredtrademarkR.attr({
        'font-size': 12,
        'font-weight': 'bold'
    });

    var slogan = paper.text(263, 112, 'Develop experiences');
    slogan.attr({
        'font-size': 32,
        'font-family': 'Arial'
    });
};