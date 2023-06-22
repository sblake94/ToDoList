using ApplicationLayer.ServiceAbstractions;
using ApplicationLayer.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer_WPF.Views
{
    /// <summary>
    /// Interaction logic for ChronologicalListView.xaml
    /// </summary>
    public partial class ChronologicalListView : UserControl
    {
        ChronologicalListViewModel ViewModel { get; set; }

        public ChronologicalListView()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;

            DataContext = ViewModel = new ChronologicalListViewModel(Ioc.Default.GetRequiredService<IDatabaseDataAccessService>());
            LoadData();
        }

        public async void LoadData()
        {
            try
            {                 
                await ViewModel.LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Visibility = Visibility.Visible;
            }
        }   

    }
}
