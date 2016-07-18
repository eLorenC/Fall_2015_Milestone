// JavaScript source code
// Dynamic Positioning for navbar on Default.aspx.

function posLock() {
    var nav = document.getElementById("nav"); 
    var homeDivTop = document.getElementById("hdTop"); 
    var navHeight = document.getElementById("nav").offsetHeight; 
    var homeDivHeight = document.getElementById("hdTop").offsetHeight; 
    var homeHeight = homeDivHeight - navHeight;
    var homeDivBottom = document.getElementById("hdBottom"); 

    if (window.pageYOffset > homeHeight) {
        nav.style.position = "fixed";
        nav.style.top = "0";
    }
    else {
        nav.style.position = "relative";
        nav.style.top = "";
        homeDivBottom.style.margin = "0 0 0 0";
    }
}

window.onscroll = posLock;
