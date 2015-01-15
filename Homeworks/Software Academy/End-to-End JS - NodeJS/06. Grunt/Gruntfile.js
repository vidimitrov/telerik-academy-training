module.exports = function (grunt) {

    grunt.initConfig({
        jshint: {
            app: ['Gruntfile.js', './APP/scripts/**/*.js']
        },
		jade: {
			compile: {
				files: {
					'./DEV/views/index.html': './APP/views/index.jade'
				}
			}
		},
		coffee: {
			compile: {
				files: {
					'./DEV/scripts/app.js': './APP/scripts/app.coffee'
				}
			}
		},
		stylus: {
			compile: {
				files: {
					'./DEV/styles/style.css': './APP/styles/style.styl'
				}
			}
		},
		copy: {
			main: {
				src: './APP/images/*',
				dest: './DEV/images/'
			}
		},
		connect: {
			options: {
				port: 8080,
				livereload: 35729,
				hostname: 'localhost'
			},
			livereload: {
				options: {
					open: true,
					base: [
						'dev'
					]
				}
			}
		},
		watch: {
			js: {
				files: ['Gruntfile.js', './APP/scripts/**/*.coffee'],
				tasks: ['coffee'],
				options: {
					livereload: true
				}
			},
			stylus: {
				files: ['./APP/styles/**/*.styl'],
				tasks: ['stylus'],
				options: {
					livereload: true
				}
			},
			jade: {
				files: ['./APP/views/main.jade'],
				tasks: ['jade'],
				options: {
					livereload: true
				}
			},
			livereload: {
				options: {
					livereload: '35729'
				},
				files: [
					'./DEV/**/*.html',
					'./DEV/**/*.css',
					'./DEV/**/*.js'
				],
				tasks: ['jshint']
			}
		}
    });
	
    grunt.loadNpmTasks('grunt-contrib-coffee');
	grunt.loadNpmTasks('grunt-contrib-jshint');
	grunt.loadNpmTasks('grunt-contrib-jade');
	grunt.loadNpmTasks('grunt-contrib-stylus');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks('grunt-contrib-connect');
	grunt.loadNpmTasks('grunt-contrib-watch');
	
	grunt.registerTask('serve', ['coffee', 'jshint', 'jade', 'stylus', 'copy', 'connect', 'watch']);
};