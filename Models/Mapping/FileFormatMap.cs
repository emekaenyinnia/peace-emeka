using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppFiles.Models.Mapping
{
    public class FileFormatMap : EntityTypeConfiguration<FileFormat>
    {
        public FileFormatMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("FileFormat");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Firstname).HasColumnName("Firstname");
            this.Property(t => t.Lastname).HasColumnName("Lastname");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
        }
    }
}
