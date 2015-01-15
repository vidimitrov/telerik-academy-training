window.onload = function () {
    var extendedConsole = (function () {
        function writeLine (input) {
            console.log(input.toString());
        }
        
        function formatLine (formatString) {
            var count = arguments.length;
            
            for (var i = 1; i < count; i++) {
                formatString = formatString.split('{' + (i - 1) + '}').join(arguments[i]);
            }
            
            console.log(formatString.toString());
        }
        
        function writeWarning (formatString) {
            var count = arguments.length;
            
            for (var i = 1; i < count; i++) {
                formatString = formatString.split('{' + (i - 1) + '}').join(arguments[i]);
            }
            
            console.error(formatString);
        }
        
        function writeError (formatString) {
            var count = arguments.length;
            
            for (var i = 1; i < count; i++) {
                formatString = formatString.split('{' + (i - 1) + '}').join(arguments[i]);
            }
            
            console.warn(formatString);
        }
        
        return {
            writeLine: writeLine,
            formatLine: formatLine,
            writeWarning: writeWarning,
            writeError: writeError
        }
    })();
    
    extendedConsole.writeLine('Helloo');
    extendedConsole.formatLine('Helloo, my name is {0}. And I\'m {1} years old.', 'Pesho', 21);
    extendedConsole.writeWarning('Warning: {0}, on line {1}', 'Something wrong happened!', 31);
    extendedConsole.writeWarning('Warning: Some warning without format');
    extendedConsole.writeError('Error: {0}, on line {1}', 'Pay attention here, you can full the stack!', 31);
    extendedConsole.writeError('Error: Some error without format');
}