/*
CREATE TABLE CUSTOMER (
   ID UNIQUEIDENTIFIER PRIMARY KEY,
   FIRST_NAME VARCHAR(50) NOT NULL,
   LAST_NAME VARCHAR(50) NOT NULL,
   DOCUMENT VARCHAR(20) NOT NULL,
   EMAIL VARCHAR(50) NOT NULL,
   ADDRESS VARCHAR(100) NOT NULL,
   CREATED_AT DATETIME NOT NULL,
   CREATED_BY VARCHAR(20) NOT NULL,
   UPDATED_AT DATETIME,
   UPDATED_BY VARCHAR(20),
);
*/

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("CUSTOMER")
                .HasKey(x => x.Id);

            builder
                .Ignore(x => x.Notifications);

            builder
                .Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired(true);

            builder
                .Property(x => x.CreatedAt)
                .HasColumnName("CREATED_AT")
                .HasColumnType("DATETIME")
                .IsRequired(true);

            builder
                .Property(x => x.CreatedBy)
                .HasColumnName("CREATED_BY")
                .HasColumnType("VARCHAR(20)")
                .IsRequired(true);

            builder
                .Property(x => x.UpdatedAt)
                .HasColumnName("UPDATED_AT")
                .HasColumnType("DATETIME")
                .IsRequired(true);

            builder
                .Property(x => x.UpdatedBy)
                .HasColumnName("UPDATED_BY")
                .HasColumnType("VARCHAR(20)")
                .IsRequired(true);

            builder.OwnsOne(x => x.Name,
                nameBuilder =>
                {
                    nameBuilder.Property(x => x.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasColumnType("VARCHAR(50)")
                    .IsRequired(true);

                    nameBuilder.Property(x => x.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasColumnType("VARCHAR(50)")
                    .IsRequired(true);

                    nameBuilder.Ignore(x => x.Notifications);
                });

            builder.OwnsOne(x => x.Document,
                documentBuilder =>
                {
                    documentBuilder.Property(x => x.Document)
                    .HasColumnName("DOCUMENT")
                    .HasColumnType("VARCHAR(20)")
                    .IsRequired(true);

                    documentBuilder.Ignore(x => x.Notifications);
                });

            builder.OwnsOne(x => x.Email,
                emailBuilder =>
                {
                    emailBuilder.Property(x => x.Address)
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR(50)")
                    .IsRequired(true);

                    emailBuilder.Ignore(x => x.Notifications);
                });

            builder.OwnsOne(x => x.Address,
                addressBuilder =>
                {
                    addressBuilder.Property(x => x.Description)
                    .HasColumnName("ADDRESS")
                    .HasColumnType("VARCHAR(100)");

                    addressBuilder.Ignore(x => x.Notifications);
                });
        }
    }
}