(function () {
    'use strict';
    angular.module('twa').controller('LogoutCtrl', LogoutCtrl);
    LogoutCtrl.$inject = ['$location', '$rootScope', 'SETTINGS'];
    function LogoutCtrl() {
        var vm = this;

        activate();

        function activate() {
            $rootScope.token = null;
            $rootScope.user = null;
            sessionStorage.removeItem(SETTINGS.AUTH_TOKEN);
            sessionStorage.removeItem(SETTINGS.AUTH_USER);
            $location.path('/login');
        }
    }
})();