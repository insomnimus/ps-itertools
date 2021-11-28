using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Itertools {
	[Cmdlet(VerbsCommon.Switch, "Pipe")]
	[OutputType(typeof(Object))]
	public class SwitchPipeCmd: PSCmdlet {
		[Parameter(
			Mandatory = true,
			Position = 1,
			HelpMessage = "The input from the pipeline.",
			ValueFromPipeline = true)]
		public Object Input;
		[Parameter(
		Mandatory = true,
		Position = 0,
		HelpMessage = "A collection to alternate with."
		)]
		public List<Object> ValuesRight { get; set; }

		[Parameter(
		HelpMessage = "How many items to take from the left pipe in each alternation."
		)]
		[ValidateRange(0, int.MaxValue / 1024)]
		public int Left { get; set; } = 1;
		[Parameter(
		HelpMessage = "How many items to take from the right collection in each alternation."
		)]
		[ValidateRange(0, int.MaxValue / 1024)]
		public int Right { get; set; } = 1;
		[Parameter(
		HelpMessage = "Discard leftover items if left or right are drained before the other."
		)]
		public SwitchParameter DiscardRest { get; set; }

		private int rIndex = 0;
		private List<Object> leftValues;
		private bool stopped = false;
		private int lCount => leftValues.Count;

		protected override void BeginProcessing() {
			stopped = Left == 0 || (DiscardRest && ValuesRight.Count == 0);
			if (!stopped) {
				leftValues = new List<Object>(Left) { };
			}
			if (Left == 0 && Right > 0) {
				var upto = ValuesRight.Count;
				if (DiscardRest) {
					upto = ValuesRight.Count - (ValuesRight.Count % Right);
				}
				for (int i = 0; i < upto; i++) {
					WriteObject(ValuesRight[i]);
				}
				rIndex = ValuesRight.Count;
			}
		}

		protected override void ProcessRecord() {
			if (stopped || (DiscardRest && rIndex + Right > ValuesRight.Count)) {
				stopped = true;
				return;
			}

			if (lCount == Left - 1) {
				foreach (var x in leftValues) {
					WriteObject(x);
				}
				WriteObject(Input);
				leftValues.Clear();

				for (int i = 0; rIndex < ValuesRight.Count && i < Right; i++) {
					WriteObject(ValuesRight[rIndex]);
					rIndex++;
				}
			} else {
				leftValues.Add(Input);
			}
		}

		protected override void EndProcessing() {
			if (!stopped && !DiscardRest) {
				foreach (var x in leftValues) {
					WriteObject(x);
				}
				for (; rIndex < ValuesRight.Count && Right > 0; rIndex++) {
					WriteObject(ValuesRight[rIndex]);
				}
			}
		}

	}
}
