using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;

namespace Campanozzi.Controller.Generator
{
	public class RectangularRoom : AbstractRoom, IRoom
	{
		private readonly int _w;
		private readonly int _h;
		private readonly int _d;

		private RectangularRoom(IDictionary<KeyValuePair<int, int>, SymbolsType> map, KeyValuePair<int, int> center, int width, int height) : base()
		{
			this._map = map;
			this._w = width;
			this._h = height;
			this._center = center;
		}

		public RectangularRoom(int width, int height, int nDoor) : base()
		{
			if (width % 2 == 0)
			{
				width -= 1;
			}
			if (height % 2 == 0)
			{
				height -= 1;
			}

			this._h = height;
			this._w = width;
			this._d = nDoor;
			Generate();
		}

		public override void Generate()
		{
			int width2 = (this._w - 1) / 2;
			int height2 = (this._h - 1) / 2;
			Random rnd = new Random(JSONDataAccessLayer._seed);

			for (int y = -height2; y <= height2; y++)
			{
				for (int x = -width2; x <= width2; x++)
				{

					if (y == -height2 || x == -width2 || y == height2 || x == width2)
					{
						_map[new KeyValuePair<int, int>(y, x)] =  SymbolsType.WALL;
					}
					else
					{
						_map[new KeyValuePair<int, int>(y, x)] = SymbolsType.WALKABLE;
					}
				}
			}

			ISet<KeyValuePair<int, int>> connections = new HashSet<KeyValuePair<int, int>>();
			while (connections.Count < this._d)
			{
				int x = rnd.Next(this._w) - width2;
				int y = rnd.Next(this._h) - height2;
				KeyValuePair<int, int> cPos = new KeyValuePair<int, int>(y, x);

				if ((!cPos.Equals(new KeyValuePair<int, int>(-height2, -width2))
						&& !cPos.Equals(new KeyValuePair<int, int>(height2, width2))
						&& !cPos.Equals(new KeyValuePair<int, int>(-height2, width2))
						&& !cPos.Equals(new KeyValuePair<int, int>(height2, -width2))) && !connections.Contains(cPos)
						&& this._map[cPos].Equals(SymbolsType.WALL))
				{
					this._map[cPos] = SymbolsType.DOOR;
					connections.Add(cPos);
				}
			}
		}

		public override IRoom DeepCopy()
		{
			return new RectangularRoom(this._map, this._center, this._w, this._h);
		}

		public int Width
		{
            get
            {
				return this._w;
            }
		}

		public int Height
		{
            get
            {
				return this._h;
            }
		}
	}
}