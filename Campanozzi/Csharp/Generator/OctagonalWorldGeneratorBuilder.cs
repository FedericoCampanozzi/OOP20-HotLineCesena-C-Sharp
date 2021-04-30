using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;

namespace Campanozzi.Controller.Generator
{
	public class OctagonalWorldGeneratorBuilder : AbstractWorldGeneratorBuilder<OctagonalRoom>, IWorldGeneratorBuilder<OctagonalRoom>
	{
		public OctagonalWorldGeneratorBuilder() : base()
		{
		}

		public override KeyValuePair<int, int> GetDirections(OctagonalRoom room)
		{
			int w = (room.Width - 1) / 2;
			return new KeyValuePair<int, int>((_rnd.Next(3) - 1) * (w + 2), (_rnd.Next(3) - 1) * (w + 2));
		}

		public override IWorldGeneratorBuilder<OctagonalRoom> Finishes()
		{
			this.HaveInitMapAndBaseRoom();
			this._xMin = _xMin - MAP_PADDING;
			this._xMax = _xMax + MAP_PADDING;
			this._yMax = _yMax + MAP_PADDING;
			this._yMin = _yMin - MAP_PADDING;

			for (int i = _xMin; i <= _xMax; i++)
			{
				for (int j = _yMin; j <= _yMax; j++)
				{

					if (!this._map.ContainsKey(new KeyValuePair<int, int>(i, j)))
					{
						this._map.Add(new KeyValuePair<int, int>(i, j), SymbolsType.VOID);
					}
				}
			}

			for (int i = _xMin; i <= _xMax; i++)
			{
				for (int j = _yMin; j <= _yMax; j++)
				{

					if (this._map[new KeyValuePair<int, int>(i, j)].Equals(SymbolsType.OBSTACOLES)
							&& this.CheckAdjacent8(i, j, SymbolsType.WALL))
					{
						this._map.Add(new KeyValuePair<int, int>(i, j), SymbolsType.WALKABLE);
					}
				}
			}

			for (int i = _xMin; i <= _xMax; i++)
			{
				for (int j = _yMin; j <= _yMax; j++)
				{
					if (this._map[new KeyValuePair<int, int>(i, j)].Equals(SymbolsType.DOOR)
							&& !this.CheckAdjacent8(i, j, SymbolsType.VOID))
					{
						this._map.Add(new KeyValuePair<int, int>(i, j), SymbolsType.WALL);
					}
				}
			}

			return this;
		}
	}
}