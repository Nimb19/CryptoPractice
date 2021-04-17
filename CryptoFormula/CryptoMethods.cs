using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using HelpfulLibrary;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary
{
    public static partial class CryptoFormula
    {
        /// <summary>
        /// Формула Эйлера для нахождения мультипликативно обратных элементов. 
        /// Если не будет решения, то придёт null.
        /// </summary>
        /// <param name="solutionError"> Подробности об ошибке, если была. </param>
        public static BigInteger? ФормулаЭйлера(WrappedInteger module, WrappedInteger num, out List<int> divisorsList, out string solutionError)
        {
            solutionError = null;
            divisorsList = module.РазложитьНаПростыеМножители();

            if (divisorsList.Count == 1)
                return num.ВозвестиВСтепень(module - 2) % module;
            else
            {
                if (divisorsList.Distinct().Count() == divisorsList.Count())
                    return num.ВозвестиВСтепень(divisorsList.Select(x => x -= 1).Aggregate((x, y) => x * y) - 1);
                else
                {
                    solutionError = $"Нет решения. Множители повторяются.";
                    return null;
                }
            }
        }

        /// <summary>
        /// Алгоритм Евклида для нахождения мультипликативно обратных элементов. Если решения не было, то будет возвращён null. 
        /// Так же, в этом случае будет выведена подробная информация о ошибке в переменную solutionError.
        /// </summary>
        /// <param name="solutionError"> Подробности об ошибке, если была. </param>
        public static BigInteger? АлгоритмЕвклида(WrappedInteger module, WrappedInteger num, out string solutionError)
        {
            solutionError = null;
            (BigInteger? ЧислоНапротивЕдиницы, bool? БылЛиМинусНапротивЕдиницы) result = (null, null);

            var leftList = new Dictionary<(BigInteger, BigInteger), BigInteger>();
            var rightList = new List<BigInteger>() { 0, 1 };
            int i = 0;

            { // Ввод данных в алгоритм
                i++;
                leftList.Add((module.Value, num.Value), module % num);
                rightList.Add(module / num * rightList.Last() + rightList[rightList.Count - 2]);
                if (leftList.Last().Value == 1) 
                    result = (rightList.Last(), i % 2 == 1);
            }

            while (leftList.Last().Value != 0)
            {
                i++;
                var currLeftItem = leftList.Last().Key.Item2;
                var currRightItem = leftList.Last().Value;
                leftList.Add((currLeftItem, currRightItem), currLeftItem % currRightItem);
                rightList.Add((currLeftItem / currRightItem) * rightList.Last() + rightList[rightList.Count - 2]);

                if (leftList.Last().Value == 1) 
                    result = (rightList.Last(), i % 2 == 1);
            }

            if (module != rightList.Last())
            { 
                solutionError = $"Модуль не сошёлся с числом напротив нуля: {module} != {rightList.Last()}.";
                return null;
            }

            if (result.ЧислоНапротивЕдиницы == null)
            {
                solutionError = $"В левом списке не было единицы.";
                return null;
            }

            if (result.БылЛиМинусНапротивЕдиницы == false)
                return result.ЧислоНапротивЕдиницы;
            else
                return module - result.ЧислоНапротивЕдиницы;
        }
    }
}
