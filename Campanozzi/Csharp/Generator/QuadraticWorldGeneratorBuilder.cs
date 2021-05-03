using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campanozzi.Controller.Generator
{
	public class QuadraticWorldGeneratorBuilder : AbstractWorldGeneratorBuilder<QuadraticRoom>, IWorldGeneratorBuilder<QuadraticRoom>
	{
		public QuadraticWorldGeneratorBuilder() : base()
		{
		}
		
		public override KeyValuePair<int, int> GetDirections(QuadraticRoom room)
		{
			int dirX = (_rnd.Next(3) - 1) * ((room.Width / 2) + 1);
			int dirY = 0;
			if (dirX == 0)
			{
				dirY = (_rnd.Next(3) - 1) * ((room.Width / 2) + 1);
			}
			return new KeyValuePair<int, int>(dirY, dirX);
		}
	}
}