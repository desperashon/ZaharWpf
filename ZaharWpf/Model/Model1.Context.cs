﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZaharWpf.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class zahartextEntities : DbContext
    {
        public zahartextEntities()
            : base("name=zahartextEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Books> Books { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<ChapterTexts> ChapterTexts { get; set; }
        public DbSet<ProgrammingLanguages> ProgrammingLanguages { get; set; }
        public DbSet<Solutions> Solutions { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
