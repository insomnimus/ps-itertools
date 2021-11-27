using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Itertools {
	[Cmdlet(VerbsCommon.Add, "Index")]
	[OutputType(typeof(IndexEntry))]
	public class AddIndexCmd: PSCmdlet {
		[Parameter(
			Mandatory = true,
			Position = 0,
			ValueFromPipeline = true,
			HelpMessage = "The input from the pipeline.",
			ValueFromPipelineByPropertyName = true)]
		public Object Input;
		[Parameter(
		HelpMessage = "The starting index."
		)]
		public int StartingIndex = 0;
		[Parameter(
		HelpMessage = "the value that will be added to the current index each iteration."
		)]
		public int Step = 1;

		protected override void ProcessRecord() {
			WriteObject(new IndexEntry {
				Index = StartingIndex,
				Item = Input
			});
			StartingIndex += Step;
		}
	}

	public class IndexEntry {
		public int Index;
		public Object Item;

		public override string ToString() {
			return $"{Index} - {Item}";
		}
	}
}
