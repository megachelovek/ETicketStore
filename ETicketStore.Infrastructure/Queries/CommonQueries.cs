namespace ETicketStore.Domain.Queries
{
    public class CommonQueries
    {
        public static string SelectAll(string table) => $"SELECT * FROM public.{table}";

        public static string SelectItem(string table, string id) => $"SELECT * FROM public.{table} WHERE Id=\"{id}\"";

        public static string CountAsync(string table) => $"SELECT COUNT(*) FROM public.{table}";

    }
}
