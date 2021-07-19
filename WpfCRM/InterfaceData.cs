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
    interface ILogWriter
    {
        string PathCreator();
        void LogWrite(string login);
    }
    interface IDataProcessor
    {
        void InterfaceData(InterfaceData interfaceData);
    }
}
