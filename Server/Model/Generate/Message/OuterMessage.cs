using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterOpcode.C2M_TestRequest)]
	[ProtoContract]
	public partial class C2M_TestRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string request { get; set; }

	}

	[Message(OuterOpcode.M2C_TestResponse)]
	[ProtoContract]
	public partial class M2C_TestResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string response { get; set; }

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterOpcode.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int MapIndex { get; set; }

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterOpcode.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

// 自己unitId
		[ProtoMember(4)]
		public long MyId { get; set; }

	}

	[Message(OuterOpcode.MoveInfo)]
	[ProtoContract]
	public partial class MoveInfo: Object
	{
		[ProtoMember(1)]
		public List<float> X = new List<float>();

		[ProtoMember(2)]
		public List<float> Y = new List<float>();

		[ProtoMember(3)]
		public List<float> Z = new List<float>();

		[ProtoMember(4)]
		public float A { get; set; }

		[ProtoMember(5)]
		public float B { get; set; }

		[ProtoMember(6)]
		public float C { get; set; }

		[ProtoMember(7)]
		public float W { get; set; }

		[ProtoMember(8)]
		public int TurnSpeed { get; set; }

	}

	[Message(OuterOpcode.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo: Object
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int ConfigId { get; set; }

		[ProtoMember(3)]
		public int Type { get; set; }

		[ProtoMember(4)]
		public float X { get; set; }

		[ProtoMember(5)]
		public float Y { get; set; }

		[ProtoMember(6)]
		public float Z { get; set; }

		[ProtoMember(7)]
		public float ForwardX { get; set; }

		[ProtoMember(8)]
		public float ForwardY { get; set; }

		[ProtoMember(9)]
		public float ForwardZ { get; set; }

		[ProtoMember(10)]
		public List<int> Ks = new List<int>();

		[ProtoMember(11)]
		public List<long> Vs = new List<long>();

		[ProtoMember(12)]
		public MoveInfo MoveInfo { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateUnits)]
	[ProtoContract]
	public partial class M2C_CreateUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.M2C_CreateMyUnit)]
	[ProtoContract]
	public partial class M2C_CreateMyUnit: Object, IActorMessage
	{
		[ProtoMember(1)]
		public UnitInfo Unit { get; set; }

	}

	[Message(OuterOpcode.M2C_StartSceneChange)]
	[ProtoContract]
	public partial class M2C_StartSceneChange: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long SceneInstanceId { get; set; }

		[ProtoMember(2)]
		public string SceneName { get; set; }

		[ProtoMember(3)]
		public int MapId { get; set; }

		[ProtoMember(4)]
		public int MatchMode { get; set; }

	}

	[Message(OuterOpcode.M2C_RemoveUnits)]
	[ProtoContract]
	public partial class M2C_RemoveUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<long> Units = new List<long>();

	}

	[Message(OuterOpcode.C2M_PathfindingResult)]
	[ProtoContract]
	public partial class C2M_PathfindingResult: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.C2M_Stop)]
	[ProtoContract]
	public partial class C2M_Stop: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	[ProtoContract]
	public partial class M2C_PathfindingResult: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

		[ProtoMember(5)]
		public List<float> Xs = new List<float>();

		[ProtoMember(6)]
		public List<float> Ys = new List<float>();

		[ProtoMember(7)]
		public List<float> Zs = new List<float>();

	}

	[Message(OuterOpcode.M2C_Stop)]
	[ProtoContract]
	public partial class M2C_Stop: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public float X { get; set; }

		[ProtoMember(4)]
		public float Y { get; set; }

		[ProtoMember(5)]
		public float Z { get; set; }

		[ProtoMember(6)]
		public float A { get; set; }

		[ProtoMember(7)]
		public float B { get; set; }

		[ProtoMember(8)]
		public float C { get; set; }

		[ProtoMember(9)]
		public float W { get; set; }

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterOpcode.C2G_Ping)]
	[ProtoContract]
	public partial class C2G_Ping: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_Ping)]
	[ProtoContract]
	public partial class G2C_Ping: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long Time { get; set; }

	}

	[Message(OuterOpcode.G2C_Test)]
	[ProtoContract]
	public partial class G2C_Test: Object, IMessage
	{
	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterOpcode.C2M_Reload)]
	[ProtoContract]
	public partial class C2M_Reload: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.M2C_Reload)]
	[ProtoContract]
	public partial class M2C_Reload: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterOpcode.C2R_Login)]
	[ProtoContract]
	public partial class C2R_Login: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.R2C_Login)]
	[ProtoContract]
	public partial class R2C_Login: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Address { get; set; }

		[ProtoMember(2)]
		public long Key { get; set; }

		[ProtoMember(3)]
		public long GateId { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterOpcode.C2G_LoginGate)]
	[ProtoContract]
	public partial class C2G_LoginGate: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long GateId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGate)]
	[ProtoContract]
	public partial class G2C_LoginGate: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	[ProtoContract]
	public partial class G2C_TestHotfixMessage: Object, IMessage
	{
		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterOpcode.C2M_TestRobotCase)]
	[ProtoContract]
	public partial class C2M_TestRobotCase: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[Message(OuterOpcode.M2C_TestRobotCase)]
	[ProtoContract]
	public partial class M2C_TestRobotCase: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterOpcode.C2M_TransferMap)]
	[ProtoContract]
	public partial class C2M_TransferMap: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_TransferMap)]
	[ProtoContract]
	public partial class M2C_TransferMap: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(A2C_LoginAccount))]
	[Message(OuterOpcode.C2A_LoginAccount)]
	[ProtoContract]
	public partial class C2A_LoginAccount: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string AccountName { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.A2C_LoginAccount)]
	[ProtoContract]
	public partial class A2C_LoginAccount: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.A2C_Disconnect)]
	[ProtoContract]
	public partial class A2C_Disconnect: Object, IMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

	}

	[Message(OuterOpcode.ServerInfoProto)]
	[ProtoContract]
	public partial class ServerInfoProto: Object
	{
		[ProtoMember(1)]
		public int Id { get; set; }

		[ProtoMember(2)]
		public int Status { get; set; }

		[ProtoMember(3)]
		public string ServerName { get; set; }

	}

	[ResponseType(nameof(A2C_GetServerInfos))]
	[Message(OuterOpcode.C2A_GetServerInfos)]
	[ProtoContract]
	public partial class C2A_GetServerInfos: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetServerInfos)]
	[ProtoContract]
	public partial class A2C_GetServerInfos: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<ServerInfoProto> ServerInfoList = new List<ServerInfoProto>();

	}

	[Message(OuterOpcode.RoleInfoProto)]
	[ProtoContract]
	public partial class RoleInfoProto: Object
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int State { get; set; }

		[ProtoMember(4)]
		public long AccountId { get; set; }

		[ProtoMember(5)]
		public long CreateTime { get; set; }

		[ProtoMember(6)]
		public long LastLoginTime { get; set; }

		[ProtoMember(7)]
		public int ServerId { get; set; }

	}

	[ResponseType(nameof(A2C_CreateRole))]
	[Message(OuterOpcode.C2A_CreteRole)]
	[ProtoContract]
	public partial class C2A_CreteRole: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public string Name { get; set; }

		[ProtoMember(4)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_CreateRole)]
	[ProtoContract]
	public partial class A2C_CreateRole: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public RoleInfoProto RoleInfo { get; set; }

	}

	[ResponseType(nameof(A2C_GetRoleInfos))]
	[Message(OuterOpcode.C2A_GetRoleInfos)]
	[ProtoContract]
	public partial class C2A_GetRoleInfos: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetRoleInfos)]
	[ProtoContract]
	public partial class A2C_GetRoleInfos: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<RoleInfoProto> RoleInfo = new List<RoleInfoProto>();

	}

	[ResponseType(nameof(A2C_DeleteRole))]
	[Message(OuterOpcode.C2A_DeleteRole)]
	[ProtoContract]
	public partial class C2A_DeleteRole: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public string RoleName { get; set; }

		[ProtoMember(4)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_DeleteRole)]
	[ProtoContract]
	public partial class A2C_DeleteRole: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long DeleteRoleInfoId { get; set; }

	}

	[ResponseType(nameof(A2C_GetRealmKey))]
	[Message(OuterOpcode.C2A_GetRealmKey)]
	[ProtoContract]
	public partial class C2A_GetRealmKey: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetRealmKey)]
	[ProtoContract]
	public partial class A2C_GetRealmKey: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string RealmKey { get; set; }

		[ProtoMember(2)]
		public string RealmAddress { get; set; }

	}

	[ResponseType(nameof(R2C_LoginRealm))]
	[Message(OuterOpcode.C2R_LoginRealm)]
	[ProtoContract]
	public partial class C2R_LoginRealm: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

		[ProtoMember(2)]
		public string RealmTokenKey { get; set; }

	}

	[Message(OuterOpcode.R2C_LoginRealm)]
	[ProtoContract]
	public partial class R2C_LoginRealm: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string GateSessionKey { get; set; }

		[ProtoMember(2)]
		public string GateAddress { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGameGate))]
	[Message(OuterOpcode.C2G_LoginGameGate)]
	[ProtoContract]
	public partial class C2G_LoginGameGate: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Key { get; set; }

		[ProtoMember(2)]
		public long RoleId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

		[ProtoMember(4)]
		public long ServerId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGameGate)]
	[ProtoContract]
	public partial class G2C_LoginGameGate: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[ResponseType(nameof(G2C_EnterGame))]
	[Message(OuterOpcode.C2G_EnterGame)]
	[ProtoContract]
	public partial class C2G_EnterGame: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterGame)]
	[ProtoContract]
	public partial class G2C_EnterGame: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

