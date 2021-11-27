using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Itertools {
	[Cmdlet("Chain", "Pipe")]
	[OutputType(typeof(Object))]
	public class ChainPipeCmd: PSCmdlet {
		[Parameter(
Mandatory = true,
Position = 0,
HelpMessage = "A collection of objects to chain at the end of this pipe."
)]
		public List<Object> Values;

		[Parameter(
			Mandatory = true,
			HelpMessage = "The input from the pipeline.",
			Position = 1,
			ValueFromPipeline = true)]
		public Object Input;

		protected override void ProcessRecord() {
			WriteObject(Input);
		}

		protected override void EndProcessing() {
			WriteVerbose($"Chaining {Values.Count} items to the pipeline.");
			foreach (var x in Values) {
				WriteObject(x);
			}
		}
	}
}
