//-----------------------------------------------------------------------
// <copyright file="QuestToUserMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// Quest to user map.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CityQuest.Entities.Models.QuestToUser}" />
    public class QuestToUserMap : IEntityTypeConfiguration<QuestToUser>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<QuestToUser> builder)
        {
            // Primary key
            builder.HasKey(t => new { t.QuestID, t.UserID });

            // Properties
            builder.ToTable("questtouser");

            builder.Property(t => t.QuestID).HasColumnName("questid");
            builder.Property(t => t.UserID).HasColumnName("userid");
            builder.Property(t => t.FinishedTask).HasColumnName("finishedtask");
            builder.Property(t => t.IsFinished).HasColumnName("isfinished");

            builder.HasOne(t => t.Quest).WithMany(t => t.QuestToUsers).HasForeignKey(t => t.QuestID);
            builder.HasOne(t => t.User).WithMany(t => t.QuestToUsers).HasForeignKey(t => t.UserID);
        }
    }
}
