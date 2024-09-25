using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(string[] args)
    {
        using (var db = new ProdutoDbContext())
        {
            var produtos = db.produto;
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.nome + " (id: " + produto.produtoid + ") custa " +
                                  produto.preco.ToString("C2"));
            }
        }
    }
}

public class ProdutoDbContext : DbContext
{
    public DbSet<Produto> produto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(@"Host=10.0.1.95;"+
                                 "Username=usuario1;"+
                                 "Password=123456;"+
                                 "Database=exemplo1");
    }
}

public class Produto
{
    public int produtoid { get; set; }
    public string nome { get; set; }
    public decimal preco { get; set; }

    public Produto()
    {

    }
}
