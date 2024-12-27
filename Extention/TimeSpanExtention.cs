namespace Tabu.Extention
{
    public static class TimeSpanExtention
    {
        private static readonly int ChacheDurationInSecound = 300;
        public static TimeSpan GetChacheDuration()
        {
            return TimeSpan.FromSeconds(ChacheDurationInSecound);
        }
    }
}
