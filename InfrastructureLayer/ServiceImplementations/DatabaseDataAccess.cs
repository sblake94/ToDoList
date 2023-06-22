using ApplicationLayer.ServiceAbstractions;
using ApplicationLayer.ViewModels;
using DomainLayer.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.ServiceImplementations
{
    public class DatabaseDataAccess
        : ServiceBase<DatabaseDataAccess>
        , IDatabaseDataAccessService
    {
        async Task<Result<IEnumerable<TodoTaskViewModel>>> IDatabaseDataAccessService.GetTodoTasksAsync()
        {
            List<TodoTaskViewModel> result = new List<TodoTaskViewModel>();

            for(int i = 0; i < 5; i++)
            {
                var task = new DomainLayer.Models.TodoTaskModel(
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
