window.onload = function() {
    var students = [{
        firstName: 'Petar',
        lastName: 'Ivanov',
        age: 21
    }, {
        firstName: 'Dimitar',
        lastName: 'Dragomirov',
        age: 14
    }, {
        firstName: 'Vanq',
        lastName: 'Ilieva',
        age: 24
    }, {
        firstName: 'Qnko',
        lastName: 'Mladenov',
        age: 28
    }, {
        firstName: 'Petq',
        lastName: 'Dimitrova',
        age: 18
    }, {
        firstName: 'Aleksanrdra',
        lastName: 'Dimitrova',
        age: 20
    }, {
        firstName: 'Bojidara',
        lastName: 'Stoimenova',
        age: 19
    }];


    var filteredStudents = _.filter(students, function(student) {
        return student.firstName < student.lastName;
    });

    filteredStudents = _.sortBy(filteredStudents, function(student) {
        return  student.firstName + ' ' + student.lastName;
    });

    filteredStudents.reverse();

    //All the students whose first name is before its last name alphabetically,
    //sorted by descending.
    console.log(filteredStudents);
}
