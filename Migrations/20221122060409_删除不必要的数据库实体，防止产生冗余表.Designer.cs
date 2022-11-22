﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using database;

#nullable disable

namespace database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221122060409_删除不必要的数据库实体，防止产生冗余表")]
    partial class 删除不必要的数据库实体防止产生冗余表
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("database.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("管理员Id，唯一");

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("真实名称");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("password")
                        .HasComment("密码");

                    b.Property<int?>("Sex")
                        .HasColumnType("int")
                        .HasColumnName("sex")
                        .HasComment("性别");

                    b.Property<string>("Tel")
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("tel")
                        .IsFixedLength()
                        .HasComment("电话");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("userName")
                        .HasComment("用户名");

                    b.HasKey("Id");

                    b.ToTable("admin", null, t =>
                        {
                            t.HasComment("管理员表");
                        });
                });

            modelBuilder.Entity("database.Entities.Dormbuild", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("宿舍楼Id，唯一");

                    b.Property<string>("Detail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("detail")
                        .HasComment("详细说明");

                    b.Property<Guid?>("Dormmanager")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dormmanager")
                        .HasComment("管理员id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("宿舍楼名称");

                    b.HasKey("Id");

                    b.ToTable("dormbuild", null, t =>
                        {
                            t.HasComment("存储宿舍楼信息");
                        });
                });

            modelBuilder.Entity("database.Entities.Dormmanager", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("宿舍管理员Id，唯一");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("真实姓名");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("password")
                        .HasComment("密码");

                    b.Property<int?>("Sex")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("sex")
                        .HasComment("性别");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("tel")
                        .IsFixedLength()
                        .HasComment("电话");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("userName")
                        .HasComment("用户名，用于登录系统");

                    b.HasKey("Id");

                    b.ToTable("dormmanager", null, t =>
                        {
                            t.HasComment("主要存储宿舍管理员信息");
                        });
                });

            modelBuilder.Entity("database.Entities.NoticeDb", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("公告Id，唯一");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("content")
                        .HasComment("发布内容");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("date")
                        .HasComment("公告发布日期");

                    b.Property<Guid?>("PId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Pid")
                        .HasComment("公告发布人id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("title")
                        .HasComment("公告标题");

                    b.HasKey("Id");

                    b.ToTable("notice", null, t =>
                        {
                            t.HasComment("用于存储公告信息");
                        });
                });

            modelBuilder.Entity("database.Entities.Punchclock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("打卡Id，唯一");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date")
                        .HasComment("发布日期");

                    b.Property<string>("Detail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("detail")
                        .HasComment("打卡说明");

                    b.Property<Guid>("PId")
                        .HasMaxLength(20)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("pid")
                        .HasComment("发布人");

                    b.Property<string>("Topic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("topic")
                        .HasComment("打卡主题");

                    b.HasKey("Id");

                    b.ToTable("punchclock", null, t =>
                        {
                            t.HasComment("用于存储打卡发布记录");
                        });
                });

            modelBuilder.Entity("database.Entities.Punchclockrecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("记录Id，唯一");

                    b.Property<Guid>("DormBuildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dormBuildId")
                        .HasComment("宿舍楼Id");

                    b.Property<string>("DormName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("dormName")
                        .HasComment("寝室号");

                    b.Property<int?>("IsRecord")
                        .HasColumnType("int")
                        .HasColumnName("isRecord")
                        .HasComment("是否已经打卡");

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("学生姓名");

                    b.Property<DateTime?>("PunchClockDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("punchClockDate")
                        .HasComment("发布日期");

                    b.Property<string>("PunchClockDetail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("punchClockDetail")
                        .HasComment("打卡说明");

                    b.Property<Guid>("PunchClockId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("punchClockId")
                        .HasComment("打卡Id");

                    b.Property<string>("PunchClockPId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("punchClockPId")
                        .HasComment("打卡发布人");

                    b.Property<string>("PunchClockTopic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("punchClockTopic")
                        .HasComment("打卡主题");

                    b.Property<string>("StuNum")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("stuNum")
                        .HasComment("学生学号");

                    b.Property<string>("Tel")
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("tel")
                        .IsFixedLength()
                        .HasComment("学生电话");

                    b.HasKey("Id");

                    b.ToTable("punchclockrecord", null, t =>
                        {
                            t.HasComment("用于存储打卡信息");
                        });
                });

            modelBuilder.Entity("database.Entities.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("考勤Id，唯一");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date")
                        .HasComment("考勤日期");

                    b.Property<string>("Detail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("detail")
                        .HasComment("详细说明");

                    b.Property<Guid>("DormBuildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dormBuildId")
                        .HasComment("宿舍楼Id");

                    b.Property<string>("DormName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("dormName")
                        .HasComment("寝室号");

                    b.Property<string>("StudentNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("studentNumber")
                        .IsFixedLength()
                        .HasComment("学生学号");

                    b.HasKey("Id");

                    b.ToTable("record", null, t =>
                        {
                            t.HasComment("用于存储考勤记录");
                        });
                });

            modelBuilder.Entity("database.Entities.Student", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("学生Id，唯一");

                    b.Property<Guid?>("DormBuildId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dormBuildId")
                        .HasComment("宿舍楼Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("姓名");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("password")
                        .HasComment("密码");

                    b.Property<int?>("Sex")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("sex")
                        .HasComment("性别");

                    b.Property<string>("StuNum")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("stuNum")
                        .IsFixedLength()
                        .HasComment("学生学号");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("tel")
                        .IsFixedLength()
                        .HasComment("电话");

                    b.HasKey("Id");

                    b.ToTable("student", null, t =>
                        {
                            t.HasComment("学生表，用于存放学生信息");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
