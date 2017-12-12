var routes = angular.module("myRoutes", ["ngRoute"]);

//app.factory("SharedData", function () {
//    return { value: 1};
//});

routes.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    debugger;

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
                templateUrl: 'home/search'
            })
        .otherwise(
        {
            redirectTo: '/'
        });

    $locationProvider.html5Mode({ enable: true, requireBase: false }).hashPrefix('!');
}]);