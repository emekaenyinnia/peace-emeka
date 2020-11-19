using System;
using System.Collections.Generic;

namespace AppFiles.Models
{
    public partial class FileFormat
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}
