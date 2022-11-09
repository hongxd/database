using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.Entities;

public class NoticeConfig : IEntityTypeConfiguration<Notice>
{
    public void Configure(EntityTypeBuilder<Notice> builder)
    {
        builder.ToTable("notice", opt => opt.HasComment("用于存储公告信息"));
        // 配置表字段的属性
        builder.Property(notice => notice.Id).HasColumnName("id").HasComment("公告Id，唯一");
        builder.Property(notice => notice.PId).HasColumnName("Pid").HasMaxLength(20).HasComment("公告发布人");
        builder.Property(notice => notice.Date).HasColumnName("date").HasComment("公告发布日期");
        builder.Property(notice => notice.Content).HasColumnName("content").HasMaxLength(100).HasComment("发布内容");
    }
}