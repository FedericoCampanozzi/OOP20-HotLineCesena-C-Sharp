using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;
using Campanozzi.Utilities;

namespace Campanozzi.Controller.Generator
{
	public class QuadraticRoom : AbstractRoom, IRoom
	{
		private int _w;
		private int _d;

		private QuadraticRoom(IDictionary<KeyValuePair<int, int>, SymbolsType> map, KeyValuePair<int, int> center, int edge) : base()
		{
			this._map = map;
			this._w = edge;
		}

		public QuadraticRoom(int edge, int nDoor) : base()
		{
			if (edge % 2 == 0)
			{
				edge -= 1;
			}

			this._w = edge;
			this._d = nDoor;
			Generate();
		}

		public override void Generate()
		{

			int width = (this._w - 1) / 2;
			Random rnd = new Random(JSONDataAccessLayer.SEED);
			for (int y = -width; y <= width; y++)
			{
				for (int x = -width; x <= width; x++)
				{

					if (y == -width || x == -width || y == width || x == width)
					{
						this._map[new KeyValuePair<int, int>(y, x)] = SymbolsType.WALL;
					}
					else
					{
						this._map[new KeyValuePair<int, int>(y, x)] = SymbolsType.WALKABLE;
					}
				}
			}
			ISet<KeyValuePair<int, int>> connections = new HashSet<KeyValuePair<int, int>>();
			while (connections.Count < this._d)
			{
				int x = rnd.Next(this._w) - width;
				int y = rnd.Next(this._w) - width;
				KeyValuePair<int, int> cPos = new KeyValuePair<int, int>(y, x);

				if ((!cPos.Equals(new KeyValuePair<int, int>(-width, -width))
						&& !cPos.Equals(new KeyValuePair<int, int>(width, width))
						&& !cPos.Equals(new KeyValuePair<int, int>(-width, width))
						&& !cPos.Equals(new KeyValuePair<int, int>(width, -width))) && !connections.Contains(cPos)
						&& this._map[cPos].Equals(SymbolsType.WALL))
				{
					this._map[cPos] = SymbolsType.DOOR;
					connections.Add(cPos);
				}
			}
		}

		public override IRoom DeepCopy()
		{
			return new QuadraticRoom(this._map, this._center, this._w);
		}

		public int GetWidth()
		{
			return this._w;
		}
	}
}
