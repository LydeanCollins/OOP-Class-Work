using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Presentation
{
    public class Logging
    {
        public void Log(Exception ex, string messaage)
        {
            System.IO.File.WriteAllText("log.txt",DateTime.Now.ToString("dd/MM/yyyy HH:mm:") + ", Custome Message: " + messaage + ", Generated Message: " + ex.Message);
        }
    }
}
