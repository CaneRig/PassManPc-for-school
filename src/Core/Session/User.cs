using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PasManPC.Core.Extention;


namespace PasManPC.Core.Session
{
    public class User
    {
        private readonly string _password;
        private readonly string _userName;

        public string UserName => _userName;

        public User(string login, string password)
        {

            _password = Security.Hash.Sha256(password);
            _userName = HashLogin(login);

            if (!FileSystem.IsThereUser(_userName))
                throw new Core.Exceptions.NoUserException();
        }


        public byte[] Crypt(byte[] bt)
        {
            var key = Security.Hash.Sha256Bin(_password);
            var iv = Security.Hash.Sha256Bin(_password + Security.Hash.Sha256(_password));

            return Security.Crypting.Bin_AesEncrypt(bt, key, iv);
        }
        public byte[] Decrypt(byte[] bt)
        {
            var key = Security.Hash.Sha256Bin(_password);
            var iv = Security.Hash.Sha256Bin(_password + Security.Hash.Sha256(_password));

            return Security.Crypting.Bin_AesDecrypt(bt, key, iv);
        }
        public Brick[] ReadData()
        {
            Brick[] vr = null;
            using (Core.FileSystem fs = new FileSystem(_userName))
            {
                fs.Open();

                byte[] bt = fs.ReadAll();

                if (bt.Length == 0)
                    return new Brick[0];

                bt = Decrypt(bt);

                vr = Util.BinOperations.ReadBricks(bt);
            }
            return vr;
        }

        public static string HashLogin(string login) => Security.Hash.Sha256(login);
    }
}
