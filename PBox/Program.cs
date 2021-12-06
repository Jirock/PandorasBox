using System;

// Господа прошу прощения если вы блеванули увидев мой код, я тоже угощал монитор моего компа блевотиной, когда узрел синтаксис php.
// Ну чтож это типо консольная программа которая работает с файлами
// Выполняет самые минимальные действия, перемещения, переименование не получится, возможно когда я отращу бороду как у Льва Толстого, я сделаю это, или когда будет время а то колледж жрет время ААААА!!!

namespace PandoraQk
{
    class Program
    {
        //Название проекта извините за кривость
        public const string ProjectTitle = "Pandora's box";
        public static void Main(string[] args)
        {
            //Я новичок не бейте :(
            //Знал бы как правильно реализовать сделал бы как вы.
            Choose();
        }

        public static byte Choose()
        {
            //Название проекта
            Console.Title = ProjectTitle;
            Console.Clear();
            
            //Инфа для консоли.
            Console.WriteLine(new string('*', 7) + $"{ProjectTitle}" + new string('*', 7) + "\n\n");
            Console.WriteLine(new string('-', 7) + "Меню" + new string('-', 7));
            Console.WriteLine("--Выберите операцию\n--(1)Настройки консоля\n--(2)Работа с файлами\n--(3)Выход");
            
            //Выборка кароче выбираешь команду
            byte Choice = byte.Parse(Console.ReadLine());
            //Это контроллер который будет контрошить за вводом, еще раз извиняюсь за кривую реализацию
            CheckChooseException a = new CheckChooseException(Choice, 3);

            //Вот собственно штукенции в ходе выбора мы попадаем.
            switch (Choice)
            {
                case 1:
                    ConsoleSettings.ConsoleSettingsMenu();
                    break;
                case 2:
                    FileWork.FileMenu();
                    break;
            }

            return Choice;
        }


    }
}


