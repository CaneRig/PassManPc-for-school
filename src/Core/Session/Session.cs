using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasManPC.Core.Extention;

namespace PasManPC.Core.Session
{
    public class Session: IEnumerable<KeyValuePair<string, Brick>>
    {
        private Dictionary<string, Brick> _data;
        private User user;

        public string UserHash => user.UserName;

        public Session(User _user)
        {
            user =_user;
            _data = new Dictionary<string, Brick>();

            var brs = _user.ReadData();

            foreach (var item in brs)
            {
                _data.Add(item.Name, item);
            }
        }

        public void Save()
        {
            using (FileSystem fs = new FileSystem(user.UserName))
            {
                fs.Open();
                fs.Clear();

                var bin = Util.BinOperations.WriteBricks(getBricks());
                var crypted = user.Crypt(bin);

                fs.Write(crypted);
            }
        }

        #region Container
        public Brick this[string name]
        {
            get => _data[name];
            set => _data[name] = value;
        }

        public bool Contains(string name) => _data.ContainsKey(name);

        public void Add(Brick b)
        {
            if (Contains(b.Name))
                throw new ArgumentException("Creating element with existing name");
            _data.Add(b.Name, b);
        }
        public void Remove(Brick b) => _data.Remove(b.Name);
        public void Rename(string newName, string oldName)
        {
            _data[oldName].Name = newName;
            _data.RenameKey(oldName, newName);
        }
        #endregion


        private Brick[] getBricks()
        {
            Brick[] bricks = new Brick[_data.Count];
            int size = 0;

            foreach (var item in _data)
            {
                bricks[size++] = item.Value;
            }

            return bricks;
        }

        public IEnumerator<KeyValuePair<string, Brick>> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
