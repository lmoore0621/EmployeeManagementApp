app.service("EmployeeServices", function ($http) {
    var baseUrl = 'http://localhost:13108/api/Employee/';

    this.getAllEmployees = function (id) {
        return $http.get(baseUrl + 'getall');
    };

    this.getEmployee = function (id) {
        return $http.get(baseUrl + id);
    };

    this.deleteEmployee = function (id) {
        var request = $http.delete(baseUrl + id);
        return request;
    };

    this.updateEmployee = function (id, employee) {
        var request = $http({
            method: "PUT",
            url: baseUrl + id,
            data: employee
        });
        return request;
    };

    this.postEmployee = function (employee) {
        var request = $http({
            method: 'POST',
            url: baseUrl,
            data: employee
        });
        return request;
    }
});