namespace DemoRegexReal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataUser")]
    public partial class DataUser
    {
        [Key]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(60)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Pasword { get; set; }

        public int? PhoneNumber { get; set; }
    }
}
