app.controller("articleviewcontroller", function ($scope, $http, $location, $state) {
    $scope.article = {
        title: '',
        body: '',
        Comments: ''
    };

    var articleId = $state.params.articleId;

    loadData = function () {
        $http.get('api/article/details/' + articleId)
        .then((resp) => {
            angular.copy(resp.data, $scope.article);
            console.log($scope.article);
        })
        .catch((err) => {
            console.log(err);
        })
    }

    loadData();

    $scope.addComment = function () {
        console.log($scope.Comment);
        $http.post('api/comment/addcomment/' + articleId, $scope.Comment)
            .then((resp) => {
                loadData();

                $scope.Comment = {};
            }, (err) => {
                console.log(err);
            })
    }
});