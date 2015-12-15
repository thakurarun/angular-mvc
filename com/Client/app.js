var GetRoot = function () {
  var rootPath = "./Client/";
  return function GetRootPath() {
    return rootPath;
  }
}();