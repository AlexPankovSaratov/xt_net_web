function charRemoved(Mainstr) {
var test1 = "";
var result = Mainstr;
var ignore = ["?", "!", ":", ";" ,",", ".", " ", "\t", "\r"];
var repeatingСharacters = [];
var tempString = "";
var MainstrArr = Mainstr.split('');
for (let index = 0; index < MainstrArr.length; index++) {
    var IsIgnoreElement = false;
    var addLastElement = false;
    ignore.forEach(ignoreElement => {
        if (MainstrArr[index] == ignoreElement) {
            IsIgnoreElement = true;
        }
        else if(index == MainstrArr.length-1){
            IsIgnoreElement = true;
            addLastElement = true;    
        }
    });
    if (addLastElement) {
        tempString += MainstrArr[index];
    }
    if (IsIgnoreElement) {
        var tempArr = tempString.split('');
        tempArr.forEach(element1 => {
            var countChar = 0;
            tempArr.forEach(element2 => {
                if (element1 == element2) {
                    countChar++;
                }
            });
            if (countChar > 1 && repeatingСharacters.indexOf(element1) < 0) {
                  repeatingСharacters[repeatingСharacters.length] = element1;
              }
          });
        tempString = "";
    }
    else {
        tempString += MainstrArr[index];
    }
}
repeatingСharacters.forEach(element => {
    result = removeCharInStr(result,element);
});
return result;
}
function removeCharInStr(String,Char) {
    result = String.replace(Char,"",)
    if (result.indexOf(Char) > -1) {
        result = removeCharInStr(result,Char);
    }
    return result;
}