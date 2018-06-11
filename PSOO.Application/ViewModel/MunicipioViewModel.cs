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
    /// parâmetros da tela de consulta de Municipios
    /// </summary>
    public class MunicipioIndexViewModel
    {
        [DisplayName("Nome:")]
        public string Nome { get; set; }
    }

    /// <summary>
    /// Esta classe servirá para listar os Municipios
    /// na tela de consulta de Municipios.
    /// </summary>
    public class MunicipioIndexListViewModel
    { 
        public int MunicipioId { get; set; }
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        [DisplayName("Codigo IBGE:")]
        public string CodigoIBGE { get; set; }
        [DisplayName("UF:")]
        public string SiglaUF { get; set; }
        [DisplayName("Codigo IBGE UF:")]
        public string CodigoIBGEUF { get; set; }
        [DisplayName("Pais:")]
        public string NomePais { get; set; }
        [DisplayName("Codigo Pais BACEN:")]
        public string CodigoPaisBACEN { get; set; }
    }

    public class MunicipioCreateViewModel
    {
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        [DisplayName("Codigo IBGE:")]
        public string CodigoIBGE { get; set; }
        [DisplayName("UF:")]
        public string SiglaUF { get; set; }
        [DisplayName("Codigo IBGE UF:")]
        public string CodigoIBGEUF { get; set; }
        [DisplayName("Pais:")]
        public string NomePais { get; set; }
        [DisplayName("Codigo Pais BACEN:")]
        public string CodigoPaisBACEN { get; set; }
    }

    public class MunicipioEditViewModel
    {
        public int MunicipioId { get; set; }
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        [DisplayName("Codigo IBGE:")]
        public string CodigoIBGE { get; set; }
        [DisplayName("UF:")]
        public string SiglaUF { get; set; }
        [DisplayName("Codigo IBGE UF:")]
        public string CodigoIBGEUF { get; set; }
        [DisplayName("Pais:")]
        public string NomePais { get; set; }
        [DisplayName("Codigo Pais BACEN:")]
        public string CodigoPaisBACEN { get; set; }
    }

    public class MunicipioDeleteViewModel
    {
        public int MunicipioId { get; set; }
        [DisplayName("Nome:")]
        public string Nome { get; set; }
    }
}

