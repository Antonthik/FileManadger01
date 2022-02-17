using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
    class CommandDeleteDir : FileManadgerCommads
    {
        public CommandDeleteDir()
        {
            Name = "DeleteDirectory";
            Discription = "Удаление папки";
            CommandMask = "[deldir] [путь источника]";
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
                if (new DirectoryObj(commandArr[1]).Exist == true)
                {
                    try
                    {
                        var dir = new DirectoryObj(commandArr[1]);
                        dir.Delete();
                        Console.Write("Папка успешно удалена.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при удалении папки.Нажмите Enter для продолжения.");
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