//unitId
		[ProtoMember(1)]
		public long MyId { get; set; }

	}

	[ResponseType(nameof(M2C_TestUnitNumeric))]
	[Message(OuterOpcode.C2M_TestUnitNumeric)]
	[ProtoContract]
	public partial class C2M_TestUnitNumeric: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_TestUnitNumeric)]
	[ProtoContract]
	public partial class M2C_TestUnitNumeric: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.M2C_NoticeUnitNumeric)]
	[ProtoContract]
	public partial class M2C_NoticeUnitNumeric: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long unitId { get; set; }

		[ProtoMember(2)]
		public int NumericType { get; set; }

		[ProtoMember(3)]
		public long NewValue { get; set; }

	}

	[ResponseType(nameof(M2C_AddAttributePoint))]
	[Message(OuterOpcode.C2M_AddAttributePoint)]
	[ProtoContract]
	public partial class C2M_AddAttributePoint: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int NumericType { get; set; }

	}

	[Message(OuterOpcode.M2C_AddAttributePoint)]
	[ProtoContract]
	public partial class M2C_AddAttributePoint: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(M2C_EnterMatch))]
	[Message(OuterOpcode.C2M_EnterMatch)]
	[ProtoContract]
	public partial class C2M_EnterMatch: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int MatchMode { get; set; }

		[ProtoMember(2)]
		public int MapId { get; set; }

	}

	[Message(OuterOpcode.M2C_EnterMatch)]
	[ProtoContract]
	public partial class M2C_EnterMatch: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public int MatchMode { get; set; }

	}

	[ResponseType(nameof(G2C_GetReadyGame))]
	[Message(OuterOpcode.C2G_GetReadyGame)]
	[ProtoContract]
	public partial class C2G_GetReadyGame: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_GetReadyGame)]
	[ProtoContract]
	public partial class G2C_GetReadyGame: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_CancelReadyGame))]
	[Message(OuterOpcode.C2G_CancelReadyGame)]
	[ProtoContract]
	public partial class C2G_CancelReadyGame: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_CancelReadyGame)]
	[ProtoContract]
	public partial class G2C_CancelReadyGame: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_AddGameRoom))]
	[Message(OuterOpcode.C2G_AddGameRoom)]
	[ProtoContract]
	public partial class C2G_AddGameRoom: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_AddGameRoom)]
	[ProtoContract]
	public partial class G2C_AddGameRoom: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_StartGame)]
	[ProtoContract]
	public partial class G2C_StartGame: Object, IActorMessage
	{
	}

	[ResponseType(nameof(G2C_CreateTowerResponse))]
	[Message(OuterOpcode.C2G_CreateTowerRequest)]
	[ProtoContract]
	public partial class C2G_CreateTowerRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int RoomIndex { get; set; }

		[ProtoMember(2)]
		public int TowerConfigId { get; set; }

		[ProtoMember(3)]
		public float TowerPX { get; set; }

		[ProtoMember(4)]
		public float TowerPY { get; set; }

		[ProtoMember(5)]
		public long TowerId { get; set; }

	}

	[Message(OuterOpcode.G2C_CreateTowerResponse)]
	[ProtoContract]
	public partial class G2C_CreateTowerResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_ReturnCreateTowerMessage)]
	[ProtoContract]
	public partial class G2C_ReturnCreateTowerMessage: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Position { get; set; }

		[ProtoMember(2)]
		public int TowerConfigId { get; set; }

		[ProtoMember(3)]
		public float TowerPX { get; set; }

		[ProtoMember(4)]
		public float TowerPY { get; set; }

		[ProtoMember(5)]
		public long TowerId { get; set; }

	}

	[ResponseType(nameof(G2C_CreateMonsterResponse))]
	[Message(OuterOpcode.C2G_CreateMonsterRequest)]
	[ProtoContract]
	public partial class C2G_CreateMonsterRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int RoomIndex { get; set; }

		[ProtoMember(2)]
		public int MonsterId { get; set; }

		[ProtoMember(3)]
		public int Position { get; set; }

	}

	[Message(OuterOpcode.G2C_CreateMonsterResponse)]
	[ProtoContract]
	public partial class G2C_CreateMonsterResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_ReturnCreateMonsterMessage)]
	[ProtoContract]
	public partial class G2C_ReturnCreateMonsterMessage: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int MonsterId { get; set; }

		[ProtoMember(2)]
		public int Position { get; set; }

	}

	[ResponseType(nameof(G2C_WinGame))]
	[Message(OuterOpcode.C2G_WinGame)]
	[ProtoContract]
	public partial class C2G_WinGame: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int RoomIndex { get; set; }

		[ProtoMember(2)]
		public int Position { get; set; }

	}

	[Message(OuterOpcode.G2C_WinGame)]
	[ProtoContract]
	public partial class G2C_WinGame: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_ReturnWinGame)]
	[ProtoContract]
	public partial class G2C_ReturnWinGame: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long WinUnitId { get; set; }

		[ProtoMember(2)]
		public List<int> WinItemId = new List<int>();

		[ProtoMember(3)]
		public List<int> WinItemNumber = new List<int>();

		[ProtoMember(4)]
		public List<int> FailItemId = new List<int>();

		[ProtoMember(5)]
		public List<int> FailItemNumber = new List<int>();

	}

	[ResponseType(nameof(G2C_ExitGameAndEnterMainHome))]
	[Message(OuterOpcode.C2G_ExitGameAndEnterMainHome)]
	[ProtoContract]
	public partial class C2G_ExitGameAndEnterMainHome: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_ExitGameAndEnterMainHome)]
	[ProtoContract]
	public partial class G2C_ExitGameAndEnterMainHome: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_DeleteTower))]
	[Message(OuterOpcode.C2G_DeleteTower)]
	[ProtoContract]
	public partial class C2G_DeleteTower: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int RoomIndex { get; set; }

		[ProtoMember(2)]
		public long TowerId { get; set; }

	}

	[Message(OuterOpcode.G2C_DeleteTower)]
	[ProtoContract]
	public partial class G2C_DeleteTower: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_ReturnDeleteTower)]
	[ProtoContract]
	public partial class G2C_ReturnDeleteTower: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long TowerId { get; set; }

	}

	[Message(OuterOpcode.OptionEvent)]
	[ProtoContract]
	public partial class OptionEvent: Object
	{
		[ProtoMember(1)]
		public int position { get; set; }

		[ProtoMember(2)]
		public int optType { get; set; }

		[ProtoMember(3)]
		public int TowerConfigId { get; set; }

		[ProtoMember(4)]
		public long TowerId { get; set; }

		[ProtoMember(5)]
		public long NewTowerId { get; set; }

		[ProtoMember(6)]
		public float TowerX { get; set; }

		[ProtoMember(7)]
		public float TowerY { get; set; }

		[ProtoMember(8)]
		public int MonsterConfigId { get; set; }

		[ProtoMember(9)]
		public long MonsterId { get; set; }

		[ProtoMember(10)]
		public List<int> SkillIds = new List<int>();

	}

	[Message(OuterOpcode.FrameOpts)]
	[ProtoContract]
	public partial class FrameOpts: Object
	{
		[ProtoMember(1)]
		public int frameid { get; set; }

		[ProtoMember(2)]
		public List<OptionEvent> opts = new List<OptionEvent>();

	}

	[Message(OuterOpcode.NextFrameOpts)]
	[ProtoContract]
	public partial class NextFrameOpts: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int frameid { get; set; }

		[ProtoMember(2)]
		public List<OptionEvent> opts = new List<OptionEvent>();

	}

	[Message(OuterOpcode.LogicFrame)]
	[ProtoContract]
	public partial class LogicFrame: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int frameid { get; set; }

		[ProtoMember(2)]
		public List<FrameOpts> unsync_frames = new List<FrameOpts>();

	}

	[Message(OuterOpcode.UpLoadFrameId)]
	[ProtoContract]
	public partial class UpLoadFrameId: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int frameid { get; set; }

	}

	[Message(OuterOpcode.ItemInfo)]
	[ProtoContract]
	public partial class ItemInfo: Object
	{
		[ProtoMember(1)]
		public long ItemUid { get; set; }

		[ProtoMember(2)]
		public int ItemConfigId { get; set; }

		[ProtoMember(3)]
		public int ItemNumber { get; set; }

	}

	[Message(OuterOpcode.G2C_ItemUpdateOpInfo)]
	[ProtoContract]
	public partial class G2C_ItemUpdateOpInfo: Object, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public ItemInfo ItemInfo { get; set; }

		[ProtoMember(2)]
		public int Op { get; set; }

		[ProtoMember(3)]
		public int ContainerType { get; set; }

	}

	[Message(OuterOpcode.G2C_AllItemsList)]
	[ProtoContract]
	public partial class G2C_AllItemsList: Object, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<ItemInfo> ItemInfoList = new List<ItemInfo>();

		[ProtoMember(2)]
		public int ContainerType { get; set; }

	}

	[Message(OuterOpcode.C2G_OpItem)]
	[ProtoContract]
	public partial class C2G_OpItem: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int OpType { get; set; }

		[ProtoMember(2)]
		public long ItemUid { get; set; }

		[ProtoMember(3)]
		public int ItemNumber { get; set; }

	}

	[Message(OuterOpcode.FightItemInfo)]
	[ProtoContract]
	public partial class FightItemInfo: Object
	{
		[ProtoMember(1)]
		public long FightItemUid { get; set; }

		[ProtoMember(2)]
		public int FightItemConfigId { get; set; }

		[ProtoMember(3)]
		public List<int> AddedTalent = new List<int>();

	}

	[Message(OuterOpcode.G2C_FightItemUpdateOpInfo)]
	[ProtoContract]
	public partial class G2C_FightItemUpdateOpInfo: Object, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public FightItemInfo FightItemInfo { get; set; }

		[ProtoMember(2)]
		public int Op { get; set; }

	}

	[Message(OuterOpcode.G2C_AllFightItemsList)]
	[ProtoContract]
	public partial class G2C_AllFightItemsList: Object, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<FightItemInfo> FightItemInfoList = new List<FightItemInfo>();

	}

	[Message(OuterOpcode.C2G_OpFightItem)]
	[ProtoContract]
	public partial class C2G_OpFightItem: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int OpType { get; set; }

		[ProtoMember(2)]
		public long FightItemUid { get; set; }

		[ProtoMember(3)]
		public int TalentConfigId { get; set; }

	}

}
