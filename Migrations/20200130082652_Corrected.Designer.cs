﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using agos_api.Models.Base;

namespace AGoS_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200130082652_Corrected")]
    partial class Corrected
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("agos_api.Models.Base.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Middlename")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("agos_api.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Classifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("TypeLessonId")
                        .HasColumnType("integer");

                    b.HasKey("DisciplineId");

                    b.HasIndex("TypeLessonId");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("agos_api.Models.DisciplineSpecial", b =>
                {
                    b.Property<int>("DisciplineSpecialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("DisciplineId")
                        .HasColumnType("integer");

                    b.Property<int?>("SpecialityOtdelId")
                        .HasColumnType("integer");

                    b.HasKey("DisciplineSpecialId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("SpecialityOtdelId");

                    b.ToTable("DisciplineSpecials");
                });

            modelBuilder.Entity("agos_api.Models.HolidayCalendar", b =>
                {
                    b.Property<int>("HolidayCalendarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateHappyBegin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateHappyEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("HolidayCalendarId");

                    b.ToTable("HolidayCalendars");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.Classroom", b =>
                {
                    b.Property<int>("ClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.HasKey("ClassroomId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.ClassroomOfTeacher", b =>
                {
                    b.Property<int>("ClassroomOfTeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClassroomId")
                        .HasColumnType("integer");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("ClassroomOfTeacherId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassroomOfTeachers");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.Group", b =>
                {
                    b.Property<long>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<short>("CountStudents")
                        .HasColumnType("smallint");

                    b.Property<short>("CourseNum")
                        .HasColumnType("smallint");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.Property<int?>("SpecialityOtdelId")
                        .HasColumnType("integer");

                    b.Property<string>("StudyLanguage")
                        .HasColumnType("text");

                    b.HasKey("GroupId");

                    b.HasIndex("SpecialityOtdelId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.Otdel", b =>
                {
                    b.Property<int>("OtdelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("OtdelName")
                        .HasColumnType("text");

                    b.HasKey("OtdelId");

                    b.ToTable("Otdels");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.RepresentativeOrganization", b =>
                {
                    b.Property<Guid>("ReprId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PositionWork")
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .HasColumnType("text");

                    b.HasKey("ReprId");

                    b.ToTable("RepresentativeOrganization");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.Semestr", b =>
                {
                    b.Property<int>("SemestrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BeginOfSemestr")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CourseNum")
                        .HasColumnType("text");

                    b.Property<DateTime>("FinishOfSemestr")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("HoursWeek")
                        .HasColumnType("text");

                    b.Property<string>("SemestrNum")
                        .HasColumnType("text");

                    b.Property<int?>("SpecialityId")
                        .HasColumnType("integer");

                    b.HasKey("SemestrId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Semestrs");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.StudyOrganization", b =>
                {
                    b.Property<int>("StudyOrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<int>("NumOfHome")
                        .HasColumnType("integer");

                    b.Property<string>("OfficialName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<Guid?>("RepresentativeOrganizationReprId")
                        .HasColumnType("uuid");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.HasKey("StudyOrganizationId");

                    b.HasIndex("RepresentativeOrganizationReprId");

                    b.ToTable("StudyOrganizations");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.TeachDiscip", b =>
                {
                    b.Property<int>("TeachDiscipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("DisciplineId")
                        .HasColumnType("integer");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("TeachDiscipId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeachDiscips");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Middlename")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("agos_api.Models.Schedule.AcademicPlan", b =>
                {
                    b.Property<int>("AcademicPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AllHours")
                        .HasColumnType("text");

                    b.Property<int?>("DisciplineSpecialId")
                        .HasColumnType("integer");

                    b.Property<int?>("SemestrId")
                        .HasColumnType("integer");

                    b.Property<int?>("SpecialityId")
                        .HasColumnType("integer");

                    b.HasKey("AcademicPlanId");

                    b.HasIndex("DisciplineSpecialId");

                    b.HasIndex("SemestrId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("AcademicPlans");
                });

            modelBuilder.Entity("agos_api.Models.Speciality", b =>
                {
                    b.Property<int>("SpecialityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Speciality_Classifier")
                        .HasColumnType("text");

                    b.Property<string>("Speciality_Name")
                        .HasColumnType("text");

                    b.HasKey("SpecialityId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("agos_api.Models.SpecialityOtdel", b =>
                {
                    b.Property<int>("SpecialityOtdelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("OtdelId")
                        .HasColumnType("integer");

                    b.Property<int?>("SpecialityId")
                        .HasColumnType("integer");

                    b.HasKey("SpecialityOtdelId");

                    b.HasIndex("OtdelId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("SpecialityOtdels");
                });

            modelBuilder.Entity("agos_api.Models.StaticData.TypeLesson", b =>
                {
                    b.Property<int>("TypeLessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("TypeLessonName")
                        .HasColumnType("text");

                    b.HasKey("TypeLessonId");

                    b.ToTable("TypeLessons");
                });

            modelBuilder.Entity("agos_api.Models.StaticData.TypeWeek", b =>
                {
                    b.Property<int>("TypeWeekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("TypeWeekName")
                        .HasColumnType("text");

                    b.HasKey("TypeWeekId");

                    b.ToTable("TypeWeeks");
                });

            modelBuilder.Entity("agos_api.Models.StaticData.WeekDay", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DayFullName")
                        .HasColumnType("text");

                    b.Property<string>("DayShortName")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("WeekDays");
                });

            modelBuilder.Entity("agos_api.Models.Users.DevUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DevUsers");
                });

            modelBuilder.Entity("agos_api.Models.UsersOrg.UserOrganization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int?>("StudyOrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StudyOrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrganizations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("agos_api.Models.Base.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("agos_api.Models.Base.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("agos_api.Models.Base.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("agos_api.Models.Base.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("agos_api.Models.Discipline", b =>
                {
                    b.HasOne("agos_api.Models.StaticData.TypeLesson", "TypeLesson")
                        .WithMany()
                        .HasForeignKey("TypeLessonId");
                });

            modelBuilder.Entity("agos_api.Models.DisciplineSpecial", b =>
                {
                    b.HasOne("agos_api.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId");

                    b.HasOne("agos_api.Models.SpecialityOtdel", "SpecialityOtdel")
                        .WithMany()
                        .HasForeignKey("SpecialityOtdelId");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.ClassroomOfTeacher", b =>
                {
                    b.HasOne("agos_api.Models.Organizations.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomId");

                    b.HasOne("agos_api.Models.Organizations.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.Group", b =>
                {
                    b.HasOne("agos_api.Models.SpecialityOtdel", "SpecialityOtdel")
                        .WithMany()
                        .HasForeignKey("SpecialityOtdelId");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.Semestr", b =>
                {
                    b.HasOne("agos_api.Models.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.StudyOrganization", b =>
                {
                    b.HasOne("agos_api.Models.Organizations.RepresentativeOrganization", "RepresentativeOrganization")
                        .WithMany()
                        .HasForeignKey("RepresentativeOrganizationReprId");
                });

            modelBuilder.Entity("agos_api.Models.Organizations.TeachDiscip", b =>
                {
                    b.HasOne("agos_api.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId");

                    b.HasOne("agos_api.Models.Organizations.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("agos_api.Models.Schedule.AcademicPlan", b =>
                {
                    b.HasOne("agos_api.Models.DisciplineSpecial", "DisciplineSpecial")
                        .WithMany()
                        .HasForeignKey("DisciplineSpecialId");

                    b.HasOne("agos_api.Models.Organizations.Semestr", "Semestr")
                        .WithMany()
                        .HasForeignKey("SemestrId");

                    b.HasOne("agos_api.Models.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");
                });

            modelBuilder.Entity("agos_api.Models.SpecialityOtdel", b =>
                {
                    b.HasOne("agos_api.Models.Organizations.Otdel", "Otdel")
                        .WithMany()
                        .HasForeignKey("OtdelId");

                    b.HasOne("agos_api.Models.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");
                });

            modelBuilder.Entity("agos_api.Models.Users.DevUser", b =>
                {
                    b.HasOne("agos_api.Models.Base.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("agos_api.Models.UsersOrg.UserOrganization", b =>
                {
                    b.HasOne("agos_api.Models.Organizations.StudyOrganization", "studyOrganization")
                        .WithMany()
                        .HasForeignKey("StudyOrganizationId");

                    b.HasOne("agos_api.Models.Base.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
