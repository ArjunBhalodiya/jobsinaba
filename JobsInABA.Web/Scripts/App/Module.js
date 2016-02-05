var app = angular.module("myApp", ["ngRoute"]);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/home',
                        {
                            templateUrl: 'App/home',
                            controller: 'HomeController'
                        });
    $routeProvider.when('/register',
                        {
                            templateUrl: 'App/Register',
                            controller: 'RegisterController'
                        });
    $routeProvider.when('/login',
                        {
                            templateUrl: 'App/SignIn',
                            controller: 'SignInController'
                        });
    $routeProvider.when('/personprofile',
                        {
                            templateUrl: 'App/PersonProfile',
                            controller: 'PersonProfileController'
                        });
    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);