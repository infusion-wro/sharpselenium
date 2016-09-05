namespace Selenium.By
{
    class ByType
    {
        private readonly string name;

        public static readonly ByType XPATH = new ByType("xpath");
        public static readonly ByType ID = new ByType("id");
        public static readonly ByType NAME = new ByType("xpath");

        private ByType(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}
