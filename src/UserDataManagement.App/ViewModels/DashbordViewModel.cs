using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataManagement.Services;

namespace UserDataManagement.App.ViewModels;

public class DashbordViewModel : ViewModelBase
{
    private readonly UserService? userService;
    private string? selectedItem;
    public DashbordViewModel(UserService userService)
    {
        this.userService = userService;
        this.SelectedItem = "User data";
    }

    public string? SelectedItem
    {
        get => this.selectedItem;
        set => SetProperty(ref this.selectedItem, value);
    }
}

