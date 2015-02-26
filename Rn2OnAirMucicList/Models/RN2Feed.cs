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
				var feed      = SyndicationFeed.Load(xmlReader);
				var feedTexts = new List<String>();
				foreach (SyndicationItem item in feed.Items) {
					feedTexts.Add(item.Summary.Text);
				}

				var delimiter = new String[]{"<br />"};
				feedTexts.ForEach(t => {
					var l = t.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
					Debug.WriteLine(IsOnairTimeText(t));
					Debug.WriteLine(IsMucicInfoText(t));
					Debug.WriteLine(string.Join("", t));
				});

				return feed;
			}
		}

		/// <summary>
		/// 値が RN2 オンエア楽曲フィード本文の時間部かどうかチェックする
		/// </summary>
		/// <param name="text">フィードから抽出した1行</param>
		/// <returns></returns>
		private bool IsOnairTimeText(String text) {
			return Const.RN2Site.ONAIR_TIME_RGX.IsMatch(text);
		}

		/// <summary>
		/// 値が RN2 オンエア楽曲フィード本文の曲タイトル/アーティスト部かどうかチェックする
		/// </summary>
		/// <param name="text">フィードから抽出した1行</param>
		/// <returns></returns>
		private bool IsMucicInfoText(String text) {
			return text.Contains(Const.RN2Site.MUSIC_INFO_DELIMITER);
		}
	}
}