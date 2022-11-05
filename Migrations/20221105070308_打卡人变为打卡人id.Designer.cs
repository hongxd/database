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
    [Migration("20221105070308_打卡人变为打卡人id")]
    partial class 打卡人变为打卡人id
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("database.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("管理员Id，唯一");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("真实名称");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("password")
                        .HasComment("密码");

                    b.Property<int>("Sex")
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
                        .HasComment("用户名");

                    b.HasKey("Id");

                    b.ToTable("admin", (string)null);

                    b.HasComment("管理员表");
                });

            modelBuilder.Entity("database.Entities.Dormbuild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("宿舍楼Id，唯一");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("detail")
                        .HasComment("详细说明");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("宿舍楼名称");

                    b.HasKey("Id");

                    b.ToTable("dormbuild", (string)null);

                    b.HasComment("存储宿舍楼信息");
                });

            modelBuilder.Entity("database.Entities.Dormmanager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("宿舍管理员Id，唯一");

                    b.Property<string>("DormBuildDetail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("dormBuildDetail")
                        .HasComment("宿舍楼详细说明");

                    b.Property<Guid>("DormBuildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dormBuildId")
                        .HasComment("宿舍楼Id");

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

                    b.Property<int>("Sex")
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

                    b.ToTable("dormmanager", (string)null);

                    b.HasComment("主要存储宿舍管理员信息");
                });

            modelBuilder.Entity("database.Entities.Notice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("公告Id，唯一");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("content")
                        .HasComment("发布内容");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date")
                        .HasComment("公告发布日期");

                    b.Property<string>("NoticePerson")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("noticePerson")
                        .HasComment("公告发布人");

                    b.HasKey("Id");

                    b.ToTable("notice", (string)null);

                    b.HasComment("用于存储公告信息");
                });

            modelBuilder.Entity("database.Entities.Punchclock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("打卡Id，唯一");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date")
                        .HasComment("发布日期");

                    b.Property<string>("Detail")
                        .IsRequired()
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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("topic")
                        .HasComment("打卡主题");

                    b.HasKey("Id");

                    b.ToTable("punchclock", (string)null);

                    b.HasComment("用于存储打卡发布记录");
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
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("dormName")
                        .HasComment("寝室号");

                    b.Property<int>("IsRecord")
                        .HasColumnType("int")
                        .HasColumnName("isRecord")
                        .HasComment("是否已经打卡");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("name")
                        .HasComment("学生姓名");

                    b.Property<DateTime>("PunchClockDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("punchClockDate")
                        .HasComment("发布日期");

                    b.Property<string>("PunchClockDetail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("punchClockDetail")
                        .HasComment("打卡说明");

                    b.Property<Guid>("PunchClockId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("punchClockId")
                        .HasComment("打卡Id");

                    b.Property<string>("PunchClockPId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("punchClockPId")
                        .HasComment("打卡发布人");

                    b.Property<string>("PunchClockTopic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("punchClockTopic")
                        .HasComment("打卡主题");

                    b.Property<string>("StuNum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("stuNum")
                        .HasComment("学生学号");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("tel")
                        .IsFixedLength()
                        .HasComment("学生电话");

                    b.HasKey("Id");

                    b.ToTable("punchclockrecord", (string)null);

                    b.HasComment("用于存储打卡信息");
                });

            modelBuilder.Entity("database.Entities.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("考勤Id，唯一");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date")
                        .HasComment("考勤日期");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("detail")
                        .HasComment("详细说明");

                    b.Property<Guid>("DormBuildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dormBuildId")
                        .HasComment("宿舍楼Id");

                    b.Property<string>("DormName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("dormName")
                        .HasComment("寝室号");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("studentNumber")
                        .IsFixedLength()
                        .HasComment("学生学号");

                    b.HasKey("Id");

                    b.ToTable("record", (string)null);

                    b.HasComment("用于存储考勤记录");
                });

            modelBuilder.Entity("database.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasComment("学生Id，唯一");

                    b.Property<Guid>("DormBuildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dormBuildId")
                        .HasComment("宿舍楼Id");

                    b.Property<string>("DormName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("dormName")
                        .HasComment("寝室号");

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

                    b.Property<int>("Sex")
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

                    b.ToTable("student", (string)null);

                    b.HasComment("学生表，用于存放学生信息");
                });
#pragma warning restore 612, 618
        }
    }
}
