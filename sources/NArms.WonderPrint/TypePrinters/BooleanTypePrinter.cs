namespace NArms.WonderPrint.TypePrinters
{
    public class BooleanTypePrinter : TypePrinterBase<bool>
    {
        protected override string Format(bool value)
        {
            return value.ToString();
        }
    }
}