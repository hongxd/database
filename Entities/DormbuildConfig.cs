using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

// 存储宿舍楼信息
public class DormbuildConfig : IEntityTypeConfiguration<Dormbuild>
{
    public void Configure(EntityTypeBuilder<Dormbuild> builder)
    {
        builder.ToTable("dormbuild", opt => opt.HasComment("存储宿舍楼信息")); // 配置表的名称
        // 配置表字段的属性
        builder.Property(dormbuild => dormbuild.Id).HasColumnName("id").HasComment("宿舍楼Id，唯一");
        builder.Property(dormbuild => dormbuild.Name).HasColumnName("name").HasMaxLength(10).HasComment("宿舍楼名称");
        builder.Property(dormbuild => dormbuild.Detail).HasColumnName("detail").HasMaxLength(100).HasComment("详细说明");
    }
}