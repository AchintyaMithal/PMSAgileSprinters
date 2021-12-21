using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Models
{
    public interface ILoggerManager
    {
        public void LogInformation(string message);
    }
}
