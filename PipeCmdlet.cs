using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Itertools;

public abstract class PipeCmdlet: PSCmdlet {
	[Parameter(
	Mandatory = true,
	ValueFromPipeline = true,
	ValueFromPipelineByPropertyName = true,
	HelpMessage = "The input object."
	)]
	public Object InputObject { get; set; }

	internal Object input => this.InputObject;
	internal List<PSVariable> pipeVar => new List<PSVariable>() { new PSVariable("_", this.input) };
}
