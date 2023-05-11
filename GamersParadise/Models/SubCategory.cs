namespace GamersParadise.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserThread> UserThreads { get; set; }
    }
}
