define(['controls', 'handlebars'], function (Controls, Handlebars) {
    var people = [
        { id: 1, name: "Petra Hristova", age: 18, avatarUrl: "images/photo1.jpg" }, 
        { id: 2, name: "Georgi Georgiev", age: 22, avatarUrl: "images/photo2.jpg" }, 
        { id: 3, name: "Pesho Ivanov", age: 20, avatarUrl: "images/photo3.jpg" }, 
        { id: 4, name: "Dragana Milanova", age: 21, avatarUrl: "images/photo4.jpg" }, 
        { id: 5, name: "Ivan Petrov", age: 25, avatarUrl: "images/photo2.jpg" }
    ];
    
    var container = document.getElementById('container');
    
    var comboBox = Controls.ComboBox(people);
    var template = document.getElementById('people-template');
    var comboBoxHtml = comboBox.render(template);
    
    container.innerHTML = comboBoxHtml.innerHTML;
    
    document.getElementsByClassName('current-selection')[0].addEventListener('click', function (ev) {
        var itemsContainer = document.getElementsByClassName('items-container')[0];
        itemsContainer.style.display = 'block';
    });
    
    var peopleContainers = document.getElementsByClassName('person');
    for (var i = 0; i < peopleContainers.length; i++) {
        peopleContainers[i].addEventListener('click', function (ev) {
        var currentSelection = document.getElementsByClassName('current-selection')[0];
        var itemsContainer = document.getElementsByClassName('items-container')[0];
        currentSelection.value = this.children[1].innerHTML;
        itemsContainer.style.display = 'none';
    });
    }
});