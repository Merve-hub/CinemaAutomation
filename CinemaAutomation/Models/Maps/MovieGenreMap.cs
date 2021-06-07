using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAutomation.Models.Maps
{
    public class MovieGenreMap:IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.MovieId, x.GenreId });

            builder.HasOne(x => x.Movie).WithMany(x=>x.MovieGenres).HasForeignKey(x=>x.MovieId);

        }
    }
}
