
using System.Collections.Generic;

namespace app.web.application
{
	public interface IMapToAnotherObject<MappableChild>
	{
		IEnumerable<MappableChild> GetChildren();
	}
}
