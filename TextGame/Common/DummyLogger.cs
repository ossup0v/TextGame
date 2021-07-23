using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Common
{
    public class DummyLogger : ILogger
    {
        public void Log(string message)
        {
			Console.WriteLine(message);
        }
    }
}
