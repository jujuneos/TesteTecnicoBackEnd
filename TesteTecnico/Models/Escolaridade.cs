using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteTecnico.Models;

[Table("Escolaridade")]
public class Escolaridade
{
    [Key]
    public int IdEscolaridade { get; set; }

    //O C# não permite que uma propriedade tenha o mesmo nome da classe.
    public string? NomeEscolaridade { get; set; }

    public ICollection<Usuario>? Usuarios { get; set; }

    public Escolaridade()
    {
        Usuarios = new Collection<Usuario>();
    }
}