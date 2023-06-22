using CommunityToolkit.Mvvm.Input;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Input;

namespace ApplicationLayer.ViewModels
{
    public class TodoTaskViewModel : INotifyPropertyChanged
    {
        static List<TodoTaskViewModel> instances = new List<TodoTaskViewModel>();


        private TodoTaskModel _dataModel;
        public TodoTaskModel DataModel { 
            get { return _dataModel; }
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
            }
        }

        public bool TaskCompletionState 
        {
            get
            {
                switch (DataModel.CompletionState)
                {
                    case TodoTaskModel.eCompletionState.Complete:
                        return true;
                    case TodoTaskModel.eCompletionState.Incomplete:
                        return false;
                    default:
                        return false;
                }
            }
        }

        public ICommand CMD_ToggleCompletedState { get; }

        public TodoTaskViewModel()
        {
            instances.Add(this);

            CMD_ToggleCompletedState = new RelayCommand(ToggleCompletedState);
        }

        public void SetDataModel(TodoTaskModel dataModel)
        {
            DataModel = dataModel;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ToggleCompletedState() 
        {
            if(TaskCompletionState != true)
                DataModel.MarkAsComplete();
            else
                DataModel.MarkAsIncomplete();

            OnPropertyChanged(nameof(TaskCompletionState));
        }
    }
}
