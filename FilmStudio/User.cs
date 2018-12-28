using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class User
    {
        public string UserID, Name, Username, Passkey;
        public bool IsAdmin;

        public User()
        {
            UserID = "1";
            Name = "Shakaib Saleem";
            Username = "shakaib";
            Passkey = "admin";
            IsAdmin = true;
        }

        public User(string userID, string name, string username, string passkey, bool isAdmin)
        {
            UserID = userID ?? throw new ArgumentNullException(nameof(userID));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Passkey = passkey ?? throw new ArgumentNullException(nameof(passkey));
            IsAdmin = isAdmin;
        }
    }
}
