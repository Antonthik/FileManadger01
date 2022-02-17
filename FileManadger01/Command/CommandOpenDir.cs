using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
   public class CommandOpenDir : FileManadgerCommads
    {
        public CommandOpenDir()
        {
            Name = "OpenDir";
            Discription = "Открытие папки";
            CommandMask = "[dir] [путь источника]";
        }

        public override void RunComm()
        {             
            string[] commandArr = Program.CommandStr.Split('|');//извлекаем путь из командной строки
            
            if (commandArr.Length != 2)
            {
                Console.Write("Ошибка параметров команды.Нажмите Enter для продолжения.");
                Console.ReadLine();
            } else
            {
               if (new DirectoryObj(commandArr[1]).Exist == true)
                {
                    Program.CurrentDirectory = new DirectoryObj(commandArr[1]);
                    Program.Display();
                }
                else
                {
                    Console.Write("Ошибка, директория не существует.Нажмите Enter для продолжения.");
                    Console.ReadLine();
                }                
            }



            


             




        }
    }
}
