using System.Text;

/// Reference: https://en.wikipedia.org/wiki/Fowler%E2%80%93Noll%E2%80%93Vo_hash_function

namespace Blackboard
{
    public class FNV1a
    {
        const int prime = 0x1000193;
        const int offsetBasis = unchecked((int)0x811c9dc5);

        public static int Compute(string str)
        {
            if (str == null)
            {
                throw new System.ArgumentNullException(nameof(str));
            }

            var hash = offsetBasis;
            byte[] bytes = Encoding.UTF8.GetBytes(str);

            foreach (var b in bytes )
            {
                hash ^= b;
                hash *= prime;
            }

            return unchecked((int)hash);
        }
    }
}
