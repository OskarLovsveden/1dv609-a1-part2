# Assignment 1 Part 2 1DV609

## Lyric App

A simple app for showing data about a songs lyric.

dotnet test --collect:"XPlat Code Coverage"
reportgenerator "-reports:TestResults\GUID\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html

### TODO

- Factory for creating new instances of class. (example: Lyric)
- Getting wordcount/frequency should/could be own class. (CountWordFrequency and StripApostrophes in Lyric)
- MUTATION SCORE?!
- Add JSONP converter class to replace functionality in the GetTrack Method
- (string)responseJson["message"]["body"]["track"]["track_id"] in GetTrack Method could be replace with a jsonreader class
- WE NEED TO CHANGE Task<TrackID> to Task<ITrackID> stuff to work
