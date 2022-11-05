using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities
{
    public class AdminConfig: IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("admin").HasComment("管理员表"); // 配置表的名称
            // 配置表字段的属性
            builder.Property(admin => admin.Id).HasColumnName("id").HasComment("管理员Id，唯一");
            builder.Property(admin => admin.UserName).HasColumnName("userName").HasMaxLength(20).HasComment("用户名");
            builder.Property(admin => admin.Password).HasColumnName("password").HasMaxLength(20).HasComment("密码");
            builder.Property(admin => admin.Name).HasColumnName("name").HasMaxLength(10).HasComment("真实名称");
            builder.Property(admin => admin.Sex).HasColumnName("sex").HasComment("性别");
            builder.Property(admin => admin.Tel).HasColumnName("tel").HasComment("电话").HasMaxLength(11).IsFixedLength();
        }
    }
}
