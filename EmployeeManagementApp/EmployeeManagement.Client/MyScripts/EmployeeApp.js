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

app.constant('employeeUrl', 'http://localhost:13108/api/employee/');
app.constant('statesUrl', 'http://localhost:13108/api/states/');
app.constant('genderUrl', 'http://localhost:13108/api/gender/');
app.constant('degreesUrl', 'http://localhost:13108/api/eductions/');

app.factory('generalService', ['$http', 'statesUrl', 'genderUrl', 'degreeUrl', function ($http, statesUrl, genderUrl, degreeUrl) {

    var service = {}

    service.getStateOptions = function () {
        return $http.get(statesUrl + 'GetAll');
    };

    service.getGenderOptions = function () {
        return $http.get(genderUrl + 'GetAll')
    }

    service.getDegreeOptions = function () {
        return $http.get(degreeUrl + 'GetAll')
    }

    return service;

}]);

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

app.controller("EmployeeController", ['$scope', '$http', '$timeout', '$window', '$log', 'employeeService', 'generalService', function ($scope, $http, $timeout, $window, $log, employeeService, generalService) {
    var baseUrl = 'http://localhost:13108/api/Employee/';
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

    $scope.deleteEmployeeById = function (employeeId) {
        employeeService.delete(employeeId)
            .then(function (response) {
                alert($scope.employee.name + " has been deleted");
                getAllEmployees();
            });
        //alert(employee);
        //var index = $scope.employees.indexOf(employee);
        //alert(index);
        //$scope.employees.splice(index, 1);
    };

    //#endregion

    //#region General Service Operations

    function getAllStates() {
        generalService.getStatesOptions()
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
        generalService.getDegreeOptions()
            .then(function (response) {
                $scope.genders = response.data;
            });
    };

    //#endregion

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


    

    

    

    var self = this;

    self.simulateQuery = false;
    self.isDisabled = false;

    // list of `state` value/display objects
    self.querySearch = querySearch;
    self.states = [];
    $scope.selectedItemChange = selectedItemChange;
    self.searchTextChange = searchTextChange;

    //self.newState = newState;

    //function newState(state) {
    //    alert("Sorry! You'll need to create a Constitution for " + state + " first!");
    //}

    function searchTextChange(text) {
        $log.info('Text changed to ' + text);
    }

    function selectedItemChange(item) {
        if (item) {
            $scope.employee.state_Id = item.usa_state_id;
            $log.info('Item changed to ' + JSON.stringify(item));
        }
    }

    function querySearch(query) {
        var results = query ? self.states.filter(createFilterFor(query)) : self.states,
            deferred;
        if (self.simulateQuery) {
            deferred = $q.defer();
            $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
            return deferred.promise;
        } else {
            return results;
        }
    }

    getAllGenders();
    getAllDegrees();
    getAllStates();
    getAllEmployees();
}]);