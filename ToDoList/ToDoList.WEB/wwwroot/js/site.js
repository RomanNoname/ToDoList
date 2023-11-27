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
function toggleCompleted(element, item)
{
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", "/api/ApiToDoList");
    xhr.setRequestHeader("Content-Type", "application/json");

    item.IsFinished = !item.IsFinished;
    var jsonData = JSON.stringify(item);

    xhr.onload = function () {
        if (xhr.status === 200) {

            element.querySelector('span').classList.toggle('completed');

        } else if (xhr.status === 400) {
            window.alert('Bad Request');
        }
    };

    xhr.send(jsonData);
}
function editTask(item) {
  
    var divSpan = document.getElementById(item.Id);

    if (divSpan == null)
        divSpan = document.getElementById(item.id);

    var span = divSpan.querySelector("span");
    var newTask = prompt('Input new title for the task', span.textContent);
    if (newTask !== null) {
        var xhr = new XMLHttpRequest();
        item.title = newTask;
        var jsonData = JSON.stringify(item);
        xhr.open("PUT", "/api/ApiToDoList");
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onload = function () {
            if (xhr.status === 200) {
                span.textContent = newTask;
            } else if (xhr.status === 400) {
                window.alert('Bad Request');
            }
        };

        xhr.send(jsonData);
       
    }
}

function deleteTask(id) {
   
    var xhr = new XMLHttpRequest();
 
    xhr.open("DELETE", "/api/ApiToDoList?id=" + id);
    xhr.setRequestHeader("Content-Type", "application/json");
        
    xhr.onload = function () {
        if (xhr.status === 204) {
            var item = document.getElementById(id);
            item.remove();
        }
        else if (xhr.status === 400) {
            window.alert('Bad Request');
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
    var taskList = document.getElementById('taskList');

    if (taskInput.value.trim() === '') {
        alert('Add title');
        return;
    }

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/api/ApiToDoList");
    xhr.setRequestHeader("Content-Type", "application/json");

    var item = {
        title: taskInput.value
    };

    var jsonData = JSON.stringify(item);

    xhr.onload = function () {
        if (xhr.status === 200) {

            var response = JSON.parse(xhr.responseText);
           
            var divContainer = document.createElement('div');
            divContainer.style.display="flex";
            divContainer.id = response.id;
            
            var divItem = document.createElement('div');
            divItem.classList.add("taskItem")
            divItem.onclick = function () {
                toggleCompleted(this, response);
            };

            var span = document.createElement('span');
            span.textContent = item.title;

          
            var editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
            editBtn.classList.add("green-btn");
            editBtn.onclick = function () {
                editTask(response);
            };
          
            var deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.classList.add("red-btn");
            deleteBtn.onclick = function () {
                deleteTask(response.id);
            };

            var divButtons = document.createElement("div");

            divItem.appendChild(span);
            divButtons.appendChild(editBtn);
            divButtons.appendChild(deleteBtn);
            divContainer.appendChild(divItem);
            divContainer.appendChild(divButtons);

            var taskList = document.getElementById("taskList")
            taskList.insertBefore(divContainer, taskList.firstChild);

        } else if (xhr.status === 400) {
            window.alert('Bad Request');
        }
    };

    xhr.send(jsonData);
    taskInput.value = '';
}
