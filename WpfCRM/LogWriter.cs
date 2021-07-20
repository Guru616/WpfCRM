using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WpfCRM.DataModels;

namespace WpfCRM
{
    class LogWriter : ILogWriter
    {
        public string PathCreator()
        {
            string dirName = "Logs";
            string logdir = Path.Combine(Environment.CurrentDirectory, dirName);
            string date = DateTime.Now.ToShortDateString().Replace("/", "-");
            string logpath = Path.Combine(Environment.CurrentDirectory, "Log " + date + ".txt");

            if (Directory.Exists(logdir))
            {
                return logpath = Path.Combine(Path.Combine(Environment.CurrentDirectory, dirName), "Log " + date + ".txt");
            }
            else
            {
                Directory.CreateDirectory(logdir);
                return logpath = Path.Combine(Path.Combine(Environment.CurrentDirectory, dirName), "Log " + date + ".txt");
            }
        }
        public void LogWrite(string login)
        {
            DataBaseProcessor dataBase = new DataBaseProcessor();
            using (StreamWriter streamWriter = new StreamWriter(PathCreator(), true, Encoding.Default))
            {
                foreach (User item in dataBase.GetUsers())
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
