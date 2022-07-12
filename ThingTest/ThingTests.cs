using NUnit.Framework;
using Speckle.Core.Api;
using Thing.NoKit;
using Thing.Kit;

namespace Thing.Tests
{
	public class ThingTests
	{

		[Test]
		public void BasicTypes()
		{
			var kit = new ThingKit();
			Assert.IsNotEmpty(kit.Types);
		}

		[Test]
		public void BasicHandling()
		{
			var obj = new KitObj()
			{
				outside = new NotInKit
				{
					helpfulInt = 10, helpfulProp = 22, helpfulString = "Helpful Here"
				}
			};

			var res = Operations.Serialize(obj);
			Assert.IsNotNull(res);

			var de = Operations.Deserialize(res);
			Assert.IsNotNull(de);

			if (de is not KitObj hto)
			{
				Assert.Fail("Object is not of type");
				return;
			}

			Assert.IsTrue(
				hto.outside.helpfulInt == obj.outside.helpfulInt
				&& hto.outside.helpfulProp == obj.outside.helpfulProp
				&& hto.outside.helpfulString == obj.outside.helpfulString
			);
		}
	}
}