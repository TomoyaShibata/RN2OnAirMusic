using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Diagnostics;

namespace Rn2OnAirMucicList.Models {
	public class RN2Feed {
		private void Fiid() {
			GetFeed();
		}

		/// <summary>
		/// RN2のフィードを取得する
		/// </summary>
		/// <returns>RN2フィード</returns>
		public SyndicationFeed GetFeed() {
			var feeds = new List<String>();
			using (XmlReader xmlReader = XmlReader.Create(Const.RN2Site.FEED_URI)) {
				var feed = SyndicationFeed.Load(xmlReader);
				var feedTexts = new List<String>();
				foreach (SyndicationItem item in feed.Items) {
					feedTexts.Add(item.Summary.Text);
				}

				var delimiter = new String[]{"<br />"};
				feedTexts.ForEach(t => {
					var l = t.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
					Debug.WriteLine(string.Join("", t));
				});

				return feed;
			}
		}
	}
}