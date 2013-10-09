/// <reference path="../libs/jquery-1.10.1.js" />
var GameEndsHandler = Class.create({
    init: function () {
        this.popUpMenu = $("#popup-menu");
    },

    openMenu: function (scoreResult) {
        if (scoreResult < 100) {
            $("#gameover").html("GAME OVER").css("color", "#606060");
        } else {
            $("#gameover").html("YOU WIN").css("color", "#81B1E8");
        }

        $("#score").html(scoreResult + "% ");

        this.popUpMenu.bPopup({
            easing: 'easeOutBack', //uses jQuery easing plugin
            speed: 450,
            transition: 'slideDown'
        });

        //this.popUpMenu.slideDown(2000).animate({
        //    top: "+=200"
        //}, 2000).dequeue();

        //var width = $(window).width() / 4;
        //this.popUpMenu.css({
        //    position: "absolute",
        //    left: width,
        //    top: 0,
        //    opacity: 0.9
        //});
    },

    closeMenu: function () {
        this.popUpMenu.fadeOut(500);
    }
});