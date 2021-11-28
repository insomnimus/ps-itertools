param(
	[switch]$release,
	[switch]$readme
)

function starts-with-space($s) {
	$s.length -eq 0 -or
	" `n`t`r".contains($s.chars(0))
}

function build-project($cfg = "debug", $out) {
	$output = dotnet build --nologo --configuration $cfg --output $out 2>&1
	while(starts-with-space $output[0]) {
		$output = $output[1..($output.length)]
	}

	$output | % {
		write-host $_.replace("$PSScriptRoot\", "")
	}

	return $lastExitCode
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

$code = build-project $cfg $out

if($code -eq 0) {
	copy-manifest $out
	echo "built the module into $out"
}

if($readme) {
	&"$PSScriptRoot/gen-repodocs.md" -readme
}
