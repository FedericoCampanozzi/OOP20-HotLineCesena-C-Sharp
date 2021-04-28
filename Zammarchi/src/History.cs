using System;
using System.Collections.Generic;
using System.Text;

namespace Zammarchi
{
    public sealed class History
    {
        History()
        {
        }

        private static readonly object padlock = new object();
        private static History instance = null;

        public static History Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new History();
                        }
                    }
                }
                return instance;
            }
        }

        public void Reset()
        {
            instance = new History();
        }

        public int DamageCounter { get; set; } = 0;
        public int ProjCounter { get; set; } = 0;

    }
}
