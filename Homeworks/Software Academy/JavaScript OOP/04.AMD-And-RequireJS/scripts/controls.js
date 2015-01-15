define(['handlebars'], function(Handlebars){    
    function ComboBox (items) {
        this.items = items;
    }
    
    ComboBox.prototype = {
        render: function (handlebarsTemplate) {
            var comboBoxHtml = document.createElement('div');
            var comboField = document.createElement('input');
            comboField.classList.add('current-selection');
            
            comboBoxHtml.appendChild(comboField);
            
            var peopleComboTemplate = Handlebars.compile(handlebarsTemplate.innerHTML);
            
            var itemsContainer = document.createElement('div');
            itemsContainer.classList.add('items-container');
            itemsContainer.innerHTML = peopleComboTemplate({people: this.items});            
            comboBoxHtml.appendChild(itemsContainer);
            
            return comboBoxHtml;
        }
    }
    
    return {
        ComboBox: function (items){
            return new ComboBox(items);
        }
    }
});