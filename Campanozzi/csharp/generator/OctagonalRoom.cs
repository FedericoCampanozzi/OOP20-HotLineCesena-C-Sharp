using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;
using Campanozzi.Utilities;

namespace Campanozzi.Controller.Generator
{
    public class OctagonalRoom : AbstractRoom, IRoom
    {
        private int width;
        private int edge;
        private int nDoor;

        private OctagonalRoom(IDictionary<KeyValuePair<int, int>, SymbolsType> map, KeyValuePair<int, int> center, int width) : base()
        {
            this._center = center;
            this._map = map;
            this.width = width;
        }

        public OctagonalRoom(int edge, int nDoor) : base()
        {
            if (edge % 2 == 0)
            {
                edge -= 1;
            }
            this.width = (3 * (edge - 1)) + 1;
            this.edge = edge;
            this.nDoor = nDoor;
            Generate();
        }

        public override void Generate()
        {
            int edge2 = (edge - 1) / 2;
            int width2 = (width - 1) / 2;
            Random rnd = new Random(JSONDataAccessLayer.SEED);
            IList<KeyValuePair<int, int>> walls = new List<KeyValuePair<int, int>>();
            IList<KeyValuePair<int, int>> dirs = new List<KeyValuePair<int, int>>();
            KeyValuePair<int, int> start = new KeyValuePair<int, int>(0, 0);
            dirs.Add(new KeyValuePair<int, int>(0, 1));
            dirs.Add(new KeyValuePair<int, int>(-1, 1));
            dirs.Add(new KeyValuePair<int, int>(-1, 0));
            dirs.Add(new KeyValuePair<int, int>(-1, -1));
            dirs.Add(new KeyValuePair<int, int>(0, -1));
            dirs.Add(new KeyValuePair<int, int>(1, -1));
            dirs.Add(new KeyValuePair<int, int>(1, 0));
            dirs.Add(new KeyValuePair<int, int>(1, 1));

            foreach (KeyValuePair<int, int> dir in dirs)
            {
                for (int i = 1; i < edge; i++)
                {
                    start = MathUtils.Sum(start, dir);
                    walls.Add(start);
                }
            }

            start = new KeyValuePair<int, int>(-edge - edge2 + 1, edge2);

            for (int i = 0; i < walls.Count; i++)
            {
                walls[i] = MathUtils.Subtract(start, walls[i]);
                this._map[walls[i]] = SymbolsType.WALL;
            }

            for (int i = 0; i < this.nDoor;)
            {
                KeyValuePair<int, int> door = walls[rnd.Next(walls.Count)];

                if ((walls.Contains(new KeyValuePair<int, int>(door.Key, door.Value + 1)) &&
                                walls.Contains(new KeyValuePair<int, int>(door.Key, door.Value - 1))) ||
                        (walls.Contains(new KeyValuePair<int, int>(door.Key + 1, door.Value)) &&
                                walls.Contains(new KeyValuePair<int, int>(door.Key - 1, door.Value))) ||
                        (walls.Contains(new KeyValuePair<int, int>(door.Key - 1, door.Value + 1)) &&
                                walls.Contains(new KeyValuePair<int, int>(door.Key + 1, door.Value - 1))) ||
                        (walls.Contains(new KeyValuePair<int, int>(door.Key + 1, door.Value + 1)) &&
                                walls.Contains(new KeyValuePair<int, int>(door.Key - 1, door.Value - 1)))
                        )
                {
                    this._map[door] = SymbolsType.DOOR;
                    i++;
                }
            }

            for (int i = -width2 + 1; i <= width2 - 1; i++)
            {
                for (int j = -width2 + 1; j <= width2 - 1; j++)
                {
                    if (MathUtils.Distance(new KeyValuePair<int, int>(i, j), _center) < (((double)this.width - 2) / 2.0d))
                    {
                        this._map[new KeyValuePair<int, int>(i, j)] = SymbolsType.WALKABLE;
                    }
                }
            }
        }

        public override IRoom DeepCopy()
        {
            return new OctagonalRoom(this._map, this._center, this.edge);
        }

        public int GetWidth()
        {
            return this.width;
        }
    }
}