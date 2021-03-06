﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    public class User
    {
        public string ID, Name, Username, Passkey;
        public bool IsAdmin;

        public User()
        {
            ID = "1";
            Name = "FName LName";
            Username = "";
            Passkey = "password";
            IsAdmin = false;
        }

        public User(string userID, string name, string username, string passkey, bool isAdmin)
        {
            ID = userID ?? throw new ArgumentNullException(nameof(userID));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Passkey = passkey ?? throw new ArgumentNullException(nameof(passkey));
            IsAdmin = isAdmin;
        }
    }
}
