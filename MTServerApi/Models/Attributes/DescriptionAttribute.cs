namespace mtvendors_api.Models.Attributes
{
    public class DescriptionAttribute : Attribute
    {
        public string AdditionalInfo { get; set; }

        public DescriptionAttribute(string additionalInfo)
        {
            AdditionalInfo = additionalInfo;
        }
    }
}
