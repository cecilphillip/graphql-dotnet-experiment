using GraphQL;
using GraphQL.Types;

namespace CodeFirstWeb.GraphQL
{
    public class ShowManagerSchema : Schema
    {
        public ShowManagerSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ShowManagerQuery>();

        }
    }
}