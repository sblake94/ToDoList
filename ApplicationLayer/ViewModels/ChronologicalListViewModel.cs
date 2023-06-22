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


            for(int i = 0; i < 100; i++)
            {
                var task = new DomainLayer.Models.TodoTask(
                        title: $"Task {i}",
                        description: $"Description {i}",
                        dueDate: DateTime.Now.AddDays(1));

                var taskViewModel = new TodoTaskViewModel();
                taskViewModel.SetDataModel(task);

                TodoTasks.Add(taskViewModel);
            }
        }

        public async Task LoadDataAsync()
        {
            // DataLoading Logic here
            var result = await _databaseDataAccessService.GetTodoTasksAsync();

            TodoTasks.Clear();

            foreach (var item in result)
                TodoTasks.Add(item);
        }
    }
}
