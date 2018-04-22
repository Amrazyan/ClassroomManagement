



var a = document.getElementById("quest");
var b = document.getElementById("por");
a.addEventListener("click", openn);

function openn() {
    b.style.width = "400px";
    a.style.webkitTransform = 'rotate(180deg)';
    a.style.transition = '0.2s';
    a.removeEventListener("click", openn);
    a.addEventListener("click",clos)
}
function clos() {
    b.style.width = "0px";
    a.style.webkitTransform = 'rotate(0deg)';
    a.removeEventListener("click", clos);
    a.addEventListener("click", openn);
}


