using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManadger.Command
{
  public class CommandPageMove : FileManadgerCommads
    {
        public CommandPageMove()
        {
            Name = "MovePage";
            Discription = "Открытие страницы";
            CommandMask = "[page] [номер страницы отсчет с нуля]";
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
                int num;
                bool isNum = int.TryParse(commandArr[1], out num);

                if (isNum)
                {
                    Program.CurrentPage = num;
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
