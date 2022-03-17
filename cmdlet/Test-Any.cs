using System;
using System.Management.Automation;

namespace Itertools;

[Cmdlet(VerbsDiagnostic.Test, "Any", DefaultParameterSetName = "script")]
[OutputType(typeof(bool))]
public class TestAnyCmd: PipeCmdlet {
	[Parameter(
	ParameterSetName = "script",
	Mandatory = true,
	Position = 0,
	HelpMessage = "A predicate that evaluates to a bool."
	)]
	public ScriptBlock Predicate;
	[Parameter(
	ParameterSetName = "eq",
	Mandatory = true,
	Position = 0,
	HelpMessage = "Test that any value from the pipeline is equal to this one."
	)]
	public Object Value;

	private bool stopped = false;

	protected override void ProcessRecord() {
		if (!stopped) {
			if (this.Predicate is not null) {
				var result = this.Predicate.InvokeWithContext(null, this.pipeVar);
				if (result is not null && result.Count != 0 && result[result.Count - 1].Equals(true)) {
					this.stopped = true;
					this.WriteObject(true);
				}
			} else if (this.input.Equals(this.Value)) {
				this.WriteObject(true);
				this.stopped = true;
			}
		}
	}

	protected override void EndProcessing() {
		if (!stopped) this.WriteObject(false);
	}
}
