using System;
using System.Collections.Generic;

namespace AppFiles.Models
{
    public partial class FileRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Record { get; set; }
    }
}
