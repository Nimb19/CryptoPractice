using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using HelpfulLibrary;

namespace CryptoFormula
{
    public static partial class CryptoFormula
    {
        /// <summary>
        /// Формула Эйлера для нахождения мультипликативно обратных элементов. 
        /// Если не будет решения, то придёт null.
        /// </summary>
        public static BigInteger? ФормулаЭйлера(int module, int num, out List<int> divisorsList, out Exception exception)
        {
            exception = null;
            divisorsList = module.РазложитьНаПростыеМножители();

            if (divisorsList.Count == 1)
                return num.ВозвестиВСтепень(module - 2) % module;
            else
            {
                if (divisorsList.Distinct().Count() == divisorsList.Count())
                    return num.ВозвестиВСтепень(divisorsList.Select(x => x -= 1).Aggregate((x, y) => x * y) - 1);
                else
                {
                    exception = new Exception($"Нет решения. Множители повторяются. ");
                    return null;
                }
            }
        }

        /// <summary>
        /// Алгоритм Евклида для нахождения мультипликативно обратных элементов. Если решения не было, то будет возвращён null. 
        /// Так же, в этом случае будет выведена подробная информация о ошибке в переменную Exception.
        /// </summary>
        /// <param name="exception"> Подробности об ошибке, если была. </param>
        public static BigInteger? АлгоритмЕвклида(int module, int num, out Exception exception)
        {
            exception = null;
            (int? ЧислоНапротивЕдиницы, bool? БылЛиМинусНапротивЕдиницы) result = (null, null);

            var leftList = new Dictionary<(int, int), int>();
            var rightList = new List<int>() { 0, 1 };
            int i = 0;

            { // Ввод данных в алгоритм
                i++;
                leftList.Add((module, num), module % num);
                rightList.Add(module / num * rightList.Last() + rightList[rightList.Count - 2]);
                if (leftList.Last().Value == 1) result = (rightList.Last(), i % 2 == 1);
            }

            while (leftList.Last().Value != 0)
            {
                i++;
                var currLeftItem = leftList.Last().Key.Item2;
                var currRightItem = leftList.Last().Value;
                leftList.Add((currLeftItem, currRightItem), currLeftItem % currRightItem);
                rightList.Add((currLeftItem / currRightItem) * rightList.Last() + rightList[rightList.Count - 2]);

                if (leftList.Last().Value == 1) result = (rightList.Last(), i % 2 == 1);
            }

            if (module != rightList.Last())
            { 
                exception = new Exception($"Число напротив нуля не сошлось с {nameof(module)}: {module} != {rightList.Last()}");
                return null;
            }

            if (result.ЧислоНапротивЕдиницы == null)
            {
                exception = new Exception($"Не было единицы: {leftList.Values.JoinToString()}");
                return null;
            }

            if (result.БылЛиМинусНапротивЕдиницы == false)
                return result.ЧислоНапротивЕдиницы;
            else
                return module - result.ЧислоНапротивЕдиницы;
        }
    }
}
