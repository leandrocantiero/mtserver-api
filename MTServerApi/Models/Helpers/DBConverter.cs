using mtvendors_api.Models.Attributes;
using mtvendors_api.Models.DAO;
using System.Reflection;

namespace mtvendors_api.Models.Helpers
{
    public static class DBConverter
    {
        public static Schema GetDatabaseSchema(string databaseName)
        {
            Schema schema = new Schema();
            schema.Name = databaseName;

            schema.Tables.Add(GetTableSchema(typeof(AgendaVisita)));
            schema.Tables.Add(GetTableSchema(typeof(Cidade)));

            return schema;
        }

        private static Table GetTableSchema(Type type)
        {
            var tableAttribute = Attribute.GetCustomAttribute(type, typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute)) as System.ComponentModel.DataAnnotations.Schema.TableAttribute;

            Table table = new Table { Name = tableAttribute.Name };
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                var keyAttribute = Attribute.GetCustomAttribute(prop, typeof(System.ComponentModel.DataAnnotations.KeyAttribute)) as System.ComponentModel.DataAnnotations.KeyAttribute;
                var columnAttribute = Attribute.GetCustomAttribute(prop, typeof(System.ComponentModel.DataAnnotations.Schema.ColumnAttribute)) as System.ComponentModel.DataAnnotations.Schema.ColumnAttribute;
                // var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute));
                var sizeAttribute = Attribute.GetCustomAttribute(prop, typeof(SizeAttribute)) as SizeAttribute;
                var precisionAttribute = Attribute.GetCustomAttribute(prop, typeof(SizeAttribute)) as SizeAttribute;
                var defaultValueAttribute = Attribute.GetCustomAttribute(prop, typeof(DefaultValueAttribute)) as DefaultValueAttribute;

                Column column = new()
                {
                    isPrimary = keyAttribute != null,
                    Name = columnAttribute.Name,
                    // Description = descriptionAttribute.AdditionalInfo,
                    Type = ColumnTypeConverter(columnAttribute.TypeName != null ? columnAttribute.TypeName : prop.PropertyType.Name),
                    Size = sizeAttribute != null ? sizeAttribute.AdditionalInfo : 255,
                    Precision = precisionAttribute != null ? precisionAttribute.AdditionalInfo : 0,
                    DefaultValue = defaultValueAttribute != null ? defaultValueAttribute.AdditionalInfo : ""
                };

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
