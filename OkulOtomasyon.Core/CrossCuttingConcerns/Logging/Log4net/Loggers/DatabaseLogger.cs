using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
