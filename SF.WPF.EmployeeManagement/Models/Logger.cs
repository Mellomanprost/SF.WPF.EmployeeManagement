using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SF.WPF.EmployeeManagement.Models
{
    class Logger : ILogger
    {
        private ReaderWriterLockSlim _lock;

        private string _logDirectory { get; set; }

        public Logger()
        {
            _logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" +
                            DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

            if (!Directory.Exists(_logDirectory))
                Directory.CreateDirectory(_logDirectory);
        }

        public void WriteEvent(string eventMessage)
        {
            _lock.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(_logDirectory + "events.txt", append: true))
                {
                    writer.WriteLine(eventMessage);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void WriteError(string errorMessage)
        {
            _lock.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter("errors.txt", append: true))
                {
                    writer.WriteLine(errorMessage);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
