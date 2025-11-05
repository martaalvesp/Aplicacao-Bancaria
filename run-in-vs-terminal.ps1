# Run this from Visual Studio Terminal (View > Terminal) to run the project inside the integrated terminal
# Usage: Open Visual Studio, open Terminal, run: `./run-in-vs-terminal.ps1`

$projectPath = "projetotest\projetotest.csproj"
Write-Host "Running project: $projectPath`n"

dotnet run --project $projectPath
