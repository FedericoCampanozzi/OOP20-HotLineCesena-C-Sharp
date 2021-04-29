using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;

namespace Campanozzi.Controller.Generator
{
    public interface IWorldGeneratorBuilder<X>
    {
        /// <summary>
        /// Add single room in base room list
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> AddSingleBaseRoom(X r);

        /// <summary>
        /// Add a list room in base room list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> AddSomeBaseRoom(IList<X> list);

        /// <summary>
        /// Generate rooms list
        /// </summary>
        /// <param name="nRoomsMin"></param>
        /// <param name="nRoomsMax"></param>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> GenerateRooms(int nRoomsMin, int nRoomsMax);

        /// <summary>
        /// Put player symbols in gamemap
        /// </summary>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> GeneratePlayer();

        /// <summary>
        /// Put key item symbols in gamemap
        /// </summary>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> GenerateKeyObject();

        /// <summary>
        /// Put some enemy symbols in gamemap
        /// </summary>
        /// <param name="minRoom"></param>
        /// <param name="maxRoom"></param>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> GenerateEnemy(int minRoom, int maxRoom);

        /// <summary>
        /// Put some obstacles symbols in gamemap
        /// </summary>
        /// <param name="minRoom"></param>
        /// <param name="maxRoom"></param>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> GenerateObstacoles(int minRoom, int maxRoom);

        /// <summary>
        /// Put some items symbols in gamemap
        /// </summary>
        /// <param name="minRoom"></param>
        /// <param name="maxRoom"></param>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> GenerateItem(int minRoom, int maxRoom);

        /// <summary>
        /// Put some weapons symbols in gamemap
        /// </summary>
        /// <param name="minRoom"></param>
        /// <param name="maxRoom"></param>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> GenerateWeapons(int minRoom, int maxRoom);

        /// <summary>
        /// Apply some effect of post-processing
        /// </summary>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> Finishes();

        /// <summary>
        /// Return the final builder
        /// </summary>
        /// <returns></returns>
        IWorldGeneratorBuilder<X> Build();

        IDictionary<KeyValuePair<int, int>, SymbolsType> Map { get; }

        int MinX { get; }

        int MaxX { get; }

        int MinY { get; }

        int MaxY { get; }

        bool IsKeyObjectPresent { get; }
    }
}
