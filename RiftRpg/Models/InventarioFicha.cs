namespace RiftRpg.Models
{
    public class InventarioFicha
    {
        public int Id { get; set; }
        public int IdFicha { get; set; }
        public Ficha? Ficha { get; set; } 

        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; } = 1;
        public int? Peso { get; set; }
        public bool Equipado { get; set; }
    }
}
