using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campanozzi.Model.DataAccessLayer;
using Campanozzi.Utilities;

namespace Campanozzi.Controller.Generator
{
    abstract class AbstractWorldGeneratorBuilder<X> : IWorldGeneratorBuilder<X> where X : IRoom
    {
        protected const int ACCETABLE_MAP = 5;
        protected const int MAX_POSSIBILITY = 10000;
        protected const int MAP_PADDING = 10;
        protected Random _rnd = new Random(JSONDataAccessLayer.SEED);
        protected int _xMin, _xMax, _yMin, _yMax;
        protected int _pRoomIndex;
        protected int? _objRoomIndex = null;

        protected IDictionary<KeyValuePair<int, int>, SymbolsType> _map = new Dictionary<KeyValuePair<int, int>, SymbolsType>();

        protected List<X> _baseRooms = new List<X>();
        protected List<X> _rooms = new List<X>();

        public AbstractWorldGeneratorBuilder()
        {
            _rnd = new Random(JSONDataAccessLayer.SEED);
        }

        public IWorldGeneratorBuilder<X> AddSingleBaseRoom(X r)
        {
            this._baseRooms.Add(r);
            return this;
        }

        public IWorldGeneratorBuilder<X> AddSomeBaseRoom(IList<X> list)
        {
            this._baseRooms.AddRange(list);
            return this;
        }

        public abstract KeyValuePair<int, int> GetDirections(X room);

        public IWorldGeneratorBuilder<X> GenerateRooms(int nRoomsMin, int nRoomsMax)
        {
            this.HaveInitBaseRoom();
            int nRooms = _rnd.Next(nRoomsMin, nRoomsMax);
            for (int l = 0; l < MAX_POSSIBILITY && this._rooms.Count < nRooms; l++)
            {

                X toPut = (X)this._baseRooms[_rnd.Next(this._baseRooms.Count)].DeepCopy();

                if (this._rooms.Count == 0)
                {
                    GenerateRoom(new KeyValuePair<int, int>(0, 0), toPut);
                }
                else
                {
                    KeyValuePair<int, int> doorLink = GetConnectionsLinking();
                    KeyValuePair<int, int> dir = GetDirections(toPut);
                    KeyValuePair<int, int> center = MathUtils.Sum(doorLink, dir);
                    if (CanPutRoom(center, doorLink, dir, toPut))
                    {
                        GenerateRoom(center, toPut);
                        toPut.Center = center;
                    }
                }
            }
            return this;
        }
        public IWorldGeneratorBuilder<X> GenerateKeyObject()
        {
            HaveInitMapAndBaseRoom();
            if (this._rooms.Count <= ACCETABLE_MAP)
            {
                return this;
            }
            this._objRoomIndex = _rnd.Next(this._rooms.Count);
            while (this._objRoomIndex.Value == this._pRoomIndex)
            {
                this._objRoomIndex = _rnd.Next(this._rooms.Count);
            }
            IRoom r = this._rooms[this._objRoomIndex.Value];
            r.Map[r.Center] =  SymbolsType.KEY_ITEM;
            this._map[r.Center] = SymbolsType.KEY_ITEM;
            return this;
        }

        public IWorldGeneratorBuilder<X> GeneratePlayer()
        {
            HaveInitMapAndBaseRoom();
            this._pRoomIndex = _rnd.Next(this._rooms.Count);
            IRoom r = this._rooms[this._pRoomIndex];
            r.Map[r.Center] = SymbolsType.PLAYER;
            this._map[r.Center] = SymbolsType.PLAYER;
            return this;
        }

        public IWorldGeneratorBuilder<X> GenerateEnemy(int minInRoom, int maxInRoom)
        {
            HaveInitMapAndBaseRoom();
            return GenerateTotalRandomnessMany(SymbolsType.ENEMY, minInRoom, maxInRoom);
        }

        public IWorldGeneratorBuilder<X> GenerateWeapons(int minInRoom, int maxInRoom)
        {
            HaveInitMapAndBaseRoom();
            return GenerateTotalRandomnessMany(SymbolsType.WEAPONS, minInRoom, maxInRoom);
        }

        public IWorldGeneratorBuilder<X> GenerateItem(int minInRoom, int maxInRoom)
        {
            HaveInitMapAndBaseRoom();
            return GenerateTotalRandomnessMany(SymbolsType.ITEM, minInRoom, maxInRoom);
        }

        public IWorldGeneratorBuilder<X> GenerateObstacoles(int minInRoom, int maxInRoom)
        {
            HaveInitMapAndBaseRoom();
            return GenerateTotalRandomnessMany(SymbolsType.OBSTACOLES, minInRoom, maxInRoom);
        }

