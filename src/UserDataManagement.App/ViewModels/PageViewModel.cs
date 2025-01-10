using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using UserDataManagement.App.ViewModels;

namespace UserDataManagement.App.ViewModels;

public class PageViewModel : ViewModelBase
{
    private readonly Type? contentType;
    private readonly object? dataContext;
    private object? _content;
    private ScrollBarVisibility _horizontalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto;
    private ScrollBarVisibility _verticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto;
    private Thickness _marginRequirement = new(16);

    public PageViewModel(string name, string kind, Type? contentType, object? dataContext = null)
    {
        this.Kind = kind;
        this.Name = name;
        this.contentType = contentType;
        this.dataContext = dataContext;

    }

    public string Name { get; }
    public string Kind { get; }

    public IEnumerable<object>? Documentation { get; }

    public object? Content => _content ??= CreateContent();

    public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement
    {
        get => _horizontalScrollBarVisibilityRequirement;
        set => SetProperty(ref _horizontalScrollBarVisibilityRequirement, value);
    }

    public ScrollBarVisibility VerticalScrollBarVisibilityRequirement
    {
        get => _verticalScrollBarVisibilityRequirement;
        set => SetProperty(ref _verticalScrollBarVisibilityRequirement, value);
    }

    public Thickness MarginRequirement
    {
        get => _marginRequirement;
        set => SetProperty(ref _marginRequirement, value);
    }

    private object? CreateContent()
    {
        var content = Activator.CreateInstance(this.contentType);
        if (this.dataContext != null && content is FrameworkElement element)
        {
            element.DataContext = this.dataContext;
        }

        return content;
    }
}