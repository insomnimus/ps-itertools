using System;
using System.Management.Automation;

namespace Itertools;

[Cmdlet(VerbsCommon.Add, "Index")]
[OutputType(typeof(IndexEntry))]
public class AddIndexCmd: PipeCmdlet {
	[Parameter(HelpMessage = "The starting index.")]
	public int StartingIndex = 0;
	[Parameter(HelpMessage = "the value that will be added to the current index each iteration.")]
	public int Step = 1;

	protected override void ProcessRecord() {
		WriteObject(new IndexEntry {
			Index = this.StartingIndex,
			Value = this.input
		});
		this.StartingIndex += this.Step;
	}
}

public struct IndexEntry {
	public int Index;
	public Object Value;

	public override string ToString() => $"{this.Index} - {this.Value}";
}
