namespace PrintAll
{
    public class CustomPrint
    {
        #region Fields
        private string? _name;
        #endregion

        #region Methods
        public void Print()
        {
            Console.WriteLine("Printing from Print");
        }

        public string? GetName()
        {
            return _name;
        }

        public void PrintName()
        {
            Console.WriteLine($"Name set as {_name}");
        }

        public void Print(string? name )
        {
            Console.WriteLine($"Name passed: {name}");
        }

        private void PrintPrivate()
        {
            Console.WriteLine("Printing from private");
        }
        #endregion

        #region Properties
        public string? Name => _name;

        public static string StaticName => "Static Property Name";
        #endregion
    }
}