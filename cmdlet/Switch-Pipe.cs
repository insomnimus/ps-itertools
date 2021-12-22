using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Itertools;

[Cmdlet(VerbsCommon.Switch, "Pipe")]
[OutputType(typeof(Object))]
public class SwitchPipeCmd: PipeCmdlet {
	[Parameter(
	Mandatory = true,
	Position = 0,
	HelpMessage = "A collection to alternate with."
	)]
	public Object[] Values;

	[Parameter(
	HelpMessage = "How many items to take from the left pipe in each alternation."
	)]
	[ValidateRange(0, int.MaxValue / 1024)]
	public int Left = 1;
	[Parameter(
	HelpMessage = "How many items to take from the right collection in each alternation."
	)]
	[ValidateRange(0, int.MaxValue / 1024)]
	public int Right = 1;
	[Parameter(
	HelpMessage = "Discard leftover items if left or right are drained before the other."
	)]
	public SwitchParameter DiscardRest { get; set; }

	private int rIndex = 0;
	private List<Object> leftValues;
	private bool stopped = false;
	private int lCount => leftValues.Count;

	protected override void BeginProcessing() {
		this.stopped = this.Left == 0 || (this.DiscardRest && this.Values.Length == 0);
		if (!stopped) {
			leftValues = new List<Object>(Math.Min(this.Left, 64)) { };
		}
		if (this.Left == 0 && this.Right > 0) {
			var upto = this.Values.Length;
			if (this.DiscardRest) {
				upto = this.Values.Length - (this.Values.Length % this.Right);
			}
			for (int i = 0; i < upto; i++) {
				this.WriteObject(this.Values[i]);
			}
			this.rIndex = this.Values.Length;
		}
	}

	protected override void ProcessRecord() {
		if (stopped || (DiscardRest && rIndex + Right > Values.Length)) {
			this.stopped = true;
			return;
		}

		if (lCount == Left - 1) {
			foreach (var x in this.leftValues) {
				this.WriteObject(x);
			}
			this.WriteObject(this.input);
			this.leftValues.Clear();

			for (int i = 0; rIndex < Values.Length && i < Right; i++) {
				this.WriteObject(this.Values[this.rIndex]);
				this.rIndex++;
			}
		} else {
			this.leftValues.Add(this.input);
		}
	}

	protected override void EndProcessing() {
		if (!stopped && !DiscardRest) {
			foreach (var x in leftValues) {
				this.WriteObject(x);
			}
			for (; this.rIndex < this.Values.Length && this.Right > 0; this.rIndex++) {
				this.WriteObject(this.Values[this.rIndex]);
			}
		}
	}
}
