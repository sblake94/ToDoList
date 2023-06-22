using ApplicationLayer.ServiceAbstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace ApplicationLayer.ViewModels
{
    public class ChronologicalListViewModel 
        : ViewModelBase
    {
        private readonly IDatabaseDataAccessService _databaseDataAccessService;
        public ObservableCollection<TodoTaskViewModel> TodoTasks { get; set; }

        public ChronologicalListViewModel(IDatabaseDataAccessService databaseDataAccessService)
        {
            _databaseDataAccessService = databaseDataAccessService;
            TodoTasks = new ObservableCollection<TodoTaskViewModel>();
        }

        public async Task LoadDataAsync()
        {
            var serviceRequestResult = await _databaseDataAccessService.GetTodoTasksAsync();
            var taskViewModels = serviceRequestResult.Value;

            TodoTasks.Clear();

            foreach (var item in taskViewModels)
                TodoTasks.Add(item);
        }
    }
}
