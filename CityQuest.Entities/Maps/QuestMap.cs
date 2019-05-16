//-----------------------------------------------------------------------
// <copyright file="QuestMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Quest map.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CityQuest.Entities.Models.Quest}" />
    public class QuestMap : IEntityTypeConfiguration<Quest>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Quest> builder)
        {
            // Primary key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.ID).ValueGeneratedOnAdd();

            builder.ToTable("quests");

            builder.Property(t => t.ID).HasColumnName("id");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.AuthorID).HasColumnName("authorid");
            builder.Property(t => t.TopicID).HasColumnName("topicid");
            builder.Property(t => t.Price).HasColumnName("price");
            builder.Property(t => t.Points).HasColumnName("points");
        }
    }
}
