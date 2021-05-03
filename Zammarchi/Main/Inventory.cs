namespace Zammarchi
{
    public sealed class Inventory
    {
        public int DamageCounter { get; set; } = 0;
        public int ProjCounter { get; set; } = 0;
        public int MoneyCounter { get; set; } = 0;
        public int AmmoCounter { get; set; } = 0;
        Inventory()
        {
        }

        private static readonly object padlock = new object();
        private static Inventory instance = null;

        public static Inventory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Inventory();
                }
                return instance;
            }
        }

        public void Reset()
        {
            instance = new Inventory();
        }
    }
}
