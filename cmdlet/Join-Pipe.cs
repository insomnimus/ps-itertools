using System;
using System.Management.Automation;
using Itertools.DataTypes;

namespace Itertools;

[Cmdlet(VerbsCommon.Join, "Pipe", DefaultParameterSetName = "script")]
[OutputType(typeof(Zip))]
public class JoinPipeCmd: PipeCmdlet {
	[Parameter(
	Mandatory = true,
	Position = 0,
	HelpMessage = "A collection to join with the current pipe.",
	ParameterSetName = "collection"
	)]
	public Object[] ValuesRight;
	[Parameter(
	Mandatory = true,
	Position = 0,
	HelpMessage = "A script block with access to the pipeline ($_) that will yield a value.",
	ParameterSetName = "script"
	)]
	public ScriptBlock ScriptBlock;

	private int idx = 0;
	private bool isScript;

	private Option<Zip> nextValue() {
		if (this.isScript) {
			var output = this.ScriptBlock.InvokeWithContext(null, this.pipeVar, new Object[] { });
			if (output is null || output.Count == 0)
				return new Zip(this.input, null);
			else if (output.Count == 1)
				return new Zip(this.input, output[0]);
			else return new Zip(this.input, output);
		} else if (this.idx >= this.ValuesRight.Length) {
			return Option<Zip>.None;
		} else {
			var x = new Zip(this.input, this.ValuesRight[this.idx]);
			this.idx++;
			return x;
		}
	}

	protected override void BeginProcessing() {
		this.isScript = this.ParameterSetName == "script";
	}

	protected override void ProcessRecord() => this.nextValue().Map(x => this.WriteObject(x));
}

public struct Zip {
	public Zip(Object left, Object right) => (this.Left, this.Right) = (left, right);

	public Object Left;
	public Object Right;

	public override string ToString() => $"({this.Left}, {this.Right})";
}
