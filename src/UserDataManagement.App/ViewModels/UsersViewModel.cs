
using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UserDataManagement.App.Commands;
using UserDataManagement.Models;
using UserDataManagement.Services;

namespace UserDataManagement.App.ViewModels;
public class UsersViewModel : ViewModelBase
{
    private readonly UserService? userService;
    private ObservableCollection<UserViewModel> users = [];
    private string? selectedItem;
    public UsersViewModel(UserService userService)
    {
        this.userService = userService;
        this.AddUserCommand = new RelayCommand(this.ExcuteAddUser);
        this.LoadUsers();
    }
    private void LoadUsers()
    {
        this.Users.Clear();
        this.userService?.GetAllUsers().ForEach(user => this.Users.Add(new UserViewModel(user.Name, user.Email)));
    }
    public string? SelectedItem
    {
        get => this.selectedItem;
        set => this.SetProperty(ref this.selectedItem, value);
    }
    public ICommand AddUserCommand { get; }

    private void ExcuteAddUser()
    {
        var newUser = new UserViewModel(GenerateUserName(), "ghz@protonmail.com");
        this.userService?.AddUser(newUser.Model);
        this.LoadUsers();
    }
    public ObservableCollection<UserViewModel> Users
    {
        get => this.users;
        set => this.SetProperty(ref this.users, value);
    }


    private static string GenerateUserName()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
    }

}

