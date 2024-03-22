using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSDC.Common.Configurations
{
    /// <summary>
    /// This class defines Database constants
    /// </summary>
    /// <remarks>
    /// The properties are self explanatory and can be changed as per requirement.
    /// </remarks>
    public class EF
    {
        public const string DatabaseName = Application.Abbreviation;
        public const string DatabaseSchema = Application.Abbreviation;
        public const string DatabaseServer = "DESKTOP-KV83HTN";
        public const string DatabaseUsername = "sa";
        public const string DatabasePassword = "Admin@2018";

        //public const string DatabaseServer = "3DTC121AX02087";
        //public const string DatabaseUsername = "mi10";
        //public const string DatabasePassword = "mi10";
    }
}
