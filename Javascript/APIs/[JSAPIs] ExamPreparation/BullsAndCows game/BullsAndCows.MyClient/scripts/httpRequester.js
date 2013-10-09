/// <reference path="utils/jquery-1.9.1.min.js" />
var httpRequester = (function () {
    function getJSON(url, success, error) {
        $.ajax({
            url: url,
            type: "GET",
            timout: 5000,
            contentType: "application/json",
            success: success,
            error: error
        });
    };

    function postJSON(url, data, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            timout: 5000,
            contentType: "application/json",
            success: success,
            error: error
        });
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON
    }
}())