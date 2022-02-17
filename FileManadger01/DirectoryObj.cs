using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManadger
{
   public class DirectoryObj: FileSystemItemObj
    {
        private readonly DirectoryInfo _Directory;
        public string Name=>_Directory.Name;
        public string Extension=>_Directory.Extension;
        public bool Exist => _Directory.Exists;
        public string FullName => _Directory.FullName;

        public FileAttributes Attribute => _Directory.Attributes;





        public DirectoryObj(string PathFolder) : this(new DirectoryInfo(PathFolder))//Передаем второму конструктору вновь созданный объект из первого
        {

        }

        public DirectoryObj(DirectoryInfo Directory)//Второй конструктор
        {
            _Directory = Directory;        
        }

        

        public DirectoryInfo[] GetDirectories(string Mask=null)
        {
            if (Mask is null)
                return _Directory.GetDirectories();
            else
                return _Directory.GetDirectories(Mask);
        }

        public FileInfo[] GetFiles(string Mask = null)
        {
            if (Mask is null)
                return _Directory.GetFiles();
            else
                return _Directory.GetFiles(Mask);
        }

        
        /// <summary>
        /// Используем перечисления для ускорения чтения директорий в директории
        /// </summary>
        /// <param name="Mask"></param>
        /// <returns></returns>
        public IEnumerable <DirectoryObj> EnumerateDirectories(string Mask = null)
        {
            //if (Mask is null)
            //    return _Directory.EnumerateDirectories();
            //else
            //    return _Directory.EnumerateDirectories(Mask);

            var files = Mask is null
                 ? _Directory.EnumerateDirectories()
                 : _Directory.EnumerateDirectories(Mask);

            foreach (var directory in files)
                //yield return (DirectoryObj)directory;
                yield return new DirectoryObj(directory);
        }

        /// <summary>
        ///  Используем перечисления для ускорения чтения файлов в директории
        /// </summary>
        /// <param name="Mask"></param>
        /// <returns></returns>
        public IEnumerable <FileObj> EnumerateFiles(string Mask = null)
        {
            //if (Mask is null)
            //    return _Directory.EnumerateFiles();
            //else
            //    return _Directory.EnumerateFiles(Mask);

            if (Mask is null)
                return _Directory.EnumerateFiles().Select(file => new FileObj(file));
             else   
                return _Directory.EnumerateFiles(Mask).Select(file => new FileObj(file));
        }

        public IEnumerable<FileSystemItemObj> EnumerateContent(string Mask = null)
        {
            //if (Mask is null)
            //    return _Directory.EnumerateFileSystemInfos();

            //return _Directory.EnumerateFileSystemInfos(Mask);

            var items = Mask is null
                ? _Directory.EnumerateFileSystemInfos()
                : _Directory.EnumerateFileSystemInfos(Mask);

            foreach (var item in items)
                switch (item)
                {
                    case FileInfo file:
                        yield return new FileObj(file);
                        break;

                    case DirectoryInfo dir:
                        yield return new DirectoryObj(dir);
                        break;
                }


        }
        /// <summary>
        /// Формируем список директорий и файлов в массив
        /// </summary>
        /// <returns></returns>
        public string[] GetPage()
        {
            List<string> PageList = new List<string>();
            int Size = 30;
            int Take = Program.CurrentPage* Size;
            var FSObj = Program.CurrentDirectory.EnumerateContent();
            var arrFSObj = FSObj.Skip(Take).Take(Size).ToArray();

            foreach (var dir in arrFSObj)

            {
                if (dir is DirectoryObj)
                {
                    var d = (DirectoryObj)dir; 
                    var str = $"{ConstructStr(d.Name,30)} <DIR> {ConstructStr("", 5)}    {ConstructStr($"{d.Attribute}", 23)}";                   
                    PageList.Add(str);
                }
                else
                {
                    var d = (FileObj)dir;                    
                    var str = $"{ConstructStr(d.Name, 30)} <file> {ConstructStr($"{d.Size/1024/1024}",5)}MB {ConstructStr($"{d.Attribute}",23)}";
                    PageList.Add(str);
                }
            }
           ;
            return PageList.ToArray();
        }

        // public static implicit operator DirectoryInfo(DirectoryObj model) => model._Directory;
        // public static explicit operator DirectoryObj(DirectoryInfo dir) => new DirectoryObj(dir);
        private string ConstructStr(string str,int size)
        {
            if (str.Length > size) str = str.Substring(0,size-1);
            
            var newstr = $"{str}{new string(' ', size - str.Length)}";
            return newstr;
        }
        public void Delete()
        {
            try
            {
                _Directory.Delete(true);
            }
            catch (Exception)
            {
                // throw new Exception("Ошибка пр");
                Console.Write("Ошибка при удалении");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Для переименования папки используем перемещение.
        /// </summary>
        /// <param name="destDirName - путь переименованной папки"></param>
        public void Rename(string destDirName)
        {
            try
            {
                _Directory.MoveTo(destDirName);
            }
            catch (Exception)
            {
                // throw new Exception("Ошибка пр");
                Console.Write("Ошибка при переименовании");
                Console.ReadLine();
            }
        }

        public void Move(string destDirName)
        {
            try
            {
                _Directory.MoveTo(destDirName);
            }
            catch (Exception)
            {
                // throw new Exception("Ошибка пр");
                Console.Write("Ошибка при перемещении");
                Console.ReadLine();
            }
        }
        public double Size(string PathDir, double s)
        {

                foreach (var dir in new DirectoryObj(PathDir).EnumerateDirectories())
                {
                    var files = new DirectoryObj(PathDir).EnumerateFiles();
                    s = s + files.Sum(f => f.Size);

                    Size(dir.FullName, s);
                }

            return s;

        }


    }
}

