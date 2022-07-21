namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IFinanceExtensions
    {
        public static T SetOpen<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.SetOpen(new NumberDataField(field));
        }

        public static T SetOpen<T>(this T visualization, NumberDataField field)
            where T : IFinance
        {
            visualization.Opens.Clear();
            
            if (field.Formatting is null)
                field.Formatting = GetFinancialNumberFormatting();

            visualization.Opens.Add(new MeasureColumn()
            {
                DataField = field
            });
            return visualization;
        }

        public static T SetHigh<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.SetHigh(new NumberDataField(field));
        }

        public static T SetHigh<T>(this T visualization, NumberDataField field)
            where T : IFinance
        {
            visualization.Highs.Clear();
            
            if (field.Formatting is null)
                field.Formatting = GetFinancialNumberFormatting();

            visualization.Highs.Add(new MeasureColumn()
            {
                DataField = field
            });
            return visualization;
        }

        public static T SetLow<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.SetLow(new NumberDataField(field));
        }

        public static T SetLow<T>(this T visualization, NumberDataField field)
            where T : IFinance
        {
            visualization.Lows.Clear();
            
            if (field.Formatting is null)
                field.Formatting = GetFinancialNumberFormatting();

            visualization.Lows.Add(new MeasureColumn()
            {
                DataField = field
            });
            return visualization;
        }

        public static T SetClose<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.SetClose(new NumberDataField(field));
        }

        public static T SetClose<T>(this T visualization, NumberDataField field)
            where T : IFinance
        {
            visualization.Closes.Clear();
            
            if (field.Formatting is null)
                field.Formatting = GetFinancialNumberFormatting();

            visualization.Closes.Add(new MeasureColumn()
            {
                DataField = field
            });
            return visualization;
        }

        static NumberFormattingSpec GetFinancialNumberFormatting()
        {
            return new NumberFormattingSpec()
            {
                DecimalDigits = 0,
                ShowGroupingSeparator = true
            };
        }
    }
}
