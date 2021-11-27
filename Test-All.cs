using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;

namespace Itertools {
	[Cmdlet(VerbsDiagnostic.Test, "All", DefaultParameterSetName = "script")]
	[OutputType(typeof(bool))]
	public class TestAllCmd: PSCmdlet {
		[Parameter(
		ParameterSetName = "script",
		Mandatory = true,
		Position = 0,
		HelpMessage = "A predicate that evaluates to a bool."
		)]
		public ScriptBlock Predicate;
		[Parameter(
		ParameterSetName = "eq",
		Mandatory = true,
		Position = 0,
		HelpMessage = "Test that all values from the pipeline are equal to this one."
		)]
		public Object Value;

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
				if (Predicate != null) {
					var vars = new List<PSVariable>(){
					new PSVariable("_", Input)
				};
					var result = Predicate.InvokeWithContext(null, vars);
					if (result == null || result.Count == 0 || !result[result.Count - 1].Equals(true)) {
						stopped = true;
						WriteObject(false);
					}
				} else if (!Input.Equals(Value)) {
					WriteObject(false);
					stopped = true;
				}
			}
		}

		protected override void EndProcessing() {
			if (!stopped) WriteObject(true);
		}
	}
}
