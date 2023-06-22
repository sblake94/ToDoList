using ApplicationLayer.ViewModels;
using DomainLayer.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationLayer.ServiceAbstractions
{
    public interface IDatabaseDataAccessService
    {
        Task<Result<IEnumerable<TodoTaskViewModel>>> GetTodoTasksAsync();
    }
}
