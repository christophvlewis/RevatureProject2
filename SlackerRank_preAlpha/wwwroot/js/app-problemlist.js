//page for display of problem list
(function () {
    "use strict";
    //creating module ('[]' signifies this)
    angular.module("app-problemlist", ["ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/testingjs", {

                controller: "problemlistController",
                controllerAs: "vm",
                templateUrl:"/Compiler"
            });

            $routeProvider.otherwise({redirectTo: "/"});

        });
})();