namespace project1.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        public int Id { get; set; }

        public int? user_id { get; set; }

        public int? prod_id { get; set; }

        public double? price { get; set; }

        public int? qty { get; set; }

        public DateTime? dateTime { get; set; }

        public virtual product product { get; set; }

        public virtual User User { get; set; }
    }
}
