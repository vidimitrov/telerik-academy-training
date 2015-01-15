window.onload = function() {
    var animals = [{
        specie: 'Cat',
        animal: 'Wild Cat',
        numberOfLegs: 4
    }, {
        //It's a joke, but I don't know such an animal
        specie: 'Dog',
        animal: 'Strange Dog',
        numberOfLegs: 2
    }, {
        specie: 'Fish',
        animal: 'Shark',
        numberOfLegs: 0
    }, {
        specie: 'Cat',
        animal: 'Leopard',
        numberOfLegs: 4
    }, {
        specie: 'Dog',
        animal: 'Wolf',
        numberOfLegs: 4
    }, {
        specie: 'Fish',
        animal: 'Dolphin',
        numberOfLegs: 0
    }, {
        specie: 'Monkey',
        animal: 'Shimpansee',
        numberOfLegs: 2
    }];
    
    var totalNumberOfLegs = 0;
    _.each(animals, function(animal) {
       totalNumberOfLegs += animal.numberOfLegs;
    });
       
    console.log('Total number of legs: ', totalNumberOfLegs);
}