(function () {
    'use strict';
    angular.module('twa').controller('LoginCtrl', LoginCtrl);
    LoginCtrl.$inject = ['$location', '$rootScope', 'SETTINGS', 'AccountFactory'];
    function LoginCtrl($location, $rootScope, SETTINGS, AccountFactory) {
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
            AccountFactory.login(vm.login)
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