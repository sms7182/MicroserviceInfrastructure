using FatalError.Communication.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Data.Configuration
{
    public class WriteApplicationDBContext:DbContext
    {
        public WriteApplicationDBContext(DbContextOptions<WriteApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageEntityConfiguration());
        }
    }

    public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            if (builder == null)
            {
                return;
            }

            builder.HasKey(d => d.Id);
        }
    }
}
