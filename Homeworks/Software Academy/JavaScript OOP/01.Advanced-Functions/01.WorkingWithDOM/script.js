window.onload = function () {
    var domModule = (function () {
        var buffer = document.createDocumentFragment();
        
        function appendChild (element, parentSelector) {
            var parentElement = document.querySelector(parentSelector);
            
            parentElement.appendChild(element);
        }
        
        function removeChild (element, parentSelector) {
            var parent = document.querySelector(parentSelector);
            
            if (typeof element == 'object') {
                parent.removeChild(element);
            }
            else {
                var element = document.querySelector(element);
                
                parent.removeChild(element);
            }
            
        }
        
        function addHandler (selector, eventType, eventHandler) {
            var element = document.querySelector(selector);
            element.addEventListener(eventType, eventHandler);
        }
        
        function appendToBuffer (element) {
            buffer.appendChild(element);
            
            if (buffer.length >= 100) {
                document.appendChild(buffer);
                console.log('elements added, see in console');
            }
            
            return buffer;
        }
        
        function getElementByCSSSelctor (selector) {
            var element = document.querySelector(selector);
            
            return element;
        }
        
        return {
            addElement: appendChild,
            removeElement: removeChild,
            attachEvent: addHandler,
            appendToBuffer: appendToBuffer,
            getElementByCSSSelctor: getElementByCSSSelctor
        }
    })();
    
    var divElement = document.createElement('div');
    divElement.style.width = '300px';
    divElement.style.height = '200px';
    divElement.style.border = '1px solid blue';
    
    domModule.addElement(divElement, '#main-div');
    
    var divToRemove = document.createElement('div');
    divToRemove.style.width = '400px';
    divToRemove.style.height = '200px';
    divToRemove.style.border = '1px solid red';
    
    domModule.addElement(divToRemove, '#main-div');
    domModule.removeElement(divToRemove, '#main-div');
    
    var eventType = 'click';
    var eventHandler = function () {
        alert('clicked!');
    }
    
    domModule.attachEvent('div ul li:first-child', eventType, eventHandler);
    
    for(var i = 0; i < 100; i++){
        var divEl = document.createElement('div');
        domModule.appendToBuffer(divEl);
    }
    
    var cssSelectedElement = domModule.getElementByCSSSelctor('div ul');
    console.log(cssSelectedElement);
    
}