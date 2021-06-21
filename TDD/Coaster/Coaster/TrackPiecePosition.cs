using System.Drawing;

namespace CoasterKata.Coaster
{
    public struct TrackPiecePosition
    {
        public TrackType TrackType { get; set; }
        public Point Position { get; set; }

        public TrackPiecePosition(TrackType trackType, Point position)
        {
            TrackType = trackType;
            Position = position;
        }
    }
}