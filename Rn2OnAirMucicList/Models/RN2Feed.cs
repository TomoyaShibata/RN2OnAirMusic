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
				var feedText = new List<String>();
				foreach (SyndicationItem item in feed.Items) {
					feedText.Add(item.Summary.Text);
				}

				var delimiter = new String[]{"<br />"};
				feedText.ForEach(text => {
					var l = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
					Debug.WriteLine(string.Join("", l));
				});

				return feed;
			}
		}
	}
}