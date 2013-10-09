function Queue() {
    var that = this;
    that.arr = [];
}

Queue.prototype = {
    constructor: Queue,

    enqueue: function (elem) {
        this.arr.push(elem);
    },

    dequeue: function () {
        var retValue = this.arr[0];
        var newArr = new Array(this.arr.length - 1);
        for (var i = 0; i < newArr.length; i++) {
            newArr[i] = this.arr[i + 1];
        }

        this.arr = newArr;
        return retValue;
    },

    length: function () {
        return this.arr.length;
    },

    contains: function (elem) {
        for (var i = 0; i < this.arr.length; i++) {
            if (this.arr[i] == elem) {
                return true;
            }
        }

        return false;
    }
}