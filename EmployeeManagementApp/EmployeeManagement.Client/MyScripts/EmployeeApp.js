var app = angular.module("EmployeeApp", ['myRoutes', "ui.bootstrap"]);

app.filter('beginning_data', function () {
    return function (input, begin) {
        if (input) {
            begin = +begin;
            return input.slice(begin);
        }
        return [];
    }
});

app.controller("EmployeeController", ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
    var baseUrl = 'http://localhost:13108/api/Employee/';
    $scope.updating = false;

    function getAllEmployees() {
        return $http.get(baseUrl + 'getall')
                    .then(function (response) {
                        $scope.employees = response.data;
                        $scope.file = response.data;
                        $scope.current_grid = 1;
                        $scope.data_limit = 10;
                        $scope.filter_data = $scope.employees.length;
                        $scope.entire_user = $scope.employees.length;
                    });
    };

    $scope.page_position = function(page_number) {
        $scope.current_grid = page_number;
    };
    $scope.filter = function() {
        $timeout(function() {
            $scope.filter_data = $scope.employees.length;
        }, 20);
    };
    $scope.sort_with = function (base) {
        $scope.base = base;
        $scope.reverse = !$scope.reverse;
    };

    function getAllStates() {
        return $http.get('http://localhost:13108/api/States/GetAll')
            .then(function (response) {
                $scope.states = response.data;
            });
    };

    function getAllDegrees() {
        return $http.get('http://localhost:13108/api/educations/GetAll')
            .then(function (response) {
                $scope.educations = response.data;
            });
    };

    function getAllGenders() {
        return $http.get('http://localhost:13108/api/gender/GetAll')
            .then(function (response) {
                $scope.genders = response.data;
            });
    };

    $scope.deleteEmployeeById = function (employee) {
        $http.delete(baseUrl + employee)
            .then(function (response) {
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
                alert($scope.employee.name + " has been added");
                $scope.employee = {};
                getAllEmployees();
            });
    };

    $scope.selectEmployeeToUpdate = function (employee) {
        $scope.employee = angular.copy(employee);
        $scope.updating = true;
    };

    $scope.updateEmployeeInfo = function () {
        $http.put(baseUrl + '/' + $scope.employee.employee_Id, $scope.employee)
            .then(function (response) {
                alert($scope.employee.name + " has been updated");
                $scope.employee = {};
                $scope.updating = false;
                getAllEmployees();
            });
    };

    getAllGenders();
    getAllDegrees();
    getAllStates();
    getAllEmployees();
}]);

//$("input").on("change", function () {
//    this.setAttribute(
//        "data-date",
//        moment(this.value, "YYYY-MM-DD")
//        .format(this.getAttribute("data-date-format"))
//    )
//}).trigger("change")