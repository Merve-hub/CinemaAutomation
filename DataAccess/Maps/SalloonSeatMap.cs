using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Maps
{
    class SalloonSeatMap : IEntityTypeConfiguration<SalloonSeat>
    {
        public void Configure(EntityTypeBuilder<SalloonSeat> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.SalloonId, x.SeatId });

            builder.HasOne(x => x.Salloon).WithMany(x => x.SalloonSeats).HasForeignKey(x => x.SalloonId);
            builder.HasOne(x => x.Seat).WithMany(x =>x.SalloonSeats).HasForeignKey(x => x.SeatId);
        }
    }
}
