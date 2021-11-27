using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Itertools {
	[Cmdlet(VerbsCommon.Join, "Pipe")]
	[OutputType(typeof(Zip))]
	public class JoinPipeCmd: PSCmdlet {
		[Parameter(
			Mandatory = true,
			Position = 1,
			ValueFromPipeline = true,
			ValueFromPipelineByPropertyName = true)]
		public Object Input;
		[Parameter(
		Mandatory = true,
		Position = 0,
		HelpMessage = "A collection to join with the current pipe."
		)]
		public List<Object> RightValues;
		private int CurrentIndex = 0;

		protected override void ProcessRecord() {
			if (CurrentIndex < RightValues.Count) {
				WriteObject(new Zip {
					Left = Input,
					Right = RightValues[CurrentIndex]
				});
				CurrentIndex++;
			}
		}
	}

	public class Zip {
		public Object Left { get; set; }
		public Object Right { get; set; }

		public override string ToString() {
			return $"({Left}, {Right})";
		}
	}
}
