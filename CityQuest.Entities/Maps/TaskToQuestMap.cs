//-----------------------------------------------------------------------
// <copyright file="TaskToQuestMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Task to quest map.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CityQuest.Entities.Models.MissionToQuest}" />
    public class TaskToQuestMap : IEntityTypeConfiguration<MissionToQuest>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<MissionToQuest> builder)
        {
            // Primary key
            builder.HasKey(t => new { t.QuestID, t.Task });

            // Properties
            builder.ToTable("tasktoquest");

            builder.Property(t => t.QuestID).HasColumnName("questid");
            builder.Property(t => t.TaskID).HasColumnName("taskid");

            builder.HasOne(t => t.Quest).WithMany(t => t.TaskToQuests).HasForeignKey(t => t.QuestID);
            builder.HasOne(t => t.Task).WithMany(t => t.TaskToQuests).HasForeignKey(t => t.TaskID);
        }
    }
}
