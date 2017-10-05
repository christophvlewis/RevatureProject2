//controller for app-problemlist.js 
(function () {

    "use strict";
         //getting module
    angular.module("app-problemlist")
        .controller("problemlistController", problemlistController);
    function problemlistController($http,$scope,$window) {
       

        /*

        $scope.redirect = function (url, refresh) {
            if (refresh || $scope.$$phase) {
                $window.location.href = url;
            } else {
                $location.path(url);
                $scope.$apply();
            }
        }
        */

        var vm = this;
        vm.alert = function () { alert("alert"); };

        vm.redirectCompiler = function (id) {

            var changeLocation = function (url, forceReload) {
                $scope = $scope || angular.element(document).scope();
                if (forceReload || $scope.$$phase) {
                    window.location = url;
                }
                else {
                    //only use this if you want to replace the history stack
                    //$location.path(url).replace();

                    //this this if you want to change the URL and add it to the history stack
                    $location.path(url);
                    $scope.$apply();
                }
            };
       
              changeLocation("/Compiler/Index/"+id, "true")
            //window.location("#/compiler/index/" + id);
            //alert("should have redirected");//pass problem id from problem list form using the onclick.
        };
        vm.name = "Nick";
        vm.trips = [{ name: "US Trip", created: new Date() }, { name: "World Trip", created: new Date() }];
        vm.newTrip = {};

        
        //go = function () { alert("yoyoyo"); };
        vm.problem = [];
        vm.alert = function () { alert("hello"); };
        $http.get("/api/default")
            .then(function (response) {
                //success
                angular.copy(response.data, vm.problem)  //gets all problems (from myRestAPI which is set to the /api/default route)

              

            },

         

            function () { alert("FAILED TO HTTP GET");}); //failure

          //actual controller code goes here
        
        vm.newTrip = {};

        vm.addTrip = function () {
            alert("test");
            alert(vm.newTrip.name);


           

        };
    }

    
    
})();

