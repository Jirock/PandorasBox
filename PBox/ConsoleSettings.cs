using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace PandoraQk
{
    public class ConsoleSettings
    {
        public static void ConsoleSettingsMenu()
        {
            Console.Clear();
            //Инфа для консоли
            Console.WriteLine(new string('*', 7) + "Настройки консоля" + new string('*', 7) + "\n\n");
            Console.WriteLine(new string('-', 7) + "Меню" + new string('-', 7));
            Console.WriteLine("--Выберите операцию\n--(1)Настройка заднего фона\n--(2)Настройка текста\n--(3)Настройка окна\n--(4)Назад");
            //Вызываем операции
            ConsoleSettings Choose = new ConsoleSettings();
            Choose.MenuChoose();

        }

        #region Операции
        private void MenuChoose()
        {
            //Ввод команды
            byte Choice = byte.Parse(Console.ReadLine());
            CheckChooseException Check = new CheckChooseException(Choice, 4);

            switch (Choice)
            {
                //Настройка заднего фона
                case 1:
                    CSBackground();
                    break;
                //Настройка цвета текста
                case 2:
                    CSFont();
                    break;
                //Настройка ширины и высоты окна
                case 3:
                    CSWindow();
                    break;
                //Выгоняет прочь обратно к главному боссу.
                case 4:
                    Program.Choose();
                    break;
            }
        }
        #endregion

        #region Настройка цвета заднего фона 
        private void CSBackground()
        {
            Console.Clear();
            //Инфа для консоли
            Console.WriteLine(new string('*', 7) + "Задний фон" + new string('*', 7));
            Console.WriteLine("--Изменить цвет заднего фона на:\n--(1)Белый\n--(2)Черный\n--(3)Зеленый\n--(4)Синий\n--(5)Красный\n--(6)Назад");
            
            //Ввод команды
            byte OperationNum = byte.Parse(Console.ReadLine());
            //Контроша зорко чекает
            CheckChooseException Check = new CheckChooseException(OperationNum, 6);
            switch (OperationNum)
            {
                //Белый цвет
                case 1:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    goto default;
               
                //Черный цвет
                case 2:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    goto default;

                //Зеленый цвет
                case 3:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Green;
                    goto default;

                //Синий цвет
                case 4:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    goto default;

                //Красный цвет
                case 5:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    goto default;

                //Направляет в сторону меню
                case 6:
                    ConsoleSettingsMenu();
                    break;

                //Возвращает нас к настройке заднего фона
                default:
                    CSBackground();
                    break;
            }
        }
        #endregion

        #region Настройка цвета текстов
        private void CSFont()
        {
            Console.Clear();
            //Инфа для консоли
            Console.WriteLine(new string('*', 7) + "Текст" + new string('*', 7));
            Console.WriteLine("--Изменить цвет текста на:\n--(1)Синий\n--(2)Зеленый\n--(3)Красный\n--(4)Назад");
            //Ввод команды
            byte OperationNum = byte.Parse(Console.ReadLine());
            //Контролер контрошит
            CheckChooseException Check = new CheckChooseException(OperationNum, 4);

            switch (OperationNum)
            {
                //Синий цвет
                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    goto default;

                //Зеленый цвет
                case 2:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    goto default;

                //Красный цвет
                case 3:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    goto default;

                //Направляет в меню
                case 4:
                    ConsoleSettingsMenu();
                    break;

                //Продолжает работу до тех пор не выбран команда назад
                default:
                    CSFont();
                    break;
            }
        }
        #endregion

        #region Настройка высоты и ширины окна
        private void CSWindow()
        {
            Console.Clear();
            //Инфа для консоли
            Console.WriteLine(new string('*', 7) + "Окно" + ('*', 7));
            Console.WriteLine("--Выберите операцию\n--(1)Изменение размера окна\n--(2)Назад");
            
            //Ввод команды
            byte OperationNum = byte.Parse(Console.ReadLine());
            
            //Контролер не спит, а я хачу квас
            CheckChooseException Check = new CheckChooseException(OperationNum, 3);
            switch (OperationNum)
            {
                case 1:
                    Console.Clear();
                    //Инфа для консоли
                    Console.WriteLine(new string('*', 7) + "Консоль" + new string('*', 7));
                    Console.WriteLine("Введите ширину(Макс. ширина 200)");
                    
                    //Ввод ширины окна
                    byte Width = byte.Parse(Console.ReadLine());
                    
                    //Ввод высоты окна
                    Console.WriteLine("Введите высоту(Макс. высота 51)");
                    byte Height = byte.Parse(Console.ReadLine());

                    //Благодаря введенным значениям меняется окно вау, мэджик.
                    Console.SetWindowSize(Width, Height);
                    goto default;

                //Направляет в меню
                case 2:
                    ConsoleSettingsMenu();
                    break;

                //Продолжаете работу до тех пор пока не прозвучит команда НАЗАД!
                default:
                    CSWindow();
                    break;
            }
        }
        #endregion
    }
}
