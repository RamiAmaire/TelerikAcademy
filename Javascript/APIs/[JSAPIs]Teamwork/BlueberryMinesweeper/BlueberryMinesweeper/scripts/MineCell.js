/// <reference path="Cell.js" />
/// <reference path="../libs/classical-oop.js" />
var MineCell = Class.create({
    init: function (row, col) {
        this._super = new Cell(arguments);
        this._super.init.apply(this, arguments);
        this.type = "mine";
    }
});

MineCell.inherit(Cell);