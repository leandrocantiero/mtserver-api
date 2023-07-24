namespace mtvendors_api.Models.Helpers
{
    public class Schema
    {
        public string Name { get; set; } = "";
        public List<Table> Tables { get; set; } = new List<Table>();
    }

    public class Table
    {
        public string Name { get; set; } = "";
        public List<Column> Columns { get; set; } = new List<Column>();
    }

    public class Column
    {
        public bool isPrimary { get; set; } = false;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public int Size { get; set; }
        public int Precision { get; set; } = 0;
        public string DefaultValue { get; set; } = string.Empty;
    }
}
