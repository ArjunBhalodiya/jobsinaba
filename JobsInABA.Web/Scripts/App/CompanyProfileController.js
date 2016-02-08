app.controller('CompanyProfileController', function ($scope, httpService) {
    $scope.addCompany = function () {
        var Company = {
            FirstName: $scope.firstName,
            LastName: $scope.lastName,
            Name: $scope.companyName,
            StartDate: $scope.startDate,
            Title: $scope.address,
            City: $scope.city,
            State: $scope.state,
            ZipCode: $scope.zip,
            Number: $scope.phoneNo,
            Cell: $scope.cell,
            Address: $scope.email,
            Site: $scope.website,
            CompanyDetail:$scope.companyDetail,
            IsActive: true,
            IsDeleted: false
        }

        var addCompanyResult = httpService.post(Company, "/api/Business/CreateBusiness");
        addCompanyResult.then(function (pl) {
            alert("Success" + pl);
        }, function (errorPl) {
            alert("Error" + errorPl);
        });
    };
});