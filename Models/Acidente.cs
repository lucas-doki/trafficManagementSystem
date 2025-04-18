namespace TrafficManagementSystem.Models
{
    public class Acidente
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
    }
}
