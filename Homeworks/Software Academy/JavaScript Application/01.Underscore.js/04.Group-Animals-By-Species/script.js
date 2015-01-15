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
    
    var groupedAndSortedAnimals = _.chain(animals)
        .groupBy(function(animal) {
            return animal.specie;
        })
        .sortBy(function(animal) {
            return animal.numberOfLegs;
        })
        .value();
    
    console.log(groupedAndSortedAnimals);
}