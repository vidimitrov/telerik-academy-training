require.config({
    baseUrl: 'libs',
    paths: {
        jquery: 'jquery',
        mustache: 'mustache',
        sammy: 'sammy',
        q: 'q',
        underscore: 'underscore',
        mocha: 'mocha',
        chai: 'chai',
        bootstrap: 'bootstrap'
    },
    shim: {
        'mocha': {
            init: function () {
                this.mocha.setup('bdd');
                return this.mocha;
            }
        }
    }
});

require(['jquery', 'mustache', 'sammy', 'q', 'underscore', 'mocha', 'chai', 'bootstrap'], 
   function($, Mustache, Sammy, Q, _, Mocha, Chai) {
        var apiUrl = '';

        var app = Sammy('#main-container', function () {
            this.get('#/', function() {
                
            });
        });

        app.run('#/');
   }
);