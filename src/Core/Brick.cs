using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasManPC.Core
{
    public class Brick
    {
        private const string _passwordBase = "123456789";
        private string _name = "", _login = "";
        private byte[] _password = new byte[0];

        public string Name
        {
            get => _name;
            set
            {
                string oldpas = Password;
                _name = value;
                Password = oldpas;
            }
        }
        public string Login { get => _login; set => _login = value; }
        public string Password {
            get => Security.Crypting.b2s_Aes( _password, Security.Hash.Sha256Bin(_name), Security.Hash.Sha256Bin(Security.Hash.Sha256(_name)+ _name));
            set => _password = Security.Crypting.s2b_Aes(value, Security.Hash.Sha256Bin(_name), Security.Hash.Sha256Bin(Security.Hash.Sha256(_name) + _name));
        }

        public Brick(string name, string login="", string password="")
        {
            Name = name;
            Login = login;
            Password = password;
        }

        public override int GetHashCode() => Name.GetHashCode();

        public static bool operator ==(Brick lhs, Brick rhs) => (lhs.Name == rhs.Name) && (lhs.Password == rhs.Password) && (lhs.Login == rhs.Login);
        public static bool operator !=(Brick lhs, Brick rhs) => !(lhs.Name == rhs.Name) && (lhs.Password == rhs.Password) && (lhs.Login == rhs.Login);
    }
}
