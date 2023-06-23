using ApplicationLayer.ServiceAbstractions;
using ApplicationLayer.ViewModels;
using DomainLayer.Models;
using DomainLayer.Models.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.ServiceImplementations
{
    public class DatabaseDataAccess
        : ServiceBase<DatabaseDataAccess>
        , IDatabaseDataAccessService
    {
        IEnumerable<TodoTaskModel> TodoTasks { get; set; }

        #region InterfaceMethods
        async Task<Result<Empty>> IDatabaseDataAccessService.SubmitNewTodoTaskAsync(TodoTaskModel modelToSubmit)
        {
            return await SaveToLocalList(modelToSubmit);
        }
        async Task<Result<IEnumerable<TodoTaskViewModel>>> IDatabaseDataAccessService.GetTodoTasksAsync()
        {
            return GenerateFakeTasks();
        }
        #endregion

        private async Task<Result<Empty>> SaveToLocalList(TodoTaskModel modelToSubmit)
        {
            TodoTasks.ToList().Add(modelToSubmit);
            await Task.Delay(100);
            return new Success<Empty>(Empty.Instance);
        }

        private static Result<IEnumerable<TodoTaskViewModel>> GenerateFakeTasks()
        {
            List<TodoTaskViewModel> result = new List<TodoTaskViewModel>();

            for (int i = 0; i < 5; i++)
            {
                var task = new TodoTaskModel(
                    title: $"Task {i}",
                    description: $"Description {i}. We can put a description of anything here.",
                    dueDate: System.DateTime.Now.AddDays(1));

                var taskViewModel = new TodoTaskViewModel();
                taskViewModel.SetDataModel(task);

                result.Add(taskViewModel);
            }

            return new Success<IEnumerable<TodoTaskViewModel>>(result);
        }
    }
}
