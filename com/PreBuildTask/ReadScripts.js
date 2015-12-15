var path = require("path"),
    fs = require("fs");
module.exports = function (pathArrays) {
    var parentPath = path.join(__dirname, '../Client');
    var walk = function (path) {
        fs.readdirSync(path).forEach(function (file) {
            var newPath = path + '/' + file;
            var fileStatus = fs.statSync(newPath);
            if (fileStatus.isFile()) {
                if (/(.*)\.(js$)/.test(file)) {
                    pathArrays.push(newPath);
                }
            }
            else if (fileStatus.isDirectory()) {
                walk(newPath);
            }
        });
    };
    var parentWalk = function (parentpath) {
        fs.readdirSync(parentpath).forEach(function (file) {
            var newPath = parentpath + '/' + file;
            var fileStatus = fs.statSync(newPath);
            if (fileStatus.isDirectory()) {
                walk(newPath);
            }
            else if (fileStatus.isDirectory()) {
                parentWalk(newPath);
            }
        });
    };
    parentWalk(parentPath);
}