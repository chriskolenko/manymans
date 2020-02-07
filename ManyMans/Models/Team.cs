using Dapper.Contrib.Extensions;

namespace ManyMans
{
    public class Team
    {
        [Key]
        public long Id { get; set; }
 
        public string Name { get; set; }
    }
}
