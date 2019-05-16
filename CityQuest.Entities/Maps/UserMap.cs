//-----------------------------------------------------------------------
// <copyright file="UserMap.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityQuest.Entities.Models
{
    /// <summary>
    /// User map.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CityQuest.Entities.Models.User}" />
    public class UserMap : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary key
            builder.HasKey(t => t.ID);

            // Properties
            builder.Property(t => t.ID).ValueGeneratedOnAdd();

            builder.ToTable("users");

            builder.Property(t => t.ID).HasColumnName("id");
            builder.Property(t => t.Login).HasColumnName("login");
            builder.Property(t => t.Password).HasColumnName("password");
            builder.Property(t => t.IsAdmin).HasColumnName("isadmin");
        }
    }
}
