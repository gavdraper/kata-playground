# Coaster Kasta

A track is a complete circuit of track pieces, the track is split into secions by the use of block brakes. The coaster safety features will never alow a train to bein a section containing another train.

## Track Builder

- The Track is constructed with a TrackBuilder, the builder has an add method and takes in the oriantation to add the piece onto the last added piece, e.g Top, Right, Bottom, Left.
- The first piece can call the version of add with no orientation

### Tests

- If no pieces have been added Empty should be true
- Once a piece has been added it should return false
- If the first piece is added with an orientation it show throw an exception
- If any non first piece is added without an orentation it should throw an exception
- If a piece is added that goes back on itself it should throw an exception
- If a piece intersets another piece it should throw an exception
- Once the track joins up then IsComplete should return true
- If a piece is added to a complete track it should throw an exception

## SafetySystem

The safety system is responsibe for stopping trains crashing.

### Tests
