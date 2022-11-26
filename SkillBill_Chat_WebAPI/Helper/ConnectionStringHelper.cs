using System.Text.RegularExpressions;

namespace SkillBill_Chat_WebAPI.Helper
{
    public class ConnectionStringHelper
    {
        public static string GetRootPath(string rootFilename)
        {
            string _root;
            var rootDir = System.IO.Path.GetDirectoryName(
                      System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex matchThepath = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = matchThepath.Match(rootDir).Value;
            _root = Path.Combine(appRoot, rootFilename);

            return _root;
        }
        public static IConfiguration GetConfig()
        {
            var config = (IConfiguration)new ConfigurationBuilder().AddJsonFile(GetRootPath("Databasesettings.json")).Build();

            return config;
        }

    }
}
