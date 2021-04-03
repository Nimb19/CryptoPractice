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
    }
}
