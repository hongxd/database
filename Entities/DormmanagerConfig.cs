using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

public class DormmanagerConfig : IEntityTypeConfiguration<Dormmanager>
{
    public void Configure(EntityTypeBuilder<Dormmanager> builder)
    {
        builder.ToTable("dormmanager", opt => opt.HasComment("主要存储宿舍管理员信息")); // 配置表的名称
        // 配置表字段的属性
        builder.Property(dormmanager => dormmanager.Id).HasColumnName("id").HasComment("宿舍管理员Id，唯一").IsRequired();
        builder.Property(dormmanager => dormmanager.UserName).HasColumnName("userName").HasMaxLength(20)
            .HasComment("用户名，用于登录系统").IsRequired();
        builder.Property(dormmanager => dormmanager.Password).HasColumnName("password").HasMaxLength(20)
            .HasComment("密码").IsRequired();
        builder.Property(dormmanager => dormmanager.Name).HasColumnName("name").HasMaxLength(10).HasComment("真实姓名")
            .IsRequired();
        builder.Property(dormmanager => dormmanager.Sex).HasColumnName("sex").HasComment("性别").IsRequired();
        builder.Property(dormmanager => dormmanager.Tel).HasColumnName("tel").HasComment("电话").HasMaxLength(11)
            .IsFixedLength().IsRequired();
    }
}