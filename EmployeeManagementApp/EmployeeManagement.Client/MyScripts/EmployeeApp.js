﻿var app = angular.module("EmployeeApp", ['myRoutes']);

app.controller("EmployeeController", ['$scope', '$http', function ($scope, $http) {
    var baseUrl = 'http://localhost:13108/api/Employee/';
    $scope.updating = false;

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

    function getAllDegrees() {
        return $http.get('http://localhost:13108/api/educations/GetAll')
            .then(function (response) {
                $scope.educations = response.data;
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

    getAllDegrees()
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