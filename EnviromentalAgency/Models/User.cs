namespace EnviromentalAgency.Models;

internal class User
{
    public string user_id { get; set; }
    public DateTime update_datetime {get; set;}
    public string forename { get; set; }
    public string surname { get; set; }
    public string email {get; set;}

    public string role {get; set;}

    public User()
    {
        user_id = "";
        update_datetime = DateTime.Now;
        forename = "";
        surname = "";
        email = "";
        role = "";
    }

    public void Save() =>
    File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, ""), "");

    public void Delete() =>
        File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, ""));

    public static User Load(string userId)
    {
        userId = System.IO.Path.Combine(FileSystem.AppDataDirectory, userId);

        if (!File.Exists(userId))
            throw new FileNotFoundException("Unable to find file on local storage.", userId);

        return
            new()
            {
                //Filename = Path.GetFileName(filename),
                //Text = File.ReadAllText(filename),
                //Date = File.GetLastWriteTime(filename)
            };
    }

    public static IEnumerable<User> LoadAll()
    {
        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        return Directory

                // Select the file names from the directory
                .EnumerateFiles(appDataPath, "*.notes.txt")

                // Each file name is used to load a note
                .Select(filename => User.Load(Path.GetFileName(filename)))

                // With the final collection of notes, order them by date
                .OrderByDescending(user => user.user_id);
    }
}
