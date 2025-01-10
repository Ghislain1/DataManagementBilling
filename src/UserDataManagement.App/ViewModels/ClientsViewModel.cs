
using UserDataManagement.Services;

namespace UserDataManagement.App.ViewModels;

public class ClientsViewModel : ViewModelBase
{
    private readonly UserService? userService;
    private string? selectedItem;
    private int selectedIndex;
    public ClientsViewModel(UserService userService)
    {
        this.userService = userService;
    }
    public int SelectedIndex
    {
        get => this.selectedIndex;
        set => SetProperty(ref this.selectedIndex, value);
    }
    public string? SelectedItem
    {
        get => this.selectedItem;
        set => SetProperty(ref this.selectedItem, value);
    }
}
