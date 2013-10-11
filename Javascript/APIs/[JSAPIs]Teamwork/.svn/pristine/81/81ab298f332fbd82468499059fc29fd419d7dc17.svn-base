/// <reference path="../libs/classical-oop.js" />
/// <reference path="Cell.js" />
var NumberCell = Class.create({
    init: function (row, col, value) {
        this._super = new Cell(arguments);
        this._super.init.apply(this, arguments);
        this.type = "number";
        this.value = value;
    }
});

NumberCell.inherit(Cell);