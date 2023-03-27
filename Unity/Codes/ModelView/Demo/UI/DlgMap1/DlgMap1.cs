using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMap1 :Entity,IAwake,IUILogic
	{

		public DlgMap1ViewComponent View { get => this.Parent.GetComponent<DlgMap1ViewComponent>();}

		public List<ESButton_CreateTower> eSButton_CreateTowers = new List<ESButton_CreateTower>();

	}
}
