using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

public class PunchclockrecordConfig: IEntityTypeConfiguration<Punchclockrecord>
{
    public void Configure(EntityTypeBuilder<Punchclockrecord> builder)
    {
        builder.ToTable("punchclockrecord").HasComment("用于存储打卡信息"); // 配置表的名称
        // 配置表字段的属性
        builder.Property(punchclockrecord => punchclockrecord.Id).HasColumnName("id").HasComment("记录Id，唯一");
        builder.Property(punchclockrecord => punchclockrecord.PunchClockId).HasColumnName("punchClockId").HasComment("打卡Id");
        builder.Property(punchclockrecord => punchclockrecord.PunchClockDate).HasColumnName("punchClockDate").HasComment("发布日期");
        builder.Property(punchclockrecord => punchclockrecord.PunchClockTopic).HasColumnName("punchClockTopic").HasMaxLength(50).HasComment("打卡主题");
        builder.Property(punchclockrecord => punchclockrecord.PunchClockDetail).HasColumnName("punchClockDetail").HasMaxLength(100).HasComment("打卡说明");
        builder.Property(punchclockrecord => punchclockrecord.PunchClockPId).HasColumnName("punchClockPId").HasMaxLength(20).HasComment("打卡发布人");
        builder.Property(punchclockrecord => punchclockrecord.Name).HasColumnName("name").HasMaxLength(10).HasComment("学生姓名");
        builder.Property(punchclockrecord => punchclockrecord.DormName).HasColumnName("dormName").HasMaxLength(10).HasComment("寝室号");
        builder.Property(punchclockrecord => punchclockrecord.Tel).HasColumnName("tel").HasMaxLength(11).IsFixedLength().HasComment("学生电话");
        builder.Property(punchclockrecord => punchclockrecord.StuNum).HasColumnName("stuNum").HasMaxLength(20).HasComment("学生学号");
        builder.Property(punchclockrecord => punchclockrecord.DormBuildId).HasColumnName("dormBuildId").HasComment("宿舍楼Id");
        builder.Property(punchclockrecord => punchclockrecord.IsRecord).HasColumnName("isRecord").HasComment("是否已经打卡");
    }
}