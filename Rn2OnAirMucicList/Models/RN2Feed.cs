using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Rn2OnAirMucicList.Models {
	public class RN2Feed {
		private void Fiid() {
			FetchFeed();
		}

		/// <summary>
		/// RN2 のフィードを取得する
		/// </summary>
		/// <returns>RN2 フィード</returns>
		//public String GetFeed() {
		//	var feeds = new List<String>();
		//	using (XmlReader xmlReader = XmlReader.Create(Const.RN2Site.FEED_URI)) {
		//		var feed      = SyndicationFeed.Load(xmlReader);
		//		foreach (SyndicationItem item in feed.Items) {
		//			feeds.Add(item.Summary.Text);
		//		}

		//		var dic        = new Dictionary<String, String>();
		//		var cleandFeed = new List<String>();
		//		var brTag      = new String[] { "<br />" };
		//		feeds.ForEach(t => {
		//			var l = t.Split(brTag, StringSplitOptions.RemoveEmptyEntries);

		//		});
		//	}

		//	return feeds[0];
		//}

		public List<string> GetContext() {
			var feeds = FetchFeed();
			feeds.ForEach(l => {
				Debug.WriteLine("l: " + l);
				Trace.WriteLine("l: " + l);
			});

			return feeds;
		}

		private List<string> FetchFeed() {
			var feeds = new List<string>();
			using (XmlReader xmlReader = XmlReader.Create(Const.RN2Site.FEED_URI)) {
				var brTag = new string[] { "<br />" };
				var feed  = SyndicationFeed.Load(xmlReader);
				feeds.AddRange(feed.Items.Select(item =>
					item.Summary.Text.Split(brTag, StringSplitOptions.RemoveEmptyEntries).ToString()));
			}

			return feeds;
		}

		private Dictionary<string, List<string>> hoge(List<string> feeds) {
			var dic = new Dictionary<string, List<string>>();
			feeds.ForEach(l => {
				if (IsOnairTimeText(l)) {
					dic.Add(l, null);
					return;
				}

				if (!IsMucicInfoText(l)) return;
				dic.Last().Value.Add(l);
			});

			return dic;
		}

		/// <summary>
		/// 値が RN2 オンエア楽曲フィード本文の時間部かどうかチェックする
		/// </summary>
		/// <param name="l">フィードから抽出した1行</param>
		/// <returns></returns>
		private static bool IsOnairTimeText(string l) {
			return new Regex(Const.RN2Site.REGEX_STR_ONAIR_TIME).IsMatch(l);
		}

		/// <summary>
		/// 値が RN2 オンエア楽曲フィード本文の曲タイトル/アーティスト部かどうかチェックする
		/// </summary>
		/// <param name="l">フィードから抽出した1行</param>
		/// <returns></returns>
		private static bool IsMucicInfoText(string l) {
			return l.Contains(Const.RN2Site.MUSIC_INFO_DELIMITER);
		}
	}
}