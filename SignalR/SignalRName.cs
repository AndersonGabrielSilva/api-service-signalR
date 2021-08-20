namespace ApiServiceHub.SignalR
{
    public static class SignalRName
    {
        #region Rotas
        public const string RouteExampleHub = "/exemplehub";
        #endregion

        #region Grupos
        public const string Group = nameof(Group);
        #endregion

        #region Metodos Server
        public const string JoinGroup = nameof(JoinGroup);
        public const string LeaveGroup = nameof(LeaveGroup);
        #endregion

        #region Metodos Client
        public const string ExampleHub = nameof(ExampleHub);
        #endregion
    }
}
