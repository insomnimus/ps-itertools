using System;
using System.Management.Automation;
using System.Collections.Generic;
using Itertools.RingBuffer;

namespace Itertools {
	[Cmdlet(VerbsCommon.Skip, "Item", DefaultParameterSetName = "number")]
	[OutputType(typeof(Object))]
	public class SkipItemCmd: PSCmdlet {
		[Parameter(
		ParameterSetName = "number",
Mandatory = true,
Position = 0,
HelpMessage = "How many items to skip."
)]
		[ValidateRange(1, int.MaxValue - 1)]
		public int N;
		[Parameter(
		ParameterSetName = "number",
		HelpMessage = "Skip last N items instead."
		)]
		public SwitchParameter Last;

		[Parameter(
		ParameterSetName = "script",
		Mandatory = true,
		Position = 0,
		HelpMessage = "Skip items while this script block evaluates to true."
		)]
		public ScriptBlock While;

		[Parameter(
			Mandatory = true,
			HelpMessage = "The input from the pipeline.",
			ValueFromPipeline = true)]
		public Object Input;

		private bool wLastVal = true;
		private int nSkipped = 0;
		// private List<Object> items;
		private RingBuf<Object> lastItems;

		protected override void BeginProcessing() {
			if (While == null && Last) {
				// items = new List<Object>(Math.Min(N * 2, 8 * 1024)){};
				lastItems = new RingBuf<Object>(N);
			}
		}

		protected override void ProcessRecord() {
			if (While == null) {
				processN();
			} else {
				processWhile();
			}
		}

		private void processWhile() {
			if (wLastVal) {
				var vars = new List<PSVariable>() {
					new PSVariable("_", Input)
				};
				var result = While.InvokeWithContext(null, vars);
				wLastVal = result != null && result.Count != 0 && result[result.Count - 1].Equals(true);
				if (!wLastVal) {
					WriteObject(Input);
				}
			} else {
				WriteObject(Input);
			}
		}

		private void processN() {
			if (Last) {
				if (lastItems.Count == N) {
					WriteObject(lastItems[0]);
				}
				lastItems.Push(Input);
			} else if (nSkipped < N) {
				nSkipped++;
			} else {
				WriteObject(Input);
			}
		}
	}
}
