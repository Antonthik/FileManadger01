using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
    class CommandDeleteFile : FileManadgerCommads
    {
        public CommandDeleteFile()
        {
            Name = "DeleteFile";
            Discription = "Удаление файла";
            CommandMask = "[delfile] [путь источника]";
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
                if (new FileObj(commandArr[1]).Exist == true)
                {
                    try
                    {
                        var file = new FileObj(commandArr[1]);
                        file.Delete();
                        Console.Write("Файл успешно удален.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при удалении файла.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }


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
