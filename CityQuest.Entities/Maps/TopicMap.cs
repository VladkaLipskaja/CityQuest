//-----------------------------------------------------------------------
// <copyright file="TopicMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Topic map.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CityQuest.Entities.Models.Topic}" />
    public class TopicMap : IEntityTypeConfiguration<Topic>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            // Primary key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.ID).ValueGeneratedOnAdd();

            builder.ToTable("topics");

            builder.Property(t => t.ID).HasColumnName("id");
            builder.Property(t => t.Name).HasColumnName("name");
        }
    }
}
