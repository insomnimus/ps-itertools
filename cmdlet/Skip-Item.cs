using System;
using System.Management.Automation;
using System.Collections.Generic;
using Itertools.DataTypes;

namespace Itertools;

[Cmdlet(VerbsCommon.Skip, "Item", DefaultParameterSetName = "number")]
[OutputType(typeof(Object))]
public class SkipItemCmd: PipeCmdlet {
	[Parameter(
	ParameterSetName = "number",
Mandatory = true,
Position = 0,
HelpMessage = "How many items to skip."
)]
	[ValidateRange(0, int.MaxValue - 1)]
	public int N;
	[Parameter(
	ParameterSetName = "number",
	HelpMessage = "Skip last N items instead."
	)]
	public SwitchParameter Last;

	[Parameter(
	ParameterSetName = "script",
	Mandatory = true,
	Position = 0,
	HelpMessage = "Skip items while this script block evaluates to true."
	)]
	public ScriptBlock While;

	private bool wLastVal = true;
	private int nSkipped = 0;
	private MemBuf<Object> lastItems;
	private bool isScript;

	protected override void BeginProcessing() {
		this.isScript = this.ParameterSetName == "script";
		if (this.ParameterSetName == "number" && this.Last && this.N > 0) {
			this.lastItems = new MemBuf<Object>((uint)this.N);
		}
	}

	protected override void ProcessRecord() {
		if (this.isScript) {
			this.processWhile();
		} else {
			this.processN();
		}
	}

	private void processWhile() {
		if (this.wLastVal) {
			var result = this.While.InvokeWithContext(null, this.pipeVar);
			this.wLastVal = result != null && result.Count != 0 && result[result.Count - 1].Equals(true);
			if (!this.wLastVal) {
				this.WriteObject(this.input);
			}
		} else {
			this.WriteObject(this.input);
		}
	}

	private void processN() {
		if (this.Last && this.N > 0) {
			if (this.lastItems.Length == this.N) {
				this.WriteObject(this.lastItems[0]);
			}
			lastItems.Add(this.input);
		} else if (this.nSkipped < this.N) {
			this.nSkipped++;
		} else {
			this.WriteObject(this.input);
		}
	}
}
