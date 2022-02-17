using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManadger.Command
{
    public class CommandCopyFile : FileManadgerCommads

    {
        public CommandCopyFile()
        {
            Name = "CopyFile";
            Discription = "Копирование файла";
            CommandMask = "[copy] [путь источника],[путь назначения]";
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
                if (new FileObj(commandArr[1]).Exist == true )
                {
                    //Program.CurrentDirectory = new DirectoryObj(commandArr[1]);
                    Program.CurrentFile = new FileObj(commandArr[1]);
                    try
                    {
                        Program.CurrentFile.CopyTo(commandArr[2]);
                        Console.Write("Файл успешно скопирован.Нажмите Enter для продолжения.");
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
    }
}
