using mtvendors_api.Models.Attributes;
using mtvendors_api.Models.DAO;
using System.Reflection;

namespace mtvendors_api.Models.Helpers
{
    public static class DBConverter
    {
        public static Schema GetDatabaseSchema()
        {
            Schema schema = new Schema();
            schema.Name = "mtvendorsdb";

            schema.Tables.Add(GetTableSchema(typeof(Cidade)));

            return schema;
        }

        private static Table GetTableSchema(Type type)
        {
            Table table = new Table();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                var keyAttribute = (System.ComponentModel.DataAnnotations.KeyAttribute)Attribute.GetCustomAttribute(prop, typeof(System.ComponentModel.DataAnnotations.KeyAttribute));
                var columnAttribute = (System.ComponentModel.DataAnnotations.Schema.ColumnAttribute)Attribute.GetCustomAttribute(prop, typeof(System.ComponentModel.DataAnnotations.Schema.ColumnAttribute));
                var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute));
                var sizeAttribute = (SizeAttribute)Attribute.GetCustomAttribute(prop, typeof(SizeAttribute));
                var precisionAttribute = (SizeAttribute)Attribute.GetCustomAttribute(prop, typeof(SizeAttribute));
                var defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(prop, typeof(DefaultValueAttribute));

                Column column = new Column();
                column.isPrimary = keyAttribute != null;
                column.Name = columnAttribute.Name;
                column.Description = descriptionAttribute.AdditionalInfo;
                column.Type = ColumnTypeConverter(columnAttribute.TypeName != null ? columnAttribute.TypeName : prop.PropertyType.Name);
                column.Size = sizeAttribute != null ? sizeAttribute.AdditionalInfo : 255;
                column.Precision = precisionAttribute != null ? precisionAttribute.AdditionalInfo : 0;
                column.DefaultValue = defaultValueAttribute != null ? defaultValueAttribute.AdditionalInfo : "";
                table.Columns.Add(column);
            }

            return table;
        }

        private static string ColumnTypeConverter(string v)
        {
            switch (v)
            {
                case "Int64":
                case "Int32":
                    return "INTEGER";
                case "Float":
                case "Double":
                    return "REAL";
                case "String":
                    return "TEXT";
                case "Date":
                    return "DATE";
                case "DateTime":
                    return "DATETIME";
                case "Boolean":
                    return "BOOLEAN";
                default:
                    return v;
            }
        }
    }
}
