//-----------------------------------------------------------------------
// <copyright file="TaskToTopicMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Task to topic map.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CityQuest.Entities.Models.MissionToTopic}" />
    public class MissionToTopicMap : IEntityTypeConfiguration<MissionToTopic>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<MissionToTopic> builder)
        {
            // Primary key
            builder.HasKey(t => new { t.TaskID, t.TopicID });

            // Properties
            builder.ToTable("tasktotopic");

            builder.Property(t => t.TopicID).HasColumnName("topicid");
            builder.Property(t => t.TaskID).HasColumnName("taskid");

            builder.HasOne(t => t.Topic).WithMany(t => t.TaskToTopics).HasForeignKey(t => t.TopicID);
            builder.HasOne(t => t.Task).WithMany(t => t.TaskToTopics).HasForeignKey(t => t.TaskID);
        }
    }
}
