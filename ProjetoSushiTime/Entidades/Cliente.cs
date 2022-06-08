using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSushiTime.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int NumeroCasa { get; set; }
        public string Senha { get; set; }
    }
}
