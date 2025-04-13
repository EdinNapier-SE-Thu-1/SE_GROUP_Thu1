/*using CommunityToolkit.Mvvm.Input;
using Notes.Database.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnviromentalAgency.ViewModels;

internal class UsersViewModel : IQueryAttributable
{
    public ObservableCollection<ViewModels.UserViewModel> AllUsers { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectUserCommand { get; }

    public UsersViewModel()
    {
        AllUsers = new ObservableCollection<ViewModels.UserViewModel>(Models.User.LoadAll().Select(n => new UserViewModel(n)));
        NewCommand = new AsyncRelayCommand(NewUserAsync);
        SelectUserCommand = new AsyncRelayCommand<ViewModels.UserViewModel>(SelectUserAsync);
    }

    private async Task NewUserAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.UserPage));
    }

    private async Task SelectUserAsync(ViewModels.UserViewModel user)
    {
        if (user != null)
            await Shell.Current.GoToAsync($"{nameof(Views.UserPage)}?load={user.user_id}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string userId = query["deleted"].ToString();
        UserViewModel matchedUser = AllUsers.Where((n) => n.user_id == userId).FirstOrDefault();

        // If note exists, delete it
        if (matchedUser != null)
            AllUsers.Remove(matchedUser);
    }
    else if (query.ContainsKey("saved"))
    {
        string userId = query["saved"].ToString();
        UserViewModel matchedUser = AllUsers.Where((n) => n.user_id == userId).FirstOrDefault();

        // If note is found, update it
        if (matchedUser != null)
        {
            matchedUser.Reload();
            AllUsers.Move(AllUsers.IndexOf(matchedUser), 0);
        }
        // If note isn't found, it's new; add it.
        else
            AllUsers.Insert(0, new UserViewModel(Models.User.Load(userId)));
    }
}

}
*/