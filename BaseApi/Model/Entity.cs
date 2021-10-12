﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Model
{
    public class Entity
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }

        [Column(TypeName="DateTime2")]
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DateUpdated { get; set; }




    }
}
