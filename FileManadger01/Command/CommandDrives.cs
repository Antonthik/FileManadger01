using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManadger.Command
{
    class CommandDrives : FileManadgerCommads
    {
        public CommandDrives()
        {
            Name = "GetDrives";
            Discription = "Вывод дисков";
            CommandMask = "[copydir] [путь источника],[путь назначения]";
        }

        public override void RunComm()
        {
            var Drives = DriveInfo.GetDrives();
            Program.Drives = Drives;

        }
    }
}
