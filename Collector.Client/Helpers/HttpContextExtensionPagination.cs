namespace Collector.Client.Helpers
{
    public static class HttpContextExtensionPagination
    {
        public static void InsertParametersPagination<T>(this HttpContext context,
            IQueryable<T> queryable , int amountOfInfo)
        {
            if(context  == null)
            {
               throw new ArgumentNullException(nameof(context));
            }

            double count = queryable.Count();
            double totalPages = Math.Ceiling(count / amountOfInfo);
            context.Response.Headers.Append("TotalPages", totalPages.ToString());
        }
    }
}
