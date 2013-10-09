function wrapping() {
    "use strict";

    var addScroll = false;
    if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
             (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    var positionX = 0; // horizontal coordinate
    var positionY = 0; // vertical coordinate
    document.onmousemove = mouseMove;

    var navAppName = navigator.appName;
    if (navAppName === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(evn) {
        if (navAppName === "Netscape") {
            positionX = evn.pageX - 5;
            positionY = evn.pageY;
        }
        else {
            positionX = event.x - 5; positionY = event.y;
        }

        if (navAppName === "Netscape") {
            if (document.layers.ToolTip.visible === 'show') {
                popTip();
            }
        }
        else {
            if (document.all.ToolTip.style.visible === 'visible') {
                popTip();
            }
        }
    }

    var theLayer;
    function popTip() {
        if (navAppName === "Netscape") {
            theLayer = document.layers.ToolTip;

            if ((positionX + 120) > window.innerWidth) {
                positionX = window.innerWidth - 150;
            }

            theLayer.left = positionX + 10;
            theLayer.top = positionY + 15;
            theLayer.visible = 'show';
        }
        else {
            theLayer = document.all.ToolTip;

            if (theLayer) {
                positionX = event.x - 5; positionY = event.y;

                if (addScroll) {
                    positionX = positionX + document.body.scrollLeft;
                    positionY = positionY + document.body.scrollTop;
                }

                if ((positionX + 120) > document.body.clientWidth) {
                    positionX = positionX - 150;
                }

                theLayer.style.pixelLeft = positionX + 10;
                theLayer.style.pixelTop = positionY + 15;
                theLayer.style.visible = 'visible';
            } 
        }
    }

    function hideTip() {
        if (navAppName === "Netscape") {
            document.layers.ToolTip.visible = 'hide';
        }
        else {
            document.all.ToolTip.style.visible = 'hidden';
        }
    }

    function hideMenu1() {
        if (navAppName === "Netscape") {
            document.layers.menu1.visible = 'hide';
        }
        else {
            document.all.menu1.style.visible = 'hidden';
        }
    }

    function showMenu1() {
        if (navAppName === "Netscape") {
            theLayer = document.layers.menu1;
            theLayer.visible = 'show';
        }
        else {
            theLayer = document.all.menu1;
            theLayer.style.visible = 'visible';
        }
    }

    function hideMenu2() {
        if (navAppName === "Netscape") {
            document.layers.menu2.visible = 'hide';
        }
        else {
            document.all.menu2.style.visible = 'hidden';
        }
    }

    function showMenu2() {
        if (navAppName === "Netscape") {
            theLayer = document.layers.menu2;
            theLayer.visible = 'show';
        }
        else {
            theLayer = document.all.menu2;
            theLayer.style.visible = 'visible';
        }
    }
}