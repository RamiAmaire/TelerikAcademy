
//use this to shim original method so field doesn't display in page
function generateDOMElements() {
    for (var row = 0; row < this.field.rows; row++) {
        var line = $("<div></div>");
        for (var col = 0; col < this.field.cols; col++) {
            var cell = $("<button>C</button>").data("row", row);
            cell.data("col", col);
            cell.attr("class", "Cell");
            line.append(cell);

            this.domMatrix[row][col] = cell;
        }

    }
};