
var speakersApp = angular.module("speakersApp", ["ngRoute"]);


//Routes
speakersApp.config(function ($routeProvider) {
    $routeProvider
        .when("/speakers", {
            templateUrl: "partial-views/speakers.html",
            controller: "SpeakersController"
        })
        .when("/sessions", {
            templateUrl: "partial-views/sessions.html",
            controller: "SessionsController"
        })
        .otherwise({
            redirectTo: "/speakers"
        });
});


//SpeakersController
speakersApp.controller("SpeakersController", function ($scope, $http) {
    $http({ method: "GET", url: "/api/speakers" }).success(function (data, status) {
        $scope.speakers = data;
    });

    $scope.saveSpeaker = function (speaker, formSpeaker) {
        $http({ method: "POST", url: "/api/speakers", data: speaker }).success(function (data, status) {
            $scope.speakers.push(data);
        });
    };
});

//SessionsController
speakersApp.controller("SessionsController", function ($scope) {
    $scope.sessions = [
        "AngularJS + NancyFx + MongoDB = Best trio for Ultimate SPA",
        "Building modern and ambitious apps with all latest Ninja technologies",
        "Windows Azure 101"
    ];
});

