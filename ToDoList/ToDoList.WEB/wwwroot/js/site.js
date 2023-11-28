$('#taskForm').submit(function (event) {
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
    var checkbox = $('#checkbox_' + item.Id);
    var label = $('#label_' + item.Id);

    item.IsFinished = checkbox.prop('checked');

    $.ajax({
        url: "/api/ApiToDoList",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function () {
            label.toggleClass('completed');
        },
        error: function () {
            window.alert('Something went wrong');
        }
    });
}

function editTask(item) {
    var divSpan = $('#' + item.Id);

   
    var label = divSpan.find("label");
    var newTitle = prompt('Input new title for the task (up to 100 characters)', label.text());
    if (newTitle.trim().length > 100) {
        alert('Title should be up to 100 characters.');
    } else if (newTitle.trim() !== "") {
        item.Title = newTitle;

        $.ajax({
            url: "/api/ApiToDoList",
            type: "PUT",
            contentType: "application/json",
            data: JSON.stringify(item),
            success: function () {
                label.text(newTitle);
            },
            error: function () {
                window.alert('Something went wrong');
            }
        });
    }
}

function deleteTask(id) {
    if (!window.confirm("Do you really want to delete?")) {
        return;
    }

    $.ajax({
        url: "/api/ApiToDoList?id=" + id,
        type: "DELETE",
        contentType: "application/json",
        success: function () {
            $('#' + id).remove();
        },
        error: function () {
            window.alert('Something went wrong');
        }
    });
}

function countCharacters() {
    var taskInput = $('#taskInput');
    var charCount = $('#charCount');
    charCount.text(taskInput.val().length);
}

function addTask() {
    var taskInput = $('#taskInput');

    if (taskInput.val().trim() === '') {
        return;
    }

    var item = {
        title: taskInput.val()
    };

    $.ajax({
        url: '/api/ApiToDoList',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (response) {

            response.Id = response.id;
            response.Title = response.title;
            response.IsFinished = response.isFinished;

            var divContainer = createTaskContainer(response);
            var taskList = $('#taskList');
            taskList.prepend(divContainer);
        },
        error: function () {
            window.alert('Something went wrong');
        }
    });

    taskInput.val('');
    $('#charCount').text('0');
}

function createTaskContainer(response) {
    var divContainer = $('<div>').addClass('taskItemContainer').attr('id', response.id);

    var divItem = $('<div>').addClass('taskItem');

    var checkbox = $('<input>').attr({
        'id': 'checkbox_' + response.id,
        'type': 'checkbox'
    }).change(function () {
        toggleCompleted(response);
    }).prop('checked', response.IsFinished);

    var label = $('<label>').attr({
        'id': 'label_' + response.id,
        'for': 'checkbox_' + response.id
    }).text(response.title);


    var editBtn = createButton('Edit', 'green-btn', function () {
        editTask(response);
    });

    var deleteBtn = createButton('Delete', 'red-btn', function () {
        deleteTask(response.id);
    });

    var divButtons = $('<div>').addClass('btn-container');
    divItem.append(checkbox).append(label);
    divButtons.append(editBtn).append(deleteBtn);
    divContainer.append(divItem).append(divButtons);

    return divContainer;
}
function createButton(text, className, clickHandler) {
    return $('<button>').text(text).addClass(className).click(clickHandler);
}
