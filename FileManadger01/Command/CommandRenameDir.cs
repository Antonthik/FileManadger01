using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
    class CommandRenameDir : FileManadgerCommads
    {
        public CommandRenameDir()
        {
            Name = "RenameDirectory";
            Discription = "Переименование папки";
            CommandMask = "[redir] [путь источника],[новое имя]";
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
                if (new DirectoryObj(commandArr[1]).Exist == true && commandArr[2]!="")
                {
                    try
                    {
                        var dir = new DirectoryObj(commandArr[1]);
                        var Path = dir.FullName.Replace(dir.Name,"");
                        dir.Rename(Path + "\\" + commandArr[2]);
                        Console.Write("Папка успешно переименована.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.Write("Ошибка при переименовании папки.Нажмите Enter для продолжения.");
                        Console.ReadLine();
                    }


                }
                else
                {
                    Console.Write("Ошибка, папка не существует.Нажмите Enter для продолжения.");
                    Console.ReadLine();
                }
            }
        }
    }
}
