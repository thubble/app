using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
	public class CommandRegistry : IFindCommands
	{
		 IEnumerable<IProcessOneRequest> commands;
		 IProcessOneRequest fallback;

		public CommandRegistry(IEnumerable<IProcessOneRequest> commands, IProcessOneRequest fallback)
		{
			this.commands = commands;
			this.fallback = fallback;
		}

		public CommandRegistry()
			: this(Stub.with<StubSetOfCommands>(), Stub.with<StubMissingCommand>())
	  {
	  }

	  public IProcessOneRequest get_the_command_that_can_process(IContainRequestInformation request)
		{
		  return this.commands.FirstOrDefault(c => c.can_handle(request)) ?? fallback;
		}
	}
}