using System;

namespace Domain.Model
{
    public class FuncionarioEpi
    {
        public int ID { get; set; }
        public DateTimeOffset DatEntrega { get; set; }
        public DateTimeOffset? DatTroca { get; set; }
        public int FuncionarioID { get; set; }
        public int EpiID { get; set; }

        public Funcionario Funcionario { get; set; }
        public Epi Epi { get; set; }
    }
}