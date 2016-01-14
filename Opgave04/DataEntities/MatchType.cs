using System;

namespace DataEntities
{
    [Serializable]
    public abstract class MatchType
    {
        public DateTime dateTime { get; set; }
        public GameType GameID { get; set; }
        public MatchCategories Category { get; set; }

    }
}
