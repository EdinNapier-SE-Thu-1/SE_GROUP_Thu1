using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EnviromentalAgency.ViewModels;

internal class UserViewModel : ObservableObject, IQueryAttributable
{
    private Models.User _user;

    public string user_id
    {
        get => _user.user_id;
        set
        {
            if (_user.user_id != value)
            {
                _user.user_id = value;
                OnPropertyChanged();
            }
        }
    }

    public string forename => _user.forename;

    public string surname => _user.surname;

    public ICommand SaveCommand { get; private set; }
    public ICommand DeleteCommand { get; private set; }

    public UserViewModel()
    {
        _user = new Models.User();
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    public UserViewModel(Models.User user)
    {
        _user = user;
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    private async Task Save()
    {
        _user.user_id = "";
        _user.Save();
        await Shell.Current.GoToAsync($"..?saved={_user.user_id}");
    }

    private async Task Delete()
    {
        _user.Delete();
        await Shell.Current.GoToAsync($"..?deleted={_user.user_id}");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            _user = Models.User.Load(query["load"].ToString());
            RefreshProperties();
        }
    }

    public void Reload()
    {
        _user = Models.User.Load(_user.user_id);
        RefreshProperties();
    }

    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(user_id));
        OnPropertyChanged(nameof(user_id));
    }
}
