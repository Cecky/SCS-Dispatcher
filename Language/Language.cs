using CustomForms;
using HashFS;
using Newtonsoft.Json;
using Scs.SaveGame;
using ScsDispatcher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Language
{
    public enum BuildResult
    {
        Success,
        FileNotFound,
        FileNotValid
    }
    public enum FileType
    {
        ScsC,
        SiiN,
        BSII,
        _3nK,
        ScsHash,
        Err
    };

    public class LanguageGenerator
    {
        /// <summary>
        /// Extract all translations from cities, companies and cargos and generate all translationfiles in the appfolder
        /// </summary>
        /// <param name="Folder">Basefolder where the gamefiles are located</param>
        /// <param name="GameID">ETS or ATS</param>
        /// <returns>Result of buildprocess</returns>
        public static BuildResult Build(string Folder, ScsDictionary.GameID GameID)
        {
            CustomMessageBox frmMessage = new CustomMessageBox("Generator", "Bitte warten...");
            string tmp;

            frmMessage.Show();
            Application.DoEvents();

            // Load data
            ScsDictionary scsDictionary = GetBaseData(Folder, GameID);
            List<string> HashfileData = GetHashfiles(Folder);

            // Generate translation for cities (only ETS)
            Dictionary<string, string> FinalCityTranslation = new Dictionary<string, string>();
            if (GameID == ScsDictionary.GameID.ETS)
            {
                Dictionary<string, string> CityTranslation = BuildTranslation(HashfileData, @"#+ Names of cities");
                foreach (KeyValuePair<string, string> Item in scsDictionary.Cities)
                {
                    CityTranslation.TryGetValue(Item.Value, out tmp);
                    if (tmp != null)
                        FinalCityTranslation.Add(Item.Key, tmp);
                }
                WriteToFileJSON(FinalCityTranslation, AppContext.BaseDirectory + Resources.LanguageCitiesETS);
            }
            else
            {
                // There are nor translations for citynames in ATS.
                // Just use the basedictionary
                WriteToFileJSON(scsDictionary.Cities, AppContext.BaseDirectory + Resources.LanguageCitiesATS);
            }

            // Generate translation for cargos
            Dictionary<string, string> CargoTranslation = BuildTranslation(HashfileData, @"#+ Names of individual cargos.");
            Dictionary<string, string> FinalCargoTranslation = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> Item in scsDictionary.Cargo)
            {
                CargoTranslation.TryGetValue(Item.Value, out tmp);
                if (tmp != null)
                    FinalCargoTranslation.Add(Item.Key, tmp);
            }
            if (GameID == ScsDictionary.GameID.ETS)
                WriteToFileJSON(FinalCargoTranslation, AppContext.BaseDirectory + Resources.LanguageCargosETS);
            else
                WriteToFileJSON(FinalCargoTranslation, AppContext.BaseDirectory + Resources.LanguageCargosATS);

            // Generate companies (no translation here)
            if (GameID == ScsDictionary.GameID.ETS)
                WriteToFileJSON(scsDictionary.Companies, AppContext.BaseDirectory + Resources.LanguageCompaniesETS);
            else
                WriteToFileJSON(scsDictionary.Companies, AppContext.BaseDirectory + Resources.LanguageCompaniesATS);

            // Generate countrynames and/or states (no translation here)
            if (GameID == ScsDictionary.GameID.ETS)
                WriteToFileJSON(scsDictionary.Countries_States, AppContext.BaseDirectory + Resources.LanguageCountriesETS);
            else
                WriteToFileJSON(scsDictionary.Countries_States, AppContext.BaseDirectory + Resources.LanguageStatesATS);

            frmMessage.Close();
            return BuildResult.Success;
        }
        /// <summary>
        /// Parse all gamefiles and collect all names of cities, companies and cargos.
        /// This includes all DLCs
        /// </summary>
        /// <param name="Folder">Basefolder where the gamefiles are located</param>
        /// <param name="GameID">ETS or ATS</param>
        /// <returns></returns>
        private static ScsDictionary GetBaseData(string Folder, ScsDictionary.GameID GameID)
        {
            ScsDictionary scsDictionary = new ScsDictionary
            {
                GameId = GameID
            };

            DirectoryInfo di = new DirectoryInfo(Folder);

            foreach (FileInfo file in di.GetFiles("*.scs"))
            {
                bool FoundCityHash = false;
                bool FoundCargoHash = false;
                bool FoundCompanyHash = false;

                if (file.Name == "locale.scs")
                    continue;

                IHashFsReader reader = HashFsReader.Open(file.FullName);

                // Locate header of searched file. Open and decode the file
                try
                {
                    if (reader.EntryExists(@"def/city") == EntryType.Directory)
                        FoundCityHash = true;
                }
                catch
                { }
                if (FoundCityHash)
                {
                    (List<string> SubDirs, List<string> Dateiliste) = reader.GetDirectoryListing("def/city", true, true);
                    // parse all cities
                    foreach (string Datei in Dateiliste)
                    {
                        List<string> CityDataArray = Encoding.ASCII.GetString(reader.Extract(Datei)).Split('\n').ToList<string>();
                        string strCity, strLocalized, strCountryState;

                        strCity = CityDataArray.Where(x => x.Contains("city.")).First();
                        strCity = StringRemove(strCity, new string[] { "\t", "\"", ":", "city_data", "city." });
                        strCity = strCity.Trim();

                        if (GameID == ScsDictionary.GameID.ETS)
                        {
                            strLocalized = CityDataArray.Where(x => x.Contains("city_name_localized")).First();
                            strLocalized = StringRemove(strLocalized, new string[] { "\t", "\"", ":", "@", "city_name_localized" });
                        }
                        else
                        {
                            strLocalized = CityDataArray.Where(x => x.Contains("city_name:")).First();
                            strLocalized = StringRemove(strLocalized, new string[] { "\t", "\"", ":", "@", "city_name" });
                        }
                        strLocalized = strLocalized.Trim();

                        strCountryState = CityDataArray.Where(x => x.Contains("country:")).First();
                        strCountryState = StringRemove(strCountryState, new string[] { "\t", "\"", ":", "@", "country" });
                        strCountryState = strCountryState.Trim();

                        scsDictionary.Cities.Add(strCity, strLocalized);
                        scsDictionary.Countries_States.Add(strCity, strCountryState);
                    }
                }

                try
                {
                    if (reader.EntryExists(@"def/cargo") == EntryType.Directory)
                        FoundCargoHash = true;
                }
                catch
                { }
                if (FoundCargoHash)
                {
                    (List<string> SubDirs, List<string> Dateiliste) = reader.GetDirectoryListing("def/cargo", true, true);

                    // parse all cargos
                    foreach (string Datei in Dateiliste)
                    {
                        List<string> CityDataArray = Encoding.ASCII.GetString(reader.Extract(Datei)).Split('\n').ToList<string>();
                        string strCity = CityDataArray.Where(x => x.Contains("cargo.")).First();
                        string strLocalized = CityDataArray.Where(x => x.Contains("name")).First();
                        // format data
                        strCity = StringRemove(strCity, new string[] { "\t", "\"", ":", "cargo_data", "cargo." });
                        strCity = strCity.Trim();

                        strLocalized = StringRemove(strLocalized, new string[] { "\t", "\"", ":", "@", "name" });
                        strLocalized = strLocalized.Trim();

                        scsDictionary.Cargo.Add(strCity, strLocalized);
                    }
                }

                try
                {
                    if (reader.EntryExists(@"def/company") == EntryType.Directory)
                        FoundCompanyHash = true;
                }
                catch
                { }
                if (FoundCompanyHash)
                {
                    (List<string> SubDirs, List<string> Dateiliste) = reader.GetDirectoryListing("def/company", true, true);
                    
                    // parse all compannies
                    foreach (string Datei in Dateiliste)
                    {
                        List<string> CityDataArray = Encoding.ASCII.GetString(reader.Extract(Datei)).Split('\n').ToList<string>();
                        string strCity = CityDataArray.Where(x => x.Contains("company.permanent.")).First();
                        string strLocalized = CityDataArray.Where(x => x.Contains("name")).First();
                        // format data
                        strCity = StringRemove(strCity, new string[] { "\t", "\"", ":", "@", "company_permanent", "company.permanent." });
                        strCity = strCity.Trim();

                        strLocalized = StringRemove(strLocalized, new string[] { "\t", "\"", ":", "@", "name" });
                        strLocalized = strLocalized.Trim();

                        scsDictionary.Companies.Add(strCity, strLocalized);
                    }
                }
            }
            return scsDictionary;
        }
        /// <summary>
        /// Read the hashfiles "localse.sii" and "local.override.sii" from file "locale.scs"
        /// </summary>
        /// <param name="Folder">Basefolder where the gamefiles are located</param>
        /// <returns>Content of the hashfiles</returns>
        private static List<string> GetHashfiles(string Folder)
        {
            return ReadHashFile(Folder, "localization.sui", "local.sii", "local.override.sii");
        }
        /// <summary>
        /// Open "locale.scs" in basegamefolder and extract the hasfiles
        /// </summary>
        /// <param name="GamePath">Basefolder of the game</param>
        /// <param name="FileNames">List of hashfilenames to extract</param>
        /// <returns></returns>
        private static List<string> ReadHashFile(string GamePath, params string[] FileNames)
        {
            // We want to open the file "locale.scs", unpack the folder "de_de" (in my case "German") and decode the files
            // "local.sii", "local.override.sii" and "localization.sui"
            List<string> retval = new List<string>();
            IHashFsReader reader = HashFsReader.Open(GamePath + "/locale.scs");

            // Locate header of searched file. Open and decode the file
            foreach (var item in FileNames)
            {
                try
                {
                    retval.Add(Encoding.UTF8.GetString(reader.Extract("locale/de_de/" + item)));
                }
                catch { }
            }
            return retval;
        }
        /// <summary>
        /// Parse the hashfiles, find the specified datablocks and generate a translationdictionary
        /// </summary>
        /// <param name="Hashfiles"></param>
        /// <param name="Key"></param>
        /// <returns>Dictionary that contains a trtanslation</returns>
        private static Dictionary<string,string> BuildTranslation(List<string> Hashfiles, string Key)
        {
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();

            foreach(var Hashfile in Hashfiles)
            {
                int IndexStart = Hashfile.IndexOf(Key);
                if (IndexStart == -1)
                    continue;
                IndexStart = Hashfile.IndexOf("{", IndexStart);
                int IndexEnd = Hashfile.IndexOf("}", IndexStart);
                string Block = Hashfile.Substring(IndexStart, IndexEnd - IndexStart).Replace("\n\n", "\r");
                List<string> BlockElements = Block.Split('\r').ToList<string>();
                BlockElements.RemoveAt(0);
                BlockElements.RemoveAt(BlockElements.Count - 1);

                foreach (string Item in BlockElements)
                {
                    string tmp = Item.Replace("\"", "");
                    tmp = tmp.Replace("\tkey[]: ", "");
                    tmp = tmp.Replace("\tval[]: ", "");
                    string[] tmpArr = tmp.Split('\n');
                    if (!Dictionary.ContainsKey(tmpArr[0]))
                        Dictionary.Add(tmpArr[0], tmpArr[1]);
                }
            }
            return Dictionary;
        }

        #region JSON
        public static void WriteToFileJSON(Dictionary<string, string> dictionary, string path)
        {
            if(!Directory.Exists(Path.GetDirectoryName(path))) 
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, JsonConvert.SerializeObject(dictionary, Formatting.Indented));
        }
        public static Dictionary<string,string> ReadFromFileJSON(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private static string StringRemove(string Input, string[] characters)
        {
            string retval = Input;
            foreach (string s in characters)
            {
                retval = retval.Replace(s, "");
            }
            return retval;
        }
        private static FileType GetFileType(byte[] data)
        {
            UInt32 Signature = BitConverter.ToUInt32(data, 0);

            switch (Signature)
            {
                case 0x43736353:    //"ScsC"
                    return FileType.ScsC;
                case 0x4e696953:    //"SiiN"
                    return FileType.SiiN;
                case 0x49495342:    //"BSII"
                    return FileType.BSII;
                case 0x014b6e33:    //"3nK#01"
                    return FileType._3nK;
                case 0x23534353:    //SCS#
                    return FileType.ScsHash;
            }
            return FileType.Err;
        }
    }
    public class ScsDictionary
    {
        public enum GameID
        {
            ETS,
            ATS
        }
        public Dictionary<string, string> Cities { get; set; }
        public Dictionary<string, string> Companies { get; set; }
        public Dictionary<string, string> Cargo { get; set; }
        public Dictionary<string, string> Countries_States { get; set; }
        public GameID GameId { get; set; }

        #region Constructor
        public ScsDictionary()
        {
            GameId = GameID.ETS;
            Cities = new Dictionary<string, string>();
            Companies = new Dictionary<string, string>();
            Cargo = new Dictionary<string, string>();
            Countries_States = new Dictionary<string, string>();
        }
        #endregion

        #region Methods
        public bool Update()
        {
            // defaults to ETS
            return Update(GameID.ATS);
        }
        public bool Update(GameID Game)
        {
            try
            {
                if (Game == GameID.ETS)
                {
                    Cities = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCitiesETS);
                    Cargo = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCargosETS);
                    Dictionary<string, string> CargoUser = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCargosUserETS);
                    if (CargoUser != null)
                    {
                        foreach (var item in CargoUser)
                        {
                            Cargo.Add(item.Key, item.Value);
                        }
                    }
                    foreach (var item in Cargo)
                    {
                        // just ignore multiple variants of the same cargo
                        // 
                        Cargo.Add(item.Key, item.Value);
                    }
                    Companies = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCompaniesETS);
                    Countries_States = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCountriesETS);
                }
                else
                {
                    Cities = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCitiesATS);
                    Cargo = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCargosATS);
                    Dictionary<string, string> CargoUser = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCargosUserATS);
                    if (CargoUser != null)
                    {
                        foreach (var item in CargoUser)
                        {
                            Cargo.Add(item.Key, item.Value);
                        }
                    }
                    foreach (var item in Cargo)
                    {
                        // just ignore multiple variants of the same cargo
                        // 
                        if (!Cargo.ContainsKey(item.Key))
                            Cargo.Add(item.Key, item.Value);
                    }
                    Companies = LanguageGenerator.ReadFromFileJSON(Resources.LanguageCompaniesATS);
                    Countries_States = LanguageGenerator.ReadFromFileJSON(Resources.LanguageStatesATS);
                }
                if (Cities == null || Cargo == null || Companies == null || Countries_States == null)
                {
                    MessageBox.Show("Die Lokaldaten konnten nicht gelesen werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Die Lokaldaten konnten nicht gelesen werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<City> LoadAllCitiesAndCompanies(List<string> DataIn)
        {
            List<City> TranslatedCities = new List<City>();
            string CityTranslation;
            string CompanyTranslation;
            int CompanyCount;
            int offset;

            if (CheckForATS(DataIn))
                GameId = GameID.ATS;
            else
                GameId = GameID.ETS;

            Update(GameId);

            offset = Tools.FindFirstIndex(DataIn, "companies:");
            CompanyCount = Convert.ToInt32(DataIn[offset].Replace("companies:", ""));
            offset++;

            for (int i = offset; i < CompanyCount + offset; i++)
            {
                string strCity = City.ParseCity(DataIn[i]);
                string strCompany = Company.ParseCompany(DataIn[i]);
                this.Companies.TryGetValue(strCompany, out CompanyTranslation);

                int index = City.GetIndex(TranslatedCities, strCity);

                if (index == -1)
                {
                    // City not in list -> Add the city
                    this.Cities.TryGetValue(strCity, out CityTranslation);
                    TranslatedCities.Add(new City(strCity, CityTranslation, strCompany, CompanyTranslation));
                }
                else
                {
                    // City already in list
                    TranslatedCities[index].AddCompany(strCompany, CompanyTranslation);
                }
            }
            return TranslatedCities;
        }
        public List<Cargo> LoadCargo()
        {
            List<Cargo> TranslatedCargo = new List<Cargo>();
            foreach (var item in this.Cargo)
            {
                TranslatedCargo.Add(new Cargo(item.Key, item.Value));
            }
            return TranslatedCargo;
        }
        private bool CheckForATS(List<string> Data)
        {
            List<string> BaseGameCities = new List<string>
            {
                "bakersfield",
                "barstow",
                "carlsbad_nm",
                "carson_city",
                "el_centro",
                "elko",
                "ely",
                "eureka",
                "fresno",
                "huron",
                "jackpot",
                "las_vegas",
                "los_angeles",
                "oakdale",
                "oakland",
                "oxnard",
                "pioche",
                "primm",
                "redding",
                "reno",
                "sacramento",
                "san_diego",
                "san_francisc",
                "santa_cruz",
                "stockton",
                "tonopah",
                "truckee",
                "winnemucca",
                "ukiah"
            };
            //quickly read all comapanies
            int offset = Tools.FindFirstIndex(Data, "companies:");
            int CompanyCount = Convert.ToInt32(Data[offset].Replace("companies:", ""));
            offset++;

            for (int i = offset; i < CompanyCount + offset; i++)
            {
                foreach (var entry in BaseGameCities)
                    if (entry == City.ParseCity(Data[i]))
                        return true;
            }
            return false;
        }
        #endregion
    }
}

