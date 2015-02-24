using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rn2OnAirMucicList.Const {
	public class RN2Site {
		public const string FEED_URI   = "http://www.radionikkei.jp/musicrn2/rss2/";
		public const string TIME_REGEX = @"＜.*＞$"; // ＜ で始まり ＞ で終わる単語に一致
		public const string MUSIC_INFO_DELIMITER= @"/";
	}
}