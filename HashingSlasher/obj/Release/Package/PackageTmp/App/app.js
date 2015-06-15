var app = angular.module('passwordApp', []);

app.controller('passwordController', ['$scope', '$http', function ($scope, $http) {
   
    $scope.getPasswords = function () {
        
        if (($scope.options.PasswordCount > 0 && $scope.options.PasswordCount < 20) && ($scope.options.Length <= 30 && $scope.options.Length >= 6)) {
            $scope.loading = true;
            $scope.showPassword = false;
            
            $http.post("http://hashslinger.azurewebsites.net/api/password/", $scope.options)
                .then(function(response) {
                    $scope.passwords = response.data;
                    $scope.showPassword = true;
                })
                .catch(function(err) {
                    $scope.error = "Something went wrong.";
                })
                .finally(function() {
                    $scope.loading = false;
                });
        } else {
            alert("Check the Minimum and Maximum settings for password slinging!");
        }
    }

    $scope.options = {
        HasSimilarChars: false,
        IsMixedCase: false,
        IsPunctuated: false,
        IsNumeric: false,
        Length: 6,
        PasswordCount: 3
    };



}]);

app.controller('hasherController', ['$scope', '$http', function ($scope, $http) {

    $scope.getHash = function () {
        if ($scope.option.Text.length <= 150) {
            $scope.loading = true;
            $scope.showHash = false;

            $http.post("http://hashslinger.azurewebsites.net/api/hasher/", $scope.option)
                .then(function(response) {
                    $scope.hash = response.data;
                    $scope.showHash = true;
                })
                .catch(function(err) {
                    $scope.booty = "Something went wrong.";
                })
                .finally(function() {
                    $scope.loading = false;
                });
        } else {
            alert("Maximum length is 150 Characters!");
        }
    }

    $scope.option = {
        Hash: "MD5",
        Text: ""
    };



}]);

