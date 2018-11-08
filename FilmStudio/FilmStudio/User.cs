using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class User
    {
        public int UserID;
        public string Name, Username, Passkey;
        public bool IsAdmin;

        public User()
        {
            UserID = 9211;
            Name = "Shakaib Saleem";
            Username = "shakaib";
            Passkey = "admin";
            IsAdmin = false;
        }

        public User(int userID, string name, string username, string passkey, bool isAdmin)
        {
            UserID = userID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Passkey = passkey ?? throw new ArgumentNullException(nameof(passkey));
            IsAdmin = isAdmin;
        }
    }
}
