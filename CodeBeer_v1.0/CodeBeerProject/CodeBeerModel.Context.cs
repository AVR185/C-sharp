﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeBeerProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CodeBeerDb : DbContext
    {
        public CodeBeerDb()
            : base("name=CodeBeerDb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Break> Break { get; set; }
        public virtual DbSet<CheckInOut> CheckInOut { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
    }
}
