app.controller('SignInController', function ($scope, $http) {
    $scope.login = function () {

        var logIn = {
            email: $scope.username,
            password: $scope.password
        }


        $http({
            method: "post",
            url: "/api/UserAccount/SignIn",
            data: logIn,
            async: false
        }).then(function (pl) {
            $scope.message = "Success";
            alert("Sucess Register");
        },
              function (errorPl) {
                  $scope.message = 'failure loading', errorPl;
                  alert("Error Register");
              });
    }
});