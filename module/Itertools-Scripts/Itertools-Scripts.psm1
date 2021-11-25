function Assert-Value {
	[CmdletBinding(DefaultParameterSetName = "script")]
	param(
	[parameter(Mandatory, ValueFromPipeline)]
	[object]$Input,
		[parameter(ParameterSetName = "script",
		Mandatory,
		Position = 0,
		HelpMessage = "A script block returning a boolean.")]
		[ScriptBlock]$Predicate,
		[parameter(ParameterSetName = "value",
		Mandatory,
		Position = 0,
		HelpMessage = "Assert that every item in the pipeline is the same as this one.")]
		[object]$Eq,
		[parameter(Position = 1,
		HelpMessage = "Assertion criteria. 'all' means every object in the pipeline must satisfy the predicate; 'any' means any is sufficient and 'none' is the exact opposite of 'all'.")]
		[ValidateSet("all", "any", "none")]
		[string]$Criteria = "all"
	)

	begin {
		$isScript = $PSCmdlet.ParameterSetName -eq "script"
		switch($criteria) {
			"all" { $all=$true; break }
			"any" { $any=$true; break }
			default { $none=$true}
		}
	}

	process {
		$val = (($isScript -and (foreach-object -process $predicate -inputObject $input)) -or
		(-not $isScript -and ($input -eq $eq)))

		if(($all -and -not $val) -or ($none -and $val)) {
			write-output $false
			break
		} elseif($any -and $val) {
			write-output $true
			break
		}
	}

	end {
		$out = $all -or $none
		write-output $out
	}
}
