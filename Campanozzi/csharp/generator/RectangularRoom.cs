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
		private int w;
		private int h;
		private int d;

		private RectangularRoom(IDictionary<KeyValuePair<int, int>, SymbolsType> map, KeyValuePair<int, int> center, int width, int height) : base()
		{
			this._map = map;
			this.w = width;
			this.h = height;
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

			this.h = height;
			this.w = width;
			this.d = nDoor;
			Generate();
		}

		public override void Generate()
		{
			int width2 = (this.w - 1) / 2;
			int height2 = (this.h - 1) / 2;
			Random rnd = new Random(JSONDataAccessLayer.SEED);

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
			while (connections.Count < this.d)
			{
				int x = rnd.Next(this.w) - width2;
				int y = rnd.Next(this.h) - height2;
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
			return new RectangularRoom(this._map, this._center, this.w, this.h);
		}

		public int GetWidth()
		{
			return this.w;
		}

		public int GetHeight()
		{
			return this.h;
		}
	}
}