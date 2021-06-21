using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CoasterKata.Coaster
{

    public class TrackBuilder
    {
        private List<TrackPiecePosition> trackPieces;

        public bool IsEmpty => !trackPieces.Any();

        public bool IsComplete
        {
            get
            {
                if (trackPieces.Count() < 4)
                    return false;

                var firstPiece = trackPieces[0];
                var lastPiece = trackPieces.Last();

                if (firstPiece.Position.X == lastPiece.Position.X &&
                Math.Abs(firstPiece.Position.Y - lastPiece.Position.Y) == 1)
                    return true;

                if (firstPiece.Position.Y == lastPiece.Position.Y &&
                Math.Abs(firstPiece.Position.X - lastPiece.Position.X) == 1)
                    return true;

                return false;
            }
        }

        public TrackBuilder()
        {
            trackPieces = new List<TrackPiecePosition>();
        }

        public void Add()
        {
            if (trackPieces.Count() != 0)
                throw new InvalidOperationException("Must Supplly Orientation When Adding Additional Pieces");
            trackPieces.Add(new TrackPiecePosition(TrackType.Track, new Point(1, 1)));
        }

        public void Add(TrackPieceOrientation orientation)
        {
            if (trackPieces.Count() == 0)
                trackPieces.Add(new TrackPiecePosition(TrackType.Track, new Point(1, 1)));

            Point position = calculateNewPiecePosition(orientation, trackPieces.Last().Position);

            if (trackPieces.Any(x => x.Position == position))
            {
                throw new InvalidOperationException("Can't Overlap Track Piece");
            }

            trackPieces.Add(new TrackPiecePosition(TrackType.Track, position));
        }

        private Point calculateNewPiecePosition(TrackPieceOrientation orientation, Point previousPosition)
        {
            if (orientation == TrackPieceOrientation.Top)
                return new Point(previousPosition.X, previousPosition.Y - 1);
            if (orientation == TrackPieceOrientation.Right)
                return new Point(previousPosition.X + 1, previousPosition.Y);
            if (orientation == TrackPieceOrientation.Bottom)
                return new Point(previousPosition.X, previousPosition.Y + 1);
            if (orientation == TrackPieceOrientation.Left)
                return new Point(previousPosition.X - 1, previousPosition.Y);
            throw new Exception("Unknow orientation");
        }


    }
}