using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("auditoria")]
    public class AuditoriaModel
    {
        [Key]
        [Column("auditoriaid")]
        public Guid Id { get; set; }

        [Column("data")]
        public string Data { get; set; }

        [Column("hora")]
        public string Hora { get; set; }

        [Column("operacao")]
        public string Operacao { get; set; }

        [Column("nomeentidade")]
        public string NomeEntidade { get; set; }

        [Column("valoresantigos")]
        public string? ValoresAntigos { get; set; }

        [Column("novosvalores")]
        public string? NovosValores { get; set; }

        [Column("idusuario")]
        public int IdUsuario { get; set; }

        public object DeserializeValoresAntigos()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(this.ValoresAntigos);
        }

        public object DeserializeNovosValores()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(this.NovosValores);
        }

        public void ObterData()
        {
            DateTime data = DateTime.Now;
            this.Data = data.ToString("dd/MM/yyyy");
        }

        public void ObterHora()
        {
            DateTime data = DateTime.Now;
            this.Hora = data.ToString("HH:mm");
        }
    }
}
