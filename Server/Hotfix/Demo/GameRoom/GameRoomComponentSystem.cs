using System.Collections.Generic;

namespace ET
{
    public class GameRoomComponentAwakeSystem : AwakeSystem<GameRoomComponent>
    {
        public override void Awake(GameRoomComponent self)
        {
            self.CurrentRoom = 0;
            self.rooms.Clear();
            for(int i=1;i<=100;i++)
            {
                List<Unit> units = new List<Unit>();
                self.rooms.Add(i, units);
                self.roomstate.Add(i, 0);
            }
        }
    }
    public class GameRoomComponentDestroySystem : DestroySystem<GameRoomComponent>
    {
        public override void Destroy(GameRoomComponent self)
        {
            self.CurrentRoom = 0;
            self.rooms.Clear();
        }
    }
    [FriendClass(typeof(GameRoomComponent))]
    public static class GameRoomComponentSystem
    {
        public static void Add(this GameRoomComponent self,int roomIndex,List<Unit> unit)
        {
            if (self.rooms.ContainsKey(roomIndex))
            {
                self.rooms[roomIndex] = unit;
            }
            else
            {
                self.rooms.Add(roomIndex, unit);
            }
        }
        public static void Remove(this GameRoomComponent self,int RoomIndex)
        {
            self.rooms.Remove(RoomIndex);
        }
        public static void RemoveUnit(this GameRoomComponent self,int RoomIndex,Unit unit)
        {
            self.rooms[RoomIndex].Remove(unit);
        }
        public static void ClearRoomUnit(this GameRoomComponent self,int RoomIndex)
        {
            List<Unit> units = self.Get(RoomIndex);
            units.Clear();
            self.rooms[RoomIndex] = units;
        }
        public static void SetRoomState(this GameRoomComponent self, int RoomIndex,int State)
        {
            self.roomstate[RoomIndex] = 0;
        }
        public static int GetRoomState(this GameRoomComponent self, int RoomIndex)
        {
            return self.roomstate[RoomIndex];
        }
        public static List<Unit> Get(this GameRoomComponent self,int RoomIndex)
        {
            if(self.rooms.TryGetValue(RoomIndex,out List<Unit> value))
            {
                return value;
            }
            return null;
        }
        public static void StartGame(this GameRoomComponent self,int RoomIndex)
        {
            long id = IdGenerater.Instance.GenerateId();
            LogicComponent logic = self.AddChildWithId<LogicComponent,int>(id,RoomIndex);
            self.logics[RoomIndex] = id;
        }
    }
}
