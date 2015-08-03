namespace NArms.WonderPrint.TypePrinters
{
    public class StringTypePrinter : TypePrinterBase<string>
    {
        protected override string Format(string value)
        {
            return $"\"{value}\"";
        }
    }
}