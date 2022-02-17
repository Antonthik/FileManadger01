using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
    class CommandMoveDir : FileManadgerCommads
    {
        public CommandMoveDir()
        {
            Name = "MoveDirectory";
            Discription = "Перемещение папки";
            CommandMask = "[movedir] [путь источника],[путь назначения]";
        }
        /// <summary>
        /// Переименование папки, указываем путь исходящей папки и новое имя
        /// </summary>
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
                if (new DirectoryObj(commandArr[1]).Exist == true && new DirectoryObj(commandArr[2]).Exist == false)
                {
                    try
                    {
                        var dir = new DirectoryObj(commandArr[1]);
                        //var Path = dir.FullName.Replace(dir.Name,"");
                        dir.Move(commandArr[2]);
                        Console.Write("Папка успешно перемещена.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при перемещении папки.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }


                }
                else
                {
                    Console.Write("Ошибка, исходная папка не существует или целевая папка уже существует.Нажмите Enter для продолжения.");
                    Console.ReadLine();
                }
            }
        }
    }
}
