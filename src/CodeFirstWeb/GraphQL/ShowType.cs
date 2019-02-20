using System.Linq;
using System.Threading.Tasks;
using CodeFirstWeb.Data;
using GraphQL.DataLoader;
using GraphQL.Types;


namespace CodeFirstWeb.GraphQL
{
    public class ShowType : ObjectGraphType<Show>
    {
        public ShowType(DataRepository dataRepository, IDataLoaderContextAccessor dataLoaderAccesor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("This is the name of the show");
            Field(t => t.Host).Description("This is the name of th person show hosts the show");

            Field<ListGraphType<EpisodeType>>(
                name: "episodes",
                description: "The episodes associated with this show",
                resolve: ctx =>
                {
                  var dataLoader=  dataLoaderAccesor.Context.GetOrAddCollectionBatchLoader<string, Episode>("GetEpisodesByShowID", (epIds) =>
                    {
                        var results = dataRepository.Episodes.Where(e => epIds.Contains(e.Show.Id)).ToLookup(e => e.Id);
                        return Task.FromResult(results);
                    });
                    return dataLoader.LoadAsync(ctx.Source.Id);
                }
            );
        }
    }
}