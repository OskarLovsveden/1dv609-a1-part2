# Assignment 1 Part 2 1DV609

## Lyric App

A simple app for showing data about a songs lyric.

## How to generate code coverage

- Create TestResults Folder: `dotnet test --collect:"XPlat Code Coverage"`
- GUID Folder will be created under TestResults, use this GUID in the next step
- Generate Report:
  `reportgenerator "-reports:TestResults\{GUID}\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html`
- Open index.html in the coveragereport folder in any browser.

### TODO - Things considered for future implementation

- Factory for creating new instances of classes
- Getting wordcount/frequency should/could be own class. (CountWordFrequency and StripApostrophes in Lyric)
- Add JSONP converter class to replace functionality in GetTrack Method in TrackDAL class.
- (string)responseJson["message"]["body"]["track"]["track_id"] in GetTrack Method in TrackDAL class could be replace with a jsonreader class.
- ConsoleWrapperTests could benefit from this style: http://www.vtrifonov.com/2012/11/getting-console-output-within-unit-test.html
- App should show lyrics searched for in the console.
- User should be able to get a word frequency of the current lyric shown by navigating the console.
