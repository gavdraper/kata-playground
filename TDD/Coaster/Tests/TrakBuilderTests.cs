using System;
using CoasterKata.Coaster;
using Xunit;

namespace CoasterKata
{
    public class TrackBuilderTests
    {
        [Fact]
        public void ReturnsEmptyWhenNoPieces()
        {
            var trackBuilder = new TrackBuilder();
            Assert.True(trackBuilder.IsEmpty);
        }

        [Fact]
        public void ReturnsNotEmptyOnceHasAPiece()
        {
            var trackBuilder = new TrackBuilder();
            trackBuilder.Add();
            Assert.False(trackBuilder.IsEmpty);
        }

        [Fact]
        public void ThrowsIfAddingAPieceToExistingTrackWithoutOrientation()
        {
            var trackBuilder = new TrackBuilder();
            trackBuilder.Add();
            Assert.Throws<InvalidOperationException>(() => trackBuilder.Add());
        }

        [Fact]
        public void ThrowOnOverlap()
        {
            /*
                0 0
                X 0
                0
            */
            var trackBuilder = new TrackBuilder();
            trackBuilder.Add();
            trackBuilder.Add(TrackPieceOrientation.Top);
            trackBuilder.Add(TrackPieceOrientation.Top);
            trackBuilder.Add(TrackPieceOrientation.Right);
            trackBuilder.Add(TrackPieceOrientation.Bottom);
            Assert.Throws<InvalidOperationException>(() => trackBuilder.Add(TrackPieceOrientation.Left));
        }

        [Fact]
        public void SinglePieceIsNotComplete()
        {
            var trackBuilder = new TrackBuilder();
            trackBuilder.Add();
            Assert.False(trackBuilder.IsComplete);
        }


        [Fact]
        public void NonLoopIsNotComplete()
        {
            var trackBuilder = new TrackBuilder();
            trackBuilder.Add();
            trackBuilder.Add(TrackPieceOrientation.Top);
            trackBuilder.Add(TrackPieceOrientation.Right);
            trackBuilder.Add(TrackPieceOrientation.Right);
            trackBuilder.Add(TrackPieceOrientation.Bottom);
            Assert.False(trackBuilder.IsComplete);
        }


        [Fact]
        public void IsCompleteOnLoop()
        {
            /*
                0 0 0
                0   0
                0 0 0
            */
            var trackBuilder = new TrackBuilder();
            trackBuilder.Add();
            trackBuilder.Add(TrackPieceOrientation.Top);
            trackBuilder.Add(TrackPieceOrientation.Top);
            trackBuilder.Add(TrackPieceOrientation.Right);
            trackBuilder.Add(TrackPieceOrientation.Right);
            trackBuilder.Add(TrackPieceOrientation.Bottom);
            trackBuilder.Add(TrackPieceOrientation.Bottom);
            trackBuilder.Add(TrackPieceOrientation.Left);
            Assert.True(trackBuilder.IsComplete);
        }
    }
}
