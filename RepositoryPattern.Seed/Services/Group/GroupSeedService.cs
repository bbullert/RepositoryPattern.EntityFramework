﻿using Bogus;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public class GroupSeedService : IGroupSeedService
    {
        public Faker<Group> SeedGenerator(Faker<User> userGenerator)
        {
            Random random = new Random();
            var generator = new Faker<Group>()
                .RuleFor(o => o.Name, (f, u) =>
                    "Group#" + random.Next(1, 99999).ToString().PadLeft(5, '0')
                )
                .RuleFor(o => o.Users, (f, u) =>
                    userGenerator.Generate(random.Next(1, 5)).ToList()
                );
            return generator;
        }
    }
}