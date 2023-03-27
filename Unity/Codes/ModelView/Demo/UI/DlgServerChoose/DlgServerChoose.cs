using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgServerChoose :Entity,IAwake,IUILogic
	{

		public DlgServerChooseViewComponent View { get => this.Parent.GetComponent<DlgServerChooseViewComponent>();}

		public Dictionary<int, Scroll_Item_serverTest> Items;

	}
}
