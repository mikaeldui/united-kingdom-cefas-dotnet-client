namespace UnitedKingdom.Cefas.DataPortal
{
    public class HoldingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool SearchDefault { get; set; }
        public bool NotifySubmitterOnApproveReject { get; set; }
        public bool NotifyApproverOnSubmitReady { get; set; }
        public bool NotifyApproverByProperty { get; set; }
        public bool AllowExternalSync { get; set; }
        public bool AutoApprove { get; set; }
        public bool ShowData { get; set; }
        public HoldingTypeSection[]? Sections { get; set; }
        /// <summary>
        /// E.g. "Self".
        /// </summary>
        public Dictionary<string, Link> Links { get; set; }
        public object[] Children { get; set; }
        public object[] Mutations { get; set; }
        public object[] ApprovalMatrix { get; set; }
        public string? SubmitTemplate { get; set; }
        public string? ApproveTemplate { get; set; }
        public string? RejectTemplate { get; set; }
    }
}
