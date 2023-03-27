namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMainHome :Entity,IAwake,IUILogic
	{

		public DlgMainHomeViewComponent View { get => this.Parent.GetComponent<DlgMainHomeViewComponent>();} 

		 

	}
}
