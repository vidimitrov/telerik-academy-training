window.onload = function () {
    var getAllButton = document.getElementById('get-all-button');
    var addStudentButton = document.getElementById('add-button');
    var deleteStudentButton = document.getElementById('delete-button');
    var studentsList = document.getElementById('students-list');
    
    var apiUrl = 'http://localhost:3000/students/';
    var contentType = 'application/json';
    
    getAllButton.addEventListener('click', onGetAllButtonClick);
    addStudentButton.addEventListener('click', onAddStudentButtonClick);
    deleteStudentButton.addEventListener('click', onDeleteStudentButtonClick);
    
    function onGetAllButtonClick (ev) {
        Http.getJSON({
            url: apiUrl,
            contentType: contentType,
            success: function (value) {
                console.log('GET request made for getting all students!');
            },
            error: function () {
                console.log('GET request cannot be made for getting all students!');
            }
        })
        .then(function (responseText) {
            var students = JSON.parse(responseText);
            var studentsAsHtml = '<ul>';
            
            for (var i = 0; i < students.count; i++) {
                studentsAsHtml += '<li> Name: ' + students.students[i].name 
                                    + ' --- Grade: ' + students.students[i].grade + '</li>';
            }
            
            studentsAsHtml += '</ul>';
            
            studentsList.innerHTML = studentsAsHtml;
        });
    }
    
    function onAddStudentButtonClick (ev) {
        var studentName = document.getElementById('student-name').value;
        var studentGrade = document.getElementById('student-grade').value;
        
        Http.postJSON({
            url: apiUrl,
            contentType: contentType,
            params: {
                name: studentName,
                grade: studentGrade
            },
            success: function (value) {
                console.log('POST request made for adding a student!');
                onGetAllButtonClick();
            },
            error: function () {
                console.log('POST request cannot be made for adding a student!');
            }
        });
    }
    
    function onDeleteStudentButtonClick (ev) {
        var studentId = parseInt(document.getElementById('student-id').value);
        console.log('You want to delete: ', studentId);
        
        var _httpRequest;
        
        if (window.XMLHttpRequest) {
            _httpRequest = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            try{
                _httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (e) {
                _httpRequest = new ActiveXObject("Microsoft.XMLHTTP"); 
            }
        }
        
        var deffered = Q.defer();
        var method = 'DELETE';
        
        _httpRequest.open(method, apiUrl + studentId, true);
        _httpRequest.setRequestHeader('Content-type', contentType);
        
        _httpRequest.onreadystatechange = function () {
            if (_httpRequest.readyState === 4) {
                if (_httpRequest.status === 200) {
                    deffered.resolve(_httpRequest.responseText);
                }
                else {
                    deffered.reject(new Error("Status code was " + _httpRequest.status));
                }
            }
        }
        
        _httpRequest.send(null);
        
        return deffered.promise;
    }
}