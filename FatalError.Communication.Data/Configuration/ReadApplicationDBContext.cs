using FatalError.Communication.Domain.Messages;
using FatalError.Communication.Domain.Messages.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Data.Configuration
{
    public class ReadApplicationDBContext : DbContext
    {
        public ReadApplicationDBContext(DbContextOptions<ReadApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageReadEntityConfiguration());
        }
    }

    public class MessageReadEntityConfiguration : IEntityTypeConfiguration<MessageViewModel>
    {
        public void Configure(EntityTypeBuilder<MessageViewModel> builder)
        {
            if (builder == null)
            {
                return;
            }
            builder.ToTable("MessageReadModel");

            builder.HasKey(d => d.Id);
        }
    }
}
