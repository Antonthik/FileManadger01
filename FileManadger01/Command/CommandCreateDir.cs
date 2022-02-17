using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManadger.Command
{
    public class CommandCreateDir : FileManadgerCommads
    {
        public CommandCreateDir()
        {
            Name = "CreateDir";
            Discription = "Создание директории";
            CommandMask = "[crdir] [путь назначения]";
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
                if (new DirectoryObj(commandArr[1]).Exist == false)
                {
                    try
                    {
                        Directory.CreateDirectory(commandArr[1]);
                        Console.Write("Директория успешно создана.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при создании директории.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }


                }
                else
                {
                    Console.Write("Ошибка, директория уже существует.Нажмите Enter для продолжения.");
                    Console.ReadLine();
                }
            }
        }
    }
}
