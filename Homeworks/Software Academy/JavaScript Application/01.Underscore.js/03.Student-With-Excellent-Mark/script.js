window.onload = function() {
    var students = [{
        firstName: 'Petar',
        lastName: 'Ivanov',
        age: 21,
        marks: [3, 4, 5, 4, 3, 4]
    }, {
        firstName: 'Dimitar',
        lastName: 'Dragomirov',
        age: 14,
        marks: [2, 3, 3, 5, 6, 2]
    }, {
        firstName: 'Vanq',
        lastName: 'Ilieva',
        age: 24,
        marks: [6, 5, 6, 6, 5, 5]
    }, {
        firstName: 'Qnko',
        lastName: 'Mladenov',
        age: 28,
        marks: [4, 5, 3, 4, 4, 3]
    }, {
        firstName: 'Petq',
        lastName: 'Dimitrova',
        age: 18,
        marks: [2, 3, 3, 4, 3, 2]
    }, {
        firstName: 'Aleksanrdra',
        lastName: 'Dimitrova',
        age: 20,
        marks: [6, 6, 6, 6, 6, 5]
    }, {
        firstName: 'Bojidara',
        lastName: 'Stoimenova',
        age: 19,
        marks: [4, 5, 4, 3, 4, 3]
    }];

    students = _.each(students, function(student) {
        var averageMark;
        var sum = 0;
        var marksCount = student.marks.length;
        
        for (var i = 0; i < marksCount; i++) {
            sum += student.marks[i];
        }
        
        averageMark = sum / marksCount; 

        student.averageMark = averageMark;
    });

    var excellentStudent = _.max(students, function(student) {
        return student.averageMark;
    });

    console.log(excellentStudent);
}
