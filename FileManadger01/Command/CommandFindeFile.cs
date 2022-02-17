using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
   public class CommandFindeFile : FileManadgerCommads
    {
        public CommandFindeFile()
        {
            Name = "FindeFile";
            Discription = "Поиск файла по маске";
            CommandMask = "[ffile] [имя файла с маской]";
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
                FindeF(Program.CurrentDirectory.FullName, FilesList, commandArr[1]);
                foreach(var f in FilesList)
                {
                    Console.WriteLine(f);
                }
                Console.Write("Поиск завершен.Нажмите Enter для продолжения.");
                Console.ReadLine();
                Program.Display();
              
            }


             void FindeF(string PathDir, List<string>FilesList,string mask)
            {

                foreach (var dir in new DirectoryObj(PathDir).EnumerateDirectories())
                {
                    var files = new DirectoryObj(PathDir).EnumerateFiles(mask);
                    foreach (var f in files)
                    {
                        FilesList.Add(f.FullName);
                    }

                    try
                    {
                        FindeF(dir.FullName, FilesList, mask);
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
