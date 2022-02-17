using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileManadger
{
   public class FileObj: FileSystemItemObj
    {
        private FileInfo _File;
        public string Name => _File.Name;
        public string Extension => _File.Extension;
        public string FullName => _File.FullName;
        public bool Exist => _File.Exists;
        public double Size => _File.Length;

        public FileAttributes  Attribute => _File.Attributes;

        
        public FileObj(string PathFile) : this(new FileInfo(PathFile))//Передаем второму конструктору вновь созданный объект из первого
        {

        }

        public FileObj(FileInfo File)//Второй конструктор
        {
            _File = File;
        }

        public void CopyTo(string FileD) 
        {
            try
            {
                _File.CopyTo(FileD);
            }
            catch (Exception)
            {

                // throw new Exception("Ошибка пр");
                Console.WriteLine("Ошибка при копировании");
                Console.ReadLine();
            }

        }
        public void Delete()
        {
            try
            {
                _File.Delete();
            }
            catch (Exception)
            {
                // throw new Exception("Ошибка пр");
                Console.Write("Ошибка при удалении");
                Console.ReadLine();
            }
        }
        public void Rename(string destFileName)
        {
            try
            {
                _File.MoveTo(destFileName);
            }
            catch (Exception)
            {
                // throw new Exception("Ошибка пр");
                Console.Write("Ошибка при переименовании");
                Console.ReadLine();
            }
        }
        public void Move(string destFileName)
        {
            try
            {
                _File.MoveTo(destFileName);
            }
            catch (Exception)
            {
                // throw new Exception("Ошибка пр");
                Console.Write("Ошибка при переименовании");
                Console.ReadLine();
            }
        }

    }
}
