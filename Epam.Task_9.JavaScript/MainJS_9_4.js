var Pause = false;
(function startTimer() {
    var Timer = document.getElementById("Timer");
    var time = Timer.innerHTML;
    if (time == 0) {
        switch (document.title) {
            case "Task 9.4 First Page":
                document.location.href = "Task 9.4 SecondPage.html";
                break;
            case "Task 9.4 Second Page":
                document.location.href = "Task 9.4 ThirdPage.html";
                break;
            case "Task 9.4 Third Page":
                return;
            default:
                break;
        }
        return;
    }
    else{
        if (!Pause) {
            Timer.innerHTML = time - 1;
        }
    }
    setTimeout(startTimer, 1000);
}());
var ButtonGoBack = document.getElementById("GoBack");
ButtonGoBack.onclick = function GoBack() {
    switch (document.title) {
        case "Task 9.4 Second Page":
            document.location.href = "Task 9.4 FirstPage.html";
            break;
        case "Task 9.4 Third Page":
            document.location.href = "Task 9.4 SecondPage.html";
            break;
        default:
            break;
    }
}
var ButtonPauseTimer = document.getElementById("PauseTimer");
ButtonPauseTimer.onclick = function PauseTimer() {
    Pause = !Pause;
}
var ButtonRePlayTimer = document.getElementById("RePlayTimer");
ButtonRePlayTimer.onclick = function RePlayTimer() {
    if(document.title == "Task 9.4 Third Page"){
        document.location.href = "Task 9.4 ThirdPage.html";
        // просто вызов startTimer(); не особо понял почему не работае =(
    }  
    Pause = false;
    Timer.innerHTML = 5
}

