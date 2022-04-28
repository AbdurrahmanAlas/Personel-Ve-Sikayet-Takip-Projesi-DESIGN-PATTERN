using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context:DbContext
    {

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SahaDurum> SahaDurums { get; set; }
        public DbSet<PetrolRuhsat> PetrolRuhsats { get; set; }
        public DbSet<Punishment> Punishments { get; set; }
    }
}
