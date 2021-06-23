using System.Collections.Generic;

namespace Domain.Model
{
    public class Funcao
    {
        public int ID { get; set; }
        public string NomeFuncao { get; set; }
        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}