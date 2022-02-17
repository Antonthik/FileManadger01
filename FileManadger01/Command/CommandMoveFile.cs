using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
    class CommandMoveFile : FileManadgerCommads
    {
        public CommandMoveFile()
        {
            Name = "MoveFile";
            Discription = "Перемещение файла";
            CommandMask = "[movefile] [путь источника],[путь назначения]";
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
                if (new FileObj(commandArr[1]).Exist == true && new FileObj(commandArr[2]).Exist == false)
                {
                    try
                    {
                        var file = new FileObj(commandArr[1]);
                        //var Path = file.FullName.Replace(file.Name,"");
                        file.Move(commandArr[2]);
                        Console.Write("Файл успешно перемещен.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при перемещении файла.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }


                }
                else
                {
                    Console.Write("Ошибка, исходная файл не существует или целевой файл уже существует.Нажмите Enter для продолжения.");
                    Console.ReadLine();
                }
            }
        }
    }
}
