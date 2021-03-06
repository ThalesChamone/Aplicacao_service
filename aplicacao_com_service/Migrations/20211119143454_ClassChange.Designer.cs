// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aplicacao_com_service.Data;

namespace aplicacao_com_service.Migrations
{
    [DbContext(typeof(aplicacao_com_serviceContext))]
    [Migration("20211119143454_ClassChange")]
    partial class ClassChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("aplicacao_com_service.Models.Convenio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeContato")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeEmpresa")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.Property<string>("URL")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Convenio");
                });

            modelBuilder.Entity("aplicacao_com_service.Models.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeEspecialidade")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("aplicacao_com_service.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("Numero")
                        .HasColumnType("double");

                    b.Property<string>("Rua")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("aplicacao_com_service.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<int?>("ConvenioId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("Numero")
                        .HasColumnType("double");

                    b.Property<int?>("ProcedimentoId")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ConvenioId");

                    b.HasIndex("ProcedimentoId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("aplicacao_com_service.Models.Procedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataProcedimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeProcedimento")
                        .HasColumnType("longtext");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext");

                    b.Property<string>("Sexo")
                        .HasColumnType("longtext");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("aplicacao_com_service.Models.Medico", b =>
                {
                    b.HasOne("aplicacao_com_service.Models.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");
                });

            modelBuilder.Entity("aplicacao_com_service.Models.Paciente", b =>
                {
                    b.HasOne("aplicacao_com_service.Models.Convenio", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioId");

                    b.HasOne("aplicacao_com_service.Models.Procedimento", "Procedimento")
                        .WithMany()
                        .HasForeignKey("ProcedimentoId");

                    b.Navigation("Convenio");

                    b.Navigation("Procedimento");
                });
#pragma warning restore 612, 618
        }
    }
}
