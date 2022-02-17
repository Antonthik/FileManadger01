using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
    
namespace FileManadger.Command
{
    public class CommandPrintFiles : FileManadgerCommads
    {
        //public DirectoryInfo[] Files { get; set; }
        //public string PathFile { get; set; }


        public CommandPrintFiles()
        {
            Name = "PrintFiles";
            Discription = "Вывод файлов текущей папки";            
        }

        public override void RunComm()
        {
            //string PathFiles = "";
            var dir = new DirectoryObj(Program.CurrentDirectory.FullName);
            //Program.CurrentDirectoryFiles = dir.GetFiles();
            //Program.CurrentDirectoryFolders = dir.GetDirectories();
            //return Files;       
        }


    }
}
