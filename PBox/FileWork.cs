using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PandoraQk
{
    class FileWork
    {
        //Место где будет происходить работы с файлами, кароче путь
        private static string FileBox = @"..\..\Files";
        //Название папки
        private static string FileName;

        //Переключатель 
        public static void FileMenu()
        {
            Console.Clear();
            //Инфа для консоли
            Console.WriteLine(new string('*', 7) + "Работа с файлами" + new string('*', 7) + "\n\n");
            Console.WriteLine(new string('-', 7) + "Меню" + new string('-', 7));
            Console.WriteLine("На данный момент из за ограничений навыков в области разработки, могу лишь предоставить работу с файлами с расширением .txt");
            Console.WriteLine("--Выберите операцию\n--(1)Создать файл\n--(2)Вывести данные о файле\n--(3)Удалить файл\n--(4)Узнать содержимое файла\n--(5)Ввести данные в файл\n--(6)Назад");
            
            //Выборка, кароче выбираешь команду
            byte Choose = byte.Parse(Console.ReadLine());
            //Контроша, доблестно следит за порядком.
            CheckChooseException Check = new CheckChooseException(Choose, 6);
            switch (Choose)
            {
                //Создание файла
                case 1:
                    CreateFile();
                    break;

                //Тут чтобы клиенту было удобно, я переместил часть кода сюда, чтобы он ввел название файла лишь раз, а не +100500 раз.
                //Вывод данных о файле
                case 2:                    
                    Console.Clear();
                    DirectoryInfo dir = new DirectoryInfo(FileBox);
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        Console.WriteLine("Файл: " + file);
                    }
                    Console.WriteLine("Введите название файла(без расширения)");
                    FileName = Console.ReadLine();
                    AboutFile();
                    break;
                //Удаление файла
                case 3:
                    DeleteFile();
                    break;
                //Содержимое файла
                case 4:
                    InsideFile();
                    break;
                //Добавить текст в файле
                case 5:
                    AddinFile();
                    break;
                //Уходим к начале
                case 6:
                    Program.Choose();
                    break;
            }
        }

        #region 5 Ввести данные в файл
        private static void AddinFile()
        {
            Console.Clear();
            Console.WriteLine("Файлы:");
            //Вывод списка файлов
            DirectoryInfo dir = new DirectoryInfo(FileBox);
            foreach (FileInfo files in dir.GetFiles())
            {
                Console.WriteLine(files);
            };

            //Вводите имя файла
            Console.WriteLine("Введите название файла где нужно внести данные(без расширения)");
            FileName = Console.ReadLine();
            
            //Вводите то чего хотите ввести в файл
            Console.WriteLine("Введите то чего хотите ввести в файл(только текст)");
            string TextForFile = Console.ReadLine();
            
            //Вводит написанный вами текст в файл
            using (StreamWriter sr = new StreamWriter(FileBox + "\\" + FileName + ".txt", true))
            {
                sr.WriteLine(TextForFile);
            }

            //Тут кароче снова выборка, если выберете 1 то вы продолжите ввести данные в файл, иначе прогонит вон! 
            Console.WriteLine("Все успешно завершилось, хотите продолжить?\n(1)Да\n(2)Нет");
            byte Choose = byte.Parse(Console.ReadLine());
            CheckChooseException Check = new CheckChooseException(Choose, 2);
            switch (Choose)
            {
                case 1:
                    AddinFile();
                    break;
                case 2:
                    FileMenu();
                    break;
            }
        }
#endregion

        #region 4 Узнать содержимое файла
        private static void InsideFile()
        {
            Console.Clear();
            Console.WriteLine("Файлы:");
            //Вывод в консоли списка файлов
            DirectoryInfo dir = new DirectoryInfo(FileBox);
            foreach (FileInfo files in dir.GetFiles())
            {
                Console.WriteLine(files);
            }

            Console.WriteLine("Введите имя файла чтобы ее открыть");
            //Ввод названии файла
            FileName = Console.ReadLine();

            //Чекаем на корректность ввода
            if (string.IsNullOrWhiteSpace(FileName))
            {
                InsideFile();
            }
            else
            {
                //Запускает файл вроде на блокноте.
                System.Diagnostics.Process.Start(FileBox + "\\" + FileName + ".txt");
            }

            Console.WriteLine("Хотите продожить?\n(1)Да\n(2)Нет");
            //Выборка команды
            byte Choose = byte.Parse(Console.ReadLine());
            //Контрошит жестко Симпл в ахуе
            CheckChooseException Check = new CheckChooseException(Choose, 2);
            switch (Choose)
            {
                case 1:
                    InsideFile();
                    break;
                case 2:
                    FileMenu();
                    break;
            }
        }
        #endregion

        #region 3 Удаление файла
        private static void DeleteFile()
        {
            Console.Clear();

            //Вывод список файлов
            DirectoryInfo dir = new DirectoryInfo(FileBox);
            foreach (FileInfo files in dir.GetFiles())
            {
                Console.WriteLine(files);
            }
            //Инфа для консоли
            Console.WriteLine("Введитe название файла которую хотите удалить");
            //Ввод названии файла.
            FileName = Console.ReadLine();
            //Путь шобы уничтожить файл
            string Path = $"{FileBox}\\{FileName}.txt";
            //Удаляет файл
            File.Delete(Path);

            Console.WriteLine(new string('.', 3) + "Файл удален" + new string('.', 3) + "\nНажмите чтобы продолжить");
            Console.ReadLine();
            FileMenu();
        }
        #endregion

        #region 2 Данные о файле
        private static void AboutFile()
        {
            Console.Clear();
            //Инфа для консоли
            Console.WriteLine(new string('*', 3) + "Что вы хотите узнать?" + new string('*', 3));
            Console.WriteLine("(1) Дата последнего доступа к файлу\n(2) Размер файла\n(3) Путь к файлу\n(4) Имя файла\n(5) Дата создания файла\n(6) Назад");
            
            //Выбор команды
            byte Choose = byte.Parse(Console.ReadLine());
            //Контроша ужасен... просто курам на смех
            CheckChooseException Check = new CheckChooseException(Choose, 6);

            //Цикл который ищет 
            foreach (string findFile in Directory.EnumerateFiles(FileBox + "\\", FileName + ".txt", SearchOption.AllDirectories))
            {
                FileInfo FI = new FileInfo(findFile);

                switch (Choose)
                {
                    case 1:
                        Console.WriteLine("Дата последнего доступа к файлу: " + FI.LastAccessTime);
                        goto default;
                    case 2:
                        Console.WriteLine("Размер файла: " + FI.Length);
                        goto default;
                    case 3:
                        Console.WriteLine("Путь к файлу: " + FI.FullName);
                        goto default;
                    case 4:
                        Console.WriteLine("Имя файла: " + FI.Name);
                        goto default;
                    case 5:
                        Console.WriteLine("Дата создания файла " + FI.CreationTime);
                        goto default;
                    case 6:
                        FileMenu();
                        break;
                    default:
                        Console.WriteLine("\nНажмите чтобы продолжить");
                        Console.ReadLine();
                        AboutFile();
                        break;
                }
            }
        }
        #endregion

        #region 1 Создание файла
        private static void CreateFile()
        {
            Console.Clear();
            //Инфа для консоли
            Console.WriteLine("Введите название файла");
            
            //Ввод имени файла
            FileName = Console.ReadLine();

            //Всякие условия чтобы исключить клиентские пакости
            if (string.IsNullOrWhiteSpace(FileName) || FileName.Length < 1 || FileName.Length > 50)
            {
                throw new ArgumentNullException(nameof(FileName));
            }
            
            //Переменная которая запоминает путь
            string Path = $"{FileBox}\\{FileName}.txt";
            //Создает файл по пути
            using (File.Create(Path)) { }
            //Опять инфа для консоли
            Console.WriteLine("Файл создан\n\nНажмите Enter чтобы вернуться");
            Console.ReadLine();
            //Выгоняет прочь сотону!
            FileMenu();
        }
        #endregion

    }
}
