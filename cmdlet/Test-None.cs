using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;

namespace Itertools;

[Cmdlet(VerbsDiagnostic.Test, "None", DefaultParameterSetName = "script")]
[OutputType(typeof(bool))]
public class TestNoneCmd: PipeCmdlet {
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
	HelpMessage = "Test that no value from the pipeline is equal to this one."
	)]
	public Object Value;

	private bool stopped = false;

	protected override void ProcessRecord() {
		if (!stopped) {
			if (this.Predicate is not null) {
				var result = Predicate.InvokeWithContext(null, this.pipeVar);
				if (result is not null && result.Count != 0 && result[0].Equals(true)) {
					this.stopped = true;
					this.WriteObject(false);
				}
			} else if (this.input.Equals(this.Value)) {
				this.WriteObject(false);
				stopped = true;
			}
		}
	}

	protected override void EndProcessing() {
		if (!stopped) this.WriteObject(true);
	}
}
