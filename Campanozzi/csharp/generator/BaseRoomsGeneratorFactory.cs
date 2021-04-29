using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;

namespace Campanozzi.Controller.Generator
{
    public class BaseRoomsGeneratorFactory : IBaseRoomsGeneratorFactory
    {
        public IList<QuadraticRoom> GenerateQuadraticRoomList(int wMin, int wMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax)
        {
            Random rnd = new Random(JSONDataAccessLayer._seed);
            return this.GenerateGenericList<QuadraticRoom>(nBaseRoomsMin, nBaseRoomsMax, () => new QuadraticRoom(
                        rnd.Next(wMin, wMax),
                        rnd.Next(dMin, dMax)
                    ));
        }

        public IList<RectangularRoom> GenerateRectungolarRoomList(int wMin, int wMax, int hMin, int hMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax)
        {
            Random rnd = new Random(JSONDataAccessLayer._seed);
            return this.GenerateGenericList(nBaseRoomsMin, nBaseRoomsMax, () => new RectangularRoom(
                        rnd.Next(wMin, wMax),
                        rnd.Next(hMin, hMax),
                        rnd.Next(dMin, dMax)
                    ));
        }

        public IList<OctagonalRoom> GenerateOctagonalRoomList(int edgeMin, int edgeMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax)
        {
            Random rnd = new Random(JSONDataAccessLayer._seed);
            return this.GenerateGenericList(nBaseRoomsMin, nBaseRoomsMax, () => new OctagonalRoom(
                        rnd.Next(edgeMin, edgeMax),
                        rnd.Next(dMin, dMax)
                    ));
        }

        private IList<X> GenerateGenericList<X>(int nBaseRoomsMin, int nBaseRoomsMax, Func<X> add)
        {
            Random rnd = new Random(JSONDataAccessLayer._seed);
            int nBaseRooms = rnd.Next(nBaseRoomsMin, nBaseRoomsMax);
            IList<X> baseRooms = new List<X>();
            for (int i = 0; i < nBaseRooms; i++)
            {
                baseRooms.Add(add());
            }

            return baseRooms;
        }
    }
}
