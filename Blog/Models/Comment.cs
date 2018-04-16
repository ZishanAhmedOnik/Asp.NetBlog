using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string comment { get; set; }
    }
}