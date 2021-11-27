using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;

namespace Itertools {
	[Cmdlet(VerbsDiagnostic.Test, "All")]
	[OutputType(typeof(bool))]
	public class TestAllCmd: PSCmdlet {
		[Parameter(
		Mandatory = true,
		Position = 0,
		HelpMessage = "A predicate that evaluates to a bool."
		)]
		public ScriptBlock Predicate;
		[Parameter(
			Mandatory = true,
			Position = 1,
			ValueFromPipeline = true,
			HelpMessage = "The input from the pipeline."
			)]
		public Object Input;

		private bool stopped = false;

		protected override void ProcessRecord() {
			if (!stopped) {
				var vars = new List<PSVariable>(){
					new PSVariable("_", Input)
				};
				var result = Predicate.InvokeWithContext(null, vars);
				if (result == null || result.Count == 0 || !result[result.Count - 1].Equals(true)) {
					stopped = true;
					WriteObject(false);
				}
			}
		}

		protected override void EndProcessing() {
			if (!stopped) WriteObject(true);
		}
	}
}
