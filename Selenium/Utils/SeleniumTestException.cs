using System;

namespace Selenium.Utils
{
    class SeleniumTestException : Exception
    {
        public SeleniumTestException()
        {
        }

        public SeleniumTestException(string message, params string[] placeholders) : base(string.Format(message, placeholders))
        {
        }

        public SeleniumTestException(string message, Exception inner, params string[] placeholders) : base(string.Format(message, placeholders), inner)
        {
        }
    }
}
