using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities
{
    public class PunchclockConfig: IEntityTypeConfiguration<Punchclock>
    {
        public void Configure(EntityTypeBuilder<Punchclock> builder)
        {
            builder.ToTable("punchclock").HasComment("用于存储打卡发布记录"); // 配置表的名称
            // 配置表字段的属性
            builder.Property(punchclock => punchclock.Id).HasColumnName("id").HasComment("打卡Id，唯一");
            builder.Property(punchclock => punchclock.Topic).HasColumnName("topic").HasMaxLength(50).HasComment("打卡主题");
            builder.Property(punchclock => punchclock.Detail).HasColumnName("detail").HasMaxLength(100).HasComment("打卡说明");
            builder.Property(punchclock => punchclock.Date).HasColumnName("date").HasComment("发布日期");
            builder.Property(punchclock => punchclock.PId).HasColumnName("pid").HasMaxLength(20).HasComment("发布人");
        }
    }
}
