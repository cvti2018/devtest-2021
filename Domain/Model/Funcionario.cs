using System.Collections.Generic;

namespace Domain.Model
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string NomeFuncionario { get; set; }
        public string Cpf { get; set; }
        public int FuncaoID { get; set; }
        public Funcao Funcao { get; set; }

        public ICollection<FuncionarioEpi> FuncionarioEpis { get; set; }
    }
}