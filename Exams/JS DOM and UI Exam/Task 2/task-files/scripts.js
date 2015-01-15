$.fn.gallery = function (inputColumns) {
    var $this = $(this);
    $this.addClass('gallery');
    
    var columns = inputColumns || 4;
    $this.css('width', columns * 260);
    
    var $galleryList = $this.find('.gallery-list');
    var $imageContainers = $this.find('.image-container');
    var $selectedImageDiv = $this.find('.selected');
    $selectedImageDiv.hide();
    
    var firstImageSrc = 'imgs/1.jpg';
    var lastImageSrc = 'imgs/12.jpg';
    
    var $prevImageContainer = $selectedImageDiv.find('#previous-image');
    var $currentImageContainer = $selectedImageDiv.find('#current-image');
    var $nextImageContainer = $selectedImageDiv.find('#next-image');
    
    var prevImgSrc;
    var currentImgSrc;
    var nextImgSrc;
    
    $imageContainers.on('click', function(ev){
        if($galleryList.hasClass('blurred')){
            return;
        }
        
        $galleryList.addClass('blurred');
        
        var $selectedContainer = $(this);
        var $selectedImage = $selectedContainer.find('img');
        
        prevImgSrc = $selectedContainer.prev().find('img').attr('src');
        currentImgSrc = $selectedImage.attr('src');
        nextImgSrc = $selectedContainer.next().find('img').attr('src');
                
        $selectedImageDiv.find('#previous-image').attr('src', prevImgSrc || lastImageSrc);
        $selectedImageDiv.find('#current-image').attr('src', currentImgSrc);
        $selectedImageDiv.find('#next-image').attr('src', nextImgSrc || firstImageSrc);
        
        $selectedImageDiv.show();
    });
    
    $prevImageContainer.on('click', function(ev){
        var imgFromList = $imageContainers.filter(function(){
            return $(this).find('img').attr('src') === prevImgSrc;
        });
        
        nextImgSrc = currentImgSrc;
        currentImgSrc = prevImgSrc;
        prevImgSrc = imgFromList.prev().find('img').attr('src') || lastImageSrc;
        
        $selectedImageDiv.find('#previous-image').attr('src', prevImgSrc);
        $selectedImageDiv.find('#current-image').attr('src', currentImgSrc);
        $selectedImageDiv.find('#next-image').attr('src', nextImgSrc);
    });
    
    $currentImageContainer.on('click', function(ev){
        $galleryList.removeClass('blurred');
        $selectedImageDiv.hide();
    });
    
    $nextImageContainer.on('click', function(ev){
        var imgFromList = $imageContainers.filter(function(){
            return $(this).find('img').attr('src') === nextImgSrc;
        });
        
        prevImgSrc = currentImgSrc;
        currentImgSrc = nextImgSrc;
        nextImgSrc = imgFromList.next().find('img').attr('src') || firstImageSrc;
        
        $selectedImageDiv.find('#previous-image').attr('src', prevImgSrc);
        $selectedImageDiv.find('#current-image').attr('src', currentImgSrc);
        $selectedImageDiv.find('#next-image').attr('src', nextImgSrc);
    });
};