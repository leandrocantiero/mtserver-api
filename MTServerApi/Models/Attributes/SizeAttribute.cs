namespace mtvendors_api.Models.Attributes
{
    public class SizeAttribute : Attribute
    {
        public int AdditionalInfo { get; set; }

        public SizeAttribute(int additionalInfo)
        {
            AdditionalInfo = additionalInfo;
        }
    }
}
