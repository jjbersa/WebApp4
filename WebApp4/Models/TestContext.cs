using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp4.Models
{
    public partial class TestContext : DbContext
    {
        public virtual DbSet<MbCausal> MbCausal { get; set; }
        public virtual DbSet<MbMag> MbMag { get; set; }
        public virtual DbSet<MgAnaArt> MgAnaArt { get; set; }
        public virtual DbSet<MgAnaUbicazioni> MgAnaUbicazioni { get; set; }
        public virtual DbSet<MgMovimenti> MgMovimenti { get; set; }
        public virtual DbSet<MgRegistrazioni> MgRegistrazioni { get; set; }
        public virtual DbSet<MgUbicazioniArticoli> MgUbicazioniArticoli { get; set; }
        public virtual DbSet<PkAnag> PkAnag { get; set; }
        public virtual DbSet<PkArticoli> PkArticoli { get; set; }
        public virtual DbSet<SecUsers> SecUsers { get; set; }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MbCausal>(entity =>
            {
                entity.HasKey(e => e.MbcsId);

                entity.ToTable("MB_Causal");

                entity.HasIndex(e => new { e.MbcsMbmgId, e.MbcsCaus })
                    .HasName("UQ_MB_Caus_MagCode")
                    .IsUnique();

                entity.Property(e => e.MbcsId).HasColumnName("MBCS_Id");

                entity.Property(e => e.MbcsCaus)
                    .IsRequired()
                    .HasColumnName("MBCS_Caus")
                    .HasColumnType("nchar(3)");

                entity.Property(e => e.MbcsDescr)
                    .IsRequired()
                    .HasColumnName("MBCS_Descr")
                    .HasMaxLength(80);

                entity.Property(e => e.MbcsMbmgId).HasColumnName("MBCS_MBMG_Id");

                entity.Property(e => e.MbcsMgauId).HasColumnName("MBCS_MGAU_ID");

                entity.HasOne(d => d.MbcsMbmg)
                    .WithMany(p => p.MbCausal)
                    .HasForeignKey(d => d.MbcsMbmgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MB_Caus__MBCS_MB__55E3AD8C");

                entity.HasOne(d => d.MbcsMgau)
                    .WithMany(p => p.MbCausal)
                    .HasForeignKey(d => d.MbcsMgauId)
                    .HasConstraintName("FK__MB_Caus__MG_AnaUbicazioni");
            });

            modelBuilder.Entity<MbMag>(entity =>
            {
                entity.HasKey(e => e.MbmgId);

                entity.ToTable("MB_Mag");

                entity.HasIndex(e => e.MbmgCode)
                    .HasName("UQ_MB_Mag_Code")
                    .IsUnique();

                entity.Property(e => e.MbmgId).HasColumnName("MBMG_Id");

                entity.Property(e => e.MbmgCode)
                    .IsRequired()
                    .HasColumnName("MBMG_Code")
                    .HasMaxLength(10);

                entity.Property(e => e.MbmgDataFinVal)
                    .HasColumnName("MBMG_DataFinVal")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbmgDescr)
                    .IsRequired()
                    .HasColumnName("MBMG_Descr")
                    .HasMaxLength(50);

                entity.Property(e => e.MbmgMag).HasColumnName("MBMG_Mag");
            });

            modelBuilder.Entity<MgAnaArt>(entity =>
            {
                entity.HasKey(e => e.MgaaId);

                entity.ToTable("MG_AnaArt");

                entity.HasIndex(e => new { e.MgaaMatricola })
                    .HasName("UQ_MG_AnaArt_1__35")
                    .IsUnique();

                entity.Property(e => e.MgaaId).HasColumnName("MGAA_Id");

                entity.Property(e => e.MgaaDataIns)
                    .HasColumnName("MGAA_DataIns")
                    .HasColumnType("datetime")
                    .HasDefaultValue(DateTime.Now);

                entity.Property(e => e.MgaaDataUltMod)
                    .HasColumnName("MGAA_DataUltMod")
                    .HasColumnType("datetime")
                    .HasDefaultValue(DateTime.Now);

                entity.Property(e => e.MgaaDescr)
                    .IsRequired()
                    .HasColumnName("MGAA_Descr")
                    .HasMaxLength(200);

                entity.Property(e => e.MgaaMatricola)
                    .IsRequired()
                    .HasColumnName("MGAA_Matricola")
                    .HasMaxLength(50);

                entity.Property(e => e.MgaaMbdcClasse)
                    .IsRequired()
                    .HasColumnName("MGAA_MBDC_Classe")
                    .HasColumnType("nchar(3)");

                entity.Property(e => e.MgaaNote)
                    .HasColumnName("MGAA_Note")
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<MgAnaUbicazioni>(entity =>
            {
                entity.HasKey(e => e.MgauId);

                entity.ToTable("MG_AnaUbicazioni");

                entity.HasIndex(e => new { e.MgauMbmgId, e.MgauCodCompl })
                    .HasName("UQ_MG_AnaUbicazioni_10")
                    .IsUnique();

                entity.Property(e => e.MgauId).HasColumnName("MGAU_Id");

                entity.Property(e => e.MgauAltezza)
                    .HasColumnName("MGAU_Altezza")
                    .HasColumnType("decimal(28, 15)");

                entity.Property(e => e.MgauBloccata).HasColumnName("MGAU_Bloccata");

                entity.Property(e => e.MgauCodCompl)
                    .IsRequired()
                    .HasColumnName("MGAU_CodCompl")
                    .HasMaxLength(255);

                entity.Property(e => e.MgauCodice)
                    .IsRequired()
                    .HasColumnName("MGAU_Codice")
                    .HasColumnType("nchar(3)");

                entity.Property(e => e.MgauDataIns)
                    .HasColumnName("MGAU_DataIns")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.MgauDescr)
                    .HasColumnName("MGAU_Descr")
                    .HasMaxLength(50);

                entity.Property(e => e.MgauLarghezza)
                    .HasColumnName("MGAU_Larghezza")
                    .HasColumnType("decimal(28, 15)");

                entity.Property(e => e.MgauLivello).HasColumnName("MGAU_Livello");

                entity.Property(e => e.MgauMbmgId).HasColumnName("MGAU_MBMG_Id");


                entity.Property(e => e.MgauPrenotata).HasColumnName("MGAU_Prenotata");

                entity.Property(e => e.MgauProfondita)
                    .HasColumnName("MGAU_Profondita")
                    .HasColumnType("decimal(28, 15)");

                entity.Property(e => e.MgauTreeCtrl)
                    .HasColumnName("MGAU_TreeCtrl")
                    .HasMaxLength(255);

                entity.Property(e => e.MgauUbiDef).HasColumnName("MGAU_UbiDef");

                entity.HasOne(d => d.MgauMbmg)
                    .WithMany(p => p.MgAnaUbicazioni)
                    .HasForeignKey(d => d.MgauMbmgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MG_AnaUbicazioni_MB_Mag");
                
            });

            modelBuilder.Entity<MgMovimenti>(entity =>
            {
                entity.HasKey(e => e.MgmvId);

                entity.ToTable("MG_Movimenti");

                entity.Property(e => e.MgmvId).HasColumnName("MGMV_Id");

                entity.Property(e => e.MgmvCodUbi)
                    .HasColumnName("MGMV_CodUbi")
                    .HasMaxLength(255);

                entity.Property(e => e.MgmvDataIns)
                    .HasColumnName("MGMV_DataIns")
                    .HasColumnType("datetime");

                entity.Property(e => e.MgmvIdRegDest).HasColumnName("MGMV_IdRegDest");

                entity.Property(e => e.MgmvIdRegProv).HasColumnName("MGMV_IdRegProv");

                entity.Property(e => e.MgmvMgaaId).HasColumnName("MGMV_MGAA_Id");

                entity.Property(e => e.MgmvMgauId).HasColumnName("MGMV_MGAU_Id");

                entity.Property(e => e.MgmvMgrgId).HasColumnName("MGMV_MGRG_Id");

                entity.Property(e => e.MgmvNote)
                    .HasColumnName("MGMV_Note")
                    .HasMaxLength(255);

                entity.Property(e => e.MgmvPkanId).HasColumnName("MGMV_PKAN_Id");

                entity.Property(e => e.MgmvPkarId).HasColumnName("MGMV_PKAR_Id");

                entity.Property(e => e.MgmvProg).HasColumnName("MGMV_Prog");

                entity.Property(e => e.MgmvQuantita)
                    .HasColumnName("MGMV_Quantita")
                    .HasColumnType("decimal(28, 15)");

                entity.Property(e => e.MgmvUsrId).HasColumnName("MGMV_USR_ID");

                entity.HasOne(d => d.MgmvMgaa)
                    .WithMany(p => p.MgMovimenti)
                    .HasForeignKey(d => d.MgmvMgaaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MG_Movimenti_MG_AnaArt");

                entity.HasOne(d => d.MgmvMgau)
                    .WithMany(p => p.MgMovimenti)
                    .HasForeignKey(d => d.MgmvMgauId)
                    .HasConstraintName("FK__MG_Movimenti_MG_AnaUbicazioni");

                entity.HasOne(d => d.MgmvMgrg)
                    .WithMany(p => p.MgMovimenti)
                    .HasForeignKey(d => d.MgmvMgrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MG_Movimenti_MG_Registrazioni");

                entity.HasOne(d => d.MgmvPkan)
                    .WithMany(p => p.MgMovimenti)
                    .HasForeignKey(d => d.MgmvPkanId)
                    .HasConstraintName("FK_MG_Movimenti_PK_Anag");

                entity.HasOne(d => d.MgmvPkar)
                    .WithMany(p => p.MgMovimenti)
                    .HasForeignKey(d => d.MgmvPkarId)
                    .HasConstraintName("FK_MG_Movimenti_PK_Articoli");

                entity.HasOne(d => d.MgmvUsr)
                    .WithMany(p => p.MgMovimenti)
                    .HasForeignKey(d => d.MgmvUsrId)
                    .HasConstraintName("FK_MG_Movimenti_SEC_Users");
            });

            modelBuilder.Entity<MgRegistrazioni>(entity =>
            {
                entity.HasKey(e => e.MgrgId);

                entity.ToTable("MG_Registrazioni");

                entity.HasIndex(e => new { e.MgrgMbmgId, e.MgrgMbcsId, e.MgrgData, e.MgrgNum })
                    .HasName("UQ___2__18")
                    .IsUnique();

                entity.Property(e => e.MgrgId).HasColumnName("MGRG_Id");

                entity.Property(e => e.MgrgCreationDate)
                    .HasColumnName("MGRG_CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MgrgCreationUserUsrId).HasColumnName("MGRG_CreationUser_USR_Id");

                entity.Property(e => e.MgrgData)
                    .HasColumnName("MGRG_Data")
                    .HasColumnType("datetime");

                entity.Property(e => e.MgrgDataRif)
                    .HasColumnName("MGRG_DataRif")
                    .HasColumnType("datetime");

                entity.Property(e => e.MgrgDocRif)
                    .HasColumnName("MGRG_DocRif")
                    .HasMaxLength(100);

                entity.Property(e => e.MgrgLastEditDate)
                    .HasColumnName("MGRG_LastEditDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MgrgLastEditUserUsrId).HasColumnName("MGRG_LastEditUser_USR_Id");

                entity.Property(e => e.MgrgMbcsId).HasColumnName("MGRG_MBCS_Id");

                entity.Property(e => e.MgrgMbmgId).HasColumnName("MGRG_MBMG_Id");

                entity.Property(e => e.MgrgNum).HasColumnName("MGRG_Num");

                entity.HasOne(d => d.MgrgCreationUserUsr)
                    .WithMany(p => p.MgRegistrazioniMgrgCreationUserUsr)
                    .HasForeignKey(d => d.MgrgCreationUserUsrId)
                    .HasConstraintName("FK_MG_Registrazioni_Creation_SEC_Users");

                entity.HasOne(d => d.MgrgLastEditUserUsr)
                    .WithMany(p => p.MgRegistrazioniMgrgLastEditUserUsr)
                    .HasForeignKey(d => d.MgrgLastEditUserUsrId)
                    .HasConstraintName("FK_MG_Registrazioni_LastEdit_SEC_Users");

                entity.HasOne(d => d.MgrgMbcs)
                    .WithMany(p => p.MgRegistrazioni)
                    .HasForeignKey(d => d.MgrgMbcsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MG_Registrazioni_MB_Caus");

                entity.HasOne(d => d.MgrgMbmg)
                    .WithMany(p => p.MgRegistrazioni)
                    .HasForeignKey(d => d.MgrgMbmgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MG_Registrazioni_MB_Mag");
            });

            modelBuilder.Entity<MgUbicazioniArticoli>(entity =>
            {
                entity.HasKey(e => e.MguaId);

                entity.ToTable("MG_UbicazioniArticoli");

                entity.Property(e => e.MguaId).HasColumnName("MGUA_Id");

                entity.Property(e => e.MguaMbmgId).HasColumnName("MGUA_MBMG_Id");

                entity.Property(e => e.MguaMgaaId).HasColumnName("MGUA_MGAA_Id");

                entity.Property(e => e.MguaMgauId).HasColumnName("MGUA_MGAU_Id");

                entity.HasOne(d => d.MguaMbmg)
                    .WithMany(p => p.MgUbicazioniArticoli)
                    .HasForeignKey(d => d.MguaMbmgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MG_UbicazioniArticoli_MB_Mag");

                entity.HasOne(d => d.MguaMgaa)
                    .WithMany(p => p.MgUbicazioniArticoli)
                    .HasForeignKey(d => d.MguaMgaaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MG_UbicazioniArticoli_MG_AnaArt");

                entity.HasOne(d => d.MguaMgau)
                    .WithMany(p => p.MgUbicazioniArticoli)
                    .HasForeignKey(d => d.MguaMgauId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MG_UbicazioniArticoli__MG_AnaUbicazioni");
            });

            modelBuilder.Entity<PkAnag>(entity =>
            {
                entity.HasKey(e => e.PkanId);

                entity.ToTable("PK_Anag");

                entity.Property(e => e.PkanId).HasColumnName("PKAN_Id");

                entity.Property(e => e.PkanData)
                    .HasColumnName("PKAN_Data")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PkanDesc)
                    .IsRequired()
                    .HasColumnName("PKAN_Desc")
                    .HasMaxLength(255);

                entity.Property(e => e.PkanNote)
                    .IsRequired()
                    .HasColumnName("PKAN_Note")
                    .HasMaxLength(255);

                entity.Property(e => e.PkanNum).HasColumnName("PKAN_Num");

                entity.Property(e => e.PkanScaric).HasColumnName("PKAN_Scaric");

                entity.Property(e => e.PkanYear).HasColumnName("PKAN_Year");
            });

            modelBuilder.Entity<PkArticoli>(entity =>
            {
                entity.HasKey(e => e.PkarId);

                entity.ToTable("PK_Articoli");

                entity.Property(e => e.PkarId).HasColumnName("PKAR_Id");

                entity.Property(e => e.PkarCodice)
                    .HasColumnName("PKAR_Codice")
                    .HasMaxLength(30);

                entity.Property(e => e.PkarMbcsId).HasColumnName("PKAR_MBCS_Id");

                entity.Property(e => e.PkarMbmgId).HasColumnName("PKAR_MBMG_Id");

                entity.Property(e => e.PkarMgaaId).HasColumnName("PKAR_MGAA_Id");

                entity.Property(e => e.PkarMgauId).HasColumnName("PKAR_MGAU_Id");

                entity.Property(e => e.PkarMgmvProg).HasColumnName("PKAR_MGMV_Prog");

                entity.Property(e => e.PkarMgrgId).HasColumnName("PKAR_MGRG_Id");

                entity.Property(e => e.PkarNote).HasColumnName("PKAR_Note");

                entity.Property(e => e.PkarPkanId).HasColumnName("PKAR_PKAN_Id");

                entity.Property(e => e.PkarQtaPick).HasColumnName("PKAR_QtaPick");

                entity.Property(e => e.PkarQtaSca)
                    .HasColumnName("PKAR_QtaSca")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PkarTransferred).HasColumnName("PKAR_Transferred");

                entity.HasOne(d => d.PkarMbcs)
                    .WithMany(p => p.PkArticoli)
                    .HasForeignKey(d => d.PkarMbcsId)
                    .HasConstraintName("FK__PK_Artico__PKAR___5206CACC");

                entity.HasOne(d => d.PkarMbmg)
                    .WithMany(p => p.PkArticoli)
                    .HasForeignKey(d => d.PkarMbmgId)
                    .HasConstraintName("FK__PK_Artico__PKAR___52FAEF05");

                entity.HasOne(d => d.PkarMgaa)
                    .WithMany(p => p.PkArticoli)
                    .HasForeignKey(d => d.PkarMgaaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PK_Artico__PKAR___54CF8DC2");

                entity.HasOne(d => d.PkarMgau)
                    .WithMany(p => p.PkArticoli)
                    .HasForeignKey(d => d.PkarMgauId)
                    .HasConstraintName("FK__PK_Artico__PKAR___445B90DC");
            });

            modelBuilder.Entity<SecUsers>(entity =>
            {
                entity.HasKey(e => e.UsrId);

                entity.ToTable("SEC_Users");

                entity.HasIndex(e => e.UsrLogin)
                    .HasName("UQ_SEC_Users_Login_Domain")
                    .IsUnique();

                entity.Property(e => e.UsrId).HasColumnName("USR_Id");

                entity.Property(e => e.UsrDescription)
                    .HasColumnName("USR_Description")
                    .HasMaxLength(255);

                entity.Property(e => e.UsrEmail)
                    .HasColumnName("USR_Email")
                    .HasMaxLength(255);

                entity.Property(e => e.UsrLogin)
                    .IsRequired()
                    .HasColumnName("USR_Login")
                    .HasMaxLength(50);

                entity.Property(e => e.UsrName)
                    .IsRequired()
                    .HasColumnName("USR_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.UsrPasswd).HasColumnName("USR_Passwd");

                entity.Property(e => e.UsrUserType).HasColumnName("USR_UserType");
            });
        }
    }
}
