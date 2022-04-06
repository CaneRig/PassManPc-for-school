using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PasManPC.Core.Extention;


namespace PasManPC.Core.Util
{
    public static class BinOperations
    {
        public static byte[] String2Bin(string str)
        {
            MemoryStream stream = new MemoryStream();

            stream.Append(str.Length);
            stream.Append(str);

            return stream.ToArray();
        }
        public static byte[] Brick2Bin(Brick b)
        {
            MemoryStream stream = new MemoryStream();

            stream.Append(String2Bin(b.Name));

            stream.Append(String2Bin(b.Login));

            byte[] key = Security.Hash.Sha256Bin(b.Login);
            byte[] iv = Security.Hash.Sha256Bin(Security.Hash.Sha256(b.Login) + b.Login);
            var pass = Security.Crypting.s2b_Aes(b.Password, key, iv);

            stream.Append(pass.Length);
            stream.Append(pass);

            return stream.ToArray();
        }

        public static int ReadString(byte[] input, int start, out string res)
        {
            int counter = 4;

            int length = BitConverter.ToInt32(input, start);

            res = Encoding.Default.GetString(input, start+4, length);

            counter += length;

            return counter;
        }
        public static int ReadInt32(byte[] input, int start, out int res)
        {
            res = BitConverter.ToInt32(input, start);

            return 4;
        }
        public static Brick[] ReadBricks(byte[] bt)
        {
            List<Brick> bricks = new List<Brick>();

            int pos = 0;

            while (pos < bt.Length)
            {
                string name, login, pass;

                pos += Util.BinOperations.ReadString(bt, pos, out name);
                pos += Util.BinOperations.ReadString(bt, pos, out login);

                {
                    int len;
                    pos += Util.BinOperations.ReadInt32(bt, pos, out len);

                    byte[] arr = bt.SubArray(pos, len);

                    pos += len;

                    byte[] key = Security.Hash.Sha256Bin(login);
                    byte[] iv = Security.Hash.Sha256Bin(Security.Hash.Sha256(login) + login);
                    pass = Security.Crypting.b2s_Aes(arr, key, iv);
                }

                bricks.Add(new Brick(name, login, pass));
            }

            return bricks.ToArray();
        }

        public static byte[] WriteBricks(Brick[] br)
        {
            MemoryStream stream = new MemoryStream();

            foreach (var item in br)
                stream.Append(Util.BinOperations.Brick2Bin(item));

            return stream.ToArray();
        }
    }
}
