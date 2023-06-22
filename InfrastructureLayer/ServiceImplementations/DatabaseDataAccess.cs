using ApplicationLayer.ServiceAbstractions;
using ApplicationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.ServiceImplementations
{
    public class DatabaseDataAccess
        : ServiceBase<DatabaseDataAccess>
        , IDatabaseDataAccessService
    {
        async Task<IEnumerable<TodoTaskViewModel>> IDatabaseDataAccessService.GetTodoTasksAsync()
        {
            List<TodoTaskViewModel> result = new List<TodoTaskViewModel>();

            for(int i = 0; i < 100; i++)
            {
                var task = new DomainLayer.Models.TodoTask(
                    title: $"Task {i}",
                    description: $"Description {i}",
                    dueDate: System.DateTime.Now.AddDays(1));

                var taskViewModel = new TodoTaskViewModel();
                taskViewModel.SetDataModel(task);

                result.Add(taskViewModel);
            }

            return result;
        }
    }
}
