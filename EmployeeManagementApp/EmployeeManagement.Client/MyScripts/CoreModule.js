var core = angular.module('coreModule', []);

core.constant('employeeUrl', 'http://localhost:13108/api/employee/');
core.constant('statesUrl', 'http://localhost:13108/api/states/');
core.constant('genderUrl', 'http://localhost:13108/api/gender/');
core.constant('degreeUrl', 'http://localhost:13108/api/educations/');

core.factory('generalService', ['$http', 'statesUrl', 'genderUrl', 'degreeUrl', function ($http, statesUrl, genderUrl, degreeUrl) {

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