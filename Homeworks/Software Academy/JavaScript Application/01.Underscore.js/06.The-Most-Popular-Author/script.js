window.onload = function() {
    var books = [{
        author: 'Pesho',
        title: 'Peshovcite',
        year: 2014
    }, {
        author: 'Gosho',
        title: 'Listo pod shuma',
        year: 2000
    }, {
        author: 'Pesho',
        title: 'Edin sred mnogo',
        year: 2012
    }, {
        author: 'Pesho',
        title: 'Stranno ime za kniga',
        year: 2013
    }, {
        author: 'Stamat',
        title: 'Stamat i kompaniq',
        year: 2014
    }, {
        author: 'Neznainiq voin',
        title: 'Istoriqta na edna legenda',
        year: 1994
    }];
    
    var booksGroupedByAuthor = _.groupBy(books, function(book) {
        return book.author;
    });
    
    var mostPopularAuthorBooks = _.max(booksGroupedByAuthor, function(group) {
        return group.length;
    });
    
    var mostPopularAuthor = _.first(mostPopularAuthorBooks).author;
    
    console.log('The most popular author is: ', mostPopularAuthor);
};