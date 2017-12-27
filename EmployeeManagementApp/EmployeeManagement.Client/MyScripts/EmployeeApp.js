var app = angular.module("EmployeeApp", ['myRoutes', "ui.bootstrap", 'coreModule']);

app.filter('beginning_data', function () {
    return function (input, begin) {
        if (input) {
            begin = +begin;
            return input.slice(begin);
        }
        return [];
    }
});

app.factory('employeeService', ['$http', 'employeeUrl', function ($http, employeeUrl) {
    var service = {};

    service.create = function (employee) {
        return $http.post(employeeUrl, employee);
    };

    service.getAll = function () {
        return $http.get(employeeUrl + 'getall');
    };
    
    service.update = function (employee) {
        return $http.put(employeeUrl + '/' + employee.employee_Id, employee);
    };

    service.delete = function (id) {
        return $http.delete(employeeUrl + id);
    };

    service.get = function (id) {
        return $http.get(employeeUrl + id);
    };

    return service;
}]);

app.controller("EmployeeController", ['$scope', '$timeout', '$window', '$log', 'employeeService', 'generalService', function ($scope, $timeout, $window, $log, employeeService, generalService) {
    $scope.updating = false;

    //#region Employee Service Operations

    function getAllEmployees() {
        employeeService.getAll()
                    .then(function (response) {
                        $scope.employees = response.data;
                        $scope.file = response.data;
                        $scope.current_grid = 1;
                        $scope.data_limit = 10;
                        $scope.filter_data = $scope.employees.length;
                        $scope.entire_user = $scope.employees.length;
                    });
    };

    $scope.addEmployeeInfo = function () {
        employeeService.create($scope.employee)
            .then(function (response) {
                alert($scope.employee.name + " has been added");
                $scope.employee = {};
                getAllEmployees();
            });
    };

    $scope.selectEmployeeToUpdate = function (employee) {
        $scope.employee = angular.copy(employee);
        $scope.employee.date_of_birth = new Date($scope.employee.date_of_birth);
        $scope.updating = true;
        $window.scrollTo(0, 0);
    };

    $scope.updateEmployeeInfo = function () {
        employeeService.update($scope.employee)
            .then(function (response) {
                alert($scope.employee.name + " has been updated");
                $scope.employee = {};
                $scope.updating = false;
                getAllEmployees();
            });
    };

    $scope.deleteEmployeeById = function (employeeId, name) {
        employeeService.delete(employeeId)
            .then(function (response) {
                alert(name + " has been deleted");
                getAllEmployees();
            });
    };

    //#endregion

    //#region General Service Operations

    function getAllStates() {
        generalService.getStateOptions()
            .then(function (response) {
                $scope.states = response.data;
            });
    };

    function getAllDegrees() {
        generalService.getDegreeOptions()
            .then(function (response) {
                $scope.educations = response.data;
            });
    };

    function getAllGenders() {
        generalService.getGenderOptions()
            .then(function (response) {
                $scope.genders = response.data;
            });
    };

    //#endregion

    // #region Pagination
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
    // #endregion

    // #region states auto completion event handlers
    $scope.selectedItemChange = function(item) {
        if (item) {
            $scope.employee.state_Id = item.usa_state_id;
            $log.info('Item changed to ' + JSON.stringify(item));
        }
    };

    $scope.searchTextChange = function(text) {
        $log.info('Text changed to ' + text);
    };
    //#endregion

    //#region Initializations
    getAllGenders();
    getAllDegrees();
    getAllStates();
    getAllEmployees();
    //#endregion
}]);