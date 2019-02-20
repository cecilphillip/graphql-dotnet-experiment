using System.Collections.Generic;

namespace CodeFirstWeb.Data
{
    public class Show
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }

        public IEnumerable<Episode> Episodes { get; set; }
    }
}