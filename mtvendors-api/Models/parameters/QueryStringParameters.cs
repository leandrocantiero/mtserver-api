namespace mtvendors_api.Models.parameters
{
    public class QueryStringParameters
    {
        public int PageNumber { get; set; } = 1;

        public string Sort { get; set; } = "asc";

        public string OrderBy { get; set; } = "";

        public int PageSize { get; set; } = 100;

    }
}
