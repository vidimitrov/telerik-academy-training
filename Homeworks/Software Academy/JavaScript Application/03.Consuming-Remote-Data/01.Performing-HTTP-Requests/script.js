window.onload = function() {
    var requestsUrl = 'http://crowd-chat.herokuapp.com/posts',//'https://api.github.com/users/ivaylokenov/repos',
        requestContentType = 'application/json';
    
    Http.postJSON({
        url: requestsUrl,
        contentType: requestContentType,
        params: {
            user: 'Pesho proverqvashtiq',
            text: 'Refreshni i naspami... :D'
        },
        success: onSuccess,
        error: onFailure
    })
    .then(function(isSubmitted) {
        if (isSubmitted) {
            console.log('Message submitted!');
        }
        else {
            console.log('Message fails to submit');
        }
    }, function(error) {
        console.log('Error: ', error);
    });
    
    Http.getJSON({
        url: requestsUrl,
        contentType: requestContentType,
        success: onSuccess,
        error: onFailure
    })
    .then(function(response){
        console.log('Response: ', response);
    }, function(error) {
        console.log('Error: ', error);
    });
    
    function onSuccess(method) {
        console.log(method + ' request successed!');
    }
    
    function onFailure(method) {
        console.log(method + ' request failed!');
    }
};