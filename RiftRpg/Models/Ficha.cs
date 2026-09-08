using RiftRpg.Models.Enumerates;

namespace RiftRpg.Models
{
    public class Ficha
    {
        // Caracteristicas do personagem
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NomePersonagem { get; set; } = string.Empty;
        public int Nivel { get; set; } = 1;
        public int PontosVidaMax { get; set; } = 10;
        public int PontosVidaAtual { get; set; } = 10;
        public int PontosManaMax { get; set; } = 10;
        public int PontosManaAtual { get; set; } = 10;
        public string Despertar { get; set; } = string.Empty;
        public string Estilo { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;

        // Atributos
        public int Forca { get; set; } 
        public int Destreza { get; set; } 
        public int Constituicao { get; set; } 
        public int Intelecto{ get; set; } 
        public int Poder { get; set; }

        // Pericias
        public NivelPericia Lutar { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Ocultismo { get; set; } = NivelPericia.Destreinado;
        public NivelPericia ArmasBrancas { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Pontaria { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Robustez { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Crime { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Atletismo { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Furtividade { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Intimidacao { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Percepcao { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Psicologia { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Reflexos { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Acrobacias { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Iniciativa { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Vontade { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Labia { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Domar { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Conhecimento { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Intuicao { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Investigacao { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Medicina { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Direcao { get; set; } = NivelPericia.Destreinado;
        public NivelPericia Sobrevivencia { get; set; } = NivelPericia.Destreinado;

        // Anotações da Ficha

        public string Habilidades { get; set; } = string.Empty;
        public string Anotacoes { get; set; } = string.Empty;
        public string Equipamentos { get; set; } = string.Empty;
        public string Historia { get; set; } = string.Empty;
        public ICollection<InventarioFicha> Inventario { get; set; } = new List<InventarioFicha>();
    }
}
