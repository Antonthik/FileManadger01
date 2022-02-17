using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
   public class CommandSizeFolder : FileManadgerCommads
    {
        public CommandSizeFolder()
        {
            Name = "SizeFolder";
            Discription = "Определение размера текущей папки";
            CommandMask = "[sdir]";
        }

        public override void RunComm()
        {             
            string[] commandArr = Program.CommandStr.Split('|');//извлекаем путь из командной строки
            
            if (commandArr.Length != 2)
            {
                Console.Write("Ошибка параметров команды.Нажмите Enter для продолжения.");
                Console.ReadLine();
            } else
            {

                //Program.CurrentDirectory = new DirectoryObj(commandArr[1]);
                //var files = Program.CurrentDirectory.EnumerateFiles(commandArr[1]);
                List<string> FilesList = new List<string>();
                double sum=0;
                FindeF(Program.CurrentDirectory.FullName, ref sum);

               
                Console.Write($"Размер папки:{sum} байт.Нажмите Enter для продолжения.");
                Console.ReadLine();
                Program.Display();
              
            }


             void FindeF(string PathDir,ref double s)
            {
                var files = new DirectoryObj(PathDir).EnumerateFiles();
                var sumdir = files.Sum(f => f.Size);
                s += sumdir;

                foreach (var dir in new DirectoryObj(PathDir).EnumerateDirectories())
                {
                    try
                    {
                        FindeF(dir.FullName,ref s);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                   
                   
                    
                }

                

            }











        }
    }
}
