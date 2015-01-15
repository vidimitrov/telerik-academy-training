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

    var filteredStudentsFirstAndLastNames = _.chain(students)
        .filter(function(student) {
            return student.age >= 18 && student.age <= 24;
        })
        .map(function(student) {
            return {
                firstName: student.firstName,
                lastName: student.lastName
            };
        })
        .value();

    console.log(filteredStudentsFirstAndLastNames);
}
