﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IneorBusiness.Models
{
    public class FilterModel
    {
        public string key { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
