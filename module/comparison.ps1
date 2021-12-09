function Measure-Max {
	[CmdletBinding(DefaultParameterSetName = "pipe")]
	param(
		[Parameter(
			Mandatory,
			ValueFromPipeline,
			ParameterSetName = "pipe",
			HelpMessage = "The pipeline object.")]
		[object]$InputObject,
		[parameter(
			Mandatory,
			ValueFromRemainingArguments,
			ParameterSetName = "nopipe",
			HelpMessage = "A collection of objects.")]
		[object[]] $Items
	)

	begin {
		$isPipe = $PSCmdlet.ParameterSetName -eq "pipe"
		$max = $null
	}

	process {
		if(!$isPipe) {
			foreach($x in $items) {
				if($x -gt $max) {
					$max = $x
				}
			}
		} elseif($inputObject -gt $max) {
			$max = $inputObject
		}
	}

	end {
		$max
	}
}

function Measure-Min {
	[CmdletBinding(DefaultParameterSetName = "pipe")]
	[OutputType([object])]
	param(
		[Parameter(
			Mandatory,
			ValueFromPipeline,
			ParameterSetName = "pipe",
			HelpMessage = "The pipeline object.")]
		[object]$InputObject,
		[Parameter(
			Mandatory,
			ValueFromRemainingArguments,
			ParameterSetName = "nopipe",
			HelpMessage = "A collection of objects.")]
		[object[]] $Items
	)

	begin {
		$isPipe = $PSCmdlet.ParameterSetName -eq "pipe"
		$min = $isPipe ? $InputObject : $items[0]
	}

	process {
		if(!$isPipe) {
			foreach($x in $items[1..$items.length]) {
				if($x -lt $min) {
					$min = $x
				}
			}
		} elseif($min -eq $null -or $inputObject -lt $min) {
			$min = $inputObject
		}
	}

	end {
		$min
	}
}
