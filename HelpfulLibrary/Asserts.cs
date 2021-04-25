using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelpfulLibrary
{
    public static class Asserts
    {
        public static void IsError(this Action action, string errorMessage = null)
        {
            try
            {
                action.Invoke();
            }
            catch 
            { 
                return;
            }

            throw new AssertFailedException(errorMessage ?? "Ошибки не возникло");
        }

        public static void IsError<TException>(this Action action, string errorMessage = null)
        {
            try
            {
                action.Invoke();
            } catch (Exception exc) when (exc.GetType() == typeof(TException))
            {
                return;
            } catch (Exception exc)
            {
                throw new AssertFailedException(errorMessage ?? $"Возникла другая ошибка: {exc}");
            }

            throw new AssertFailedException(errorMessage ?? "Ошибки не возникло");
        }
    }
}
