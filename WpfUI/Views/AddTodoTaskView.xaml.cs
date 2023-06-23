using ApplicationLayer.ViewModels;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer_WPF.Views
{
    /// <summary>
    /// Interaction logic for AddTodoTaskView.xaml
    /// </summary>
    public partial class AddTodoTaskView : UserControl
    {
        AddTodoTaskViewModel ViewModel { get; set; }

        public AddTodoTaskView()
        {
            InitializeComponent();

            DataContext = ViewModel = new AddTodoTaskViewModel();
        }

        private void OnTitleTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SubmitTitleText((sender as TextBox)!.Text);
        }

        private void OnDescriptionTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SubmitDescriptionText((sender as TextBox)!.Text);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SubmitDueDate((sender as DatePicker)!.SelectedDate!.Value);
        }

        private void OnRecurringFrequencyChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CBOX_RecurringPeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
