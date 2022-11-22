using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

public class RepairConfig : IEntityTypeConfiguration<Repair>
{
    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        builder.ToTable("repair", opt => opt.HasComment("用于存储报修记录")); // 配置表的名称
        // 配置表字段的属性
        builder.Property(repair => repair.Id).HasColumnName("id").HasComment("报修Id，唯一");
        builder.Property(repair => repair.Thing).HasColumnName("thing").HasMaxLength(50).HasComment("上报物品");
        builder.Property(repair => repair.Detail).HasColumnName("detail").HasMaxLength(100).HasComment("物品详细描述");
        builder.Property(repair => repair.ReportTime).HasColumnName("reportTime").HasComment("上报时间");
        builder.Property(repair => repair.Status).HasColumnName("status").HasComment("报修状态");
    }
}