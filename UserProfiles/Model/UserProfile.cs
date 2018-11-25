using System;

namespace UserProfiles.Model
{
    public class UserProfile
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Account { get; set; }
        public string DomainName { get; set; }
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public bool IsAdmin { get; set; }
        public int? InsertedBy { get; set; }
        public DateTime? InsertedAt { get; set; }
    }

    public enum Status
    {
        Active = 0,
        Deleted = -1,
        Undefined
    }
}