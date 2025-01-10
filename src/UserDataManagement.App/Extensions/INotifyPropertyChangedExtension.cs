using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UserDataManagement.App.Extensions;
public static class INotifyPropertyChangedExtension
{
    // public event PropertyChangedEventHandler PropertyChanged;

    public static void OnPropertyChanged(this INotifyPropertyChanged self, PropertyChangedEventHandler PropertyChanged, [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(self, new PropertyChangedEventArgs(propertyName));
    }
}

