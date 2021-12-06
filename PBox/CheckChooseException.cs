using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraQk
{
    //Это исключение которое будет когда нужно будет сделать выбор.

    class CheckChooseException
    {
        //ChooseNum это выбранная число, ChooseLenght это кол-во выборов.
        public CheckChooseException(byte ChooseNum, byte ChooseLenght)
        {
            //Вы введете только команды которые имеются в указанном диапазоне не меньше не больше не пусто, иначе это штуковина заорет
            if (ChooseNum > ChooseLenght || ChooseNum < 1 || string.IsNullOrWhiteSpace(Convert.ToString(ChooseNum)))
            {
                Console.Beep();
                throw new ArgumentException("Номер выбранной операции должна соответствовать номеру операции и не должна выйти за пределы");
            }
            //Выведет пустоту XD
            else { Console.WriteLine(); }
        }
    }
}
