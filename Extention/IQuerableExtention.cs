namespace Tabu.Extention
{
	public static class IQuerableExtention
	{
		private static readonly Random random = new Random();
		public static IQueryable<T> Random<T>(this IQueryable<T> query,int randomNumber)
		{
			int num = random.Next(0,randomNumber);
			return query.Skip(num);
		}
	}
}
