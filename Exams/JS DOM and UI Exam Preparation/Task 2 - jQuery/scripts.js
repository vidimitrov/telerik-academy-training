$.fn.tabs = function () {
    var $this = $(this);
    $this.addClass('tabs-container');
    $this.find('.tab-item').first().addClass('current');
    
    $this.find('.tab-item-content').hide();
    $this.find('.current .tab-item-content').show();
    
    var $tabItems = $this.find('.tab-item');
    
    $this.find('.tab-item-title')
        .on('click', function(ev){
            var $title = $(this);
            
            $tabItems.find('.tab-item-content').hide();
            
            var lastCurrentTab = $tabItems.filter('.current');
            lastCurrentTab.removeClass('current');

            $title.parent().addClass('current');
            $tabItems.filter('.current').find('.tab-item-content').show();
    });
};