using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
	public class CommandRegistry : IFindCommands
	{
		readonly IEnumerable<IProcessOneRequest> commands;
		readonly IProcessOneRequest fallback;

		public CommandRegistry(IEnumerable<IProcessOneRequest> commands, IProcessOneRequest fallback)
		{
			this.commands = commands;
			this.fallback = fallback;
		}

		public IProcessOneRequest get_the_command_that_can_process(IContainRequestInformation request)
		{
			var command = this.commands.FirstOrDefault(c => c.can_handle(request));
			if (command == null)
				return fallback;

			return command;
		}
	}
}