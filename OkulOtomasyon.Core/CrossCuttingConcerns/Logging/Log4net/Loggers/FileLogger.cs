using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Layouts;

namespace OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Loggers
{
    public class FileLogger : LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger("JsonFileLogger"))
        {

        }
    }
}
