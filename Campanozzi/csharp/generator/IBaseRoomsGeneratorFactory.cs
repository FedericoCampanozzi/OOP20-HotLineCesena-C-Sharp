using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campanozzi.Controller.Generator
{
    public interface IBaseRoomsGeneratorFactory
    {
        IList<QuadraticRoom> GenerateQuadraticRoomList(int wMin, int wMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax);
        IList<RectangularRoom> GenerateRectungolarRoomList(int wMin, int wMax, int hMin, int hMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax);
        IList<OctagonalRoom> GenerateOctagonalRoomList(int edgeMin, int edgeMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax);
    }
}
