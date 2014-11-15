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
        private static string fileName = "settings.ini";

        private static Dictionary<string, string> DefaultValue = new Dictionary<string, string>(){
            { "DefaultSaveGameFile", "persistentgamedata1.dat" },
            { "CurrentHexEditorView", "Hex" },
            { "IconBrightness", "Little" },
            // put the default values here
        };

        static SettingManager () {
            if ( !File.Exists( fileName ) ) {
                //Assembly assembly = Assembly.GetExecutingAssembly();
                //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo( assembly.Location );
                //string version = fvi.FileVersion;

                string content = Application.ProductVersion + Environment.NewLine
                               + "!- Do no change the option from here -!" + Environment.NewLine
                               + Environment.NewLine;

                File.AppendAllText( fileName, content );

                foreach ( var item in DefaultValue ) {
                    WriteOption( item.Key, item.Value );

                }

            } else {
                // Check for the application version and update it 
                // if neccecary.
                // Check the validity of the options
                bool isSameVersion = true;
                List<string> lines = new List<string>();

                using ( StreamReader sr = new StreamReader( fileName ) ) {
                    string version = sr.ReadLine();
                    if ( version != Application.ProductVersion ) {
                        isSameVersion = false;
                        lines.Add( version );
                        while ( !sr.EndOfStream ) {
                            lines.Add( sr.ReadLine() );

                        }

                    }

                }

                if ( !isSameVersion ) {
                    using ( StreamWriter sw = new StreamWriter( fileName ) ) {
                        string content = Application.ProductVersion + Environment.NewLine
                               + "!- Do no change the option from here -!" + Environment.NewLine
                               + Environment.NewLine;

                        sw.Write( content );
                        for ( int i = 3; i < lines.Count; i++ ) {
                            sw.WriteLine( lines.ElementAt( i ) );

                        }

                    }

                }

            }

        }

        public static string ReadOption ( string OptionName ) {
            string line = string.Empty;
            string[] p;


            using ( StreamReader sr = new StreamReader( fileName ) ) {
                // Skip the first three lines
                line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine();

                while ( !sr.EndOfStream ) {
                    line = sr.ReadLine();
                    p = line.Split( new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries );
                    if ( p[0] == OptionName ) {
                        return p[1];

                    }

                }

                //sr.Close();
            }

            return DefaultValue[OptionName];

        }

        public static void WriteOption ( string OptionName, string OptionValue ) {
            List<string> Lines = new List<string>();
            string[] p;
            bool found = false;

            using ( StreamReader sr = new StreamReader( fileName ) ) {
                while ( !sr.EndOfStream ) {
                    Lines.Add( sr.ReadLine() );

                }

                //sr.Close();
            }

            using ( StreamWriter sw = new StreamWriter( fileName ) ) {
                sw.WriteLine( Lines.ElementAt( 0 ) );
                sw.WriteLine( Lines.ElementAt( 1 ) );
                sw.WriteLine( Lines.ElementAt( 2 ) );

                for ( int i = 3; i < Lines.Count; i++ ) {
                    p = Lines.ElementAt( i ).Split( new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries );
                    if ( p[0] == OptionName ) {
                        sw.WriteLine( p[0] + "=" + OptionValue );
                        found = true;

                    } else {
                        sw.WriteLine( p[0] + "=" + p[1] );

                    }

                }

                if ( !found ) {
                    sw.WriteLine( OptionName + "=" + OptionValue );

                }
                //sw.Close();
            }


        }

        public static void initialize () {
            return;
        }

    }
}
