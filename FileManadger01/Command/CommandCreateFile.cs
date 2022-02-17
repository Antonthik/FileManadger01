using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManadger.Command
{
    class CommandCreateFile : FileManadgerCommads
    {
        public CommandCreateFile()
        {
            Name = "CreateFile";
            Discription = "Создание файла";
            CommandMask = "[crfile] [путь назначения]";
        }

        public override void RunComm()
        {
            string[] commandArr = Program.CommandStr.Split('|');//извлекаем путь из командной строки

            if (commandArr.Length != 2)
            {
                Console.Write("Ошибка параметров команды.Нажмите Enter для продолжения.");
                Console.ReadLine();
            }
            else
            {
                if (new FileObj(commandArr[1]).Exist == false)
                {
                    try
                    {
                      File.Create(commandArr[1]);
                        Console.Write("Файл успешно создан.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при создании файла.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }


                }
                else
                {
                    Console.Write("Ошибка, файл уже существует.Нажмите Enter для продолжения.");
                    Console.ReadLine();
                }
            }
        }
    }
}
