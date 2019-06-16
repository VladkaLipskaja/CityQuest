//-----------------------------------------------------------------------
// <copyright file="TaskMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Task map.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CityQuest.Entities.Models.Mission}" />
    public class MissionMap : IEntityTypeConfiguration<Mission>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            // Primary key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.ID).ValueGeneratedOnAdd();

            builder.ToTable("tasks");

            builder.Property(t => t.ID).HasColumnName("id");
            builder.Property(t => t.Text).HasColumnName("text");
            builder.Property(t => t.Answer).HasColumnName("answer");
            builder.Property(t => t.Coordinate1).HasColumnName("coordinate1");
            builder.Property(t => t.Coordinate2).HasColumnName("coordinate2");
            builder.Property(t => t.Coordinate3).HasColumnName("coordinate3");
            builder.Property(t => t.Coordinate4).HasColumnName("coordinate4");
            builder.Property(t => t.Points).HasColumnName("points");
        }
    }
}
