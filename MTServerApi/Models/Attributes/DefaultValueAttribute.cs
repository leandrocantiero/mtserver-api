namespace mtvendors_api.Models.Attributes
{
    public class DefaultValueAttribute : Attribute
    {
        public string AdditionalInfo { get; set; }

        public DefaultValueAttribute(string additionalInfo)
        {
            AdditionalInfo = additionalInfo;
        }
    }
}
