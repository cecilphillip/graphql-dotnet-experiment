using CodeFirstWeb.Data;
using GraphQL.Types;

namespace CodeFirstWeb.GraphQL
{
    public class EpisodeType : ObjectGraphType<Episode>
    {
        public EpisodeType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
        }
    }
}