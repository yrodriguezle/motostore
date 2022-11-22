namespace MOTOSTORE.Helpers
{
    public static class UtilityHelper
    {
        public static object NormalizeDateTime(object date)
        {
            if (date != null && date.GetType() == typeof(DateTime) && (Convert.ToDateTime(date).Year == 1899 || Convert.ToDateTime(date).Year == 1900))
            {
                date = null;
            }
            return date;
        }
    }
}
