app.controller("listcontroller", function ($scope, $http, $state) {
    $scope.ArticleList = [];
    var deleteCandidate = null;

    loadData = function () {
        $http.get('api/article')
        .then(function (resp) {

            angular.copy(resp.data, $scope.ArticleList);

        }, function (err) {
            console.log(err);
        });
    }

    loadData();

    $scope.deleteArticle = function (id) {
        deleteCandidate = id;
    }

    $("#modalDeleteButton").click(function () {
        $http.delete('api/article/' + deleteCandidate)
            .then((resp) => {
                console.log(resp);
                loadData();
                $("#deleteConfirmModal").modal('hide');
            },
            (err) => {
                console.log(err);
            })
    })
});