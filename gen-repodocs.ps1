using namespace System.Management.Automation

param(
	[parameter(helpMessage = "Generate the readme file.")]
	[switch]$readme,
	[parameter(helpMessage = "Generate the documentation.md file.")]
	[switch]$docs
)

if(-not ($readme -or $docs)) {
	return
}

set-strictmode -version 3.0

class Command {
	[string]$name
	[string[]]$aliases
	[string]$description
	[string]$example
	[string]$synopsis

	Command([CmdletInfo]$cmd) {
		$this.name = $cmd.name
		$this.aliases = get-alias -definition $cmd.name
		$c = get-help $this.name
		$this.example = $c.examples[0].example.code
		$this.description = $c.description | out-string
		$this.description = $this.description.trim()
		$this.synopsis = $c.synopsis
	}

	Command([FunctionInfo]$cmd) {
		$this.name = $cmd.name
		$this.aliases = get-alias -definition $cmd.name
		$c = get-help $this.name
		$this.example = $c.examples[0].example.code
		$this.description = $c.description | out-string
		$this.description = $this.description.trim()
		$this.synopsis = $c.synopsis
	}

	[string] ToString() {
		$als = if($this.aliases) {
			$als = $this.aliases | % { "-  ``$_```n" } | join-string
			"### Aliases`n$als"
		} else {
			""
		}
		$s = @"
## $($this.name)
$($this.description)
$als
### Examples
``````powershell
$($this.example.trim())
``````
"@

		$s = $s.trim()
		return $s
	}
}

import-module -scope local -disableNameChecking "$PSScriptRoot/Itertools"

$mod = get-module itertools
$commands = @(
	$mod.ExportedCmdlets.getEnumerator() | % { [Command]::new([CmdletInfo] $_.value) }
	$mod.ExportedFunctions.GetEnumerator() | % { [Command]::new([FunctionInfo] $_.value) }
) `
| sort-object -property name

if($docs) {
	$gen = $commands | % { "$_" } | join-string -separator "`n`n"
	$gen > "$PSScriptRoot/documentation.md"
}

if($readme) {
	$shorts = $commands | % {
		"- ``$($_.name)``: $($_.synopsis)`n"
	} | join-string

	copy-item -force "$PSScriptROOT/readme.md.tpl" "$PSScriptroot/readme.md"
	echo $shorts >> "$PSScriptROOT/readme.md"
}
