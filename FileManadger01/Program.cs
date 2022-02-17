using System;
using System.Collections.Generic;
using System.IO;
using FileManadger.Command;
using System.Linq;

namespace FileManadger
{
    class Program
    {
        public static DirectoryObj CurrentDirectory { get; set; }//Текущая директория
        public static FileObj CurrentFile { get; set; }//Текущий файл
        public static string CommandStr { get; set; }//Командная строка
        public static DriveInfo[] Drives { get; set; }//Список директорий
        public static int CurrentPage { get; set; }//Текущая страница
        public static Dictionary<string, FileManadgerCommads> Commands { get; set; }//Словарь команд

        static void Main(string[] args)
        {
            CurrentPage = 0;//страница
            CurrentDirectory = new DirectoryObj(@"C:\");//директория по умолчанию
            //string fileinfo = "";
            //Словарь объктов команд
            Commands = new Dictionary<string, FileManadgerCommads>()
                {
                    {"drv",new CommandDrives()}, 
                    {"dir",new CommandOpenDir()},
                    {"copy",new CommandCopyFile()},
                    {"crdir",new CommandCreateDir()},
                    {"crfile",new CommandCreateFile()},
                    {"delfile",new CommandDeleteFile()},
                    {"deldir",new CommandDeleteDir()},
                    {"copydir",new CommandCopyDir()},
                    {"redir",new CommandRenameDir()},
                    {"refile",new CommandRenameFile()},
                    {"movedir",new CommandMoveDir()},
                    {"movefile",new CommandMoveFile()},
                    {"page",new CommandPageMove()},
                    {"ffile",new CommandFindeFile()},
                    {"sdir",new CommandSizeFolder()}
                };
            
            Commands["drv"].RunComm();
           
            

            while (true)
            {
                Console.Clear();//чистка экрана
                Display();//Отрисовка экрана
                Console.Write("введите команду:");
                string input = Console.ReadLine();
                input = input.Trim();               
                var commandArr = input.Split(' ');

                //Выход из программы по запросу пользователя
                if (input == "exit")
                {
                    return;
                }
                else if (commandArr[0] != "")
                {
                    if (!Commands.TryGetValue(commandArr[0], out var command))
                    {
                        Console.WriteLine($"Неизвестная команда. Для помощи посмотрите - help");
                        Console.ReadLine();
                    }
                    else
                    {
                        CommandStr = ControlFormatComm(input,command);
                        command.RunComm();                        
                    }

                    // commadSelect(input, ref page, ref infofile, ref workDir);//селектор команд
                    //CurrentPage = page;
                    // param0.CurrentPuth = workDir;
                    // serial_json(param0, "param.json");//запись параметров программы


                }
            }

        }
        

        /// <summary>
        /// Метод отрисовки окон
        /// </summary>
        public static void Display()
        {
         
            int j = 0;
            int k = 0;
            int n = 0;
            string helpstr = "";
            string directstr = "";
            var arrDirect = CurrentDirectory.GetPage();
           // var arrComm = Program.Commands;
            int count = arrDirect.Length;

            // Формируем список и массив команд для листа хелпа. 
            List<string> listComm = new List<string>();
            foreach (var d in Program.Commands)
            {
                var str = $"{d.Key}{new string(' ',8 - d.Key.Length)} {d.Value.Discription} -> {d.Value.CommandMask}";
                listComm.Add(str);
            }
            var arrComm = listComm.ToArray();

            if (count >= 0)
            {
                j = 0;
                //k = 0;
                //Console.WriteLine(new string((char)205'-',90));
                String line1 = ($"{'\u2554'}{new string('\u2550', 75)}{'\u2557'}{'\u2554'}{new string('\u2550', 75)}{'\u2557'}");
                String line3 = ($"{'\u255a'}{new string('\u2550', 75)}{'\u255d'}{'\u255a'}{new string('\u2550', 75)}{'\u255d'}");
                String line4 = ($"{'\u2554'}{new string('\u2550', 152)}{'\u2557'}");
                String line5 = ($"{'\u255a'}{new string('\u2550', 152)}{'\u255d'}");

                string[] lineInfo =
                    {"команда cf - копирование файла",
                     "команда cd - копирование директории",
                     "команда rd - удаление директории",
                     "команда rd - удаление директории",
                     "команда rf - удаление файла",
                     "команда file - информация файла",
                     "команда pg - перелистование дерева",
                     "команда nd - выбор новой директории",
                     "команда fold - информация папки"};


                //Рисуем окно дисков
                Console.WriteLine((line4));
                Console.WriteLine(ConstructStr("Drives:","", 4));
                foreach (var d in Program.Drives)
                {
                    Console.WriteLine(ConstructStr($"Name:{d.Name} Lable:{d.VolumeLabel} Format:{ d.DriveFormat} Total:{ d.TotalSize/1024/1024}Mb FreeSpace:{ d.TotalFreeSpace / 1024 / 1024}Mb" ,"", 4));
                }
                Console.WriteLine((line5));

                //основная область
                Console.WriteLine((line1));
                Console.WriteLine(ConstructStr(CurrentDirectory.FullName,"Help information:",0));

                for (int i = 0; i < 40; i++)
                {
                    if (i >= 0 && i <= 30)
                    {
                        //if (j <= arrDirect.Length - 1)
                        //{
                            if (n <= arrComm.Length - 1)
                                helpstr = arrComm[n];
                            else
                                helpstr = "";

                            if (j <= arrDirect.Length - 1)
                                directstr = arrDirect[j];
                            else
                                directstr = "";


                        Console.WriteLine(ConstructStr(directstr, helpstr, 1));//строка с данными
                            j++;
                            n++;
                           
                            
                        //}
                        //else
                        //{
                        //    Console.WriteLine(ConstructStr("","", 1));//пустая строка
                        //}

                    }

                    if (i == 31)
                    {                       
                        Console.WriteLine((line3));
                        //Console.WriteLine((line4));
                    }

                    if (i ==31)
                    {
                        //Console.WriteLine((line2));
                        //int hhh = fileinfo.Length;
                        //Console.WriteLine($"{'\u2551'}{fileinfo}{new string(' ', 150 - (fileinfo.Length))}{'\u2551'}");//строка с данными
                        //Console.WriteLine($"{ConstructStr(fileinfo, 4)}");
                    }

                    //if (i >= 32 && i <= 39) 
                    //{ 
                    //    Console.WriteLine($"{ConstructStr(lineInfo[k],"", 4)}");
                    //    k++;
                    //}
                    


                }
                        //Console.WriteLine((line5));
            }
        }
        /// <summary>
        /// Метод конструирования строк интерфейса
        /// </summary>
        /// <param name="strwin1 - данные первого окна"></param>
        /// <param name="strwin2-данные второго окна"></param>
        /// <param name="numberwin - тип строки"></param>
        /// <returns></returns>
        static string ConstructStr(string strwin1, string strwin2,int numberwin)
        {
            string strnew = "";
            string str = "";
            string str1 = "";
            switch (numberwin)
            {
                case 0:
                    if (strwin1 != "") str = $"{strwin1}";
                    if (strwin2 != "") str1 = $"{strwin2}";
                    strnew = $"{'\u2551'}{str}{new string(' ', 75 - str.Length)}{'\u2551'}{'\u2551'}{str1}{new string(' ', 75 - str1.Length)}{'\u2551'}";
                    break;
                case 1:                    
                    if (strwin1 != "") str = $"  |-->{strwin1}";
                    if (strwin2 != "") str1 = $"{strwin2}";
                    strnew = $"{'\u2551'}{str}{new string(' ', 75 - str.Length)}{'\u2551'}{'\u2551'}{str1}{new string(' ', 75 - str1.Length)}{'\u2551'}";
                    break;
                case 4:
                    if (strwin1 != "") str = $"{strwin1}";
                    strnew = $"{'\u2551'}{str}{new string(' ', 152 - str.Length)}{'\u2551'}";
                    break;
            }

            return strnew;//строка с данными

        } 
        ///Проверка синтаксиса и адаптация комадной строки
        //Для обхода ошибок связанных с именами директорий содержащих пробелы
        static string ControlFormatComm(string instr,FileManadgerCommads Сommads)
        {
            string strout = "";
            var mask = Сommads.CommandMask.Replace("[","").Replace("]","") ;//убираем скобки
            var arr = mask.Split(" ");
            var comm = arr[0];//имя команды 

            var str = instr.Replace(comm, "");//убираем команду из строки
                                              
            var arrParam = str.Split(",").Select(str=>str.Trim()).ToArray();

            if (instr.Contains(',')==true && mask.Contains(',') == true)
            {
                if (arrParam.Length == 2) 
                    strout = string.Concat(comm, "|", arrParam[0], "|", arrParam[1]);               
            }                
            if ( instr.Contains(',') == false && mask.Contains(',') == false)
                strout = comm + "|" + str.Trim();
            return strout;
        }
    }
}
