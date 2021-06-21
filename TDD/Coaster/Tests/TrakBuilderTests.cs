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
    }
}
