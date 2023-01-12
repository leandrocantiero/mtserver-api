namespace mtvendors_api.Models.parameters
{
    public class ProdutoParameters : QueryStringParameters
    {
        public string? Descricao { get; set; }

        public string? FkFamilia { get; set; }

        public string? FkUnidadeMedida { get; set; }

        public int? FkGrade1 { get; set; }

        public int? FkGrade2 { get; set; }

        public int? FkGrade3 { get; set; }
    }
}
