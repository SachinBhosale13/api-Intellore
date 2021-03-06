﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostDetailsModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string author_name { get; set; }
        public string post_date { get; set; }
        public List<Tag> tags { get; set; }

    }

    public class Tag
    {
        public int tag_id { get; set; }
        public string tag_name { get; set; }
    }
}
