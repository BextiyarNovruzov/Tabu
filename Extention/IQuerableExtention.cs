namespace Tabu.Extention
{
	public static class IQuerableExtention
	{
		public static IQueryable<T> Random<T>(this IQueryable<T> query,int randomNumber)
		{
			Random random = new Random();
			int num = random.Next(0, randomNumber);
			return query.Skip(num);
		}
	}
}
