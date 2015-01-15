window.onload = function(){
    var addButton = document.getElementById('add-item-btn');
    var toggleButton = document.getElementById('toggle-items-btn');
    
    var todosDiv = document.getElementById('todos');
    todosDiv.style.width = '310px';
    todosDiv.style.marginTop = '10px';
    
    var todosShown = true;
    
    var todoTextBox = document.getElementById('todo-text');
    
    addButton.addEventListener('click', function(){
        var todoText = todoTextBox.value;
        
        var todoDiv = document.createElement('div');
        var strongEl = document.createElement('strong');
        strongEl.textContent = todoText;
        var deleteBtn = document.createElement('button');
        deleteBtn.innerHTML = 'Delete';
        deleteBtn.className = 'delBtn';
        todoDiv.appendChild(strongEl);
        todoDiv.appendChild(deleteBtn);
        
        deleteBtn.addEventListener('click', function(){
            todosDiv.removeChild(todoDiv);
        });
        
        todosDiv.appendChild(todoDiv);
    });
    
    toggleButton.addEventListener('click', function(){
        if(todosShown){
            todosDiv.style.visibility = 'hidden';
        }
        else{
            todosDiv.style.visibility = 'visible';
        }
        
        todosDiv = !todosDiv;
    });
}
