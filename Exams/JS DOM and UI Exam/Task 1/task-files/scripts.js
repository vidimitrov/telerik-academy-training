function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);
    container.style.width = '580px';
    
    var initializedItems = [];
    
    var currentImageContainer = document.createElement('div');
    currentImageContainer.classList.add('currentImageContainer');
    currentImageContainer.style.width = '350px';
    currentImageContainer.style.height = '380px';
    currentImageContainer.style.margin = '10px';
    currentImageContainer.style.padding = '5px';
    currentImageContainer.style.display = 'inline-block';
    currentImageContainer.style.float = 'left';
    currentImageContainer.style.textAlign = 'center';
    
    var currentImageTitle = document.createElement('h1');
    currentImageTitle.innerHTML = items[0].title;
    
    var currentImage = document.createElement('img');
    currentImage.style.width = '340px';
    currentImage.style.height = '290px'; 
    currentImage.style.borderRadius = '10px';
    currentImage.src = items[0].url;
    
    currentImageContainer.appendChild(currentImageTitle);
    currentImageContainer.appendChild(currentImage);
    
    container.appendChild(currentImageContainer);
    
    var sidebarContainer = document.createElement('div');
    sidebarContainer.style.overflowY = 'auto';
    sidebarContainer.style.overflowX = 'hidden';
    sidebarContainer.style.textAlign = 'center';
    sidebarContainer.style.height = '400px';
    
    var filterContainer = document.createElement('div');
    filterContainer.style.width = '160px';
    filterContainer.style.margin = '10px';
    filterContainer.style.display = 'inline-block';
    filterContainer.style.padding = '5px';
    
    var imageListFilterBoxLabel = document.createElement('label');
    imageListFilterBoxLabel.innerHTML = 'Filter';
    
    var imageListFilterBox = document.createElement('input');
    
    imageListFilterBox.addEventListener('change', function(ev){
        var filterValue = this.value.toLowerCase();
        var imageListContainer = document.querySelector('.imageListContainer');
        removeAllItems();
        appendItems(initializedItems, filterValue);
    });
    
    imageListFilterBox.style.width = '140px';
    
    filterContainer.appendChild(imageListFilterBoxLabel);
    filterContainer.appendChild(imageListFilterBox);
    
    var imageListContainer = document.createElement('div');
    imageListContainer.classList.add('imageListContainer');
    imageListContainer.style.width = '160px';
    imageListContainer.style.margin = '10px';
    imageListContainer.style.display = 'inline-block';
    imageListContainer.style.padding = '5px';
    
    sidebarContainer.appendChild(filterContainer);
    sidebarContainer.appendChild(imageListContainer);
    
    container.appendChild(sidebarContainer);
    
    var itemBox = document.createElement('div');
    itemBox.style.margin = '0 auto';
    
    var itemTitle = document.createElement('h3');
    itemTitle.style.margin = '0px';
    
    var itemImage = document.createElement('img');
    itemImage.style.width = '140px';
    itemImage.style.height = '100px';
    itemImage.style.borderRadius = '10px';
    
    itemBox.appendChild(itemTitle);
    itemBox.appendChild(itemImage);
    
    initializeItems();
    attachEventsToItems();
    appendItems(initializedItems);
    
    function initializeItems(){
        for(var i = 0; i < items.length; i++){
            var item = itemBox.cloneNode(true);
            item.childNodes[0].innerHTML = items[i].title;
            item.childNodes[1].src = items[i].url;
            initializedItems.push(item);
        }
    }
    
    function attachEventsToItems(){
        for(var i = 0; i < initializedItems.length; i++){
            initializedItems[i].addEventListener('mouseover', function(ev){
                this.style.backgroundColor = '#BBB';
            });

            initializedItems[i].addEventListener('mouseout', function(ev){
                this.style.backgroundColor = '';
            });

            initializedItems[i].addEventListener('click', function(ev){
                var currImgContainer = document.querySelector('.currentImageContainer');
                currImgContainer.childNodes[0].innerHTML = this.childNodes[0].innerHTML;
                currImgContainer.childNodes[1].src = this.childNodes[1].src;
            });
        }
    }
    
    function appendItems(itemsToAppend, filter){
        filter = filter || '';
        
        for(var i = 0; i < itemsToAppend.length; i++){
            var title = initializedItems[i].childNodes[0].innerHTML.toLowerCase();
            if(title.indexOf(filter) > -1){
                imageListContainer.appendChild(initializedItems[i]);
            }
        }
    }
    
    function removeAllItems(){
        document.querySelector('.imageListContainer').innerHTML = '';
    }
}