﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookManage.Models
{
    using System;
    using System.Data.Entity;
    
    public partial class BookContext : DbContext
    {
        public DbSet<Books> Books { get; set; }

        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>().ToTable("Books");
            modelBuilder.Entity<Account>().ToTable("Account");
            base.OnModelCreating(modelBuilder);
        }
    }
}
