using System;
using System.Management.Automation;

namespace Itertools {
	[Cmdlet(VerbsDiagnostic.Measure, "Count",
DefaultParameterSetName = "nopipe")]
	[OutputType(typeof(uint))]
	public class MeasureCountCmd: PSCmdlet {
		[Parameter(
		ParameterSetName = "pipe",
Mandatory = true,
Position = 0,
HelpMessage = "The pipeline object.",
ValueFromPipeline = true,
ValueFromPipelineByPropertyName = true
)]
		public object InputObject;
		[Parameter(
		ParameterSetName = "nopipe",
		HelpMessage = "A collection of items to count.",
		Mandatory = true,
		Position = 0
		)]
		public object[] Items;

		private uint n = 0;
		private bool ispipe = false;

		protected override void BeginProcessing() {
			ispipe = base.ParameterSetName == "pipe";
			n = ispipe ? 0 : (uint)Items.Length;
		}

		protected override void ProcessRecord() {
			if (ispipe) n++;
		}

		protected override void EndProcessing() {
			WriteObject(n);
		}
	}
}
