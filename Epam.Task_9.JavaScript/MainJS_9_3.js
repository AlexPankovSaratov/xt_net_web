// var buttonAllRight = document.getElementById("AllRight");
// buttonAllRight.onclick = function AllRight() {
//     var select1 = document.getElementById("select1");
//     var select2 = document.getElementById("select2");
    // var allElements = select1.childNodes;
    // for (var index = allElements.length-1; index != 0; index--) {
    //     select2.appendChild(allElements[index]);
    // }
//     console.log(this.id);
// }
// var buttonAllLeft = document.getElementById("AllLeft");
// buttonAllLeft.onclick = function AllLeft() {
//     var select1 = document.getElementById("select1");
//     var select2 = document.getElementById("select2");
    // var allElements = select2.childNodes;
    // for (var index = allElements.length-1; index != 0; index--) {
    //     select1.appendChild(allElements[index]);
    // }
//     console.log(this.id);
// }
// var buttonRight = document.getElementById("Right");
// buttonRight.onclick = function Right() {
//     console.log("test");
//     var select1 = document.getElementById("select1");
//     var select2 = document.getElementById("select2");
    // while (select1.options.selectedIndex > -1) {
    //     var selectedIndex = select1.options.selectedIndex;
    //     select2.appendChild(select1[selectedIndex]);
    // }
//     console.log(this.id);
// }
// var buttonLeft = document.getElementById("Left");
// buttonLeft.onclick = function Left() {
//     var select1 = document.getElementById("select1");
//     var select2 = document.getElementById("select2");
    // while (select2.options.selectedIndex > -1) {
    //     var selectedIndex = select2.options.selectedIndex;
    //     select1.appendChild(select2[selectedIndex]);
    // }
//     console.log(this.id);
// }


var buttonAll = document.getElementsByClassName("button");
for (index = 0; index < buttonAll.length; index++) {
    var id = buttonAll[index].id
    var button = document.getElementById(id);
    button.onclick = function MoveOptions() {
    var select1 = document.getElementById("select1");
    var select2 = document.getElementById("select2");
    switch (this.id) {
        case "Left":
            while (select2.options.selectedIndex > -1) {
            var selectedIndex = select2.options.selectedIndex;
            select1.appendChild(select2[selectedIndex]);
            }
            break;
        case "Right":
            while (select1.options.selectedIndex > -1) {
            var selectedIndex = select1.options.selectedIndex;
            select2.appendChild(select1[selectedIndex]);
            }
            break;
        case "AllRight":
            var allElements = select1.childNodes;
            for (var index = allElements.length-1; index != 0; index--) {
            select2.appendChild(allElements[index]);
            }
            break;
        case "AllLeft":
            var allElements = select2.childNodes;
            for (var index = allElements.length-1; index != 0; index--) {
            select1.appendChild(allElements[index]);
            }
            break;
        default:
            break;
    }
    }
}
