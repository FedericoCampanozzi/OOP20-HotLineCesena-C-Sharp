using System.Drawing;

namespace Campanozzi.Model.DataAccessLayer
{
    public sealed class SymbolsType
    {
        private char _c;
        private Color _testColor;
        private Color _miniMapColor;

        public char Decotification
        {
            get
            {
                return _c;
            }
        }

        public Color MiniMapColor
        {
            get
            {
                return _miniMapColor;
            }
        }

        public Color TestColor
        {
            get
            {
                return _testColor;
            }
        }

        private SymbolsType(char c, Color t, Color m)
        {
            this._c = c;
            this._testColor = t;
            this._miniMapColor = m;
        }

        public static SymbolsType VOID 
        {
            get
            {
                return new SymbolsType('_', Color.FromArgb(0, 0, 0), Color.FromArgb(0, 153, 0));
            }
        }

        public static SymbolsType DOOR
        {
            get
            {
                return new SymbolsType('D', Color.FromArgb(204, 51, 0), Color.FromArgb(0, 0, 0));
            }
        }

        public static SymbolsType WALKABLE
        {
            get
            {
                return new SymbolsType('.', Color.FromArgb(255, 255, 255), Color.FromArgb(255, 167, 77));
            }
        }

        public static SymbolsType ENEMY
        {
            get
            {
                return new SymbolsType('E', Color.FromArgb(243, 0, 0), Color.FromArgb(0, 153, 0));
            }
        }

        public static SymbolsType PLAYER
        {
            get
            {
                return new SymbolsType('_', Color.FromArgb(153, 0, 77), Color.FromArgb(82, 0, 204));
            }
        }

        public static SymbolsType OBSTACOLES
        {
            get
            {
                return new SymbolsType('O', Color.FromArgb(92, 92, 61), Color.FromArgb(0, 0, 0));
            }
        }

        public static SymbolsType WEAPONS
        {
            get
            {
                return new SymbolsType('*', Color.FromArgb(179, 179, 0), Color.FromArgb(0, 0, 0));
            }
        }

        public static SymbolsType WALL
        {
            get
            {
                return new SymbolsType('W', Color.FromArgb(128, 64, 0), Color.FromArgb(102, 68, 0));
            }
        }

        public static SymbolsType ITEM
        {
            get
            {
                return new SymbolsType('I', Color.FromArgb(102, 0, 102), Color.FromArgb(0, 0, 0));
            }
        }

        public static SymbolsType KEY_ITEM
        {
            get
            {
                return new SymbolsType('K', Color.FromArgb(153, 51, 153), Color.FromArgb(0, 0, 0));
            }
        }

        public static SymbolsType REMOVE
        {
            get
            {
                return new SymbolsType('-', Color.FromArgb(153, 255, 204), Color.FromArgb(0, 0, 0));
            }
        }

        public override bool Equals(object obj)
        {
            SymbolsType other = (SymbolsType)obj;
            return this._c.Equals(other.Decotification);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}