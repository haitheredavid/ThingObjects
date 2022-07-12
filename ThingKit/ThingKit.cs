using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Speckle.Core.Kits;
using Thing.NoKit;

namespace Thing.Kit
{

	public class ThingKit : ISpeckleKit
	{

		public ThingKit()
		{
			var types = new List<Type>();
			var kitTypes = Assembly.GetExecutingAssembly().GetTypes();
			types.AddRange(kitTypes);
			var notInKitTypes = Assembly.GetAssembly(typeof(NotInKit)).GetTypes();
			types.AddRange(notInKitTypes);
			Types = types;
		}

		public ISpeckleConverter LoadConverter(string app) => throw new NotImplementedException();

		public IEnumerable<Type> Types { get; private set; }

		public IEnumerable<string> Converters { get; }

		public string Description { get; }

		public string Name { get; }

		public string Author { get; }

		public string WebsiteOrEmail { get; }
	}
}