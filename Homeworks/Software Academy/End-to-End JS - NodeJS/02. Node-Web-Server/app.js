// Create file upload web site with NodeJS. You should 
// have the option to upload a file and be given an 
// unique URL for its download. Use GUID.

var http = require('http');
var fs = require('fs');
var formidable = require('formidable');
var util = require('util');

var PORT = 8080;

http.createServer(function(req, res) {
  if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
    // parse a file upload
    var form = new formidable.IncomingForm();

    form.parse(req, function(err, fields, files) {
      res.writeHead(200, {'content-type': 'text/html'});
      res.end('<h3>Download your upload:</h3><br><a href="' + files.upload.path + '">' + files.upload.name + '</a>');
    });

    return;
  }

  // show a file upload form
  res.writeHead(200, {'content-type': 'text/html'});
  res.end(
        '<form action="/upload" enctype="multipart/form-data" method="post">'+
        '<input type="text" name="title"><br>'+
        '<input type="file" name="upload" multiple="multiple"><br>'+
        '<input type="submit" value="Upload">'+
        '</form>'
  );
}).listen(PORT, function () {
    console.log('Server listening on port ', PORT);
});