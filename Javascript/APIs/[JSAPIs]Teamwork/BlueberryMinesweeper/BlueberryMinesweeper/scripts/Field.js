﻿/// <reference path="../libs/classical-oop.js" />
/// <reference path="MineCell.js" />
/// <reference path="NumberCell.js" />
var Field = Class.create({
    init: function (rows, cols, minesCount) {
        this.rows = rows;
        this.cols = cols;
        this.minesCount = minesCount;
        this.matrix = new Array(rows);
        for (var i = 0; i < rows; i += 1) {
            this.matrix[i] = new Array(cols);
        }

        this.gameEnds = false;

    },

    generate: function () {
        this._generateMines();
        this._generateNumbers();
        this._generateMinesCounter();
    },

    clickCell: function (clickRow, clickCol, clickType) {
        switch (clickType) {
            case "left-mouse":
                return (this._openCell(clickRow, clickCol));
                break;
            case "right-mouse":
                return (this._flagCell(clickRow, clickCol));
                break;
            default:
                alert('You have a strange mouse');

        }
    },

    _flagCell: function (clickRow, clickCol) {
        var cell = this.matrix[clickRow][clickCol];
        if (!cell.opened) {
            if (cell.flagged) {
                cell.flagged = false;
                return {
                    type: "Cell",
                }
            }
            else {
                cell.flagged = true;
                return {
                    type: "Flag",
                }
            }
        }
    },

    _openCell: function (clickRow, clickCol) {
    	var that = this;
    	if (that.gameEnds) {
        	return {
        		type: "dead",
        	}
        }

    	var cell = that.matrix[clickRow][clickCol];
        if (cell.flagged) {
            return {
                type: "Flag"
            }
        }

        if (!cell.opened) {
            cell.opened = true;
            if (cell.type == "number") {
            	return {
            		type: "number",
					value: cell.value
            	}
            }
            else {
            	that.gameEnds = true;
                return {
                	type: "mine"
                }
            }
        }
        else {
        	return {
        		type: "number"
        	}
        }
    },

    draw: function () {
        
        for (var i = 0; i < this.rows; i++) {
            var line = "";
            for (var j = 0; j < this.cols; j++) {
                if (this.matrix[i][j].type == "number") {
                    line += this.matrix[i][j].value + " ";
                }
                else {
                    line += "* ";
                }
            }
            console.log(line);
        }
        
    },

    _generateMinesCounter: function () {
        var count = $("#MineCount");
        count.html(this.minesCount);
    },

    _generateMines: function () {
        // This has to be refactored with good algorithm 
        // for placing mines
        var randomRow;
        var randomCol;
        for (var i = 0; i < this.minesCount; i += 1) {
            randomRow = Math.floor(Math.random() * this.rows);
            randomCol = Math.floor(Math.random() * this.cols);
            
            if (this.matrix[randomRow][randomCol]) {
                i -= 1;
            }
            else {
                this.matrix[randomRow][randomCol] = new MineCell(randomRow, randomCol);
            }
        }
    },

    _generateNumbers: function () {
        var that = this;
        function countNeighborMines(row, col) {
			// top middle cells
            if (row === 0 && col > 0 & col < that.cols - 1) {
                for (var i = row; i <= row + 1; i += 1) {
                    for (var j = col - 1; j <= col + 1; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // bottom middle cells
            else if (row === that.rows - 1 && col > 0 && col < that.cols - 1) {
                for (var i = row - 1; i <= row; i += 1) {
                    for (var j = col - 1; j <= col + 1; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // top left cell
            else if (row === 0 && col === 0) {
                for (var i = row; i <= row + 1; i += 1) {
                    for (var j = col; j <= col + 1; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // top right cell
            else if (row === 0 && col === that.cols - 1) {
                for (var i = row; i <= row + 1; i += 1) {
                    for (var j = col - 1; j <= col; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // left middle cells
            else if (col === 0 && row > 0 && row < that.rows - 1) {
                for (var i = row - 1; i <= row + 1; i += 1) {
                    for (var j = col; j <= col + 1; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // bottom left cell
            else if (col === 0 && row === that.rows - 1) {
                for (var i = row - 1; i <= row; i += 1) {
                    for (var j = col; j <= col + 1; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // bottom right cell
            else if (col === that.cols - 1 && row === that.rows - 1) {
                for (var i = row - 1; i <= row; i += 1) {
                    for (var j = col - 1; j <= col; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // right middle cells
            else if (col === that.cols - 1 && row > 0 && row < that.rows - 1) {
                for (var i = row - 1; i <= row + 1; i += 1) {
                    for (var j = col - 1; j <= col; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            } // middle cells
            else {
                for (var i = row - 1; i <= row + 1; i += 1) {
                    for (var j = col - 1; j <= col + 1; j += 1) {
                        if (that.matrix[i][j].type === "mine") {
                            that.matrix[row][col].value += 1;
                        }
                    }
                }
            }
        }

        // Generating the number cells
        for (var i = 0; i < that.rows; i += 1) {
            for (var j = 0; j < that.cols; j += 1) {
                if (that.matrix[i][j]) {
                    continue;
                }

                that.matrix[i][j] = new NumberCell(i, j, 0);
            }
        }

        // Count the neighbor mines for each number cell
        for (var i = 0; i < that.rows; i += 1) {
            for (var j = 0; j < that.cols; j += 1) {
                if (that.matrix[i][j].type === "number") {
                    countNeighborMines(i, j);
                }
            }
        }
    }
});
