using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppFiles.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace AppFiles.Models
{
   
    public class ViewRecords
    {
        public RecordContext dbh = null;


        //Constructor
        public ViewRecords()
        {
            dbh = new RecordContext();
        }
        public FileFormat User { get; set; }
        public List<FileFormat> UsersList { get; set; }

        public FileFormat ViewDetails(int Id)
        {
            try
            {


                var y = dbh.FileFormats.Find(Id);


                return y;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public List<FileFormat> ListOfUsers()
        {

            var d = dbh.FileFormats.Where(p => p.Id > 0).ToList();

            return d;


        }
    }
}