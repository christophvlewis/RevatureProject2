﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlackerRankData.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
	using System.Configuration;


	public partial class ChallengerDBEntities : DbContext
	{
        public ChallengerDBEntities()
			//works for tests within project, but fails outside project
			//: base()
            //: base("name=ChallengerDBEntities")
			:base("metadata=res://*/Model.TeacherCodeModel.csdl|res://*/Model.TeacherCodeModel.ssdl|res://*/Model.TeacherCodeModel.msl;provider=System.Data.SqlClient;provider connection string=\"data source=sqlmiah.database.windows.net;initial catalog=ChallengerDB;persist security info=True;user id=miahtampa;password=Pass1234;MultipleActiveResultSets=True;App=EntityFramework\"")
			//:base("metadata=C:\\Users\\Chris\\source\\repos\\RevatureProject2\\RevatureProject2\\SlackerRankData\\obj\\Debug\\edmxResourcesToEmbed\\Model\\;provider=System.Data.SqlClient;provider connection string=\"data source=sqlmiah.database.windows.net;initial catalog=ChallengerDB;persist security info=True;user id=miahtampa;password=Pass1234;MultipleActiveResultSets=True;App=EntityFramework\"")



			//:base("metadata=res:/SlackerRankData, 0.0.0.0, neutral, neutral/Model.TeacherCodeModel.csdl|res:/SlackerRankData, 0.0.0.0, neutral, neutral/Model.TeacherCodeModel.ssdl|res:/SlackerRankData, 0.0.0.0, neutral, neutral/Model.TeacherCodeModel.msl;provider=System.Data.SqlClient;provider connection string=\"data source=sqlmiah.database.windows.net;initial catalog=ChallengerDB;persist security info=True;user id=miahtampa;password=Pass1234;MultipleActiveResultSets=True;App=EntityFramework\"")


		{
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<NonAdmin> NonAdmins { get; set; }
        public virtual DbSet<Progress> Progresses { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserCred> UserCreds { get; set; }
    }
}
