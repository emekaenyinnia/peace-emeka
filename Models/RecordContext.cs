using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AppFiles.Models.Mapping;

namespace AppFiles.Models
{
    public partial class RecordContext : DbContext
    {
        static RecordContext()
        {
            Database.SetInitializer<RecordContext>(null);
        }

        public RecordContext()
            : base("Name=RecordContext")
        {
        }

        public DbSet<FileFormat> FileFormats { get; set; }
        public DbSet<FileRecord> FileRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FileFormatMap());
            modelBuilder.Configurations.Add(new FileRecordMap());
        }
    }
}
