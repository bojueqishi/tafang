using System.Security.Policy;

namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        public const int ERR_NetWorkError = 200002;//网络错误
        public const int ERR_LoginInfoIsNull = 200003;//登陆信息错误
        public const int ERR_AccountNameFormError = 200004;//登陆账号格式错误
        public const int ERR_PasswordFormError = 200005;//登陆密码格式错误
        public const int ERR_AccountInBlackListError = 200006;//账号处于黑名单中
        public const int ERR_LoginPasswordError = 200007;//登陆密码错误
        public const int ERR_RequestRepeatedly = 200008;
        public const int ERR_TokenError = 200009;
        public const int ERR_CreateRoleNameError = 200010;
        public const int ERR_CreateRoleNameSameError = 200010;
        public const int ERR_RoleNotExist = 200011;
        public const int ERR_RequestSceneTypeError = 200012;
        public const int ERR_ConnectGateKeyError = 200013;
        public const int ERR_OtherAccountlogin = 200014;
        public const int ERR_SessionPlayerError = 200015;
        public const int ERR_NonePlayerError = 200016;
        public const int ERR_PlayerSessionError = 200017;
        public const int ERR_SessionStateError = 200018;
        public const int ERR_EnterGameError = 200018;
        public const int ERR_ReEnterGameError = 200019;
        public const int ERR_NumericTypeNotAddPoint = 200020;
        public const int ERR_AddPointNotEnough = 200021;
        public const int ERR_RoomIndexError = 200022;
        public const int ERR_IsInGameError = 200023;
    }
}