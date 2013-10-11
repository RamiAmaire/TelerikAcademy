/// <reference path="../libs/classical-oop.js" />
var Timer = Class.create({
    init: function (time) {
        this.hours = 0;
        this.minutes = 0;
        this.seconds = 0;
        this.visualization = $("#Time");
        this.interval;
        this.runs = false;
    },
    stop: function () {
        var that = this;
        clearInterval(that.interval);
        that.printTime();
        this.runs = false;
    },

    start: function () {
        if (this.runs == false) {
            this.runs = true;
            var that = this;
            that.interval = setInterval(function () {
                that.seconds += 1;
                if (that.seconds === 60) {
                    that.seconds = 0;
                    that.minutes += 1;
                }

                if (that.minutes === 60) {
                    that.minutes = 0;
                    that.hours += 1;
                }

                that.printTime();

            }, 1000);
        }
    },

    printTime: function () {
        var secs;
        if (this.seconds < 10) {
            secs = "0" + this.seconds;
        }
        else {
            secs = this.seconds;
        }

        var mins;
        if (this.minutes < 10) {
            mins = "0" + this.minutes;
        }
        else {
            mins = this.minutes;
        }

        var hours;
        if (this.hours < 10) {
            hours = "0" + this.hours;
        }
        else {
            hours = this.hours;
        }

        this.visualization.html(hours + ":" + mins + ":" + secs);
    }
});