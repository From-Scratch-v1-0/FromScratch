function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}


window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i]; if (openDropdown.classList.contains('show')) { openDropdown.classList.remove('show'); }
        }
    }
}
////////////////////////////////////////
var modal = document.getElementById(" myModal");


var btn = document.getElementById("myBtn");


var span = document.getElementsByClassName("close")[0];


btn.onclick = function () {
    modal.style.display = "block";
}


span.onclick = function () {
    modal.style.display = "none";
}


window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
for (i = new Date().getFullYear(); i > 1900; i--) {
    $('#yearpicker').append($('<option />').val(i).html(i));
}
//////////////////////////////////////////////////////////////
var modal2 = document.getElementById("myModal2");


var btn2 = document.getElementById("myBtn2");


var span2 = document.getElementsByClassName("close2")[0];


btn2.onclick = function () {
    modal2.style.display = "block";
}

span2.onclick = function () {
    modal2.style.display = "none";
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal2.style.display = "none";
    }
}

