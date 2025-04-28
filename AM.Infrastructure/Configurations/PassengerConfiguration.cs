using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AM.ApplicationCore.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName , full =>
            {
                full.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                full.Property(f => f.LastName).IsRequired().HasColumnName("PassLastName");

                //TPH
                //builder.HasDiscriminator<string>("IsTraveller")
                //.HasValue<Traveller>("1")
                //.HasValue<Staff>("2")
                //.HasValue<Passenger>("0");
            });
        }

    }
}
