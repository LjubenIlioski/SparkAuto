using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAuto.Model
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPege { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems/ItemsPerPege);

        public string UrlParam { get; set; }
    }
}
