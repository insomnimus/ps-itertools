# Itertools
A collection of iterator adaptors for `powershell` pipelines.

# Building The Module
You will need:
-	`git` to clone the repository.
-	`powershell` version 7.0 or above to, well, run the build script and to use the module.
-	`dotnet cli` to build the part of the module that's written in `C#`.

```powershell
git clone https://github.com/insomnimus/ps-itertools
cd ps-itertools

./build.ps1 -release

# Import the module
import-module ./Itertools
```

# Documentation
See [here](documentation.md) for every cmdlet in one page.

See [here](docs/) to view the cmdlets separately.

# Commands Overview
- `Add-Index`: Enumerates items from the pipeline.
- `Chain-Pipe`: Appends items at the end of the pipeline.
- `Fold-Pipe`: Applies a reducing operation to every item in the pipeline, yielding a single value.
- `Join-Pipe`: Joins items from the pipeline with values from another collection or script.
- `Measure-Count`: Calculates the number of items in the pipeline, ignoring their values.
- `Measure-Max`: Finds the item with the highest value from the pipeline.
- `Measure-Min`: Finds the item with the lowest value in the pipeline.
- `Skip-Item`: Skips items from the pipeline.
- `Switch-Pipe`: Alternates between the pipeline and a collection.
- `Take-Item`: Takes items from the pipeline.
- `Test-All`: Tests if all items from the pipeline satisfy a predicate.
- `Test-Any`: Tests if any item from the pipeline satisfies a predicate.
- `Test-None`: Tests if no item from the pipeline satisfies a predicate.

