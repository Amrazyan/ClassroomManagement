﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom2017.App_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DiplomeEntities : DbContext
    {
        public DiplomeEntities()
            : base("name=DiplomeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AllAnswer> AllAnswers { get; set; }
        public virtual DbSet<AllQuestion> AllQuestions { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Proffesor> Proffesors { get; set; }
        public virtual DbSet<Stud_Answers> Stud_Answers { get; set; }
        public virtual DbSet<Stud_attendance> Stud_attendance { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<StudAnswers_live> StudAnswers_live { get; set; }
    }
}
