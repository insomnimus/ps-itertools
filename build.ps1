param(
	[switch]$release,
	[switch]$readme,
	[switch]$docs
)

$ErrorActionPreference = "stop"

function starts-with-space($s) {
	$s.length -eq 0 -or
	[char]::IsWhitespace($s.chars(0))
}

function build-project($cfg = "debug", $out) {
	$output = dotnet build --nologo --configuration $cfg --output $out 2>&1
	while(starts-with-space $output[0]) {
		$output = $output[1..($output.length)]
	}

	$output | % {
		echo $_.replace("$PSScriptRoot\", "")
	}
}

function copy-manifest($out) {
	copy-item -force -recurse "$PSScriptRoot/module/*" $out
}

$out = "$PSScriptRoot/Itertools"

if(test-path -pathType container $out) {
	remove-item -recurse $out
}

$cfg = if($release) {
	"release"
} else {
	"debug"
}

build-project $cfg $out

if($lastexitcode -eq 0) {
	copy-manifest $out
	echo "built the module into $out"
}

if($readme -or $docs) {
	&"$PSScriptRoot/gen-repodocs.ps1" -readme:$readme -docs:$docs
}
