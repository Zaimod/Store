namespace project1.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.cat_id);

            modelBuilder.Entity<product>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.prod_id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.user_id);
        }
    }
}
