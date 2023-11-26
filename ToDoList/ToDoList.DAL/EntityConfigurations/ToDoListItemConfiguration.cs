using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain;
using ToDoList.Domain.Entites;

namespace ToDoList.DAL.EntityConfigurations
{
    public class ToDoListItemConfiguration : IEntityTypeConfiguration<ToDoListItem>
    {
        public void Configure(EntityTypeBuilder<ToDoListItem> builder)
        {
            builder.Property(p => p.Title)
                   .HasMaxLength(FieldsValidation.ToDoListItem.TitleMaxLength)
                   .IsRequired()
                   .HasAnnotation("MinLength", FieldsValidation.ToDoListItem.TitleMinLength);
        }
    }
}
