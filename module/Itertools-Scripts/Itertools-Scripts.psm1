function Assert-Pipe {
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
		HelpMessage = "Assert that the pipeline fits the given criteria with this value.")]
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
		$stopped = $false
	}

	process {
		if($stopped) {
			return
		}
		$val = (($isScript -and (foreach-object -process $predicate -inputObject $input)) -or
		(-not $isScript -and ($input -eq $eq)))

		if(($all -and -not $val) -or ($none -and $val)) {
			write-output $false
			$stopped = $true
		} elseif($any -and $val) {
			write-output $true
			$stopped = $true
		}
	}

	end {
		if(!$stopped) {
			write-output (!$any)
		}
	}
}
