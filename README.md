# Assignment 1 Part 2 1DV609

## Lyric App

A simple app for showing data about a songs lyric.

dotnet test --collect:"XPlat Code Coverage"
reportgenerator "-reports:TestResults\GUID\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html

### TODO

- Factory for creating new instances of class. (example: Lyric)
- Getting wordcount/frequency should/could be own class. (CountWordFrequency and StripApostrophes in Lyric)
- MUTATION SCORE?!
