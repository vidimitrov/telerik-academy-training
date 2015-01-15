window.onload = function() {
    var people = [{
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
        firstName: 'Dimitar',
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
        firstName: 'Ivan',
        lastName: 'Stoimenov',
        age: 19
    }, {
        firstName: 'Ivan',
        lastName: 'Dimitrov',
        age: 20
    }, {
        firstName: 'Evdokiq',
        lastName: 'Stoimenova',
        age: 19
    }, {
        firstName: 'Detelina',
        lastName: 'Dimitrova',
        age: 20
    }, {
        firstName: 'Petar',
        lastName: 'Stoimenov',
        age: 12
    }, {
        firstName: 'Ivan',
        lastName: 'Stoimenov',
        age: 29
    }, {
        firstName: 'Ivan',
        lastName: 'Shahpazov',
        age: 17
    }];

    var countedByFirstName = _.countBy(people, function(person) {
        return person.firstName;
    });
    
    var countedByLastName = _.countBy(people, function(person) {
        return person.lastName;
    });
    
    var theMostCommonFirstName = '';
    var max = 0;
    
    for(var name in countedByFirstName) {
        if (countedByFirstName[name] > max) {
            max = countedByFirstName[name];
            theMostCommonFirstName = name;
        }
    }
    
    console.log('The most common first name: ', theMostCommonFirstName);
    
    var theMostCommonLastName = '';
    max = 0;
    
    for(var name in countedByLastName) {
        if (countedByLastName[name] > max) {
            max = countedByLastName[name];
            theMostCommonLastName = name;
        }
    }
    
    console.log('The most common last name: ', theMostCommonLastName);
}
