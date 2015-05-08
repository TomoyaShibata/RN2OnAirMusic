using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rn2OnAirMucicList.Models;

namespace Rn2OnAirMusicListTest {
	[TestClass]
	public class RN2FeedTest {
		[TestMethod]
		public void RN2のフィードが取得できる() {
			var rn2Feed = new RN2Feed();
			rn2Feed.GetContext();
		}
	}

}
