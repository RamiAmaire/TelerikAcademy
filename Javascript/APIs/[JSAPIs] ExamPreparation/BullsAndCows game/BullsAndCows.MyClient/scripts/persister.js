/// <reference path="utils/class.js" />
/// <reference path="utils/jquery-1.9.1.min.js" />
/// <reference path="httpRequester.js" />
var persisters = (function () {
    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.nickname);
        localStorage.setItem("sessionKey", userData.sessionKey);
    }

    function clearUserData() {
        localStorage.removeItem("sessionKey");
        localStorage.removeItem("nickname");
    }

    var MainPersister = Class.create({
        init: function (url) {
            this.rootUrl = url;
            this.user = new UserPersister(this.rootUrl);
            this.game = new GamePersister(this.rootUrl);
            this.clearUserData = clearUserData;
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "/user";
        },

        login: function (user, success, error) {
            var url = this.rootUrl + "/login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.authCode).toString() 
            };

            httpRequester.postJSON(url, userData, function (data) {
                saveUserData(data);
                success(data);
            }, error);
        },

        register: function (user, success, error) {
            var url = this.rootUrl + "/register";
            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.username + user.authCode).toString()
            }

            httpRequester.postJSON(url, userData, function (data) {
                saveUserData(data);
                success(data);
            }, error);
        },

        logout: function (success, error) {
            var url = this.rootUrl + "/logout/" + localStorage["sessionKey"];
            httpRequester.getJSON(url, function (data) {
                clearUserData(data);
                success(data);
            }, error);
        },

        scores: function (success, error) {
            var url = this.rootUrl + "/scores/" + localStorage["sessionKey"];
            httpRequester.getJSON(url, function (data) {
                success(data);
            }, error);
        },

        isUserLogged: function () {
            if (localStorage["sessionKey"] != null) {
                return true;
            }

            return false;
        }
    });

    var GamePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "/game";
        },
        
        create: function (game, success, error) {
            var url = this.rootUrl + "/create/" + localStorage["sessionKey"];
            var gameData = {
                number: game.number,
                title: game.title,
            };
            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.title + game.password).toString();
            }
            httpRequester.postJSON(url, gameData, success, error);
        },

        join: function (game, success, error) {
            var url = this.rootUrl + "/join/" + localStorage["sessionKey"];
            var gameData = {
                gameId: game.id,
                number: game.number,
            };
            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.title + game.password).toString();
            }
            httpRequester.postJSON(url, gameData, success, error);
        },

        start: function (gameId, success, error) {
            var url = this.rootUrl + "/" + gameId + "/start/" + localStorage["sessionKey"];
            httpRequester.getJSON(url, success, error);
        },

        state: function (gameId, success, error) {
            var url = this.rootUrl + "/" + gameId + "/state/" + localStorage["sessionKey"];
            httpRequester.getJSON(url, success, error);
        },

        open: function (success, error) {
            var url = this.rootUrl + "/open/" + localStorage["sessionKey"];
            httpRequester.getJSON(url, success, error);
        },

        active: function (success, error) {
            var url = this.rootUrl + "/my-active/" + localStorage["sessionKey"];
            httpRequester.getJSON(url, success, error);
        },
    });

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }
}());