app.controller("formcontroller", function ($scope, $http, $location, $state) {
    $scope.Article = {
        title: '',
        body: ''
    }

    var willBeUpdated = false;

    var url = 'api/Article/';

    if (!$state.params.articleId) {
        url = 'api/Article/NewArticle';
    }
    else {
        $http.get('api/Article/' + $state.params.articleId)
            .then((resp) => {
                angular.copy(resp.data, $scope.Article);
                willBeUpdated = true;

            },
            (err) => {
                console.log(err);
            });
    }

    $scope.save = function () {
        var article = {};

        angular.copy($scope.Article, article);
        
        if (willBeUpdated) {
            $http.put(url, article)
                .then(function (resp) {
                    console.log(resp.data);
                    $state.go('home');
                }, function (err) {
                    console.log(err);
                });
        }
        else {
            $http.post(url, article)
                .then(function (resp) {
                    console.log(resp.data);
                    $state.go('home');
                }, function (err) {
                    console.log(err);
                });
        }
    }


});