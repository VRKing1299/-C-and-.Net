using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HelperLib
{
    /// <summary>
    /// this is static helper class 
    /// - has a static method for logging validation and conversion
    /// </summary>
    public static class Helper
    {
        //this is static logging method
        public static string Logging()
        {
            return "this is logging method being called";
        }

        //this is static validation method
        public static string Validation()
        {
            return "this is validation method called ";
        }

        //this is static conversion method
        public static string Conversion()
        {
            return "this is conversion method being called ";
        }
    }
}
