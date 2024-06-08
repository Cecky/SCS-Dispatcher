using Language;
using ScsDispatcher.Properties;
using SiiLibrary;
using SiiLibrary.MemStream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Scs.SaveGame
{
    public class DataBlock : List<string>
    {
        #region variables
        public string BlockName { get; set; }
        public string BlockID { get; set; }
        public List<string> RawData { get; set; }
        #endregion

        #region constructor
        public DataBlock()
        {
            RawData = new List<string>();
        }
        public DataBlock(List<string> Data)
        {
            RawData = new List<string>();
            string[] BlockNameID = Data[0].Split(':');
            BlockName = BlockNameID[0].Replace("{", "").Trim();
            BlockID = BlockNameID[1].Replace("{", "").Trim();

            foreach (var item in Data)
                RawData.Add(item);
        }
        #endregion
    }
    public class City : IComparable<City>
    {
        #region Public Variables
        public string InternalName;
        public string TranslatedName;
        public List<Company> Companies = new List<Company>();
        #endregion

        #region constructor
        public City(string CityName, string CityTranslation)
        {
            this.InternalName = CityName;
            this.TranslatedName = CityTranslation;

            if (this.TranslatedName == null)
                this.TranslatedName = String.Format("[{0}]No Translation", this.InternalName);

        }
        public City(string CityName, string CityTranslation, string Company, string CompanyTranslation)
        {
            this.InternalName = CityName;
            this.TranslatedName = CityTranslation;

            if (this.TranslatedName == null)
                this.TranslatedName = "No Translation";

            Companies.Add(new Company(Company, CompanyTranslation));
        }
        #endregion

        #region public methods
        public void AddCompany(string Company, string CompanyTranslation)
        {
            Companies.Add(new Company(Company, CompanyTranslation));
        }
        public static int GetIndex(List<City> city, string name)
        {
            int retval = -1;
            for (int i = 0; i < city.Count; i++)
            {
                if (city[i].InternalName == name) return i;
            }
            return retval;
        }
        public static string ParseCity(string Data)
        {
            string temp = Data.Remove(0, Data.IndexOf(':') + 1);
            temp = temp.Replace("company.volatile.", "");
            temp = temp.Trim();
            string[] CompanyCity = temp.Split('.');
            return CompanyCity[1];
        }
        public int CompareTo(City comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;
            else
                return this.TranslatedName.CompareTo(comparePart.TranslatedName);
        }
        #endregion
    }
    public class Company : IComparable<Company>
    {
        #region Variables
        internal string InternalName { get; }
        public string TranslatedName { get; }
        #endregion

        #region constructor
        public Company(string CompanyName, string CompanyTranslation)
        {
            this.InternalName = CompanyName;
            this.TranslatedName = CompanyTranslation;
            if (this.TranslatedName == null)
                this.TranslatedName = String.Format("[{0}]No Translation", this.InternalName);
        }
        #endregion

        #region public methods
        public static string ParseCompany(string CompanyString)
        {
            string temp = CompanyString.Remove(0, CompanyString.IndexOf(':') + 1);
            temp = temp.Replace("company.volatile.", "");
            temp = temp.Trim();
            string[] CompanyCity = temp.Split('.');
            return CompanyCity[0];
        }
        public int CompareTo(Company comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            else
                return this.TranslatedName.CompareTo(comparePart.TranslatedName);
        }
        #endregion
    }
    public class CompanyBlock
    {
        #region Public Variables
        private string CityName;
        private string CompanyName;
        public struct CompanyDataStruct
        {
            public string ID;
            public string PermanentData;
            public string DeliveredTrailer;
            public List<string> DeliveredPos;
            public List<string> JobOffer;
            public List<string> CargoOfferSeeds;

            public string Discovered;
            public string ReservedTrailerSlot;
            public string State;
            public string StateChangeTime;
            public string EndOfBlockChar;
        }
        public CompanyDataStruct CompanyData;
        #endregion

        #region constructor
        public CompanyBlock(DataBlock dataBlock)
        {
            CompanyData.DeliveredPos = new List<string>();
            CompanyData.JobOffer = new List<string>();
            CompanyData.CargoOfferSeeds = new List<string>();

            if (dataBlock.BlockName == "company")
                ReadCompany(dataBlock);
        }
        #endregion

        #region private methods
        private void ReadCompany(DataBlock dataBlock)
        {
            int idx = 1, len;
            var tmp = dataBlock.BlockID.Trim().Split('.');
            CityName = tmp[3];
            CompanyName = tmp[2].Replace('}', '\0');

            CompanyData.PermanentData = GetString(dataBlock.RawData[idx++]);
            CompanyData.DeliveredTrailer = GetString(dataBlock.RawData[idx++]);
            string StrLen = Tools.StringRemove(dataBlock.RawData[idx++], "delivered_pos:").Trim();
            len = Convert.ToInt32(StrLen);
            for (int i = 0; i < len; i++)
            {
                string item = dataBlock.RawData[idx++];
                item = item.Substring(item.IndexOf(':') + 1).Trim();
                CompanyData.DeliveredPos.Add(item);
            }
            StrLen = Tools.StringRemove(dataBlock.RawData[idx++], "job_offer:").Trim();
            len = Convert.ToInt32(StrLen);
            for (int i = 0; i < len; i++)
            {
                string item = dataBlock.RawData[idx++];
                item = item.Substring(item.IndexOf(':') + 1).Trim();
                CompanyData.JobOffer.Add(item);
            }
            StrLen = Tools.StringRemove(dataBlock.RawData[idx++], "cargo_offer_seeds:").Trim();
            len = Convert.ToInt32(StrLen);
            for (int i = 0; i < len; i++)
            {
                string item = dataBlock.RawData[idx++];
                item = item.Substring(item.IndexOf(':') + 1).Trim();
                CompanyData.CargoOfferSeeds.Add(item);
            }
            CompanyData.Discovered = GetString(dataBlock.RawData[idx++]);
            CompanyData.ReservedTrailerSlot = GetString(dataBlock.RawData[idx++]);
            CompanyData.State = GetString(dataBlock.RawData[idx++]);
            CompanyData.StateChangeTime = GetString(dataBlock.RawData[idx++]);
            CompanyData.EndOfBlockChar = dataBlock.RawData[idx++];
        }
        private string GetString(string input)
        {
            string[] tmp = input.Split(':');
            return tmp[1].Trim();
        }
        #endregion

        #region public methods
        public DataBlock ToDataBlock()
        {
            DataBlock dataBlock = new DataBlock();
            dataBlock.BlockName = "company";
            dataBlock.BlockID = String.Format("company.volatile.{0}.{1}", CompanyName, CityName);

            dataBlock.RawData = new List<string>();
            dataBlock.RawData.Add(String.Format("company : {0} {{", dataBlock.BlockID));
            dataBlock.RawData.Add(String.Format(" permanent_data: {0}", CompanyData.PermanentData));
            dataBlock.RawData.Add(String.Format(" delivered_trailer: {0}", CompanyData.DeliveredTrailer));
            dataBlock.RawData.Add(String.Format(" delivered_pos: {0}", CompanyData.DeliveredPos.Count));
            for (int i = 0; i < CompanyData.DeliveredPos.Count; i++)
            {
                dataBlock.RawData.Add(String.Format(" delivered_pos[{0}]: {1}", i, CompanyData.DeliveredPos[i]));
            }
            dataBlock.RawData.Add(String.Format(" job_offer: {0}", CompanyData.JobOffer.Count));
            for (int i = 0; i < CompanyData.JobOffer.Count; i++)
            {
                dataBlock.RawData.Add(String.Format(" job_offer[{0}]: {1}", i, CompanyData.JobOffer[i]));
            }
            dataBlock.RawData.Add(String.Format(" cargo_offer_seeds: {0}", CompanyData.CargoOfferSeeds.Count));
            for (int i = 0; i < CompanyData.CargoOfferSeeds.Count; i++)
            {
                dataBlock.RawData.Add(String.Format(" cargo_offer_seeds[{0}]: {1}", i, CompanyData.CargoOfferSeeds[i]));
            }
            dataBlock.RawData.Add(String.Format(" discovered: {0}", CompanyData.Discovered));
            dataBlock.RawData.Add(String.Format(" reserved_trailer_slot: {0}", CompanyData.ReservedTrailerSlot));
            dataBlock.RawData.Add(String.Format(" state: {0}", CompanyData.State));
            dataBlock.RawData.Add(String.Format(" state_change_time: {0}", CompanyData.StateChangeTime));
            dataBlock.RawData.Add("}");

            return dataBlock;
        }
        #endregion
    }
    public class ProfitLogEntryBlock
    {
        #region Public Variables
        public string SourceCity { get; internal set; }
        public string DestinationCity { get; internal set; }
        public int Distance { get; internal set; }
        #endregion

        #region constructor
        public ProfitLogEntryBlock(DataBlock dataBlock)
        {
            if (dataBlock.BlockName == "profit_log_entry")
            {
                foreach (var item in dataBlock.RawData)
                {
                    string[] tmp = item.Split(':');
                    if (tmp[0].Trim() == "distance")
                        Distance = int.Parse(tmp[1].Trim());
                    if (tmp[0].Trim() == "source_city")
                        SourceCity = tmp[1].Trim();
                    if (tmp[0].Trim() == "destination_city")
                        DestinationCity = tmp[1].Trim();
                }
            }
        }
        #endregion
    }
    public class Cargo : IComparable<Cargo>, IEquatable<Cargo>
    {
        #region Public Variables
        public string InternalName { get; }
        public string TranslatedName { get; }
        #endregion

        #region constructor
        public Cargo(string CargoName, string CargoTranslation)
        {
            this.InternalName = CargoName;
            this.TranslatedName = CargoTranslation;
            if (this.TranslatedName == null)
                this.TranslatedName = String.Format("[{0}]No Translation", this.InternalName);
        }
        #endregion

        #region public methods
        public int CompareTo(Cargo comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;
            else
                return this.TranslatedName.CompareTo(comparePart.TranslatedName);
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public override bool Equals(object Object)
        {
            if (Object == null)
                return false;
            Cargo ObjAsCargo = Object as Cargo;
            if (ObjAsCargo == null)
                return false;
            else
                return Equals(ObjAsCargo);
        }
        public bool Equals(Cargo Cargo)
        {
            if (Cargo == null)
                return false;
            return (this.TranslatedName.Equals(Cargo.TranslatedName));
        }
        #endregion
    }
    public class Job : IComparable<Job>
    {
        #region Public Variables
        public struct JobDataStruct
        {
            public string ID;
            public string Target;
            public string ExpirationTime;
            public string Urgency;
            public string ShortestDistance;
            public string FerryTime;
            public string FerryPrice;
            public string Cargo;
            public string CompanyTruck;
            public string TrailerVariant;
            public string TrailerDefinition;
            public string UnitsCount;
            public string FillRatio;
            public string Trailer_Place;
        }
        public JobDataStruct JobData;
        public string CargoTranslation { get; set; }
        #endregion

        #region Constructor
        public Job(DataBlock dataBlock)
        {
            if (dataBlock.BlockName == "job_offer_data")
            {
                int idx = 0;
                JobData.ID = GetString(dataBlock.RawData[idx++]).Replace("{", "").Trim();
                JobData.Target = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.ExpirationTime = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.Urgency = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.ShortestDistance = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.FerryTime = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.FerryPrice = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.Cargo = GetString(dataBlock.RawData[idx++]).Replace("cargo.", "").Trim();
                JobData.CompanyTruck = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.TrailerVariant = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.TrailerDefinition = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.UnitsCount = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.FillRatio = GetString(dataBlock.RawData[idx++]).Trim();
                JobData.Trailer_Place = GetString(dataBlock.RawData[idx++]).Trim();
            }
        }
        #endregion

        #region private methods
        private string GetString(string input)
        {
            string[] tmp = input.Split(':');
            return tmp[1].Trim();
        }
        #endregion

        #region public methods
        public DataBlock ToDataBlock()
        {
            DataBlock dataBlock = new DataBlock();
            dataBlock.BlockName = "job_offer_data";
            dataBlock.BlockID = JobData.ID;
            dataBlock.RawData = new List<string>
            {
                String.Format("job_offer_data : {0} {{", JobData.ID),
                String.Format(" target: {0}", JobData.Target),
                String.Format(" expiration_time: {0}", JobData.ExpirationTime),
                String.Format(" urgency: {0}", JobData.Urgency),
                String.Format(" shortest_distance_km: {0}", JobData.ShortestDistance),
                String.Format(" ferry_time: {0}", JobData.FerryTime),
                String.Format(" ferry_price: {0}", JobData.FerryPrice),
                String.Format(" cargo: cargo.{0}", JobData.Cargo),
                String.Format(" company_truck: {0}", JobData.CompanyTruck),
                String.Format(" trailer_variant: {0}", JobData.TrailerVariant),
                String.Format(" trailer_definition: {0}", JobData.TrailerDefinition),
                String.Format(" units_count: {0}", JobData.UnitsCount),
                String.Format(" fill_ratio: {0}", JobData.FillRatio),
                String.Format(" trailer_place: {0}", JobData.Trailer_Place),
                "}"
            };

            return dataBlock;
        }
        public int CompareTo(Job comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;
            else if (CargoTranslation == null)
                return 0;
            else
                return this.CargoTranslation.CompareTo(comparePart.CargoTranslation);
        }
        #endregion
    }
    public class EconomyEvent : IEquatable<EconomyEvent>
    {
        #region variables
        public string ID { get; set; }
        public string Time { get; set; }
        public string UnitLink { get; set; }
        public string Param { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        #endregion

        #region constructor
        public EconomyEvent()
        {
            StartIndex = -1;
            EndIndex = -1;
        }
        public EconomyEvent(DataBlock dataBlock)
        {
            StartIndex = -1;
            EndIndex = -1;

            if (dataBlock.BlockName == "economy_event")
            {
                foreach (var item in dataBlock.RawData)
                {
                    if (item.Contains("economy_event"))
                        ID = Tools.StringRemove(item, "economy_event", ":", "{").Trim();
                    else if (item.Contains("time"))
                        Time = Tools.StringRemove(item, "time", ":").Trim();
                    else if (item.Contains("unit_link"))
                        UnitLink = Tools.StringRemove(item, "unit_link", ":").Trim();
                    else if (item.Contains("param"))
                        Param = Tools.StringRemove(item, "param", ":").Trim();
                }
            }
        }
        #endregion

        #region public methods
        public DataBlock ToDataBlock()
        {
            DataBlock dataBlock = new DataBlock
            {
                BlockName = "economy_event",
                BlockID = ID
            };
            dataBlock.RawData = new List<string>
            {
                String.Format("economy_event : {0} {{", ID),
                String.Format(" time: {0}", Time),
                String.Format(" unit_link: {0}", UnitLink),
                String.Format(" param: {0}", Param),
                "}"
            };

            return dataBlock;
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public override bool Equals(object Object)
        {
            if (Object == null)
                return false;
            EconomyEvent ObjAsCargo = Object as EconomyEvent;
            if (ObjAsCargo == null)
                return false;
            else
                return Equals(ObjAsCargo);
        }
        public bool Equals(EconomyEvent EconEvent)
        {
            if (EconEvent == null)
                return false;
            return (this.UnitLink.Equals(EconEvent.UnitLink));
        }
        #endregion
    }
    public class ScsSavegame
    {
        #region variables
        private List<DataBlock> SaveGame { get; set; }
        public List<Job> JobList { get; private set; }
        public List<City> CityList { get; private set; }
        public List<Cargo> CargoList { get; private set; }
        private List<EconomyEvent> EconomyEventList { get; set; }
        public ScsDictionary.GameID GameID { get; private set; }

        const int DefaultJobLength = 2160;  // == 48 hours
        private ScsDictionary _ScsDictionary;
        private int ExpirationTime = 0;
        private int GameTime = 0;
        private Route Route = new Route();
        private List<string> _Savegame = new List<string>();
        #endregion

        #region constructor
        public ScsSavegame(SiiStream SaveGameStream, ScsDictionary.GameID gameID)
        {
            InitializeDataStructures();

            // load sii-file and split it
            SiiStream siiStream = SiiFileDecryptor.DecodeStream(SaveGameStream);
            _Savegame = siiStream.ToString().Replace("\r", "").Split('\n').ToList();

            //loop through file and extract all blocks of data
            int LastIndexOfBlock, FirstIndexOfBlock = 2;

            while (FirstIndexOfBlock != -1)
            {
                FirstIndexOfBlock = Tools.FindFirstIndex(_Savegame, FirstIndexOfBlock, "{");
                if (FirstIndexOfBlock == -1)
                    continue;
                LastIndexOfBlock = Tools.FindFirstIndex(_Savegame, FirstIndexOfBlock, "}");
                int BlockLength = LastIndexOfBlock - FirstIndexOfBlock + 1;
                SaveGame.Add(new DataBlock(_Savegame.GetRange(FirstIndexOfBlock, BlockLength)));
                FirstIndexOfBlock = LastIndexOfBlock;
            }
            _Savegame = null;

            //find economy-block and extract the in-game-time
            List<string> Economy = GetByBlockName("economy");
            int idx = Economy.FindIndex(x => x.Contains("game_time:"));
            string[] tmp = Economy[idx].Split(':');
            GameTime = Convert.ToInt32(tmp[1].Trim());
            ExpirationTime = GameTime + DefaultJobLength;

            DictionaryInit(gameID);
            LoadAllJobs();
            LoadAllCities();
            LoadAllCargo();
            LoadAllEconomyEvents();
            LoadDistanceDb();

            if (Settings.Default.AutoDistanceLearning)
                UpdateDistances();

            GameID = _ScsDictionary.GameId;
        }
        #endregion

        #region public methods
        public string AddJob(string CityFrom, string CompanyFrom, string CityTo, string CompanyTo, string Cargo)
        {
            var RandomValue = new Random();
            CompanyBlock companyBlock = null;
            Job JobToAdd = GetTemplateFromCargo(Cargo);
            EconomyEvent economyEvent = new EconomyEvent();
            int CompanyBlockIndex = 0;
            bool ChangeExisitingData = false;

            ExpirationTime += DefaultJobLength;

            // Load CompanyBlock from file
            for (int BlockCnt = 0; BlockCnt < SaveGame.Count; BlockCnt++)
            {
                if (SaveGame[BlockCnt].BlockID.Contains(String.Format(@"company.volatile.{0}.{1}", CompanyFrom, CityFrom)))
                {
                    companyBlock = new CompanyBlock(SaveGame[BlockCnt]);
                    CompanyBlockIndex = BlockCnt;
                    break;
                }
            }

            //check if at least 1 job is offered so we can edit this one. Otherwise generate a new job
            if (companyBlock.CompanyData.JobOffer.Count > 0)
                ChangeExisitingData = true;

            JobToAdd.JobData.Target = String.Format("\"{0}.{1}\"", CompanyTo, CityTo);
            JobToAdd.JobData.ExpirationTime = ExpirationTime.ToString();
            int ShortestDistance = Route.Exits(CityFrom, CityTo);
            if (ShortestDistance == -1)
                JobToAdd.JobData.ShortestDistance = Settings.Default.DefaultJobLength.ToString();
            else
                JobToAdd.JobData.ShortestDistance = ShortestDistance.ToString();

            if (ChangeExisitingData)
            {
                Job tmpjob = null;
                foreach (var Block in SaveGame)
                {
                    if (Block.BlockName == "job_offer_data" && Block.BlockID == companyBlock.CompanyData.JobOffer[0])
                    {
                        tmpjob = new Job(Block);
                        companyBlock.CompanyData.CargoOfferSeeds[0] = (ExpirationTime + RandomValue.Next(180, 1800)).ToString();
                        break;
                    }
                }
                // Update company
                SaveGame[CompanyBlockIndex] = companyBlock.ToDataBlock();

                JobToAdd.JobData.ID = tmpjob.JobData.ID;
                // Find economy_event for job and update time
                foreach (var Block in SaveGame)
                {
                    if (Block.BlockName == "economy_event")
                    {
                        if (Block.RawData[2].Contains(String.Format("company.volatile.{0}.{1}", CompanyFrom, CityFrom)) &&
                           Block.RawData[3].Contains("0"))
                        {
                            Block.RawData[1] = String.Format(" time: {0}", JobToAdd.JobData.ExpirationTime);
                            break;
                        }
                    }
                }
                // Update job
                for (int BlockCnt = 0; BlockCnt < SaveGame.Count; BlockCnt++)
                {
                    if (SaveGame[BlockCnt].BlockName == "job_offer_data" && SaveGame[BlockCnt].BlockID == JobToAdd.JobData.ID)
                    {
                        DataBlock foo = JobToAdd.ToDataBlock();
                        SaveGame[BlockCnt] = foo;
                    }
                }
            }
            else
            {
                string JobID = GetFreeID();
                companyBlock.CompanyData.JobOffer.Add(JobID);
                companyBlock.CompanyData.CargoOfferSeeds[companyBlock.CompanyData.JobOffer.Count - 1] = (ExpirationTime + RandomValue.Next(180, 1800)).ToString();
                JobToAdd.JobData.ID = JobID;

                // Update Company
                int CompanyIndex = 0;
                for (int BlockCnt = 0; BlockCnt < SaveGame.Count; BlockCnt++)
                {
                    if (SaveGame[BlockCnt].BlockName == "company" && SaveGame[BlockCnt].BlockID == String.Format("company.volatile.{0}.{1}", CompanyFrom, CityFrom))
                    {
                        SaveGame[BlockCnt] = companyBlock.ToDataBlock();
                        CompanyIndex = BlockCnt;
                        break;
                    }
                }

                // Add new job after company-block
                SaveGame.Insert(CompanyIndex + 1, JobToAdd.ToDataBlock());

                // Create new economy_event
                economyEvent.ID = GetFreeID();
                economyEvent.Time = JobToAdd.JobData.ExpirationTime;
                economyEvent.UnitLink = String.Format("company.volatile.{0}.{1}", CompanyFrom, CityFrom);
                economyEvent.Param = (companyBlock.CompanyData.JobOffer.Count - 1).ToString();
                EconomyEventList.Add(economyEvent);

                // Generate new economy_event_queue and update economy_event_queue-block
                List<string> Output = new List<string>();
                int EconomyQueueIndex = 0;
                foreach (var Block in SaveGame)
                {
                    if (Block.BlockName == "economy_event_queue")
                    {
                        Output.Add(String.Format("{0} : {1} {{", Block.BlockName, Block.BlockID));
                        break;
                    }
                    EconomyQueueIndex++;
                }

                Output.Add(String.Format(" data: {0}", EconomyEventList.Count));
                int cnt = 0;
                foreach (var item in EconomyEventList)
                {
                    Output.Add(String.Format(" data[{0}]: {1}", cnt, item.ID));
                    cnt++;
                }
                Output.Add("}");
                SaveGame[EconomyQueueIndex].RawData = new List<string>(Output);

                // add new economy_event after the last event
                int LastEconomyEventIndex = 0;
                cnt = 0;
                foreach (var Block in SaveGame)
                {
                    if (Block.BlockName == "economy_event")
                        LastEconomyEventIndex = cnt;
                    cnt++;
                }
                SaveGame.Insert(LastEconomyEventIndex + 1, economyEvent.ToDataBlock());
            }
            return JobToAdd.JobData.ShortestDistance;
        }
        public void ClearJobs()
        {
            var rand = new Random();

            for (int BlockCnt = 0; BlockCnt < SaveGame.Count; BlockCnt++)
            {
                switch (SaveGame[BlockCnt].BlockName)
                {
                    case "company":
                        CompanyBlock companyBlock = new CompanyBlock(SaveGame[BlockCnt]);
                        companyBlock.CompanyData.JobOffer.Clear();
                        for (int i = 0; i < companyBlock.CompanyData.CargoOfferSeeds.Count; i++)
                        {
                            companyBlock.CompanyData.CargoOfferSeeds[i] = (GameTime + rand.Next(180, 1800)).ToString();
                        }
                        SaveGame[BlockCnt] = companyBlock.ToDataBlock();
                        break;

                    case "job_offer_data":
                        SaveGame.RemoveAt(BlockCnt);
                        BlockCnt--;
                        break;
                    case "economy_event_queue":
                        SaveGame[BlockCnt].RawData = SaveGame[BlockCnt].RawData.Take(1).ToList();
                        SaveGame[BlockCnt].RawData.Add(" data: 0");
                        SaveGame[BlockCnt].RawData.Add("}");
                        break;
                    case "economy_event":
                        SaveGame.RemoveAt(BlockCnt);
                        BlockCnt--;
                        break;
                }
            }
        }
        public bool TryGetCity(City City, out string CityTranslation)
        {
            string retval;
            if (_ScsDictionary.Cities.TryGetValue(City.InternalName, out retval))
            {
                CityTranslation = retval;
                return true;
            }
            else
            {
                CityTranslation = null;
                return false;
            }
        }
        public SiiStream Save()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SiiNunit");
            sb.AppendLine("{");
            foreach (var Block in SaveGame)
            {
                foreach (var DataEntry in Block.RawData)
                {
                    sb.Append(DataEntry + "\r\n");
                }
                sb.Append("\r\n");
            }
            sb.AppendLine("}");

            return new SiiStream(Encoding.ASCII.GetBytes(sb.ToString()));
        }
        public bool DictionaryInit(ScsDictionary.GameID gameID)
        {
            return _ScsDictionary.Update(gameID);
        }
        public void UpdateDistances()
        {
            foreach (var Block in SaveGame)
            {
                // Extract routes if active jobs from company block
                if (Block.BlockName == "company")
                {
                    string[] CityCompany = Block.BlockID.Replace("company.volatile.", "").Trim().Split('.');
                    string CitySrc = CityCompany[1];
                    string CompanySrc = CityCompany[0];

                    CompanyBlock CompanyBlock = new CompanyBlock(Block);

                    if (CompanyBlock.CompanyData.JobOffer.Count == 0)
                        continue;

                    int cnt = 0;
                    foreach (var JobOfferData in SaveGame)
                    {
                        if (cnt == CompanyBlock.CompanyData.JobOffer.Count)
                            break; ;

                        if (JobOfferData.BlockName == "job_offer_data")
                        {
                            foreach (var JobID in CompanyBlock.CompanyData.JobOffer)
                            {
                                if (JobID.Contains(JobOfferData.BlockID))
                                {
                                    cnt++;
                                    Job job = new Job(JobOfferData);
                                    if (job.JobData.Cargo.Contains("null"))
                                        continue;

                                    string CityDst = job.JobData.Target.Replace("\"", "");
                                    CityDst = CityDst.Substring(CityDst.IndexOf('.') + 1);

                                    // Only add new distance if the value for shortest distance is not 1500.
                                    // We use 1500 as default value for every new job which route is not in the db.
                                    // We don't want to add a wrong value to the db
                                    int ShortestDist = Convert.ToInt32(job.JobData.ShortestDistance);
                                    if (Route.Exits(CitySrc, CityDst) == -1 && ShortestDist != Settings.Default.DefaultJobLength)
                                        Route.Add(CitySrc, CityDst, ShortestDist);
                                }
                            }
                        }
                    }
                }
                // Extract routes of profit_log_entry block
                if (Block.BlockName == "profit_log_entry")
                {
                    ProfitLogEntryBlock ProfitLog = new ProfitLogEntryBlock(Block);

                    if (Route.Exits(ProfitLog.SourceCity, ProfitLog.DestinationCity) == -1 && ProfitLog.Distance != Settings.Default.DefaultJobLength)
                        Route.Add(ProfitLog.SourceCity, ProfitLog.DestinationCity, ProfitLog.Distance);
                }
            }
            if (!Directory.Exists(Path.GetDirectoryName(Resources.DinstanceDB)))
                Directory.CreateDirectory(Path.GetDirectoryName(Resources.DinstanceDB));
            File.WriteAllText(Resources.DinstanceDB, Route.ToString());
        }
        public List<string> PlausibilityCheck()
        {
            List<string> retval = new List<string>();
            DataBlock block;

            for (int BlockCnt = 0; BlockCnt < SaveGame.Count; BlockCnt++)
            {
                switch (SaveGame[BlockCnt].BlockName)
                {
                    case "company":
                        CompanyBlock companyBlock = new CompanyBlock(SaveGame[BlockCnt]);

                        for (int i = 0; i < companyBlock.CompanyData.CargoOfferSeeds.Count; i++)
                        {
                            string TmpSeed = companyBlock.CompanyData.CargoOfferSeeds[i];
                            int SeedTime = Convert.ToInt32(TmpSeed.Trim());
                            if (SeedTime < GameTime)
                            {
                                retval.Add(String.Format("Block: {0} | Seed: {1} | Gametime {2}", SaveGame[BlockCnt].BlockName, SeedTime, GameTime));
                            }
                        }
                        break;

                    case "economy_event":
                        block = SaveGame[BlockCnt];
                        for (int i = 0; i < block.RawData.Count; i++)
                        {
                            if (block.RawData[i].Contains("time"))
                            {
                                int SeedTime = GetTime(block.RawData[i]);
                                if (SeedTime < GameTime)
                                {
                                    retval.Add(String.Format("Block: {0} | Seed: {1} | Gametime {2}", block.BlockName, SeedTime, GameTime));
                                }
                            }
                        }
                        break;

                    case "job_offer_data":
                        block = SaveGame[BlockCnt];
                        for (int i = 0; i < block.RawData.Count; i++)
                        {
                            if (block.RawData[i].Contains("expiration_time") && !block.RawData[i].Contains("nil"))
                            {
                                int SeedTime = GetTime(block.RawData[i]);
                                if (SeedTime < GameTime)
                                {
                                    retval.Add(String.Format("Block: {0} [{1}] | Seed: {2} | Gametime {3}", block.BlockName, block.BlockID, SeedTime, GameTime));
                                }
                            }
                        }
                        break;
                }
            }

            return retval;
        }
        #endregion

        #region private methods
        private void InitializeDataStructures()
        {
            CityList = new List<City>();
            CargoList = new List<Cargo>();
            JobList = new List<Job>();
            EconomyEventList = new List<EconomyEvent>();
            _ScsDictionary = new ScsDictionary();
            SaveGame = new List<DataBlock>();
        }
        private void LoadAllJobs()
        {
            Job toParse;
            

            foreach (var item in SaveGame)
            {
                if (item.BlockName == "job_offer_data")
                {
                    string CargoVariant = "";
                    toParse = new Job(item);
                    if (toParse.JobData.Cargo != "null")
                    {
                        if (!Settings.Default.IgnoreTranslation)
                        {
                            foreach (var key in _ScsDictionary.Cargo.Keys)
                            {
                                if (toParse.JobData.Cargo.Contains(key))
                                {
                                    CargoVariant = key;
                                    break;
                                }
                            }

                            if (_ScsDictionary.Cargo.TryGetValue(CargoVariant, out string TranslatedName))
                            {
                                toParse.CargoTranslation = TranslatedName;
                                JobList.Add(toParse);
                            }
                        }
                        else
                        {
                            toParse.CargoTranslation = toParse.JobData.Cargo;
                            JobList.Add(toParse);
                        }
                    }
                }
            }
            JobList.Sort();
        }
        private void LoadAllCities()
        {
            CityList = _ScsDictionary.LoadAllCitiesAndCompanies(GetByBlockName("economy"));
            CityList.Sort();
        }
        private void LoadAllCargo()
        {
            foreach (var job in JobList)
            {
                if (job.CargoTranslation != null)
                {
                    Cargo TmpCargo = new Cargo(job.JobData.Cargo, job.CargoTranslation);

                    if (!CargoList.Contains(new Cargo(job.JobData.Cargo, job.CargoTranslation)))
                        CargoList.Add(TmpCargo);
                }
            }
            CargoList.Sort();
        }
        private void LoadAllEconomyEvents()
        {
            EconomyEvent EconEvent;
            foreach (var item in SaveGame)
            {
                if (item.BlockName == "economy_event")
                {
                    EconEvent = new EconomyEvent(item);
                    if (EconEvent != null)
                    {
                        EconomyEventList.Add(EconEvent);
                    }
                }
            }
        }
        private void LoadDistanceDb()
        {
            if (File.Exists(Resources.DinstanceDB))
            {
                List<string> RouteData = File.ReadAllLines(Resources.DinstanceDB).ToList<string>();
                Route = new Route(RouteData);
            }
        }
        private List<string> GetByBlockName(string BlockName)
        {
            foreach (var item in SaveGame)
            {
                if (item.BlockName == BlockName)
                    return item.RawData;
            }
            return null;
        }
        private string GetFreeID()
        {
            string retval = null;

            //Parse the file and get all used id's
            List<string> AllIds = new List<string>();
            foreach (var item in SaveGame)
            {
                if (item.BlockID.Contains("_nameless"))
                {
                    AllIds.Add(Tools.StringRemove(item.BlockID, "_nameless", "."));
                }
            }
            AllIds.Sort();

            //get the highest id and add 0xD0 (seems to be the default offset for a job_offer_data block)
            Int64 HighestID = Convert.ToInt64(AllIds[AllIds.Count - 1], 16) + 0xD0;
            retval = String.Format("{0:x}", HighestID);
            retval = retval.Insert(3, ".");
            retval = retval.Insert(8, ".");

            return "_nameless." + retval;
        }
        private Job GetTemplateFromCargo(string Cargo)
        {
            foreach (var item in JobList)
            {
                if (item.JobData.Cargo == Cargo)
                {
                    item.JobData.ID = "job_offer_data : ";
                    item.JobData.ShortestDistance = "0";
                    item.JobData.FerryTime = "0";
                    item.JobData.FerryPrice = "0";

                    return item;
                }
            }
            return null;
        }
        private int GetTime(string input)
        {
            string[] tmp = input.Split(':');
            return Convert.ToInt32(tmp[1].Trim());
        }
        #endregion
    }
    public class Tools
    {
        /// <summary>
        /// Returns the first index of List<string> that contains the searchstring.
        /// </summary>
        /// <param name="Data">Dataset to search in</param>
        /// <param name="Expression">Expression to search for</param>
        /// <returns>First index of string. -1 if no string is found</returns>
        public static int FindFirstIndex(List<string> Data, string Expression)
        {
            return FindFirstIndex(Data, new string[] { Expression });
        }

        /// <summary>
        /// Returns the first index of List<string> that contains the searchstring. Search starts at the offset
        /// </summary>
        /// <param name="Data">Dataset to search in</param>
        /// <param name="StartOffset">Index to start the search from</param>
        /// <param name="Expression">Expression to search for</param>
        /// <returns>First index of string. -1 if no string is found</returns>
        public static int FindFirstIndex(List<string> Data, int StartOffset, string Expression)
        {
            if (StartOffset < 0) return -1;

            for (int i = StartOffset; i < Data.Count; i++)
            {
                if (Data[i].Contains(Expression))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Returns the first index of string that contains all searchstrings.
        /// </summary>
        /// <param name="Data">Dataset to search in</param>
        /// <param name="ExpressionList">Expression to search for</param>
        /// <returns>First index of string. -1 if no string is found</returns>
        public static int FindFirstIndex(List<string> Data, params string[] ExpressionList)
        {
            int offset = 0;
            int bflag;
            foreach (string item in Data)
            {
                bflag = 0;
                foreach (string expr in ExpressionList)
                {
                    if (item.Contains(expr))
                        bflag++;
                    if (bflag == ExpressionList.Length)
                        return offset;
                }
                offset++;
            }
            return -1;
        }

        /// <summary>
        /// Returns the last index of List<string> that contains the searchstring.
        /// </summary>
        /// <param name="Data">Dataset to search in</param>
        /// <param name="Expression">Expression to search for</param>
        /// <returns>First index of string. -1 if no string is found</returns>
        public static int FindLastIndex(List<string> data, string Expression)
        {
            int idx = data.FindLastIndex(delegate (string str)
            {
                return str.Contains(Expression);
            });
            return idx;
        }

        /// <summary>
        /// Remove all strings included is ExpressionList
        /// </summary>
        /// <param name="Data">Dataset to search in</param>
        /// <param name="Expression">List of expressions to search for</param>
        /// <returns></returns>
        public static string StringRemove(string Data, params string[] Expression)
        {
            string retval = Data;
            foreach (string s in Expression)
            {
                retval = retval.Replace(s, "");
            }
            return retval;
        }

        /// <summary>
        /// Returns a Datablock starting at StartIndex with the size of Length
        /// </summary>
        /// <param name="Data">Dataset to search in</param>
        /// <param name="StartIndex">Index of first element of Datablock</param>
        /// <param name="Length">Length of datablock</param>
        /// <returns>Datablock</returns>
        public static List<string> GetBlock(List<string> Data, int StartIndex, int Length)
        {
            List<string> retval = new List<string>();
            for (int i = 0; i < Length; i++)
            {
                retval.Add(Data[StartIndex + i]);
            }
            return retval;
        }
    }
    public class Route
    {
        struct CityPair
        {
            public string CityA;
            public string CityB;
            public int Distance;
        }
        private List<CityPair> cityPairs;

        public Route()
        {
            cityPairs = new List<CityPair>();
        }
        public Route(List<string> RouteData)
        {
            cityPairs = new List<CityPair>();
            foreach (var item in RouteData)
            {
                CityPair cityPair = new CityPair();
                string[] arr = item.Split(';');
                cityPair.CityA = arr[0];
                cityPair.CityB = arr[1];
                cityPair.Distance = Convert.ToInt32(arr[2]);
                cityPairs.Add(cityPair);
            }
        }

        public int Exits(string CitySrc, string CityDst)
        {
            foreach (var item in cityPairs)
            {
                if ((item.CityA == CitySrc && item.CityB == CityDst) || (item.CityB == CitySrc && item.CityA == CityDst))
                    return item.Distance;
            }
            return -1;
        }
        public void Add(string CitySrc, string CityDst, int Distance)
        {
            CityPair NewItem = new CityPair
            {
                CityA = CitySrc,
                CityB = CityDst,
                Distance = Distance
            };
            cityPairs.Add(NewItem);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in cityPairs)
                sb.AppendLine(String.Format("{0};{1};{2}", item.CityA, item.CityB, item.Distance));

            return sb.ToString();
        }
    }
}
