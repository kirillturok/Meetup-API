using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
                new Event
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Concert",
                    Description = "Billie Eilish's concert",
                    Plan = "some plan...",
                    Organizer = "Billie Eilish",
                    Speaker = "Billie Eilish",
                    Address = "USA",
                    Time = new DateTime(2022, 07, 15)
                },
                new Event
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Economical discussion",
                    Description = "Some talks about economics",
                    Plan = "Speak, eat, go home",
                    Organizer = "Ivanov Ivan Ivanovich",
                    Speaker = "Ivanov Ivan Ivanovich",
                    Address = "Minsk",
                    Time = new DateTime(2022, 08, 01)
                });
        }

    }
}
