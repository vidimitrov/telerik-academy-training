var Http = (function() {
    var _httpRequest;
    
    function getJSON(config) {
        var _httpRequest;

        if (window.XMLHttpRequest) {
            _httpRequest = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            try{
                _httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (e) {
                _httpRequest = new ActiveXObject("Microsoft.XMLHTTP"); 
            }
        }
        
        var deffered = Q.defer();
        var method = 'GET';
        
        _httpRequest.open(method, config.url, true);
        
        if (config.contentType) {
            _httpRequest.setRequestHeader('Content-type', config.contentType);
        }
        
        _httpRequest.send(null);

        _httpRequest.onreadystatechange = function () {
            if (_httpRequest.readyState === 4) {
                if (_httpRequest.status === 200) {
                    config.success(method);
                    deffered.resolve(_httpRequest.responseText);
                }
                else {
                    config.error(method);
                    deffered.reject(new Error("Status code was " + _httpRequest.status));
                }
            }
        }
        
        return deffered.promise;
    }
    
    function postJSON(config) {
        if (window.XMLHttpRequest) {
            _httpRequest = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            try{
                _httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (e) {
                _httpRequest = new ActiveXObject("Microsoft.XMLHTTP"); 
            }
        }
        
        var deffered = Q.defer();
        var method = 'POST';
        
        _httpRequest.open(method, config.url, true);
        
        if (config.contentType) {
            _httpRequest.setRequestHeader('Content-type', config.contentType);
        }

        _httpRequest.onreadystatechange = function () {
            if (_httpRequest.readyState === 4) {
                if (parseInt(_httpRequest.status / 100) === 2) {
                    config.success(method);
                    deffered.resolve(_httpRequest.responseText);
                }
                else {
                    config.error(method);
                    deffered.reject(new Error("Status code was " + _httpRequest.status));
                }
            }
        }
        
        _httpRequest.send(JSON.stringify(config.params));
        
        return deffered.promise;
    }
    
    return {
        getJSON: getJSON,
        postJSON: postJSON
    } 
}());