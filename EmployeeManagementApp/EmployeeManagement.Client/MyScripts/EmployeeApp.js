﻿var app = angular.module("EmployeeApp", []);

app.controller("EmployeeController", ['$scope', '$http', function myfunction($scope, $http) {
    var baseUrl = 'http://localhost:13108/api/Employee/';

    function getAllEmployees() {
        return $http.get(baseUrl + 'getall')
                    .then(function (response) {
                        $scope.employees = response.data;
                    });
    };

    $scope.deleteEmployeeById = function (employee) {
        $http.delete(baseUrl + employee)
            .then(function (response) {
                $scope.employees = response.data;
                $scope.Status = "Deleted Successfully";
            });
        //alert(employee);
        //var index = $scope.employees.indexOf(employee);
        //alert(index);
        //$scope.employees.splice(index, 1);
    };

    $scope.addEmployeeInfo = function () {
        $http.post(baseUrl)
            .then(function (response) {
                $scope.employee = response.data;
            });
        //alert($scope.employee.email);
    };

    $scope.selectEmployeeToUpdate = function (employee) {
        $scope.employee = employee;
    };

    $scope.updateEmployeeInfo = function () {
        alert($scope.employee.name + " has been updated");
    }

    getAllEmployees();
}]);