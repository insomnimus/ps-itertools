using System;
using System.Management.Automation;
using System.Collections.Generic;
using Itertools.RingBuffer;

namespace Itertools {
	[Cmdlet("Take", "Item", DefaultParameterSetName = "number")]
	[OutputType(typeof(Object))]
	public class TakeItemCmd: PSCmdlet {
		[Parameter(
		ParameterSetName = "number",
Mandatory = true,
Position = 0,
HelpMessage = "How many items to take."
)]
		[ValidateRange(0, int.MaxValue - 1)]
		public int N;
		[Parameter(
		ParameterSetName = "number",
		HelpMessage = "Take last N items instead."
		)]
		public SwitchParameter Last;

		[Parameter(
		ParameterSetName = "script",
		Mandatory = true,
		Position = 0,
		HelpMessage = "Take items while this script block evaluates to true."
		)]
		public ScriptBlock While;

		[Parameter(
			Mandatory = true,
			HelpMessage = "The input from the pipeline.",
			ValueFromPipeline = true)]
		public Object Input;

		private bool wLastVal = true;
		private int nTaken = 0;
		private RingBuf<Object> lastItems;

		protected override void BeginProcessing() {
			if (While == null && Last && N > 0) {
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
				if (wLastVal) {
					WriteObject(Input);
				}
			}
		}

		private void processN() {
			if (Last && N > 0) {
				lastItems.Push(Input);
			} else if (nTaken < N) {
				nTaken++;
				WriteObject(Input);
			}
		}

		protected override void EndProcessing() {
			if (Last && N > 0) {
				foreach (var x in lastItems) {
					WriteObject(x);
				}
			}
		}
	}
}
