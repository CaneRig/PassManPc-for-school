using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PasManPC.Core
{
    internal class FileSystem: IDisposable
    {
        public const int MaxVersionCount = 3;
       // private string _fileName;
        private string _ufilePath;
        private FileStream _fs;

        public bool Opened => _fs != null;

        public FileSystem(string hash)
        {
            if (hash == "")
                throw new ArgumentException("bad hash");

            _ufilePath = Path.Combine(Settings.UserDataFile, hash);
        }
        ~FileSystem()
        {
            try
            {
                _fs?.Flush();
                _fs?.Close();

                _fs.Dispose();
            }catch(Exception e)
            {

            }
        }


        #region File operations
        public void Create()
        {
            checkUserDirectory();

            if (File.Exists(_ufilePath))
                throw new Exceptions.UserFileAlredyExistsException();
            if (Directory.Exists(_ufilePath))
                throw new Exceptions.DirectoryInsreardOfUserFileException();

            _fs = File.Create(_ufilePath);
        }
        public void Open()
        {
            checkUserDirectory();

            if (!File.Exists(_ufilePath))
                throw new Exceptions.UserFileNotExist();

            _fs = File.Open(_ufilePath, FileMode.Open);
        }


        public void Write(byte[] data)
        {
            checkStreamOpen();

            _fs.Write(data, 0, data.Length);
        }
        public void Clear()
        {
            checkStreamOpen();

            _fs.SetLength(0);
        }
        public byte[] ReadAll()
        {
            checkStreamOpen();

            _fs.Seek(0, SeekOrigin.Begin);

            byte[] raw = new byte[_fs.Length];

            using (var reader = new BinaryReader(_fs))
            {
                reader.Read(raw, 0, raw.Length);
            }

            return raw;
        }
        
        public static void Delete(string user)
        {
            File.Delete(Path.Combine(Settings.UserDataFile, user));
        }
        
        #endregion

        public static bool IsThereUser(string name)
        {
            return File.Exists(Path.Combine(Settings.UserDataFile, name));
        }

        private void checkUserDirectory()
        {
            if (!Directory.Exists(Settings.UserDataFile))
                Directory.CreateDirectory(Settings.UserDataFile);
        }
        private void checkStreamOpen()
        {
            if (!Opened) throw new Exceptions.FileNotOpenedException();
        }

        public void Dispose()
        {
            ((IDisposable)_fs)?.Dispose();
        }
    }
}

/*
    [NAME]
    [NAME]_cp[id]
    */