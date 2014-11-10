using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace BindingOfIsaacRebirthSaveGameParser {
    public static class SettingManager {
        public static StreamReader sr;
        public static StreamWriter sw;
        private static string fileName = "setting.ini";
        private static string content = string.Empty;

        private static Dictionary<string, string> DefaultValue = new Dictionary<string, string>(){
            {"",""}
            // put the default values here
        };

        private static Dictionary<string, string> OptionValues = new Dictionary<string, string>();


        static SettingManager () {
            if ( !File.Exists( fileName ) ) {
                File.Create( fileName );

                //Assembly assembly = Assembly.GetExecutingAssembly();
                //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo( assembly.Location );
                //string version = fvi.FileVersion;

                content = Application.ProductVersion + Environment.NewLine
                        + "!- Do no change the option from here -!" + Environment.NewLine
                        + Environment.NewLine;

                File.AppendAllText( fileName, content );

            } else {
                // Check for the application version and update it 
                // if neccecary.
                // Check the validity of the options


            }

        }

    }
}
