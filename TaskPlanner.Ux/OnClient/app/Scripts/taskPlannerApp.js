angular.module('TaskPlannerApp',
    [
        'ui.router',
        'ui.bootstrap',
        'ngResource',
        'ncy-angular-breadcrumb',
        'angucomplete-alt'
    ])
    .config([
        '$stateProvider', '$urlRouterProvider', '$breadcrumbProvider', function($stateProvider, $urlRouterProvider, $breadcrumbProvider) {

            $breadcrumbProvider.setOptions({
                template: 'bootstrap3'
            });

            // For any unmatched url, send to /route1
            $urlRouterProvider.otherwise("/");

        $stateProvider
            .state('MainMenu', {
                url: "/",
                templateUrl: "Main/Index",
                controller: "",
                ncyBreadcrumb: {
                    label: 'Menu',
                },
            })
            .state('ManageTasks', {
                url: "Tasks/Manage",
                templateUrl: "Tasks/Index",
                controller: "Tasks",
                ncyBreadcrumb: {
                    label: 'Manage Tasks',
                    parent: 'MainMenu'
                },
            })
            .state('ManageParticipants', {
                url: "Participants",
                templateUrl: "Participants/Index",
                controller: "Participants",
                ncyBreadcrumb: {
                    label: 'Manage Participants',
                    parent: 'MainMenu'
                },
            })
            .state('Reports', {
                url: "Reports",
                templateUrl: "Reports/Index",
                controller: "Reports",
                ncyBreadcrumb: {
                    label: 'Reports',
                    parent: 'MainMenu'
                },
            })
            .state('Administration', {
                url: "Administration",
                templateUrl: "Administration/Index",
                controller: "Administration",
                ncyBreadcrumb: {
                    label: 'Administration',
                    parent: 'MainMenu'
                },
            });

    }
    ]);

