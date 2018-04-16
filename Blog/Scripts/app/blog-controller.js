angular.module("BlogApp", [])
.controller("BlogController", function ($scope, $http) {
    $scope.article = {
        title: '',
        body: ''
    }

    $scope.articleList = [];

    fetchArticle = function () {
        $http.get('api/article')
            .then(function (resp) {
                angular.copy(resp.data, $scope.articleList);
            }, function (err) {
                console.log(err);
            });
    }

    $scope.init = function () {
        fetchArticle();
    }();


    $scope.save = function () {
        var article = {};
        angular.copy($scope.article, article);

        $http.post('api/Article/NewArticle', article)
            .then(function (resp) {
                fetchArticle();
            }, function (err) {
                console.log(err);
            });
    }
});