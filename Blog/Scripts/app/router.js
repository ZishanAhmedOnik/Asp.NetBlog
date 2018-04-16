var app = angular.module("BlogApp", ["ngResource", "ui.router"]);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('home', {
            url: '/',
            templateUrl: "articlelist",
            controller: "listcontroller"
        })
        .state('form', {
            url: '/form',
            templateUrl: "articleform",
            controller: "formcontroller"
        })
        .state('editform', {
            url: '/form/:articleId',
            templateUrl: "articleform",
            controller: "formcontroller"
        })
        .state('view', {
            url: '/view/:articleId',
            templateUrl: 'articleview',
            controller: 'articleviewcontroller'
        })
});
