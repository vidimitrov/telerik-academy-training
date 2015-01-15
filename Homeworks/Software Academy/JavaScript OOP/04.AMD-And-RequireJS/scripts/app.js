require.config({
    baseUrl: 'scripts',
    paths: {
        "handlebars": "libs/handlebars",
        "app": "app",
    },
    shim: {
        'handlebars': {
            exports: 'Handlebars'
        }
    }
});

require(['main', 'handlebars']);