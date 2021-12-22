@{
	RootModule = "Itertools.psm1"
	ModuleVersion = "0.1.0"
	Author = "Taylan Gökkaya<insomnimus.dev@gmail.com>"
	Copyright = "Copyrighred under the terms of the MIT license."
	Description = "A collection of iterator adaptors for PowerShell pipelines."

	CompatiblePSEditions = @("Core")
	PowerShellVersion = "7.0"
	FunctionsToExport = "*"
	CmdletsToExport = "*"
	VariablesToExport = @()
	AliasesToExport = "*"

	NestedModules = @(
		"Itertools.dll"
		"comparison.ps1"
	)
}
