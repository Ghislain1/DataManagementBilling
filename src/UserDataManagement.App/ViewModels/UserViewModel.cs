using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataManagement.Models;

namespace UserDataManagement.App.ViewModels;

public class UserViewModel : ViewModelBase
{
    private bool isSelected;
    private string? code;
    private string name = string.Empty;
    private string email = string.Empty;
    private string? description;
    public User Model { get; }
    public UserViewModel(string name, string email)
    {
        this.Model = new User();
        this.Email = email;
        this.Name = name;
    }
    public string? Description
    {
        get => this.description ?? " Descrption to do ";
        set => this.SetProperty(ref this.description, value);
    }
    public string? Code
    {
        get => this.code;
        set => this.SetProperty(ref this.code, value);
    }
    public string Name
    {
        get => this.name;
        set
        {
            if (this.SetProperty(ref this.name, value))
            {
                this.Model.Name = value;
                this.Code = value.Substring(0, 1).ToUpper();
            }
        }
    }
    public string Email
    {
        get => this.email;
        set
        {
            if (this.SetProperty(ref this.email, value))
            {
                this.Model.Email = value;
            }
        }
    }
    public bool IsSelected
    {
        get => this.isSelected;
        set => this.SetProperty(ref this.isSelected, value);
    }
}

