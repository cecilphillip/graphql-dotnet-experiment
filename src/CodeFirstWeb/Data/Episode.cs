namespace CodeFirstWeb.Data
{
    public class Episode
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Show Show { get; set; }
    }
}