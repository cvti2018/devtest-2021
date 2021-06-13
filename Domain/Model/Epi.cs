using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Epi
    {
        public int ID { get; set; }
        public string NomEpi { get; set; }
        public DateTimeOffset DatInclusao { get; set; }
        public string DatValidade { get; set; }
        public int NumCa { get; set; }
        public string NumProcesso { get; set; }
        public string NomFabricante { get; set; }
        public string CnpjFabricante { get; set; }

        public ICollection<FuncionarioEpi> FuncionarioEpis { get; set; }
    }
}