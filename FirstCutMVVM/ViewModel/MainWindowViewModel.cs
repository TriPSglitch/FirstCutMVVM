using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using FirstCutMVVM.Models;
using ReactiveUI;

namespace FirstCutMVVM.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ReactiveCommand<DataGrid, Unit> UsersListOnDoubleTapped { get; }
    public ReactiveCommand<Window, Unit> AddUserButtonClick { get; }
    public ReactiveCommand<DataGrid, Unit> CountriesListOnDoubleTapped { get; }
    public ReactiveCommand<Window, Unit> AddCountryButtonClick { get; }

    public MainWindowViewModel()
    {
        this.UsersListOnDoubleTapped = ReactiveCommand.Create<DataGrid>(UsersListOnDoubleTappedRealization);
        this.AddUserButtonClick = ReactiveCommand.Create<Window>(AddUserButtonClickRealization);
        this.CountriesListOnDoubleTapped = ReactiveCommand.Create<DataGrid>(CountriesListOnDoubleTappedRealization);
        this.AddCountryButtonClick = ReactiveCommand.Create<Window>(AddCountryButtonClickRealization);
    }

    public void OnPropertyChanged([CallerMemberName] string property = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    private List<User> usersList;

    public List<User> UsersList
    {
        get { return usersList; }
        set
        {
            usersList = value;

            OnPropertyChanged();
        }
    }

    private string userCheque;

    public string UserCheque
    {
        get { return userCheque; }
        set
        {
            userCheque = value;

            OnPropertyChanged();
        }
    }

    private List<Country> countriesList;

    public List<Country> CountriesList
    {
        get { return countriesList; }
        set
        {
            countriesList = value;

            OnPropertyChanged();
        }
    }

    private string countryCheque;

    public string CountryCheque
    {
        get { return countryCheque; }
        set
        {
            countryCheque = value;

            OnPropertyChanged();
        }
    }

    private void UsersListOnDoubleTappedRealization(DataGrid usersGrid)
    {
        try
        {
            if (usersGrid.SelectedItem != null)
            {
                User user = usersGrid.SelectedItem as User;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void AddUserButtonClickRealization(Window window)
    {
        try
        {
            UserCheque = "прикол";
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void CountriesListOnDoubleTappedRealization(DataGrid countriesGrid)
    {
        try
        {
            if (countriesGrid.SelectedItem != null)
            {
                Country country = countriesGrid.SelectedItem as Country;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void AddCountryButtonClickRealization(Window window)
    {
        try
        {
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}