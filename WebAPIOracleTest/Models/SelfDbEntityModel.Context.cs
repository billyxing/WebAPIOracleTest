﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIOracleTest.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SelfDbEntities : DbContext
    {
        public SelfDbEntities()
            : base("name=SelfDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SELF_COMPANYINFO> SELF_COMPANYINFO { get; set; }
        public virtual DbSet<SELF_DOWNLOADCODE> SELF_DOWNLOADCODE { get; set; }
        public virtual DbSet<SELF_ORDERINFO> SELF_ORDERINFO { get; set; }
        public virtual DbSet<SELF_USRS> SELF_USRS { get; set; }
        public virtual DbSet<TBCERT> TBCERTs { get; set; }
        public virtual DbSet<TBCERTTASK> TBCERTTASKs { get; set; }
        public virtual DbSet<TBITEM> TBITEMs { get; set; }
        public virtual DbSet<TBUSERINFO> TBUSERINFOes { get; set; }
    }
}