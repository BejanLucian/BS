angular.module('TaskPlannerApp')
.directive('taskWithCommands', function () {
    return {
        restrict: "AE",
        templateUrl: "/Task/TaskWithCommands",
        transclude: true,
        scope: {
            taskModel: '=scope'
        }
    };
});