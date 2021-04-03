using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HelpfulLibrary
{
    public static class ReflectionComparator
    {
        /// <summary>
        /// Сравнивает все публичные свойства ожидаемого объекта с свойствами актуального объекта (будут так же проверятся свойства всех классов рекурсивно).
        /// </summary>
        /// <typeparam name="TExp"> Тип ожидаемого объекта. </typeparam>
        /// <typeparam name="TAct"> Тип актуального объекта. </typeparam>
        /// <param name="expected"> Ожидаемый объект. </param>
        /// <param name="actual"> Актуальный объект. </param>
        /// <param name="ignoreProps"> Игнорируемые свойства. Так же вписывать и названия свойств классов, если это нужно. </param>
        /// <returns> Если значения свойств совпадают возвращают true. Иначе false. 
        /// Так же возвращается и текст (своеобразный лог для отладки). Записывает результаты проверки свойств. </returns>
        public static (bool IsEqual, string Logs) CompareProperties<TExp, TAct>(TExp expected, TAct actual, params string[] ignoreProps)
        {
            var log = new StringBuilder();
            log.AppendLine($"\r\nClass {typeof(TExp).Name} :");

            var checkNullResult = CheckNullReference(expected, actual, ref log);
            if (!checkNullResult.ContinueCheckingProps) return (checkNullResult.IsEqual, log.ToString());

            try
            {
                var expexctedProps = typeof(TExp).GetProperties().Where(x => !ignoreProps.Contains(x.Name));
                var expectedPropsNames = expexctedProps.Select(y => y.Name);

                // Если проп не присутствует в списке ожидаемых, то взят не будет
                var actualProps = typeof(TAct).GetProperties().Where(x => expectedPropsNames.Contains(x.Name));

                if (expexctedProps.Count() != actualProps.Count())
                    return (false, $"В актуальном объекте {typeof(TAct).GetType().Name} недостаточно свойств: " +
                        $"{string.Join(", ", expexctedProps.Select(x => x.Name).Except(actualProps.Select(x => x.Name)))};");
                else if (expexctedProps.Count() == 0) return (true, log.AppendLine("\t" +
                    "Количество доступных свойств в объектах равняется 0. Проверка класса завершена.").ToString());

                var result = CompareProps(expexctedProps, actualProps, expected, actual, ignoreProps, ref log);

                if (result) return (true, log.ToString());
                else return (false, log.ToString());
            }
            catch (Exception ex)
            {
                log.AppendLine(ex.Message);
                return (false, $"   Log: {log};\r\n    StackTrace: {ex.StackTrace};");
            }
        }

        private static bool CompareProps<TExp, TAct>(
            IEnumerable<PropertyInfo> expexctedProps, IEnumerable<PropertyInfo> actualProps,
            TExp expected, TAct actual, string[] ignoreProps, ref StringBuilder log
            )
        {
            foreach (var prop in expexctedProps)
            {
                log.AppendLine($"{prop.PropertyType} {prop.Name} : ");
                var expValue = prop.GetValue(expected);
                var actValue = actualProps.Single(x => x.Name == prop.Name).GetValue(actual);

                var checkNullResult = CheckNullReference(expValue, actValue, ref log);
                if (!checkNullResult.ContinueCheckingProps) if (checkNullResult.IsEqual) continue; else return (checkNullResult.IsEqual);

                var type = expValue.GetType();
                if (type.IsValueType)
                {
                    if (CompareAsValueType(expValue, actValue, ref log) == false) return false;
                }
                else if (type == typeof(string))
                {
                    if (CompareAsString(expValue, actValue, ref log) == false) return false;
                }
                else if (type.GetInterface(nameof(IEnumerable)) != null)
                {
                    if (CompareAsEnumerable(expValue, actValue, ignoreProps, ref log) == false) return false;
                }
                else // Если это не примитивный тип, а какой нибудь класс, то рекурсивно вызовется его проверка
                {
                    var compareResult = CompareProperties(expValue, actValue, ignoreProps);
                    log.AppendLine(compareResult.Logs);
                    if (compareResult.IsEqual == false) return false;
                }
            }
            return true;
        }

        private static bool CompareAsEnumerable(object expValue, object actValue, string[] ignoreProps, ref StringBuilder log)
        {
            var acts = TryCastObjectToArray(expValue, ref log);
            var exps = TryCastObjectToArray(actValue, ref log);

            if (acts.Length != exps.Length) { log.AppendLine($"    {acts.Length} != {exps.Length};"); return false; }
            if (acts.Length == 0) { log.AppendLine($"    {acts.Length} == {exps.Length};"); return true; }

            for (var i = 0; i < exps.Length; i++)
            {
                var exp = exps[i];
                var act = acts[i];

                var checkNullResult1 = CheckNullReference(exp, act, ref log);
                if (!checkNullResult1.ContinueCheckingProps) if (checkNullResult1.IsEqual) continue; else return false;
                var currType = exp.GetType();
                if (currType.IsValueType) { if (!CompareAsValueType(exp, act, ref log)) return false; }
                else if (currType == typeof(string)) { if (!CompareAsString(exp, act, ref log)) return false; }
                else
                {
                    var compareResult = CompareProperties(exp, act, ignoreProps);
                    log.Append(compareResult.Logs);
                    if (!compareResult.IsEqual) return false;
                }
            }
            return true;
        }

        private static object[] TryCastObjectToArray(object value, ref StringBuilder log)
        {
            try { return ((IEnumerable<object>)value).ToArray(); } catch { /*ignore*/ }
            try { return ((IEnumerable<Guid>)value).Select(x => (object)x).ToArray(); } catch { /*ignore*/ }
            try { return ((IEnumerable<double>)value).Select(x => (object)x).ToArray(); } catch { /*ignore*/ }
            try { return ((IEnumerable<char>)value).Select(x => (object)x).ToArray(); } catch { /*ignore*/ }
            try { return ((IEnumerable<int>)value).Select(x => (object)x).ToArray(); } catch { /*ignore*/ }
            try { return ((IEnumerable<DateTime>)value).Select(x => (object)x).ToArray(); } catch { /*ignore*/ }
            try { return ((IEnumerable<DateTimeOffset>)value).Select(x => (object)x).ToArray(); }
            catch { throw new Exception("Не удаётся преобразовать объект в массив."); }
        }

        private static (bool ContinueCheckingProps, bool IsEqual) CheckNullReference<TExp, TAct>(TExp expected, TAct actual, ref StringBuilder log)
        {
            if (expected == null || actual == null)
                if (expected == null && actual == null)
                {
                    log.AppendLine($"   null == null;");
                    return (false, true);
                }
                else
                {
                    log.AppendLine($"   EXPECTED: {typeof(TExp)} IsNull? => {expected == null};\r\n    ACTUAL: {typeof(TAct)} IsNull? => {actual == null};");
                    return (false, false);
                }
            else return (true, false);
        }

        private static bool CompareAsString(object exp, object act, ref StringBuilder log)
        {
            var expString = (string)exp;
            var actString = (string)act;
            if (expString.SequenceEqual(actString))
            {
                log.AppendLine($@"   ""{expString}"" == ""{actString}"";");
                return true;
            }
            else
            {
                log.AppendLine($@"   ""{expString}"" != ""{actString}"";");
                return false;
            }
        }

        private static bool CompareAsValueType(object expValue, object actValue, ref StringBuilder log)
        {
            dynamic exp;
            dynamic act;
            var objType = expValue.GetType();
            if (objType == typeof(Guid))
            {
                exp = (Guid)expValue;
                act = (Guid)actValue;
            }
            else if (objType == typeof(DateTime))
            {
                exp = (DateTime)expValue;
                act = (DateTime)actValue;
            }
            else if (objType == typeof(DateTimeOffset))
            {
                exp = (DateTimeOffset)expValue;
                act = (DateTimeOffset)actValue;
            }
            else
            {
                exp = Convert.ToDouble(expValue);
                act = Convert.ToDouble(actValue);
            }

            if (exp != act)
            {
                log.AppendLine($"   {exp} != {act};");
                return false;
            }
            else
            {
                log.AppendLine($"   {exp} == {act};");
                return true;
            }
        }
    }
}
