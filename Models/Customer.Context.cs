﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BurlOakMovers.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BurlOakMovers20200923103337_dbEntities2 : DbContext
    {
        public BurlOakMovers20200923103337_dbEntities2()
            : base("name=BurlOakMovers20200923103337_dbEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<TestEvent> TestEvents { get; set; }
        public virtual DbSet<workorder> workorders { get; set; }
    }
}
