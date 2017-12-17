var routes = angular.module("myRoutes", ["ngRoute", 'ngMaterial', 'ngMessages']);

routes.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider.when('/employees',
        {
            templateUrl: 'Home/login',
        })
        .when('/',
            {
                redirectTo: '/employees/create'
            })
        .when('/employees/create',
            {
                templateUrl: 'Home/Employee',
                controller: 'EmployeeController'
            })
        .when('/employees/search',
            {
                templateUrl: 'home/search',
                controller: 'EmployeeController'
            })
        .otherwise(
        {
            redirectTo: '/'
        });

    $locationProvider.html5Mode({ enable: true, requireBase: false }).hashPrefix('!');
}]);