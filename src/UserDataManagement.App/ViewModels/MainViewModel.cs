using MaterialDesignThemes.Wpf;

using UserDataManagement.App.Views;
using UserDataManagement.Services;


namespace UserDataManagement.App.ViewModels;
public class MainViewModel : ViewModelBase
{
    private UserService userService;

    private PageViewModel? selectedItem;
    private int _selectedIndex;
    private ISnackbarMessageQueue snackbarMessageQueue;
    private bool _controlsEnabled = true;
    public MainViewModel(UserService userService, ISnackbarMessageQueue snackbarMessageQueue, string? startupPage)
    {
        this.userService = userService;
        this.snackbarMessageQueue = snackbarMessageQueue;
        this.SelectedItem = this.Pages.FirstOrDefault();
    }
    public PageViewModel[] Pages => [new PageViewModel("Dashbord", "Folder", typeof(DashbordView), new DashbordViewModel(this.userService)),
        new PageViewModel("Users", "Users", typeof(UsersView), new UsersViewModel(this.userService)),
        new PageViewModel("Clients", "Bell", typeof(ClientsView), new ClientsViewModel(this.userService))];

    public PageViewModel? SelectedItem
    {
        get => this.selectedItem;
        set => SetProperty(ref this.selectedItem, value);
    }

    public int SelectedIndex
    {
        get => _selectedIndex;
        set => SetProperty(ref _selectedIndex, value);
    }

    public bool ControlsEnabled
    {
        get => _controlsEnabled;
        set => SetProperty(ref _controlsEnabled, value);
    }


}

