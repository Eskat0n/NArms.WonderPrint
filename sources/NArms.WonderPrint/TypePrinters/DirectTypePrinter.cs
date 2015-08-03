namespace NArms.WonderPrint.TypePrinters
{
    public class DirectTypePrinter : ITypePrinter
    {
        public string Format(object value)
        {
            return value.ToString();
        }
    }
}