using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WpfCRM
{
    class LogWriter : IFileWriter
    {
        public void FileWrite(string login)
        {
            DataBaseProcessor dataBase = new DataBaseProcessor();
            string date = DateTime.Now.ToShortDateString().Replace("/","-");
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Log " + date + ".txt" ), false,Encoding.Default))
            {
                foreach (Users item in dataBase.GetUsers())
                {
                    if (login == item.Login)
                    {
                        streamWriter.WriteLine(item.Name + " " + item.Surname + " : " + item.Login + "\t" + DateTime.Now.ToShortTimeString());
                    }
                }

            }
        }
    }
}
