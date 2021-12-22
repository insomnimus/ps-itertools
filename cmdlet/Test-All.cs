using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;

namespace Itertools;

[Cmdlet(VerbsDiagnostic.Test, "All", DefaultParameterSetName = "script")]
[OutputType(typeof(bool))]
public class TestAllCmd: PipeCmdlet {
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
	HelpMessage = "Test that all values from the pipeline are equal to this one."
	)]
	public Object Value;

	private bool stopped = false;

	protected override void ProcessRecord() {
		if (!stopped) {
			if (this.Predicate is not null) {
				var result = this.Predicate.InvokeWithContext(null, this.pipeVar);
				if (result is null || result.Count == 0 || !result[result.Count - 1].Equals(true)) {
					this.stopped = true;
					this.WriteObject(false);
				}
			} else if (!this.input.Equals(this.Value)) {
				this.WriteObject(false);
				this.stopped = true;
			}
		}
	}

	protected override void EndProcessing() {
		if (!stopped) this.WriteObject(true);
	}
}
