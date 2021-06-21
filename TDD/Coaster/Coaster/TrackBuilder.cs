namespace CoasterKata.Coaster
{
    public enum TrackPieceOrientation
{
    
}


    public class TrackBuilder
    {
        public bool IsEmpty{get;set;} = true;

        public void Add()
        {
            IsEmpty=false;
        }


    }
}