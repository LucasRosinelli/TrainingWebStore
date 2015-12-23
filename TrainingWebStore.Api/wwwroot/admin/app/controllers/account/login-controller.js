(function () {
    'use strict';
    angular.module('twa').controller('LoginCtrl', LoginCtrl);
    LoginCtrl.$inject = ['$http', '$location', '$rootScope', 'SETTINGS'];
    function LoginCtrl($http, $location, $rootScope, SETTINGS) {
        var vm = this;
        vm.login = {
            email: '',
            password: ''
        };
        vm.submit = login;

        activate();

        function activate() {
        }

        function login() {
            var data = "grant_type=password&username=" + vm.login.email + "&password=" + vm.login.password;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
            $http.post(url, data, header)
                .success(success)
                .catch(fail);

            function success(response) {
                $rootScope.token = response.access_token;
                $rootScope.user = vm.login.email;
                sessionStorage.setItem(SETTINGS.AUTH_TOKEN, $rootScope.token);
                sessionStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);
                $location.path('/');
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha na autenticação');
            }
        }
    }
})();