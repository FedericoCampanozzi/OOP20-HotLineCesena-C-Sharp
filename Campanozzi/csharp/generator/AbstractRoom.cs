using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;

namespace Campanozzi.Controller.Generator
{
    public abstract class AbstractRoom : IRoom
    {
        protected IDictionary<KeyValuePair<int, int>, SymbolsType> _map = new Dictionary<KeyValuePair<int, int>, SymbolsType>();
        protected KeyValuePair<int, int> _center = new KeyValuePair<int, int>(0, 0);
        
        public AbstractRoom()
        {

        }

        public AbstractRoom(IDictionary<KeyValuePair<int, int>, SymbolsType> map, KeyValuePair<int, int> center)
        {
            this._map = map;
            this._center = center;
        }

        public IDictionary<KeyValuePair<int, int>, SymbolsType> Map
        {
            get
            {
                return this._map;
            }
        }

        public KeyValuePair<int, int> Center
        {
            get
            {
                return this._center;
            }

            set
            {
                this._center = value;
            }
        }

        public abstract void Generate();

        public abstract IRoom DeepCopy();
    }
}
