# Assignment 1 Part 2 1DV609

## Lyric App

A simple app for showing data about a songs lyric.

dotnet new sln -n XUnit.Coverage
reportgenerator "-reports:TestResults\cfc95be6-56e2-43cd-8bcf-67535652ccff\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html

### TODO

- Factory for creating new instances of class. (example: Lyric)
- Getting wordcount/frequency should/could be own class. (CountWordFrequency and StripApostrophes in Lyric)
- MUTATION SCORE?!
