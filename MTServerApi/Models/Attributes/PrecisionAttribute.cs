namespace mtvendors_api.Models.Attributes
{
    public class PrecisionAttribute : Attribute
    {
        public int AdditionalInfo { get; set; }

        public PrecisionAttribute(int additionalInfo)
        {
            AdditionalInfo = additionalInfo;
        }
    }
}