        public IWorldGeneratorBuilder<X> Build()
        {
            HaveInitMapAndBaseRoom();
            return this;
        }

        private IWorldGeneratorBuilder<X> GenerateTotalRandomnessMany(SymbolsType type, int minInRoom, int maxInRoom)
        {
            for (int rIndex = 0; rIndex < this._rooms.Count; rIndex++)
            {
                if (rIndex != this._pRoomIndex)
                {
                    IRoom r = this._rooms[rIndex];
                    int roomObj = _rnd.Next(minInRoom, maxInRoom);
                    IList<KeyValuePair<int, int>> positions = (IList<KeyValuePair<int, int>>)r.Map.Keys;

                    for (int i = 0; i < roomObj; i++)
                    {
                        KeyValuePair<int, int> pii = positions[_rnd.Next(positions.Count)];
                        pii = MathUtils.Sum(pii, r.Center);
                        if (this._map.ContainsKey(pii) && this._map[pii].Equals(SymbolsType.WALKABLE))
                        {
                            this._map[pii] = type;
                            r.Map.Add(MathUtils.Subtract(pii, r.Center), type);
                        }
                    }
                }
            }
            return this;
        }
        public virtual IWorldGeneratorBuilder<X> Finishes()
        {
            HaveInitMapAndBaseRoom();
            this._xMin = _xMin - MAP_PADDING;
            this._xMax = _xMax + MAP_PADDING;
            this._yMax = _yMax + MAP_PADDING;
            this._yMin = _yMin - MAP_PADDING;

            //fill null positions
            this.applyCorrection((i, j) => {
                if (!this._map.ContainsKey(new KeyValuePair<int, int>(i, j)))
                {
                    this._map[new KeyValuePair<int, int>(i, j)] = SymbolsType.VOID;
                }
            });

            //check door that have near a void space
            this.applyCorrection((i, j) => {
                if (this.get(i, j, SymbolsType.DOOR) && checkAdjacent4(i, j, SymbolsType.VOID))
                {
                    this._map[new KeyValuePair<int, int>(i, j)] = SymbolsType.WALL;
                }
            });

            //check walkable corridor
            this.applyCorrection((i, j) => {
                if ((this.get(i, j, SymbolsType.ENEMY)
                        || this.get(i, j, SymbolsType.OBSTACOLES)) && checkAdjacent8(i, j, SymbolsType.WALL))
                {
                    this._map[new KeyValuePair<int, int>(i, j)] = SymbolsType.WALKABLE;
                }
            });

            //open corridor
            this.applyCorrection((i, j) => {
                // j+
                this.checkSemiAxis(i, j, 0, 1, -1, 0);
                // j-
                this.checkSemiAxis(i, j, 0, -1, 1, 0);
                // i+
                this.checkSemiAxis(i, j, 1, 0, 0, -1);
                // i-
                this.checkSemiAxis(i, j, -1, 0, 0, 1);
            });


            //Delete remaining doors
            this.applyCorrection((i, j) => {
                if (get(i, j, SymbolsType.DOOR))
                {
                    this._map[new KeyValuePair<int, int>(i, j)] = SymbolsType.WALL;
                }
            });

            //check walkable that have near a void space
            this.applyCorrection((i, j) => {
                if (this.get(i, j, SymbolsType.WALKABLE) && checkAdjacent8(i, j, SymbolsType.VOID))
                {
                    this._map[new KeyValuePair<int, int>(i, j)] = SymbolsType.WALL;
                }
            });

            return this;
        }

        protected void checkSemiAxis(int i, int j, int dI, int dJ, int dInvI, int dInvJ)
        {
            if (get(i, j, SymbolsType.DOOR) && get(i + dI, j + dJ, SymbolsType.DOOR) && get(i + 2 * dI, j + 2 * dJ, SymbolsType.WALKABLE))
            {
                if (dI == 1 || dI == -1)
                {
                    this._map[new KeyValuePair<int, int>(i, j + dInvJ)] = SymbolsType.WALKABLE;
                    this._map[new KeyValuePair<int, int>(i + dI + dInvI, j + dInvJ)] = SymbolsType.WALKABLE;
                    this._map[new KeyValuePair<int, int>(i, j - dInvJ)] = SymbolsType.WALKABLE;
                    this._map[new KeyValuePair<int, int>(i - dInvI + dI, j - dInvJ)] = SymbolsType.WALKABLE;
                }
                else
                {
                    this._map[new KeyValuePair<int, int>(i + dInvI, j)] = SymbolsType.WALKABLE;
                    this._map[new KeyValuePair<int, int>(i + dInvI, j + dInvJ + dJ)] = SymbolsType.WALKABLE;
                    this._map[new KeyValuePair<int, int>(i - dInvI, j)] = SymbolsType.WALKABLE;
                    this._map[new KeyValuePair<int, int>(i - dInvI, j - dInvJ + dJ)] = SymbolsType.WALKABLE;
                }
                this._map[new KeyValuePair<int, int>(i, j)] = SymbolsType.WALKABLE;
                this._map[new KeyValuePair<int, int>(i + dI, j + dJ)] = SymbolsType.WALKABLE;
            }
        }

