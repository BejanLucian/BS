angular.module('TaskPlannerApp').factory("DataService", [
    '$http',
    function ($http) {
        var baseDirectory = "http://localhost:9000";
        return {
            createTask: function (taskData) {
                return $http({
                    url: baseDirectory + '/api/Task',
                    method: "POST",
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    data: taskData
                });
            },
            getTasksList: function () {
                return $http({
                    url: baseDirectory + '/api/Task',
                    method: "GET",
                    headers: { 'Content-Type': 'application/json; charset=utf-8' }
                });
            }
        }
    }
]);
