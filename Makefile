build:
	dotnet build
clean: 
	dotnet clean
restore: 
	dotnet restore
watch: 
	dotnet watch --project AdventOfCode.Code/AdventOfCode.csproj run
run: 
	dotnet run --project AdventOfCode.Code/AdventOfCode.csproj $(day) $(file)
test: 
	dotnet test