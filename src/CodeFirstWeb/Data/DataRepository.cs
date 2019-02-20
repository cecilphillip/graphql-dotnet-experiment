using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace CodeFirstWeb.Data
{
    public class DataRepository
    {
        public IEnumerable<Episode> Episodes { get; set; }
        public IEnumerable<Show> Shows { get; set; }

        public DataRepository()
        {
            Init();
        }

        private void Init()
        {
            int showId = 0;
            Faker<Show> showFaker = new Faker<Show>()
                        .RuleFor(s => s.Id, f => $"#S{showId++}")
                        .RuleFor(s => s.Host, f => f.Name.FullName())
                        .RuleFor(s => s.Name, f => $"The {f.Company.CompanyName()} Show");

            Shows = showFaker.Generate(20);

            int episodeId = 0;
            Faker<Episode> episodeFaker = new Faker<Episode>()
                .RuleFor(e => e.Title, f => f.Hacker.Phrase());

            Shows.ForEach(s =>
            {
                s.Episodes = episodeFaker
                    .RuleFor(e => e.Id, f => $"{s.Name}-EP-#{episodeId++}")
                    .RuleFor(e => e.Show, f => s).Generate(10);
                Episodes = (Episodes == null) ? new List<Episode>(s.Episodes) : Episodes.Concat(s.Episodes);
                episodeId = 0;
            });
        }
    }
}