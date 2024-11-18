using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using FazendaUrbanaApi.Models;

namespace FazendaUrbanaApi.Data;

public partial class TetoVerdeContext : DbContext
{
    public TetoVerdeContext(DbContextOptions<TetoVerdeContext> options) : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ContaCaixa> ContaCaixas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Estoque> Estoques { get; set; }

    public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<ItemPedido> ItemPedidos { get; set; }

    public virtual DbSet<NotaFiscal> NotaFiscals { get; set; }

    public virtual DbSet<PedidoVendum> PedidoVenda { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Transportadora> Transportadoras { get; set; }

    public virtual DbSet<Valore> Valores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=vonphyther.database.windows.net;Initial Catalog=Teto_Verde;User Id=VonPhyther;Pasword=Von120836");
        }
    }
//#warning To protect potentially sensitive information in your connection string,
//you should move it out of source code. You can avoid scaffolding the connection string by using the
//Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
//For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCodCliente).HasName("PK__Cliente__1F07B43FC0F12521");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCodCliente)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Cod_Cliente");
            entity.Property(e => e.Bairro)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("BAIRRO");
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CIDADE");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fantasia)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("FANTASIA");
            entity.Property(e => e.Numero).HasColumnName("NUMERO");
            entity.Property(e => e.Rua)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("RUA");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SENHA");
            entity.Property(e => e.TelCelCli)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TEL_CEL_CLI");
            entity.Property(e => e.Uf)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("UF");
        });

        modelBuilder.Entity<ContaCaixa>(entity =>
        {
            entity.HasKey(e => e.CodCaixa).HasName("PK__CONTA_CA__C10486E1F0EF0612");

            entity.ToTable("CONTA_CAIXA");

            entity.Property(e => e.CodCaixa)
                .ValueGeneratedNever()
                .HasColumnName("COD_CAIXA");
            entity.Property(e => e.DataMovimentacao).HasColumnName("DATA_MOVIMENTACAO");
            entity.Property(e => e.EntradaCaixa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ENTRADA_CAIXA");
            entity.Property(e => e.SaidaCaixa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SAIDA_CAIXA");
            entity.Property(e => e.SaldoCaixa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SALDO_CAIXA");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.CodDepart).HasName("PK__DEPARTAM__559C0971C4F79FE0");

            entity.ToTable("DEPARTAMENTO");

            entity.Property(e => e.CodDepart)
                .ValueGeneratedNever()
                .HasColumnName("COD_DEPART");
            entity.Property(e => e.Descr)
                .HasColumnType("text")
                .HasColumnName("DESCR");
        });

        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => e.CodDeposito).HasName("PK__ESTOQUE__7A01469D315F24AC");

            entity.ToTable("ESTOQUE");

            entity.Property(e => e.CodDeposito)
                .ValueGeneratedNever()
                .HasColumnName("COD_DEPOSITO");
            entity.Property(e => e.Apartamento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("APARTAMENTO");
            entity.Property(e => e.FkCodProduto).HasColumnName("FK_COD_PRODUTO");
            entity.Property(e => e.Movimentacao)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MOVIMENTACAO");
            entity.Property(e => e.Saldo).HasColumnName("SALDO");

            entity.HasOne(d => d.FkCodProdutoNavigation).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.FkCodProduto)
                .HasConstraintName("FK__ESTOQUE__FK_COD___619B8048");
        });

        modelBuilder.Entity<FormaPagamento>(entity =>
        {
            entity.HasKey(e => e.CodPagto).HasName("PK__FORMA_PA__C5FFB2894C894B2D");

            entity.ToTable("FORMA_PAGAMENTO");

            entity.Property(e => e.CodPagto)
                .ValueGeneratedNever()
                .HasColumnName("COD_PAGTO");
            entity.Property(e => e.Boleto)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("BOLETO");
            entity.Property(e => e.Cheque)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CHEQUE");
            entity.Property(e => e.Deposito)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DEPOSITO");
            entity.Property(e => e.Dinheiro)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DINHEIRO");
            entity.Property(e => e.Pix)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("PIX");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.CodFunc).HasName("PK__FUNCIONA__BCF35E8EE2160A40");

            entity.ToTable("FUNCIONARIO");

            entity.Property(e => e.CodFunc)
                .ValueGeneratedNever()
                .HasColumnName("COD_FUNC");
            entity.Property(e => e.Banco)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("BANCO");
            entity.Property(e => e.Contato)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CONTATO");
            entity.Property(e => e.Cpf)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DataAdmissao).HasColumnName("DATA_ADMISSAO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Endereco)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ENDERECO");
            entity.Property(e => e.FkCodDepart).HasColumnName("FK_COD_DEPART");
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOME_COMPLETO");
            entity.Property(e => e.Pis).HasColumnName("PIS");

            entity.HasOne(d => d.FkCodDepartNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.FkCodDepart)
                .HasConstraintName("FK__FUNCIONAR__FK_CO__693CA210");
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(e => e.CodItem).HasName("PK__ITEM_PED__5F12EDF4D374EA69");

            entity.ToTable("ITEM_PEDIDO");

            entity.Property(e => e.CodItem)
                .ValueGeneratedNever()
                .HasColumnName("COD_ITEM");
            entity.Property(e => e.CodPedido).HasColumnName("COD_PEDIDO");
            entity.Property(e => e.FkCodProduto).HasColumnName("FK_COD_PRODUTO");
            entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE");
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.FkCodProdutoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.FkCodProduto)
                .HasConstraintName("FK__ITEM_PEDI__FK_CO__6477ECF3");
        });

        modelBuilder.Entity<NotaFiscal>(entity =>
        {
            entity.HasKey(e => e.CodNf).HasName("PK__NOTA_FIS__0A1A44B688D8BAAF");

            entity.ToTable("NOTA_FISCAL");

            entity.Property(e => e.CodNf)
                .ValueGeneratedNever()
                .HasColumnName("COD_NF");
            entity.Property(e => e.Cfop).HasColumnName("CFOP");
            entity.Property(e => e.Chave).HasColumnName("CHAVE");
            entity.Property(e => e.DataEmissao).HasColumnName("DATA_EMISSAO");
            entity.Property(e => e.FkCodFunc).HasColumnName("FK_COD_FUNC");
            entity.Property(e => e.FkCodItem).HasColumnName("FK_COD_ITEM");
            entity.Property(e => e.Icms).HasColumnName("ICMS");
            entity.Property(e => e.Ipi).HasColumnName("IPI");
            entity.Property(e => e.Situacao)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SITUACAO");

            entity.HasOne(d => d.FkCodFuncNavigation).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.FkCodFunc)
                .HasConstraintName("FK__NOTA_FISC__FK_CO__74AE54BC");

            entity.HasOne(d => d.FkCodItemNavigation).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.FkCodItem)
                .HasConstraintName("FK__NOTA_FISC__FK_CO__73BA3083");
        });

        modelBuilder.Entity<PedidoVendum>(entity =>
        {
            entity.HasKey(e => e.CodPedido).HasName("PK__PEDIDO_V__302BFB8006CFD119");

            entity.ToTable("PEDIDO_VENDA");

            entity.Property(e => e.CodPedido)
                .ValueGeneratedNever()
                .HasColumnName("COD_PEDIDO");
            entity.Property(e => e.DataCompra).HasColumnName("DATA_COMPRA");
            entity.Property(e => e.FkCodPagto).HasColumnName("FK_COD_PAGTO");
            entity.Property(e => e.FkCodTrans).HasColumnName("FK_COD_TRANS");
            entity.Property(e => e.FkIdCodCliente).HasColumnName("FK_ID_Cod_Cliente");
            entity.Property(e => e.TipoFrete)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIPO_FRETE");
            entity.Property(e => e.ValorFrete)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("VALOR_FRETE");

            entity.HasOne(d => d.FkCodPagtoNavigation).WithMany(p => p.PedidoVenda)
                .HasForeignKey(d => d.FkCodPagto)
                .HasConstraintName("FK__PEDIDO_VE__FK_CO__6E01572D");

            entity.HasOne(d => d.FkCodTransNavigation).WithMany(p => p.PedidoVenda)
                .HasForeignKey(d => d.FkCodTrans)
                .HasConstraintName("FK__PEDIDO_VE__FK_CO__6D0D32F4");

            entity.HasOne(d => d.FkIdCodClienteNavigation).WithMany(p => p.PedidoVenda)
                .HasForeignKey(d => d.FkIdCodCliente)
                .HasConstraintName("FK__PEDIDO_VE__FK_ID__6C190EBB");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.CodProduto).HasName("PK__PRODUTOS__AAF2697D97294F37");

            entity.ToTable("PRODUTOS");

            entity.Property(e => e.CodProduto)
                .ValueGeneratedNever()
                .HasColumnName("COD_PRODUTO");
            entity.Property(e => e.CodigoBarra).HasColumnName("CODIGO_BARRA");
            entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.Ncm).HasColumnName("NCM");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Transportadora>(entity =>
        {
            entity.HasKey(e => e.CodTrans).HasName("PK__TRANSPOR__B5D3F65DDCFBBB38");

            entity.ToTable("TRANSPORTADORA");

            entity.Property(e => e.CodTrans)
                .ValueGeneratedNever()
                .HasColumnName("COD_TRANS");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Contato)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CONTATO");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ENDERECO");
            entity.Property(e => e.Fantasia)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("FANTASIA");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("RAZAO_SOCIAL");
        });

        modelBuilder.Entity<Valore>(entity =>
        {
            entity.HasKey(e => e.IdValor).HasName("PK__VALORES__D68E99EEC5C4E835");

            entity.ToTable("VALORES");

            entity.Property(e => e.IdValor)
                .ValueGeneratedNever()
                .HasColumnName("ID_VALOR");
            entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
            entity.Property(e => e.NomeTabela)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOME_TABELA");
            entity.Property(e => e.ValorReal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("VALOR_REAL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
