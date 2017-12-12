var app = angular.module("EmployeeApp", ['myRoutes']);

//app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
//    debugger;

//    $routeProvider.when('/home',
//        {
//            templateUrl: 'Home/Employee',
//            controller: 'EmployeeController'
//        })
//        .when('/',
//            {
//                redirectTo: '/home'
//            })
//        .otherwise(
//        {
//            redirectTo: '/'
//        });

//    $locationProvider.html5Mode({ enable: true, requireBase: false }).hashPrefix('!');
//}]);

app.controller("EmployeeController", ['$scope', '$http', function ($scope, $http) {
    var baseUrl = 'http://localhost:13108/api/Employee/';

    function getAllEmployees() {
        return $http.get(baseUrl + 'getall')
                    .then(function (response) {
                        $scope.employees = response.data;
                    });
    };

    function getAllStates() {
        return $http.get('http://localhost:13108/api/States/GetAll')
            .then(function (response) {
                $scope.states = response.data;
            });
    };

    $scope.deleteEmployeeById = function (employee) {
        $http.delete(baseUrl + employee)
            .then(function (response) {
                $scope.employees = response.data;
                getAllEmployees();
            });
        //alert(employee);
        //var index = $scope.employees.indexOf(employee);
        //alert(index);
        //$scope.employees.splice(index, 1);
    };

    $scope.addEmployeeInfo = function () {
        $http.post(baseUrl, $scope.employee)
            .then(function (response) {
                getAllEmployees();
            });
    };

    $scope.selectEmployeeToUpdate = function (employee) {
        $scope.employee = angular.copy(employee);
    };

    $scope.updateEmployeeInfo = function () {
        $http.put(baseUrl + '/' + $scope.employee.employee_Id, $scope.employee)
            .then(function (response) {
                getAllEmployees();
                alert($scope.employee.name + " has been updated");
            });
    };

    getAllStates();
    getAllEmployees();
}]);