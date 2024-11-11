using Bogus;
using BookLibraryAPI.Models;
using System.Collections.Generic;

namespace BookLibraryApiTests.Factories
{
    public static class BookFactory
    {
        public static List<Book> GenerateBooks(int total)
        {
            var faker = new Faker<Book>()
                .RuleFor(b => b.Id, f => f.IndexFaker + 1)
                .RuleFor(b => b.Title, f => f.Lorem.Sentence())
                .RuleFor(b => b.Author, f => f.Person.FullName)
                .RuleFor(b => b.PublishedYear, f => f.Date.Past(50).Year);

            return faker.Generate(total);
        }

        public static Book GenerateBook()
        {
            var faker = new Faker<Book>()
                .RuleFor(b => b.Id, f => f.IndexFaker + 1)
                .RuleFor(b => b.Title, f => f.Lorem.Sentence())
                .RuleFor(b => b.Author, f => f.Person.FullName)
                .RuleFor(b => b.PublishedYear, f => f.Date.Past(50).Year);

            return faker.Generate();
        }
    }
}
