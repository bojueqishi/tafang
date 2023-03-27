using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(LogicComponent))]
    public class GameRoomComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, List<Unit>> rooms = new Dictionary<int,List<Unit>>();
        public Dictionary<int, int> roomstate = new Dictionary<int, int>();//0房间关闭，1房间开着但是没有准备，2房间开着游戏也开始
        public Dictionary<int, long> logics = new Dictionary<int, long>();
        public int CurrentRoom;
    }
}

