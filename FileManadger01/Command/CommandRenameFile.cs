using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
    class CommandRenameFile : FileManadgerCommads
    {
        public CommandRenameFile()
        {
            Name = "RenameFile";
            Discription = "Переименование файла";
            CommandMask = "[refile] [путь источника],[новое имя]";
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
                if (new FileObj(commandArr[1]).Exist == true && commandArr[2]!="")
                {
                    try
                    {
                        var file = new FileObj(commandArr[1]);
                        var Path = file.FullName.Replace(file.Name,"");
                        file.Rename(Path + "//" + commandArr[2]);
                        Console.Write("Файл успешно переименована.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при переименовании файла.Нажмите Enter для продолжения.");
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
