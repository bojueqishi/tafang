namespace ET
{
	public enum PlayerState
	{
		Disconnect,
		Gate,
		Game,
	}
	public sealed class Player : Entity, IAwake<string>,IAwake<long,long>
	{
		public long AccountId { get; set; }
		public long ServerId { get; set; }
		public PlayerState PlayerState { get; set; }

		public Session ClientSession { get; set; }
	}
}