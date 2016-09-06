using System;

namespace Selenium.Utils
{
    class SeleniumTestException : Exception
    {
        public SeleniumTestException()
        {
        }

        public SeleniumTestException(string message) : base(message)
        {
        }

        public SeleniumTestException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
