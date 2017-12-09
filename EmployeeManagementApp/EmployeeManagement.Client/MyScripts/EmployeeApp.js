var app = angular.module("EmployeeApp", []);

app.controller("EmployeeController", ['$scope', '$http', '$log', function myfunction($scope, $http, $log) {
    var baseUrl = 'http://localhost:13108/api/Employee/';

    function getAllEmployees() {
        return $http.get(baseUrl + 'getall')
                    .then(function (response) {
                        $scope.employees = response.data;
                    });
            }
   

    $scope.deleteEmployeeById = function (employee) {
        $http.delete(baseUrl + employee)
            .then(function (response) {
                $scope.employees = response.data;
                $scope.Status = "Deleted Successfully";
                getAllEmployees();
            });
        //alert(employee);
        //var index = $scope.employees.indexOf(employee);
        //alert(index);
        //$scope.employees.splice(index, 1);
    }

    getAllEmployees();
}]);