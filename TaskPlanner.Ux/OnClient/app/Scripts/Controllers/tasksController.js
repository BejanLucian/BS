angular.module('TaskPlannerApp')
.controller('TasksController', ['$scope','DataService',
        function ($scope, DataService) {
            $scope.createNewTask = function () {
                var newTaskData = {
                    Title: "TestTask"
                };
                DataService.createTask(newTaskData);
            };

            $scope.TasksList = [];

            var loadTasksList = function() {
                DataService.getTasksList()
                    .then(function(data) {
                        if (data) {
                            $scope.TasksList = data.data;
                        }
                    }).catch(function(error) {

                    }).finally(function() {
                        
                    });
            }

            loadTasksList();
        }
]
);