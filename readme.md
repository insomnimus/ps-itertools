# Itertools
A collection of iterator adaptors for `powershell` pipelines.

# Building The Module
You will need:
-	`git` to clone the repository.
-	`powershell` version 5 or above to, well, run the build script and to use the module.
-	`dotnet cli` to build the part of the module that's written in `C#`.

```powershell
git clone https://github.com/insomnimus/ps-itertools
cd ps-itertools

./build.ps1

# Import the module
import-module ./Itertools
```

# Documentation
See [here](documentation.md) for every cmdlet in one page.

See [here](docs/) to view the cmdlets separately.

# Commands Overview
- `Add-Index`: Adds numbers to the items from the pipeline.
- `Chain-Pipe`: Adds a collection of items to the end of the current pipeline.
- `Join-Pipe`: Zips items from the pipe with the items in a collection.
- `Measure-Count`: Counts the number of items in a collection or the pipeline.
- `Measure-Max`: Calcualtes the object with the maximum value.
- `Measure-Min`: Calculates the object with the lowest value.
- `Skip-Item`: Skips items from the pipeline.
- `Switch-Pipe`: Alternates between the pipe and a collection.
- `Take-Item`: Takes items from the pipeline.
- `Test-All`: Asserts that every item from the pipeline fits within a criteria.
- `Test-Any`: Tests if any item from the pipeline fits within the criteria given.
- `Test-None`: Tests if no item in the pipeline satisfies the criteria given.

