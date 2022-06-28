using System;

namespace WebApplication1
{
    internal class ConfigurationManager
    {
        public static object ConnectionStrings { get; internal set; }

        internal static object ConnectionStrings(string v)
        {
            throw new NotImplementedException();
        }
    }
}