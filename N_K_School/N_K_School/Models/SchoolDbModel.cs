namespace N_K_School.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SchoolDbModel : DbContext
    {
        // Your context has been configured to use a 'SchoolDbModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'N_K_School.Models.SchoolDbModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SchoolDbModel' 
        // connection string in the application configuration file.
        public SchoolDbModel()
            : base("name=SchoolDbModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<ClassTeacher> ClassTeachers { get; set; }
        public virtual DbSet<Std8_Marks> Std8_Marks { get; set; }
        public virtual DbSet<Std9_Marks> Std9_Marks { get; set; }
        public virtual DbSet<Std10_Marks> Std10_Marks { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}