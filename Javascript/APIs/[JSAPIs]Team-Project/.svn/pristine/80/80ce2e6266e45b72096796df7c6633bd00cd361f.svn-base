/// <reference path="Field.js" />
var Score = Class.create({
    init: function () {

    },
    getScore: function (field) {
        return CalculateScore(field);
    }
})

function CalculateScore(field) {
    var result = 0;
    var maxScore = parseInt(field.rows * field.cols);

    for (var row = 0; row < field.rows; row++) {
        for (var col = 0; col < field.cols; col++) {

            if (field.matrix[row][col].flagged && field.matrix[row][col].type === "mine") {
                result++;
            }

            if (field.matrix[row][col].opened && field.matrix[row][col].type === "number") {
                result++;
            }
        }
    }

    result = GetPercentage(maxScore, result);
    return result;
}

function GetPercentage(whole, part) {
    return (parseInt((part / whole)*100));
}