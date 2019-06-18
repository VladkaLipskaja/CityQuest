//-----------------------------------------------------------------------
// <copyright file="CityQuestDBContext.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using CityQuest.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CityQuest.Entities
{
    /// <summary>
    /// CityQuestDBContext class.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class CityQuestDBContext : DbContext
    {
        /// <summary>
        /// Gets or sets the quests.
        /// </summary>
        /// <value>
        /// The quests.
        /// </value>
        public DbSet<Quest> Quests { get; set; }

        /// <summary>
        /// Gets or sets the quest to users.
        /// </summary>
        /// <value>
        /// The quest to users.
        /// </value>
        public DbSet<QuestToUser> QuestToUsers { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public DbSet<Mission> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the task to quests.
        /// </summary>
        /// <value>
        /// The task to quests.
        /// </value>
        public DbSet<MissionToQuest> TaskToQuests { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>
        /// The topics.
        /// </value>
        public DbSet<Topic> Topics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityQuestDBContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CityQuestDBContext(DbContextOptions<CityQuestDBContext> options) : base(options)
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.ApplyConfiguration(new MissionMap());
            modelBuilder.ApplyConfiguration(new QuestMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TopicMap());
            modelBuilder.ApplyConfiguration(new MissionToTopicMap());
            modelBuilder.ApplyConfiguration(new QuestToUserMap());
            modelBuilder.ApplyConfiguration(new MissionToQuestMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
