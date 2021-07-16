using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCRM
{
    interface InterfaceData
    {
        List<Users> GetUsers();
    }
    interface IFileWriter
    {
        void FileWrite(string login);
    }
    interface IDataProcessor
    {
        void InterfaceData(InterfaceData interfaceData);
    }
}
