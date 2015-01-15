(function () {
    var currentSlide = 0;
    var slides = [
        'Slide 1... some text',
        '<div><h1>Slide 2</h1></div>',
        '<h2>Slide 3......</h2>     '
    ];
    
    setSlideToCurrent();
    $('#prev-button').on('click', prevSlide);
    $('#next-button').on('click', nextSlide);

    function nextSlide() {
        currentSlide++;
        if (currentSlide === slides.length) {
            currentSlide = 0;
        }

        setSlideToCurrent();
        resetTimer();
    }

    function prevSlide() {
        currentSlide--;
        if (currentSlide < 0) {
            currentSlide = slides.length - 1;
        }

        setSlideToCurrent();
        resetTimer();
    }

    function setSlideToCurrent() {
        $('#current-slide').html(slides[currentSlide]);
    }

    function resetTimer() {
        clearInterval(autoSlideChanger);
        autoSlideChanger = setInterval(nextSlide, 5000);
    }

    var autoSlideChanger = setInterval(nextSlide, 5000);
})();