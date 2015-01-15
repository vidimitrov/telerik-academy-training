//var serviceRootUrl = "http://localhost:15679/api/students/"
var serviceRootUrl = "http://school-academy-demos.apphb.com/api/students/"

function onDocumentReady() {
    performGetRequest(serviceRootUrl + "all",
        onAllStudentsSuccess, onAllStudentsError);
    $("#add-button").
        on("click", onAddButtonClick);
    $("#more-button").
        on("click", onMoreButtonClick);
    $("remove-student").
        on("click", onRemoveStudentClick());
}



function onRemoveStudentClick(){
    performPostRequest(serviceRootUrl + "remove", onRemoveSuccess, onAddError);
}
function onRemoveSuccess(data) {
    performGetRequest(serviceRootUrl + "all", onRemoveStudentSuccess, onAllStudentsError);
}
function onRemoveStudentSuccess(data) {
    $(".selected").html = "";
}




function onAddButtonClick() {
    var fname = document.getElementById("fname-tb").value;
    if (fname == "") {
        return;
    }
    var lname = document.getElementById("lname-tb").value;
    if (lname == "") {
        return;
    }
    var subjects = document.getElementsByName("tb-subject");
    var scores = document.getElementsByName("tb-score");

    var m = new Array();

    for (var i = 0; i < subjects.length; i++) {
        var subj = subjects[i].value;
        var sc = scores[i].value;
        if (subj != "" && sc != "") {
            m.push({
                subject: subj,
                score: sc
            });
        }
    }

    var student = {
        firstname: fname,
        lastname: lname,
        marks: m
    };

    performPostRequest(serviceRootUrl + "add", student, onAddSuccess, onAddError);
}

function onAddSuccess(data) {
    performGetRequest(serviceRootUrl + "all", onAllStudentsSuccess, onAllStudentsError);
}

function onAddError() {
    alert(JSON.stringify(arguments));
}

function onAllStudentsSuccess(data) {

    var studentsCount = data.length;

    if (studentsCount == 0) {
        $("#students-container").html("no students in database");
        return;
    }
    var selectedClass = ' class="selected" ';
    var studentsHtml =
        '<ul class="students-list">';
    for (var i = 0; i < studentsCount; i++) {
        var student = data[i];
        var toAppend =
            '<li' + ((i == 0) ? ' class="selected" ' : '') + '>' +
                    '<a href="#" data-id="' + student.id + '">' +
                        student.firstname + " " + student.lastname +
                    '</a>' +
            '</li>';
        studentsHtml += toAppend;
    }

    studentsHtml += '</ul>';
    $("#students-container").html(studentsHtml);

    $(".students-list li a").on("click", onStudentClick);
    $(".students-list li a:first").click();
}

function onAllStudentsError() {
    alert(JSON.stringify(arguments));
}

function onMoreButtonClick() {
    $("#new-marks-list").append(
            '<li>' +
                'Subject: ' +
                '<input type="text" name="tb-subject" placeholder="Subject" />' +
                'Score: ' +
                '<input type="text" name="tb-score" placeholder="Score" />' +
            '</li>');
}

function onStudentClick() {
    performGetRequest(serviceRootUrl + "student-marks/" +
        $(this).data("id"),
        onMarksSuccess, onMarksError);
    $(".selected").removeClass("selected");
    $(this).addClass("selected");
}

function onMarksSuccess(marks) {
    var marksHtml = '<ul class="marks-list">';

    for (var i = 0; i < marks.length; i++) {
        var mark = marks[i];
        marksHtml +=
        '<li>' +
            '(<strong>Subject</strong>: ' + mark.subject + ', ' +
            '<strong>Score</strong>: ' + mark.score + ')'
        '</li>';
    }
    $("#student-details-container").html(marksHtml);
}

function onMarksError(err) {
    alert(JSON.stringify(err));
}

function performGetRequest(serviceUrl, onSuccess, onError) {
    $.ajax({
        url: serviceUrl,
        type: "GET",
        timeout: 5000,
        dataType: "json",
        success: onSuccess,
        error: onError
    });
}

function performPostRequest(serviceUrl, data, onSuccess, onError) {

    //var postData = JSON.stringify(data);

    $.ajax({
        url: serviceUrl,
        type: "POST",
        timeout: 5000,
        dataType: "json",
        data: data,
        success: onSuccess,
        error: onError
    });
}

