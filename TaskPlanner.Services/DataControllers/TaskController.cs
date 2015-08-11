using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskPlanner.Domain.Coordinators;
using TaskPlanner.Domain.Exceptions;
using TaskPlanner.Infrastructure.Context;
using TaskPlanner.Services.DataContracts;

namespace TaskPlanner.Services.DataControllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskCoordinator _taskCoordinator;
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;

        public TaskController(ITaskCoordinator taskCoordinator, IWorkflowContextIdProvider worflowContextIdProvider, IDataContextFactory dataContextFactory)
        {
            _taskCoordinator = taskCoordinator;
            _unitOfWorkProvider = new UnitOfWorkProvider(worflowContextIdProvider, dataContextFactory);
        }

        public HttpResponseMessage GetTasks()
        {
            return GetSubtasks(Guid.Empty);
        }

        public HttpResponseMessage GetSubtasks(Guid parentId)
        {
            using (var uow = _unitOfWorkProvider.GetCurrent())
            {
                var result = TryAndBuildResponseOnExceptions(() =>
                    _taskCoordinator.GetTasks(parentId)
                    );

                return result;
            }
        }

        public HttpResponseMessage Create(CreationTaskData newTaskData)
        {
            using (var uow = _unitOfWorkProvider.GetCurrent())
            {
                var result = TryAndBuildResponseOnExceptions(() =>
                    _taskCoordinator.CreateNewTask(newTaskData.Title, newTaskData.Details, newTaskData.ParentId)
                    );
                uow.CommitChanges();

                return result;
            }
        }

        private HttpResponseMessage TryAndBuildResponseOnExceptions(Action toExecute)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                toExecute();
            }
            catch (DomainException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        private HttpResponseMessage TryAndBuildResponseOnExceptions(Func<object> toExecute)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                var data = toExecute();
                return Request.CreateResponse(HttpStatusCode.Accepted, data);
            }
            catch (DomainException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
