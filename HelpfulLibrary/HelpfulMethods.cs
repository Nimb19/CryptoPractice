using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpfulLibrary
{
    public static class HelpfulMethods
    {
        private static Random _random = new Random();

        /// <summary>
        /// Создаёт коллекцию указанного типа и инициализирует string и integer свойства.
        /// </summary>
        public static IEnumerable<T> GenerateCollection<T>(int count = 4) 
            where T : new()
        {
            for (int i = 1; i <= count; i++)
                yield return new T().InitStringAndIntProps(i);
        }

        /// <summary>
        /// Возвращает список символов от стартового и до конечного из таблицы. Например алфавит от a до z.
        /// </summary>
        public static IEnumerable<char> FromTo(char start, char end)
        {
            for (int i = start; i <= end; i++)
                yield return (char)i;
        }

        /// <summary>
        /// Приводит коллекцию в строку и соединяет эти строки указанным разделителем.
        /// </summary>
        public static string JoinToString<T>(string separator = "; ", params T[] list) =>
            string.Join(separator, list.Select(x => x.ToString()));

        /// <summary>
        /// Если класс ссылочный, то в первом параметре будет ссылка на второй, второй будет Json копией первого, не факт что все связи останутся
        /// </summary>
        public static void SwapValues<T>(ref T left, ref T right)
        {
            var leftCopy = left;
            left = right;
            right = leftCopy;
        }

        public static string GetRandomName(Random random = null)
        {
            var names = Enum.GetNames(typeof(Names));
            return names[(random ?? _random).Next(0, names.Length - 1)];
        }
    }

    enum Names 
    {
        Bula       ,
        Lida       ,
        Soledad    ,
        Earle      ,
        Burl       ,
        Garland    ,
        Arden      ,
        Brittny    ,
        Marilu     ,
        Junie      ,
        Lauralee   ,
        Natashia   ,
        Janeen     ,
        Monty      ,
        Lillia     ,
        Emmy       ,
        Criselda   ,
        Tami       ,
        Jannie     ,
        Selene     ,
        Larisa     ,
        Stacee     ,
        Alissa     ,
        Sigrid     ,
        Margy      ,
        Barney     ,
        Olga       ,
        Eva        ,
        Kyong      ,
        Leighann   ,
        Dorinda    ,
        Graham     ,
        Niesha     ,
        Bruce      ,
        Melonie    ,
        Brittanie  ,
        Marya      ,
        Winifred   ,
        Jeremiah   ,
        Rowena     ,
        Annalee    ,
        Rina       ,
        Polly      ,
        Jacquelyne ,
        Geoffrey   ,
        James      ,
        Aron       ,
        Freeda     ,
        Georgine   ,
        Carmen     ,
    }
}
