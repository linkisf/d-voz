namespace D_Voz1.Models
{
    public class AcompanharDenunciaModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public long RG { get; set; }
        public string Email { get; set; }
        public long CPF { get; set; }
        public string LocalDaDenuncia { get; set; }
        public string LocalDoOcorrido { get; set; }
        public int CEP { get; set; }
        public string TipoDenuncia { get; set; }
        public string[] Anexos { get; set; }
        public string DescricaoDenuncia { get; set; }
    }

}
