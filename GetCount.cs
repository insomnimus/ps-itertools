using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Itertools {
	[Cmdlet(VerbsCommon.Get, "Count")]
	[OutputType(typeof(int))]
	public class GetCountCmd: PSCmdlet {
		[Parameter(
			Mandatory = true,
			Position = 0,
			ValueFromPipeline = true,
			ValueFromPipelineByPropertyName = true)]
		public Object Item { get; set; }
		private int CurrentIndex { get; set; } = 0;

		protected override void ProcessRecord() {
			CurrentIndex++;
		}

		protected override void EndProcessing() {
			WriteObject(CurrentIndex);
		}
	}
}
