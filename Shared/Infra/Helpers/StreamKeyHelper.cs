namespace Shared.Infra.Helpers
{
    public static class StreamKeyHelper
    {
        public static string GenerateStreamKey()
        {
            using var aesAlgorithm = System.Security.Cryptography.Aes.Create();
            aesAlgorithm.KeySize = 256;
            aesAlgorithm.GenerateKey();
            return Convert.ToBase64String(aesAlgorithm.Key);
        }
    }
}
