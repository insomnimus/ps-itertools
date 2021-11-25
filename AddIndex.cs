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
			ValueFromPipelineByPropertyName = true)]
		public Object Item { get; set; }
		private int CurrentIndex { get; set; } = 0;

		// This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
		protected override void ProcessRecord() {
			WriteObject(new IndexEntry {
				Index = CurrentIndex,
				Item = Item
			});
			CurrentIndex++;
		}
	}

	public class IndexEntry {
		public int Index { get; set; }
		public Object Item { get; set; }
	}
}
