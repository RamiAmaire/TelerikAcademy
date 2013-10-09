/// <reference path="utils/class.js" />
/// <reference path="utils/jquery-1.9.1.min.js" />
/// <reference path="httpRequester.js" />
/// <reference path="persister.js" />
var controllers = (function () {
    var Controller = Class.create({
        init: function (url) {
            this.persister = persisters.get(url);
        },

        loadUI: function (selector) {
            var isUserLogged = this.persister.user.isUserLogged();
            this.attachEvents(selector);

            if (isUserLogged) {
                this.loadMainUI(selector);
            }
            else {
                this.loadLoginFormUI(selector);
            }
        },

        loadLoginFormUI: function (selector) {
            $(selector).find("#login-holder").remove();
            $(selector).find("#register-holder").remove();
            $(selector).find("#main-holder").remove();
            var loginHolder = $("<div></div>").attr("id", "login-holder").append(
                '<form id="login-form">' +
                    '<label for="login-username">Username: </label>' +
                    '<input type="text" id="login-username"/>' +
                    '<label for="login-password">Password: </label>' +
                    '<input type="text" id="login-password"/>' +
                    '<button id="btn-login">Login</button>' +
                    "<br></br>" +
                    '<a href="#" id="anchor-register">Register here</a>' +
                '</form>').appendTo(selector);
        },

        loadRegisterFormUI: function (selector) {
            $(selector).find("#register-holder").remove();
            $(selector).find("#login-holder").remove();
            var registerHolder = $("<div></div>").attr("id", "register-holder").append(
                '<form id="register-form">' +
                    '<label for="register-username">Username: </label>' +
                    '<input type="text" id="register-username"/>' +
                    '<label for="register-nickname">Nickname: </label>' +
                    '<input type="text" id="register-nickname"/>' +
                    '<label for="register-password">Password: </label>' +
                    '<input type="text" id="register-password"/>' +
                    '<button id="btn-register">Register</button>' +
                '</form>').appendTo(selector);
        },

        loadLogoutFormUI: function (parent) {
            $(parent).find("#logout-holder").remove();
            var logoutHolder = $("<div></div>").attr("id", "logout-holder").append(
                $("<span></span").html(localStorage['nickname']));
            logoutHolder.append($('<button id="btn-logout">Logout</button>')).appendTo(parent);
        },

        loadCreateGameUI: function (parent) {
            $(parent).find("#create-game-holder").remove();
            var createGameHolder = $("<div></div>").attr("id", "create-game-holder").append(
                '<h3>Create game</h3>' +
                '<form id="create-game-form">' +
                    '<label for="create-game-title">Title: </label>' +
                    '<input type="text" id="create-game-title"/>' +
                    '<label for="create-game-number">Number: </label>' +
                    '<input type="text" id="create-game-number"/>' +
                    '<label for="create-game-password">Password: </label>' +
                    '<input type="text" id="create-game-password"/>' +
                    '<button id="btn-create-game">Create</button>' +
                '</form>').appendTo(parent);
        },

        loadJoinGameUI: function (parent) {
            $(parent).find("#join-game-holder").remove();
            var joinGameHolder = $("<div></div>").attr("id", "join-game-holder").append(
                '<button id="btn-exit-join-game">X</button>' +
                '<form id="join-game-form">' +
                    '<label for="join-game-number">Number: </label>' +
                    '<input type="text" id="join-game-number"/>' +
                    '<label for="join-game-password">Password: </label>' +
                    '<input type="text" id="join-game-password"/>' +
                    '<button id="btn-join-game">Join</button>' +
                '</form>').appendTo(parent);
        },

        loadOpenGamesUI: function (parent) {
            $(parent).find("#open-games-holder").remove();
            var openGamesHolder = document.createElement("div");
            openGamesHolder.id = "open-games-holder";
            $("<h3>Open games</h3>").appendTo(openGamesHolder);

            this.persister.game.open(function (games) {
                var openGamesList = document.createElement("ul");
                for (var i = 0; i < games.length; i++) {
                    var li = document.createElement("li");
                    var anchor = $("<a href='#'></a>").attr("id", "open-game" + i).
                        html(games[i].title).data("game-id", games[i].id).
                        data("title", games[i].title).appendTo(li);
                    $(li).appendTo(openGamesList);
                }

                $(openGamesList).appendTo(openGamesHolder);
                $(openGamesHolder).appendTo(parent);
            }, function () {
                alert("Couldn't find any open games.")
            });
        },

        loadActiveGamesUI: function (parent) {
            $(parent).find("#active-games-holder").remove();
            var activeGamesHolder = document.createElement("div");
            activeGamesHolder.id = "active-games-holder";
            $("<h3>Active games</h3>").appendTo(activeGamesHolder);
            var self = this;

            this.persister.game.active(function (games) {
                var activeGamesList = document.createElement("ul");
                for (var i = 0; i < games.length; i++) {
                    var li = document.createElement("li");
                    var anchor = $("<a href='#'></a>").attr("id", "active-game" + i).
                        html(games[i].title).data("game-id", games[i].id).
                        data("title", games[i].title).appendTo(li);
                    $(li).appendTo(activeGamesList);
                }

                $(activeGamesList).appendTo(activeGamesHolder);
                $(activeGamesHolder).appendTo(parent);
                self.loadOpenGamesUI(parent);
            }, function () {
                alert("Couldn't find any active games.")
            });
        },

        loadMainUI: function (selector) {
            $(selector).find("#login-holder").remove();
            $(selector).find("#register-holder").remove();
            var mainHolder = document.createElement("div");
            mainHolder.id = "main-holder";
            this.loadLogoutFormUI(mainHolder);
            this.loadCreateGameUI(mainHolder);
            this.loadActiveGamesUI(mainHolder);
            $(mainHolder).appendTo(selector);
        },

        attachEvents: function (selector) {
            var self = this;
            var wrapper = $(selector);
            wrapper.on("click", "#anchor-register", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                self.loadRegisterFormUI(selector);
                return false;
            });

            wrapper.on("click", "#btn-login", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                var user = {
                    username: $("#login-username").val(),
                    authCode: $("#login-password").val()
                };
                self.persister.user.login(user, loginSuccess, loginError)
                function loginSuccess() {
                    self.loadMainUI(selector);
                };
                function loginError() {
                    alert("Couldn't login");
                }
                return false;
            });

            wrapper.on("click", "#btn-register", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                var user = {
                    username: $("#register-username").val(),
                    nickname: $("#register-nickname").val(),
                    authCode: $("#register-password").val()
                }
                self.persister.user.register(user, registerSuccess, registerError)
                function registerSuccess() {
                    self.loadMainUI(selector);
                };
                function registerError() {
                    alert("Couldn't register");
                }
                return false;
            });

            wrapper.on("click", "#btn-logout", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                self.persister.clearUserData();
                self.loadLoginFormUI(selector);
                return false;
            });

            wrapper.on("click", "#open-games-holder ul a", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                self.loadJoinGameUI(ev.target.parentNode);
                return false;
            });

            wrapper.on("click", "#btn-join-game", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                var gameInfo = {
                    number: $("#join-game-number").val(),
                    id: $(ev.target.parentNode.parentNode.previousSibling).data("game-id"),
                    title: $(ev.target.parentNode.parentNode.previousSibling).data("title"),
                };
                var password = $("#join-game-password").val();
                if (password) {
                    gameInfo.password = password;
                }
                
                self.persister.game.join(gameInfo, function (data) {
                    self.loadActiveGamesUI("#main-holder");
                }, function () {
                    alert("Couldn't join game");
                });
                return false;
            });

            wrapper.on("click", "#btn-exit-join-game", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                $(ev.target.parentNode.parentNode).find("#join-game-holder").remove();
                return false;
            });

            wrapper.on("click", "#btn-create-game", function (ev) {
                ev.preventDefault();
                ev.stopPropagation();
                var gameInfo = {
                    title: $("#create-game-title").val(),
                    number: $("#create-game-number").val(),
                };
                var password = $("#create-game-password").val();
                if (password) {
                    gameInfo.password = password;
                }

                self.persister.game.create(gameInfo, function (data) {
                    alert("Game created.");
                }, function () {
                    alert("Couldn't create game.");
                });
                return false;
            });
        }
    });

    return {
        get: function (url) {
            return new Controller(url);
        }
    }
}());