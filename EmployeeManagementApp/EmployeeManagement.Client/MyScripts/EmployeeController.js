app.controller('EmployeeController', function ($scope, $location, EmployeeServices, SharedData) {

    loadAllEmployees();

    function loadAllEmployees() {
        var promiseGetEmployees = EmployeeServices.getAllEmployees(SharedData.value).
            then(SuccessError);

        function SuccessError(respond) {
            $scope.Employees = respond.data;
        }
    };

    $scope.FinalDelete = function () {
        var promiseDeleteEmployee = SPAServices.deleteEmployee(SharedData.value).
            then(SuccessError);

        function SuccessError(respond) {
            SharedData.value = 0;
            $location.path("/Employee");
            $scope.check = respond.data;
        }
    };

    $scope.editEmployee = function (id) {
        SharedData.value = id;
        $location.path("/editEmployee");
    };

    $scope.deleteEmployee = function (id) {
        SharedData.value = id;
        $location.path("/deleteEmployee");
    };
});