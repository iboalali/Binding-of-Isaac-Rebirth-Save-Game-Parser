using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingOfIsaacRebirthSaveGameParser {
    public static class StatLocation {

        public struct Location {
            public int From;
            public int To;
            public string Name;

        }

        public static List<Location> locations;
        private static string LocationFileName { get; set; }
        private static StreamReader sr;

        /// <summary>
        /// Default content, if the file was deleted or moved.
        /// </summary>
        private static string content = 
@"Deaths|259|259
All kinds of Rocks, Mushrooms, Skulls and Urns|231|232
All kinds of Poops|239|240
Coins in the Donation Machine|299|300
Number of Accesses to the Save Game|1251|1252
";

        static StatLocation () {
            locations = new List<Location>();
            LocationFileName = "data";
            Initialize();
        }

        public static void Initialize () {
            try {
                sr = new StreamReader( LocationFileName );

            } catch ( Exception ) {
                File.AppendAllText( LocationFileName, content );
                sr = new StreamReader( LocationFileName );
            }

            string sc = sr.ReadToEnd();
            sr.Close();
            string[] st = sc.Split( new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries );

            Location l;
            for ( int i = 0; i < st.Length; i++ ) {
                l = new Location();
                string[] s = st[i].Split( new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries );
                l.Name = s[0];
                l.From = int.Parse( s[1] );
                l.To = int.Parse( s[2] );
                locations.Add( l );
            }

        }

        public static bool ContainsLocation ( int location ) {

            if ( GetLocation_Name( location ) == string.Empty ) {
                return false;
            }

            return true;

        }

        public static int GetLocation_From ( string name ) {
            foreach ( var item in locations ) {
                if ( item.Name == name ) {
                    return item.From;
                }
            }

            return -1;

        }

        public static int GetLocation_To ( string name ) {
            foreach ( var item in locations ) {
                if ( item.Name == name ) {
                    return item.To;
                }
            }

            return -1;

        }

        public static string GetLocation_Name ( int FromOrTo ) {
            foreach ( var item in locations ) {
                if ( ( item.From == FromOrTo ) || ( item.To == FromOrTo ) ) {
                    return item.Name;
                }

            }

            return string.Empty;

        }

        public static void AddNewLocation ( StatLocation.Location location ) {
            locations.Add( CloneLocation( location ) );
            using ( StreamWriter sw = new StreamWriter( LocationFileName, true ) ) {
                sw.WriteLine( location.Name + "|" + location.From + "|" + location.To );

            }
        }

        public static void UpdateLocation ( string oldName, StatLocation.Location location ) {

            for ( int i = 0; i < locations.Count; i++ ) {
                if ( locations[i].Name == oldName ) {
                    locations[i] = CloneLocation( location );

                }

            }

            using ( StreamWriter sw = new StreamWriter( LocationFileName, false ) ) {
                foreach ( var item in locations ) {
                    sw.WriteLine( item.Name + "|" + item.From + "|" + item.To );

                }

            }

        }

        public static void RemoveLocation ( string name ) {
            for ( int i = 0; i < locations.Count; i++ ) {
                if ( locations[i].Name == name ) {
                    locations.RemoveAt( i );
                    break;

                }

            }

            using ( StreamWriter sw = new StreamWriter( LocationFileName, false ) ) {
                foreach ( var item in locations ) {
                    sw.WriteLine( item.Name + "|" + item.From + "|" + item.To );

                }

            }


        }

        public static Location CloneLocation ( Location location ) {
            Location l = new Location();
            l.Name = location.Name;
            l.From = location.From;
            l.To = location.To;

            return l;

        }

        public static long GetValueFromSaveGame ( byte[] saveGame, int locationFrom, int locationTo ) {
            long value = 0;
            for ( int i = locationFrom, j = 0; i <= locationTo; i++, j += 2 ) {
                value += saveGame[i] * ( long ) Math.Pow( 16, j );

            }

            return value;

        }

        public static long GetValue ( byte[] saveGame, int location ) {
            string name = GetLocation_Name( location );
            return GetValueFromSaveGame( saveGame, GetLocation_From( name ), GetLocation_To( name ) );

        }

        public static int GetNumberOfByteMinusOne ( int location ) {
            string name = GetLocation_Name( location );
            return GetLocation_To( name ) - GetLocation_From( name );


        }
    }
}
