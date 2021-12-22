using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Itertools;

[Cmdlet("Fold", "Pipe")]
[OutputType(typeof(Object))]
public class FoldPipeCmd: PipeCmdlet {
	[Parameter(
	Mandatory = true,
	Position = 0,
	HelpMessage = "A script block that takes 1 argument (the last item calculated) and the access to the pipeline ($_)."
	)]
	public ScriptBlock ScriptBlock;
	[Parameter(HelpMessage = "An optional initial value.")]
	public Object InitialValue;

	private Object acc;

	protected override void BeginProcessing() {
		if (this.InitialValue is not null) this.acc = this.InitialValue;
	}

	protected override void ProcessRecord() {
		if (this.acc is null) {
			this.acc = this.input;
		} else {
			var vars = new List<PSVariable>() {
				new PSVariable("_", this.input),
				new PSVariable("__", this.acc)
			};
			var output = this.ScriptBlock.InvokeWithContext(null, vars, new Object[] { this.acc });
			if (output is not null && output.Count > 0) this.acc = output[output.Count - 1];
		}
	}

	protected override void EndProcessing() {
		this.WriteObject(this.acc);
	}
}