        protected void applyCorrection(Action<int, int> correction)
        {
            for (int i = _xMin; i <= _xMax; i++)
            {
                for (int j = _yMin; j <= _yMax; j++)
                {
                    correction(i, j);
                }
            }
        }

        protected bool checkAdjacent4(int i, int j, SymbolsType type)
        {
            return get(i + 1, j, type) || get(i - 1, j, type) || get(i, j + 1, type) || get(i, j - 1, type);
        }

        protected bool checkAdjacent8(int i, int j, SymbolsType type)
        {
            return checkAdjacent4(i, j, type) || get(i + 1, j + 1, type) || get(i - 1, j - 1, type)
                    || get(i - 1, j + 1, type) || get(i + 1, j - 1, type);
        }

        protected bool get(int i, int j, SymbolsType type)
        {
            return this._map[new KeyValuePair<int, int>(i, j)].Equals(type);
        }

        protected bool CanPutRoom(KeyValuePair<int, int> center, KeyValuePair<int, int> doorLink, KeyValuePair<int, int> dir, IRoom room)
        {
            bool can = true;
            bool isNearDoor = false;
            KeyValuePair<int, int> dd = new KeyValuePair<int, int>(doorLink.Key + (int)Math.Sign(dir.Key),
                    doorLink.Value + (int)Math.Sign(dir.Value));

            foreach (KeyValuePair<int, int> positions in room.Map.Keys)
            {
                var pii = MathUtils.Sum(center, positions);
                if (this._map.ContainsKey(pii))
                {
                    can = false;
                    break;
                }

                if (pii.Equals(dd) && room.Map[positions].Equals(SymbolsType.DOOR))
                {
                    isNearDoor = true;
                }
            }

            return can && isNearDoor;
        }

        protected void GenerateRoom(KeyValuePair<int, int> center, X room)
        {

            foreach (KeyValuePair<KeyValuePair<int, int>, SymbolsType> p in room.Map)
            {
                KeyValuePair<int, int> position = MathUtils.Sum(center, p.Key);

                this._map[position] = p.Value;

                if (position.Key < this._xMin)
                {
                    this._xMin = position.Key;
                }
                if (position.Key > this._xMax)
                {
                    this._xMax = position.Key;
                }

                if (position.Value < this._yMin)
                {
                    this._yMin = position.Value;
                }
                if (position.Value > this._yMax)
                {
                    this._yMax = position.Value;
                }
            }

            this._rooms.Add(room);
        }
        protected KeyValuePair<int, int> GetConnectionsLinking()
        {
            IList<KeyValuePair<int, int>> allDoors = new List<KeyValuePair<int, int>>();
            foreach (KeyValuePair<int, int> p in this._map.Keys)
            {
                if (this._map[p].Equals(SymbolsType.DOOR))
                {
                    allDoors.Add(p);
                }
            }
            return allDoors[_rnd.Next(allDoors.Count)];
        }

        protected void HaveInitMapAndBaseRoom()
        {
            this.HaveInitMap();
            this.HaveInitBaseRoom();
        }

        protected void HaveInitMap()
        {
            if (this._rooms.Count == 0)
            {
                throw new ArgumentException();
            }
        }

        protected void HaveInitBaseRoom()
        {
            if (this._baseRooms.Count == 0)
            {
                throw new ArgumentException();
            }
        }

        public IWorldGeneratorBuilder<X> build()
        {
            HaveInitMapAndBaseRoom();
            return this;
        }

        public IDictionary<KeyValuePair<int, int>, SymbolsType> Map
        {
            get
            {
                HaveInitMapAndBaseRoom();
                return this._map;
            }
        }

        public int MinX
        {
            get
            {
                HaveInitMapAndBaseRoom();
                return this._xMin;
            }
        }

        public int MaxX
        {
            get
            {
                HaveInitMapAndBaseRoom();
                return this._xMax;
            }
        }

        public int MinY
        {
            get
            {
                HaveInitMapAndBaseRoom();
                return this._yMin;
            }
        }

        public int MaxY
        {
            get
            {
                HaveInitMapAndBaseRoom();
                return this._yMax;
            }
        }

        public bool IsKeyObjectPresent
        {
            get
            {
                HaveInitMapAndBaseRoom();
                return this._objRoomIndex.HasValue;
            }
        }
    }
}