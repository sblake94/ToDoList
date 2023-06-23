using ApplicationLayer.ServiceAbstractions;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
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


        private readonly string _title = "Todo List";
        public string Title { get { return _title; } }

        private bool _addNewTodoTaskViewIsVisible;
        public bool AddNewTodoTaskViewIsVisible
        {
            get { return _addNewTodoTaskViewIsVisible; }
            set
            {
                _addNewTodoTaskViewIsVisible = value;
                OnPropertyChanged(nameof(AddNewTodoTaskViewIsVisible));
            }
        }

        public ChronologicalListViewModel()
        {

            _databaseDataAccessService = Ioc.Default.GetRequiredService<IDatabaseDataAccessService>();
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

        public void Button_AddNewTodoTask(object sender, EventArgs e)
        {
            // show the AddtodoTaskView
            AddNewTodoTaskViewIsVisible = true;
        }
    }
}
