using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ApplicationLayer.ViewModels
{
    public class TodoTaskViewModel : INotifyPropertyChanged
    {
        static List<TodoTaskViewModel> instances = new List<TodoTaskViewModel>();

        private TodoTask _dataModel;
        public TodoTask DataModel { 
            get { return _dataModel; }
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
            }
        }

        public TodoTaskViewModel()
        {
            instances.Add(this);
        }

        public void SetDataModel(TodoTask dataModel)
        {
            DataModel = dataModel;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MarkAsComplete(object sender, EventArgs e) => DataModel.MarkAsComplete();
        public void MarkAsIncomplete(object sender, EventArgs e) => DataModel.MarkAsIncomplete();
    }
}
