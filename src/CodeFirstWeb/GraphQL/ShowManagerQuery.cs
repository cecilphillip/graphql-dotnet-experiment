using CodeFirstWeb.Data;
using GraphQL.Types;

namespace CodeFirstWeb.GraphQL
{
    public class ShowManagerQuery : ObjectGraphType
    {
        public ShowManagerQuery(DataRepository dataRepo)
        {
            Field<ListGraphType<ShowType>>("shows", resolve: ctx => dataRepo.Shows);
        }
    }
}