using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace netimoveis.Net.Models
{
    public class Imovel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string TipoImovel { get; set; }

        [Required]
        public float ValorVenda { get; set; }

        [Required]
        public float ValorLocacao { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string Bairro {get; set;}

        [Required]
        public string Cidade { get;set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cep { get; set; }

    }
}