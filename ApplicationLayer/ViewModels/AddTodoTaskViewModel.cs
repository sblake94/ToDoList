using ApplicationLayer.ServiceAbstractions;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using DomainLayer.Models;
using DomainLayer.Models.Data;
using System;
using System.Dynamic;
using System.Windows.Input;

namespace ApplicationLayer.ViewModels
{
    public class AddTodoTaskViewModel 
        : ViewModelBase
    {
        private readonly IDatabaseDataAccessService _databaseDataAccessService;
        public TodoTaskModel ModelUnderConstruction { get; set; }

        private bool _visible = true;
        public bool Visible 
        { 
            get { return _visible; }
            set
            {
                _visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        public ICommand CMD_Save { get; set; }
        public ICommand CMD_Cancel { get; set; }


        public AddTodoTaskViewModel()
        {
            _databaseDataAccessService = Ioc.Default.GetRequiredService<IDatabaseDataAccessService>();

            CMD_Save = new RelayCommand(Save);
            CMD_Cancel = new RelayCommand(Cancel);
        }
        private async void Save()
        {
            if (ModelUnderConstruction is null) 
            { 
                throw new Exception("No modelData was found to submit"); 
            }

            var submissionResult = await _databaseDataAccessService.SubmitNewTodoTaskAsync(ModelUnderConstruction);

            if (!submissionResult.IsSuccess)
            {
                throw submissionResult.ThrowableException;
            }
        }

        private void Cancel()
        {
            Visible = false;
        }

        public void SubmitDescriptionText(string text)
        {
            if(ModelUnderConstruction is null) { ModelUnderConstruction = new TodoTaskModel("", "", new DateTime()); }
            ModelUnderConstruction.UpdateDescription(text);
        }

        public void SubmitTitleText(string text)
        {
            if (ModelUnderConstruction is null) { ModelUnderConstruction = new TodoTaskModel("", "", new DateTime()); }
            ModelUnderConstruction.UpdateTitle(text);
        }

        public void SubmitDueDate(DateTime date)
        {
            if (ModelUnderConstruction is null) { ModelUnderConstruction = new TodoTaskModel("", "", new DateTime()); }
            ModelUnderConstruction.UpdateDueDate(date);
        }
    }
}
