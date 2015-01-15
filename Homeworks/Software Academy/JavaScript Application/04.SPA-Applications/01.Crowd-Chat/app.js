require.config({
    baseUrl: 'libs',
    paths: {
        jquery: 'jquery',
        mustache: 'mustache',
        sammy: 'sammy',
        q: 'q',
        underscore: 'underscore'
        //mocha and chai for testing
    }
});

require(['jquery', 'mustache', 'sammy', 'q', 'underscore'], 
       function($, Mustache, Sammy, Q, _) {
            var apiUrl = 'http://crowd-chat.herokuapp.com/posts';
            var message = $('#message');
            var sendButton = $('#send-post-button');
            var loginButton = $('#login-button');
            var currentUser;
                   
            loginButton.on('click', function (ev) {
                currentUser = $('#username').val();
                $('#login-panel').css('display', 'none');
                $('#chat-box').css('display', 'block');
                $('#logged-user').text(currentUser + ':');
            });
           
            sendButton.on('click', function (ev) {
                $.ajax({
                    url: apiUrl,
                    type: 'POST',
                    data: {
                        user: currentUser,
                        text: message.val()
                    },
                    success: function () {
                        console.log('Message sent!');
                    }
                });
                
                message.val('');
            });

            var app = Sammy('#main', function () {
                this.get('#/', function() {
                    setInterval(function () {
                        $.ajax({
                            url: apiUrl,
                            type: 'GET',
                            success: function (posts) {
                                var maxPostsCount = 20;
                                var postsToShow = _.last(posts, maxPostsCount);
                                var postTemplate = $('#post-template').html();
                                var renderedPost = '';
                                var currentPosts = '';
                                
                                Mustache.parse(postTemplate);

                                _.each(postsToShow, function (post) {
                                    renderedPost = Mustache.render(postTemplate, 
                                                                   {user: post.by, text: post.text});

                                    currentPosts += renderedPost;
                                });

                                $('#chat-posts').html(currentPosts);
                            }
                        })
                    }, 1000);
                });
            });
           
            app.run('#/');
       });





























