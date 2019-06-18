//-----------------------------------------------------------------------
// <copyright file="MissionToTopicMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Mission to topic map.
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
            builder.HasKey(t => new { t.TopicId, t.TaskId });

            // Properties
            builder.ToTable("tasktotopic");
            
            builder.Property(t => t.TaskId).HasColumnName("taskid");
            builder.Property(t => t.TopicId).HasColumnName("topicid");

            builder.HasOne(t => t.Topic).WithMany(t => t.TaskToTopics).HasForeignKey(t => t.TopicId);
            builder.HasOne(t => t.Task).WithMany(t => t.TaskToTopics).HasForeignKey(t => t.TaskId);
        }
    }
}
