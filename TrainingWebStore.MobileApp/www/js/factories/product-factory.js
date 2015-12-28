(function () {
    'use strict';
    angular.module('twa').factory('ProductFactory', ProductFactory);
    ProductFactory.inject = ['$http', 'SETTINGS'];
    function ProductFactory($http, SETTINGS) {
        return {
            get: get,
            getById: getById
        };

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products');
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products/' + id);
        }
    }
})();