function mathCalculator(str) {
    var arr = str.match(/(^\-)?\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig);
    if(arr == null){ return 0;}
    var result = arr[0]*1;
    for (let index = 0; index < arr.length; index++) {
        switch (arr[index]) {
            case "+": result += arr[index+1] * 1;   
                break;
            case "-": result -= arr[index+1] * 1;
                break;
            case "*": result *= arr[index+1] * 1;
                break;
            case "/": result /= arr[index+1] * 1;
                break;
            default:
                break;
        }
    }
    return result;
}