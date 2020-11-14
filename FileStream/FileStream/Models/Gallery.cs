using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileStream.Models
{
    public class Gallery
    {
        [Key]
        public int ID { get; set; }
        public byte[] Image { get; set; }
    }
}