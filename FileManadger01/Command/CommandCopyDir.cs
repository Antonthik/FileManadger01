using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManadger.Command
{
    public class CommandCopyDir : FileManadgerCommads

    {
        public CommandCopyDir()
        {
            Name = "CopyDir";
            Discription = "Копирование папки";
            CommandMask ="[copydir] [путь источника],[путь назначения]";
        }

        public override void RunComm()
        {
            string[] commandArr = Program.CommandStr.Split('|');//извлекаем путь из командной строки



            if (commandArr.Length != 3)
            {
                Console.Write("Ошибка параметров команды.Нажмите Enter для продолжения.");
                Console.ReadLine();
            }
            else
            {
                if (new DirectoryObj(commandArr[1]).Exist == true )
                {
                    //Program.CurrentDirectory = new DirectoryObj(commandArr[1]);
                    
                    
                    
                    try
                    {
                        CopyDir(commandArr[1], commandArr[2]);
                        Console.Write("Папка успешно скопирован.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {

                        Console.Write("Ошибка копирования.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                   
                    Program.Display();
                }
                else
                {
                    Console.Write("Ошибка, файл не существует.Нажмите Enter для продолжения.");
                    Console.ReadLine();
                }

            }
        }

        /// <summary>
        /// Копирование директории методом рекурсии
        /// </summary>
        /// <param name="FromDir"></param>
        /// <param name="ToDir"></param>
        private void CopyDir(string FromDir,string ToDir)
        {
           var ToDirectory= Directory.CreateDirectory(ToDir);
            //var fromDirectory = new DirectoryObj(FromDir).EnumerateFiles();

            foreach (var files in new DirectoryObj(FromDir).EnumerateFiles())
            {
                files.CopyTo(ToDirectory.FullName+"\\"+ files.Name);
            }

            foreach (var dir in new DirectoryObj(FromDir).EnumerateDirectories())
            {
                CopyDir(dir.FullName, ToDirectory.FullName+"\\"+dir.Name);
            }

        }
    }
}
