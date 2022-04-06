using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasManPC.Core.Exceptions
{
    [Serializable]
    public class UserFileNotExist : System.Exception
    {
        public UserFileNotExist(): base("User file is not existing") { }
    }


    [Serializable]
    public class UserFileAlredyExistsException : Exception
    {
        public UserFileAlredyExistsException(): base("User already exists") { }
    }


    [Serializable]
    public class DirectoryInsreardOfUserFileException : Exception
    {
        public DirectoryInsreardOfUserFileException(): base("Trying to open userfile but insteard of file there is directory") { }
    }

    [Serializable]
    public class FileNotOpenedException : Exception
    {
        public FileNotOpenedException(): base("File not opened") { }
    }


    [Serializable]
    public class NoUserException : Exception
    {
        public NoUserException(): base("There is no user") { }
    }
}
