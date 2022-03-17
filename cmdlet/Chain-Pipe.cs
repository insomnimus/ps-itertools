using System;
using System.Management.Automation;

namespace Itertools;

[Cmdlet("Chain", "Pipe", DefaultParameterSetName = "script")]
[OutputType(typeof(Object))]
public class ChainPipeCmd: PipeCmdlet {
	[Parameter(
Mandatory = true,
Position = 0,
HelpMessage = "A collection of objects to chain at the end of this pipe.",
ParameterSetName = "collection"
)]
	public Object[] Values;
	[Parameter(
	Mandatory = true,
	Position = 0,
	HelpMessage = "A script block that yields values. Will be called after the pipe is depleted.",
	ParameterSetName = "script"
	)]
	public ScriptBlock ScriptBlock;

	protected override void ProcessRecord() {
		this.WriteObject(this.input);
	}

	protected override void EndProcessing() {
		if (this.ParameterSetName == "collection") {
			foreach (var x in this.Values) this.WriteObject(x);
		} else {
			this.WriteVerbose("invoking the scriptblock");
			var output = this.ScriptBlock.Invoke();
			foreach (var x in output) this.WriteObject(x);
		}
	}
}
