using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCRM.DataModels;

namespace WpfCRM
{
    interface InterfaceData
    {
        List<User> GetUsers();
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
