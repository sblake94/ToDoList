namespace ApplicationLayer.ViewModels
{
    public class MainViewModel 
        : ViewModelBase
    {
        public string Title { get; set; }

        public MainViewModel()
        {
            Title = "Todo List";
        }
    }
}
