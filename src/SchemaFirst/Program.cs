using System;
using GraphQL;
using GraphQL.Types;

namespace SchemaFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryScalar();
        }

        private static void InMemoryScalar()
        {
            var schema = Schema.For(@"
                type Query {
                    hello: String
                }
            ");

            var json = schema.Execute(opts =>
            {
                opts.Query = "{ hello }";
                opts.Root = new { Hello = "Hello World" };
            });

            Console.WriteLine(json);
        }
    }
}
