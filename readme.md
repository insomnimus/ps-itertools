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
