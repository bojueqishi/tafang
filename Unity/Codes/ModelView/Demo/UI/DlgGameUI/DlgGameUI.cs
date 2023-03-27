using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGameUI :Entity,IAwake,IUILogic
	{

		public DlgGameUIViewComponent View { get => this.Parent.GetComponent<DlgGameUIViewComponent>();}
        public List<int> ItemId = new List<int>();
        public List<int> ItemNumber = new List<int>();
        public Dictionary<int, Scroll_Item_Reward> Items;
        public int VisualControl;
        public float VisualScale;
        public List<ESButton_CreateTower> AllTowers = new List<ESButton_CreateTower>();
        public List<ESButton_CreateTower> CurrentTowers = new List<ESButton_CreateTower>();


    }
}
