namespace Shared.Infra.Helpers
{
    public static class PrimaryKeyHelper
    {
        public static Guid ValidateIdGetGuid(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (Guid.TryParse(id, out var guid))
            {
                return guid;
            }
            else
            {
                throw new InvalidCastException(nameof(id));
            }
        }
    }
}
