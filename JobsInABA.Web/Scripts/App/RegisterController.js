app.controller('RegisterController', function ($scope, httpService) {
    $scope.register = function () {

        var User = {
            FirstName: $scope.firstName,
            MiddleName: "",
            LastName: $scope.lastName,
            Password: $scope.password,
            ConfirmPassword: $scope.confirmPassword,
            UserName: $scope.email,
            City: $scope.city,
            State: $scope.state,
            Zip: $scope.zip,
            HighestLevelOfEducation: $scope.highestLevelOfEducation,
            HowDidYouFindABA: $scope.howDidYouFindABA,
            WhichOfTheSocialMediaUse: $scope.whichOfTheSocialMediaUse,
            IsActive: true,
            IsDeleted: false
        }

        var UserAccount = {
            UserName: $scope.email,
            Password: $scope.password,
            IsActive: true,
            IsDeleted: false
        }


        var addAccountResult = httpService.post(UserAccount, "/api/UserAccount/AddUserAccount");
        addAccountResult.then(function (pl) {
            alert("Success" + pl);
        }, function (errorPl) {
            alert("Error" + errorPl);
        });

        var addUserResult = httpService.post(User, "/api/Users/AddUsers");
        addUserResult.then(function (pl) {
            alert("Success");
        }, function (errorPl) {
            alert("Error");
        });



        //var responce = $http({
        //    method: "post",
        //    url: "/api/Users/AddUsers",
        //    data: User,
        //    async: false
        //});

        //responce.then(function (pl) {
        //    $scope.message = "Success";
        //},
        //      function (errorPl) {
        //          $scope.message = 'failure loading', errorPl;
        //      });

        //$http({
        //    method: "post",
        //    url: "/api/UserAccount/AddUserAccount",
        //    data: UserAccount,
        //    async: false
        //}).then(function (pl) {
        //    $scope.message = "Success";
        //},
        //      function (errorPl) {
        //          $scope.message = 'failure loading', errorPl;
        //      });
    }
});