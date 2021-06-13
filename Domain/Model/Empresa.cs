using System.Collections.Generic;

namespace Domain.Model
{
    public class Empresa
    {
        public int ID { get; set; }
        public string RazaoSocial { get; set; }
        public TipoIdentificador TipoIdentificador { get; set; }
        public string Identificador { get; set; }

        public ICollection<Funcao> Funcoes { get; set; }
    }
}