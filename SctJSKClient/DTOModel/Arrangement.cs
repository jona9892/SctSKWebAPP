﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOModel
{
    public class Arrangement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public virtual ICollection<ArrangementProduct> Products { get; set; }
    }
}
