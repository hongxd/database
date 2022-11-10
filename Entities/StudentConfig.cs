using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student", opt => opt.HasComment("学生表，用于存放学生信息")); // 配置表的名称
        // 配置表字段的属性
        builder.Property(student => student.Id).HasColumnName("id").HasComment("学生Id，唯一");
        builder.Property(student => student.StuNum).HasColumnName("stuNum").HasMaxLength(10).IsFixedLength().HasComment("学生学号");
        builder.Property(student => student.Password).HasColumnName("password").HasMaxLength(20).HasComment("密码");
        builder.Property(student => student.Name).HasColumnName("name").HasMaxLength(10).HasComment("姓名");
        builder.Property(student => student.DormBuildId).HasColumnName("dormBuildId").HasComment("宿舍楼Id");
        builder.Property(student => student.DormName).HasColumnName("dormName").HasMaxLength(10).HasComment("寝室号");
        builder.Property(student => student.Sex).HasColumnName("sex").HasComment("性别");
        builder.Property(student => student.Tel).HasColumnName("tel").HasMaxLength(11).IsFixedLength().HasComment("电话");
    }
}