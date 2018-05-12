using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Application.ViewModel
{
    /// <summary>
    /// Esta classe servirá para colher os
    /// parâmetros da tela de consulta de clientes
    /// </summary>
    public class ClienteIndexViewModel
    {
        [DisplayName("Nome:")]
        public string Nome { get; set; }
    }

    /// <summary>
    /// Esta classe servirá para listar os clientes
    /// na tela de consulta de clientes.
    /// </summary>
    public class ClienteIndexListViewModel
    {
        public int ClienteId { get; set; }
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        [DisplayName("Nome Fantasia:")]
        public string NomeFantasia { get; set; }
        [DisplayName("CNPJ:")]
        public string CNPJ { get; set; }
    }

    public class ClienteCreateViewModel
    {
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        [DisplayName("Nome Fantasia:")]
        public string NomeFantasia { get; set; }
        [DisplayName("CNPJ:")]
        public string CNPJ { get; set; }
    }

    public class ClienteEditViewModel
    {
        public int ClienteId { get; set; }
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        [DisplayName("Nome Fantasia:")]
        public string NomeFantasia { get; set; }
        [DisplayName("CNPJ:")]
        public string CNPJ { get; set; }
    }

    public class ClienteDeleteViewModel
    {
        public int ClienteId { get; set; }
        [DisplayName("Nome:")]
        public string Nome { get; set; }
    }
}

