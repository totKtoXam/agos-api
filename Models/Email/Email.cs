namespace agos_api.Models.Email
{
    public class EmailSendViewModel
    {
        public string EmailRecipient { get; set; }
#nullable enable
        public string? FullnameSubject { get; set; }
        public string? Link { get; set; }
        public string? MessageText { get; set; }
        public string? MessageTitle { get; set; }
#nullable enable
    }
}