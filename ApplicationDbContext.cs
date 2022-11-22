using database.Dto;
using database.Entities;
using Microsoft.EntityFrameworkCore;

namespace database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Admin> Admin { get; set; } // 连接哪个实体
    public DbSet<NoticeDb> Notice { get; set; }
    public DbSet<Dormbuild> Dormbuild { get; set; }

    public DbSet<Dormmanager> Dormmanager { get; set; }

    // public DbSet<Punchclock> Punchclock { get; set; }
    // public DbSet<Punchclockrecord> Punchclockrecord { get; set; }
    public DbSet<Dormitory> Dormitory { get; set; }
    public DbSet<Student> Student { get; set; }

    // 连接哪个数据库，已经在注入的时候配置了
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //    optionsBuilder.UseNpgsql();
    //}
    //ctx.Database.ExecuteSqlInterpolatedAsync(@$"delete blogs where id = 1"); // 执行原生非查询sql
    //ctx.table.FromSqlInterpolated(@$"select * from T_Articles").ToListAsync(); //执行原生查询sql

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); // 从哪连接
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.DefaultTypeMapping<NoticeDto>();
    }
    // 然后通过Add-Migration Init（init）只是此时操作的名称生成文件
    // 想更新数据库使用Update-database
    // 以上过程是工具建表，无需程序员手动建表
    // 更新表过程
    // Add-Migration Update(同样，update只是名字)
    // Update-database。注意update会编译生成的代码，编译失败操作就失败
}