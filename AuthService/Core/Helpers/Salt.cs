namespace AuthService.Core.Helpers
{
    public static class Salt
    {
        public static string ToSha512(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException($"invalid value for {input}");

            var bytes = System.Text.Encoding.UTF8.GetBytes(input);

            using var hash = System.Security.Cryptography.SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new System.Text.StringBuilder(128);

            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));

            return hashedInputStringBuilder.ToString().ToLower();
        }
    }
}
