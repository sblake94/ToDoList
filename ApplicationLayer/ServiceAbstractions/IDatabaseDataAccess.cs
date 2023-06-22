using ApplicationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ServiceAbstractions
{
    public interface IDatabaseDataAccessService
    {
        Task<IEnumerable<TodoTaskViewModel>> GetTodoTasksAsync();
    }
}
