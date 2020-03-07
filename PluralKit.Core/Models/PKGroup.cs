using NodaTime;

namespace PluralKit.Core
{
    public class PKGroup
    {
        public int Id { get; set; }
        public int System { get; set; }
        public string Hid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string Tag { get; set; }
        public int Priority { get; set; }
        public PrivacyLevel Privacy { get; set; }
        public Instant Created { get; set; }
    }
}