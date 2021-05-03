using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campanozzi.Controller.Generator
{
    /// <summary>
    /// This factory provide to generate some list of rooms
    /// </summary>
    public interface IBaseRoomsGeneratorFactory
    {
        /// <summary>
        /// Get a list of quadratic room
        /// </summary>
        /// <param name="wMin"></param>
        /// <param name="wMax"></param>
        /// <param name="dMin"></param>
        /// <param name="dMax"></param>
        /// <param name="nBaseRoomsMin"></param>
        /// <param name="nBaseRoomsMax"></param>
        /// <returns></returns>
        IList<QuadraticRoom> GenerateQuadraticRoomList(int wMin, int wMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax);

        /// <summary>
        /// Get a list of rectangular room
        /// </summary>
        /// <param name="wMin"></param>
        /// <param name="wMax"></param>
        /// <param name="hMin"></param>
        /// <param name="hMax"></param>
        /// <param name="dMin"></param>
        /// <param name="dMax"></param>
        /// <param name="nBaseRoomsMin"></param>
        /// <param name="nBaseRoomsMax"></param>
        /// <returns></returns>
        IList<RectangularRoom> GenerateRectungolarRoomList(int wMin, int wMax, int hMin, int hMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax);

        /// <summary>
        /// Get a list of octagonal room
        /// </summary>
        /// <param name="edgeMin"></param>
        /// <param name="edgeMax"></param>
        /// <param name="dMin"></param>
        /// <param name="dMax"></param>
        /// <param name="nBaseRoomsMin"></param>
        /// <param name="nBaseRoomsMax"></param>
        /// <returns></returns>
        IList<OctagonalRoom> GenerateOctagonalRoomList(int edgeMin, int edgeMax, int dMin, int dMax, int nBaseRoomsMin, int nBaseRoomsMax);
    }
}
