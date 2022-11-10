using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

public class RecordConfig : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        builder.ToTable("record", opt => opt.HasComment("用于存储考勤记录")); // 配置表的名称
        // 配置表字段的属性
        builder.Property(record => record.Id).HasColumnName("id").HasComment("考勤Id，唯一");
        builder.Property(record => record.StudentNumber).HasColumnName("studentNumber").HasMaxLength(10).IsFixedLength().HasComment("学生学号");
        builder.Property(record => record.DormBuildId).HasColumnName("dormBuildId").HasComment("宿舍楼Id");
        builder.Property(record => record.DormName).HasColumnName("dormName").HasMaxLength(10).HasComment("寝室号");
        builder.Property(record => record.Date).HasColumnName("date").HasComment("考勤日期");
        builder.Property(record => record.Detail).HasColumnName("detail").HasMaxLength(100).HasComment("详细说明");
    }
}