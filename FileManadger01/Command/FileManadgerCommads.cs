using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
    public abstract class FileManadgerCommads
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string CommandMask { get; set; }

      
        public abstract void RunComm();

    }
}
