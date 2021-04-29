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
        IWorldGeneratorBuilder<X> AddSingleBaseRoom(X r);
        IWorldGeneratorBuilder<X> AddSomeBaseRoom(IList<X> list);
        IWorldGeneratorBuilder<X> GenerateRooms(int nRoomsMin, int nRoomsMax);
        IWorldGeneratorBuilder<X> GeneratePlayer();
        IWorldGeneratorBuilder<X> GenerateKeyObject();
        IWorldGeneratorBuilder<X> GenerateEnemy(int minRoom, int maxRoom);
        IWorldGeneratorBuilder<X> GenerateObstacoles(int minRoom, int maxRoom);
        IWorldGeneratorBuilder<X> GenerateItem(int minRoom, int maxRoom);
        IWorldGeneratorBuilder<X> GenerateWeapons(int minRoom, int maxRoom);
        IWorldGeneratorBuilder<X> Finishes();
        IWorldGeneratorBuilder<X> Build();
        IDictionary<KeyValuePair<int, int>, SymbolsType> Map { get; }
        int MinX { get; }
        int MaxX { get; }
        int MinY { get; }
        int MaxY { get; }
        bool IsKeyObjectPresent { get; }
    }
}
