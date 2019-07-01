namespace MiniWebERP.Data.Common.Models
{
    public interface ICatalogEntity<TKey>
    {
        TKey Id { get; set; }

        string Name { get; set; }
    }
}
