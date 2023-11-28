document.getElementById('taskForm').addEventListener('submit', function (event) {
    event.preventDefault(); 
    addTask();
});

function handleKeyDown(event) {
    if (event.key === 'Enter') {
        event.preventDefault(); 
        addTask();
    }
}
function toggleCompleted(item) {

    var checkbox = document.getElementById('checkbox_'+ item.Id);
    var label = document.getElementById('label_'+item.Id);

    label.classList.toggle('completed');
  
    item.IsFinished = checkbox.checked
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", "/api/ApiToDoList");
    xhr.setRequestHeader("Content-Type", "application/json");
    var jsonData = JSON.stringify(item);

    xhr.onload = function () {
        if (xhr.status === 200) {
           return
        } else if (xhr.status === 400) {
            window.alert('Something went wrong');
        }
    };

    xhr.send(jsonData);
}

function editTask(item) {


    var divSpan = document.getElementById(item.Id);

    if (divSpan == null)
        divSpan = document.getElementById(item.id);

    var span = divSpan.querySelector("label");
    var newTitle = prompt('Input new title for the task (up to 100 characters)', span.textContent);
    if (newTitle.trim().length > 100) {
        alert('Title should be up to 100 characters.');
    } else if (newTitle.trim() !== "") {
        var xhr = new XMLHttpRequest();
        item.title = newTitle;
        var jsonData = JSON.stringify(item);
        xhr.open("PUT", "/api/ApiToDoList");
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onload = function () {
            if (xhr.status === 200) {
                span.textContent = newTitle;
            } else if (xhr.status === 400) {
                window.alert('Something went wrong');
            }
        };

        xhr.send(jsonData);
       
    }
}

function deleteTask(id) {

    if (!window.confirm("Do you really want to delete?")) {
        return;
    }
    var xhr = new XMLHttpRequest();
 
    xhr.open("DELETE", "/api/ApiToDoList?id=" + id);
    xhr.setRequestHeader("Content-Type", "application/json");
        
    xhr.onload = function () {
        if (xhr.status === 204) {
            var item = document.getElementById(id);
            item.remove();
        }
        else if (xhr.status === 400) {
            window.alert('Something went wrong');
        }
    };

    xhr.send();
   
}
function countCharacters() {
    var taskInput = document.getElementById('taskInput');
    var charCount = document.getElementById('charCount');
    charCount.textContent = taskInput.value.length;
}
function addTask() {
    var taskInput = document.getElementById('taskInput');

    if (taskInput.value.trim() === '') {
        return;
    }

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/api/ApiToDoList');
    xhr.setRequestHeader('Content-Type', 'application/json');

    var item = {
        title: taskInput.value
    };

    var jsonData = JSON.stringify(item);

    xhr.onload = function () {
        if (xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);

            var divContainer = document.createElement('div');

            response.Id = response.id;

            divContainer.classList.add('taskItemContainer');
            divContainer.id = response.id;

            var divItem = document.createElement('div');
            divItem.classList.add('taskItem');

            var checkbox = document.createElement('input');
            checkbox.id = 'checkbox_' + response.id;
            checkbox.type = 'checkbox';
            checkbox.onchange = function () {
                toggleCompleted(response);
            };
            checkbox.checked = item.IsFinished;

            var label = document.createElement('label');
            label.textContent = item.title;
            label.id = 'label_' + response.id;
            label.setAttribute('for', 'checkbox_' + response.id);

            var editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
            editBtn.classList.add('green-btn');
            editBtn.onclick = function () {
                editTask(response);
            };

            var deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.classList.add('red-btn');
            deleteBtn.onclick = function () {
                deleteTask(response.id);
            };
          

            var divButtons = document.createElement('div');
            divButtons.classList.add("btn-container");

            divItem.appendChild(checkbox);
            divItem.appendChild(label);
            divButtons.appendChild(editBtn);
            divButtons.appendChild(deleteBtn);
            divContainer.appendChild(divItem);
            divContainer.appendChild(divButtons);

            var taskList = document.getElementById('taskList');
            taskList.insertBefore(divContainer, taskList.firstChild);
        } else if (xhr.status === 400) {
            window.alert('Something went wrong');
        }
    };

    xhr.send(jsonData);
    taskInput.value = '';
    document.getElementById('charCount').textContent = '0';
}

