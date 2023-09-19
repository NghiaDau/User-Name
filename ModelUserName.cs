using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DemoRegexReal
{
    public partial class ModelUserName : DbContext
    {
        public ModelUserName()
            : base("name=ModelUserName")
        {
        }

        public virtual DbSet<DataUser> DataUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
