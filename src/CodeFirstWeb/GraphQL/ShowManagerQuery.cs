using System.Linq;
using CodeFirstWeb.Data;
using GraphQL.Types;

namespace CodeFirstWeb.GraphQL
{
    public class ShowManagerQuery : ObjectGraphType
    {
        public ShowManagerQuery(DataRepository dataRepo)
        {
            Field<ListGraphType<ShowType>>("shows", resolve: ctx => dataRepo.Shows);

            Field<ShowType>("show",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<string>("id");
                    return dataRepo.Shows.SingleOrDefault(s => s.Id == id);
                });
        }
    }
}