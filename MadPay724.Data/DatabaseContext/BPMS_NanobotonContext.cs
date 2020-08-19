using MadPay724.Data.Models.Report;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.DatabaseContext
{
    public partial class BPMS_NanobotonContext : DbContext
    {
        public BPMS_NanobotonContext()
        {
        }

        public BPMS_NanobotonContext(DbContextOptions<BPMS_NanobotonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DocGroups> DocGroups { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HO9R1KR\SA ;Initial Catalog = BPMS_NanoBoton; Integrated Security= True; MultipleActiveResultSets=True");
           // optionsBuilder.UseSqlServer(@"Data Source=WEB ;Initial Catalog = BPMS_NanoBoton;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.TopicCode);

                entity.ToTable("Categories", "Acc");

                entity.Property(e => e.TopicCode).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AuditId).HasColumnName("AuditID");

                entity.Property(e => e.AuditReferenceTxt)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BudgetPrice).HasColumnType("money");

                entity.Property(e => e.BudgetTopicId).HasColumnName("BudgetTopicID");

                entity.Property(e => e.ConstructionPercent).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.FinancialId).HasColumnName("FinancialID");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.MakeDate)
                    .HasColumnName("makeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MoeenNameL1)
                    .IsRequired()
                    .HasColumnName("MoeenName_L1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MoeenNameL2)
                    .HasColumnName("MoeenName_L2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.RecalInterfaceId)
                    .HasColumnName("RecalInterfaceID")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UserRelated)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.HasIndex(e => e.CustomerGrpId);

                entity.HasIndex(e => new { e.CustId, e.CustomerGrpId, e.CustName, e.NationalId, e.CustFirstName, e.CustomerActive })
                    .HasName("IX_Customers_CustomerActive");

                entity.HasIndex(e => new { e.CustId, e.CustName, e.Balance, e.FirstBalance, e.Country, e.City, e.WebSite, e.Region, e.Address, e.Tel, e.Fax, e.Email, e.Pobox, e.AccDetailCode, e.MaxCredit, e.ServiceCalcType, e.ServicePrice, e.ExtServicePrice, e.RevenuePercent, e.EconomicNumber, e.PostalCode, e.State, e.ModifyDate, e.OperatorId, e.CustomerNote, e.ValuationType, e.ProjectId, e.BudgetId, e.InfoWeight, e.InfoDate, e.GrpActionCustomer, e.ContactRate, e.AccCtopicCode, e.AccCtopicCode2, e.BankId, e.BankName, e.AccountNumber, e.AccountKind, e.BankReports, e.ManageName, e.ManagerSells, e.ContactNo, e.DiscountNote, e.Discount, e.DayTime, e.ConveyKind, e.ArzTypeId, e.AccStateDefault, e.NationalId, e.Mobile, e.CustomersRow, e.PersonId1, e.EstablishDate, e.SellsMethod, e.SellsEmporium, e.SellsDefaultState, e.MasirId, e.MaxCreditCurrentForm, e.ReagentName, e.Tel2, e.Tel3, e.PersonId3, e.UseUnitId, e.InsertAutoEffectId, e.EffectId, e.CustomerGrpId2, e.PurchasePercent, e.TechnicalCode, e.AccCtopicCode3, e.CustAccountNumber, e.AccTopicCode, e.RegisterNumber, e.HctarafGaradadTypeCode, e.HckharidarTypeCode, e.CustFirstName, e.PerCityCode, e.StateCode, e.CityCode, e.LastUser, e.FirstUser, e.CustomerState, e.HcforoushandeType1Code, e.Max4WaterCo, e.SupervisorAllocation, e.CustomerCheckNote, e.DayOrder, e.CustomerGrpId, e.CustomerActive })
                    .HasName("IX_Customers_CustomerGrpID_CustomerActive");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccCtopicCode)
                    .IsRequired()
                    .HasColumnName("acc_CTopicCode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccCtopicCode2)
                    .IsRequired()
                    .HasColumnName("acc_CTopicCode2")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccCtopicCode3)
                    .IsRequired()
                    .HasColumnName("acc_CTopicCode3")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccDetailCode)
                    .IsRequired()
                    .HasColumnName("acc_DetailCode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccStateDefault).HasColumnName("accStateDefault");

                entity.Property(e => e.AccTopicCode)
                    .HasColumnName("acc_TopicCode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountKind).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AlternativeCustId).HasColumnName("AlternativeCustID");

                entity.Property(e => e.AlternativeCustId2).HasColumnName("AlternativeCustID2");

                entity.Property(e => e.ArzTypeId).HasColumnName("ArzTypeID");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.BankIdc)
                    .HasColumnName("BankIDc")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BankName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BankReports)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BudgetId).HasColumnName("BudgetID");

                entity.Property(e => e.BusinesslicenseValidityDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CarType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustAccountNumber)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CustFirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CustNameL2)
                    .HasColumnName("CustName_L2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerCheckNote)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerGrpId).HasColumnName("CustomerGrpID");

                entity.Property(e => e.CustomerGrpId2).HasColumnName("CustomerGrpID2");

                entity.Property(e => e.CustomerNote)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Degree)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscountNote)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EconomicNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.EffectId).HasColumnName("EffectID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EstablishDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExtServicePrice).HasColumnType("money");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstBalance).HasColumnType("money");

                entity.Property(e => e.FirstUser).HasMaxLength(20);

                entity.Property(e => e.HcforoushandeType1Code)
                    .HasColumnName("HCForoushandeType1Code")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HckharidarTypeCode).HasColumnName("HCKharidarTypeCode");

                entity.Property(e => e.HctarafGaradadTypeCode).HasColumnName("HCTarafGaradadTypeCode");

                entity.Property(e => e.InfoDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsertAutoEffectId).HasColumnName("InsertAutoEffectID");

                entity.Property(e => e.LastUser).HasMaxLength(20);

                entity.Property(e => e.LeaseValidityDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ManageName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerSells)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MasirId).HasColumnName("MasirID");

                entity.Property(e => e.Max4WaterCo).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MaxCredit).HasColumnType("money");

                entity.Property(e => e.MaxCreditCurrentForm)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((999999999))");

                entity.Property(e => e.MaxWeeklyShoppingCredit).HasColumnType("money");

                entity.Property(e => e.MinWeeklyShoppingAmount).HasColumnType("money");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.NationalId)
                    .HasColumnName("NationalID")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.OperatorId)
                    .HasColumnName("OperatorID")
                    .HasMaxLength(100);

                entity.Property(e => e.PelakSabtiAsli)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PelakSabtiFari)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PerCityCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId1).HasColumnName("PersonID1");

                entity.Property(e => e.PersonId3).HasColumnName("PersonID3");

                entity.Property(e => e.Pobox)
                    .HasColumnName("pobox")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ReagentName).HasMaxLength(60);

                entity.Property(e => e.Region)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SellsEmporium).HasDefaultValueSql("((1))");

                entity.Property(e => e.ServicePrice).HasColumnType("money");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.TTabeiat).HasColumnName("T_Tabeiat");

                entity.Property(e => e.TechnicalCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tel2).HasMaxLength(30);

                entity.Property(e => e.Tel3).HasMaxLength(30);

                entity.Property(e => e.TelegramChatId)
                    .HasColumnName("TelegramChatID")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UseUnitId).HasColumnName("UseUnitID");

                entity.Property(e => e.VatValidityDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WebSite)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.PersonId1Navigation)
                    .WithMany(p => p.InversePersonId1Navigation)
                    .HasForeignKey(d => d.PersonId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_Customers");

                entity.HasOne(d => d.PersonId3Navigation)
                    .WithMany(p => p.InversePersonId3Navigation)
                    .HasForeignKey(d => d.PersonId3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_CustomersPersonID3");
            });

            modelBuilder.Entity<DocGroups>(entity =>
            {
                entity.HasKey(e => new { e.Serial, e.YearId, e.CompanyCode });

                entity.ToTable("DocGroups", "Acc");

                entity.HasIndex(e => e.YearId)
                    .HasName("IX_YearID");

                entity.HasIndex(e => new { e.YearId, e.CompanyCode, e.SecondaryDocNo })
                    .HasName("IX_UniqueDoc")
                    .IsUnique();

                entity.HasIndex(e => new { e.DocDate, e.PrimaryDocNo, e.SecondaryDocNo, e.Serial })
                    .HasName("IX_DocGroup");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.Property(e => e.AttachFolderName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.DocDate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocDateMiladi)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DocNoteL1)
                    .HasColumnName("DocNote_L1")
                    .HasMaxLength(6000)
                    .IsUnicode(false);

                entity.Property(e => e.DocNoteL2)
                    .HasColumnName("DocNote_L2")
                    .HasMaxLength(6000)
                    .IsUnicode(false);

                entity.Property(e => e.DocTopicL1)
                    .HasColumnName("DocTopic_L1")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DocTopicL2)
                    .HasColumnName("DocTopic_L2")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FirstUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MakeDate).HasColumnType("datetime");

                entity.Property(e => e.SecondUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceDataBase)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => new { e.Serial, e.CompanyCode, e.Id, e.YearId });

                entity.ToTable("Documents", "Acc");

                entity.HasIndex(e => new { e.TopicCode, e.DetailCode });

                entity.HasIndex(e => new { e.CompanyCode, e.YearId, e.Serial });

                entity.HasIndex(e => new { e.Serial, e.YearId, e.CompanyCode })
                    .HasName("IX_Documents_DocGrouops");

                entity.HasIndex(e => new { e.CompanyCode, e.YearId, e.TopicCode, e.DetailCode })
                    .HasName("IX_Documents_TopicCode DetailCodeYearIDCompanyCode");

                entity.Property(e => e.CompanyCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.Property(e => e.AidAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AidDocNo)
                    .HasColumnType("decimal(20, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AidDocdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BudgetId)
                    .HasColumnName("BudgetID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetTopicId)
                    .HasColumnName("BudgetTopicID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CashType).HasDefaultValueSql("((1))");

                entity.Property(e => e.CommentL1)
                    .HasColumnName("Comment_L1")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CommentL2)
                    .HasColumnName("Comment_L2")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Credit).HasColumnType("money");

                entity.Property(e => e.CtopicCode)
                    .HasColumnName("CTopicCode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CtopicCode2)
                    .HasColumnName("CTopicCode2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ctopiccode3).HasColumnName("ctopiccode3");

                entity.Property(e => e.Debt).HasColumnType("money");

                entity.Property(e => e.DetailCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceCheck).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReferenceNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceTxt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RelatedId).HasColumnName("RelatedID");

                entity.Property(e => e.SanamaId)
                    .HasColumnName("SanamaID")
                    .HasColumnType("xml");

                entity.HasOne(d => d.CtopicCodeNavigation)
                    .WithMany(p => p.DocumentsCtopicCodeNavigation)
                    .HasForeignKey(d => d.CtopicCode)
                    .HasConstraintName("FK_Documents_Customers1");

                entity.HasOne(d => d.CtopicCode2Navigation)
                    .WithMany(p => p.DocumentsCtopicCode2Navigation)
                    .HasForeignKey(d => d.CtopicCode2)
                    .HasConstraintName("FK_Documents_Customers2");

                entity.HasOne(d => d.Ctopiccode3Navigation)
                    .WithMany(p => p.DocumentsCtopiccode3Navigation)
                    .HasForeignKey(d => d.Ctopiccode3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documents_Customers3");

                entity.HasOne(d => d.DetailCodeNavigation)
                    .WithMany(p => p.DocumentsDetailCodeNavigation)
                    .HasForeignKey(d => d.DetailCode)
                    .HasConstraintName("FK_Documents_Customers");

                entity.HasOne(d => d.TopicCodeNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.TopicCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documents_Categories");

                entity.HasOne(d => d.DocGroups)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => new { d.Serial, d.YearId, d.CompanyCode })
                    .HasConstraintName("FK_Documents_DocGroups");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
