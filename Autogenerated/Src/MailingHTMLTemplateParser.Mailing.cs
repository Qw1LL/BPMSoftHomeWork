namespace BPMSoft.Configuration.Mailing
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	#region Class: MailingHTMLTemplateParser

	/// <summary>
	/// Provides utility methods for parsing and processing HTML templates.
	/// </summary>
	public class MailingHTMLTemplateParser
	{
		#region Constants: Private

		private const string ImgIdentifierPattern = "cid:{0}";
		private const string ImgNamePattern = "IMG{0}";
		private const string HtmlImageElementRegExp = @"<img.*?>";
		private const string HtmlImageElementSrcRegExp = "src=\".*?\"";
		private const string HtmlImageElementSrcPattern = "src=\"{0}\"";

		#endregion

		#region Methods: Private

		private static string ExtractImageSource(string htmlImage) {
			string imgSrc = string.Empty;
			if (!string.IsNullOrEmpty(htmlImage)) {
				Regex regexForImgSrc = 
					new Regex(HtmlImageElementSrcRegExp, RegexOptions.Multiline | RegexOptions.IgnoreCase);
				Match regexForImgSrcMatchResult = regexForImgSrc.Match(htmlImage);
				string matchedImgSrcString = regexForImgSrcMatchResult.Value;
				if (!string.IsNullOrEmpty(matchedImgSrcString)) {
					imgSrc = matchedImgSrcString.Replace("\"", string.Empty);
					imgSrc = imgSrc.Replace("src=", string.Empty);
				}
			}
			return imgSrc;
		}

		/// <summary>
		/// Parses src html text on match the string representation of HTMLImageElement.
		/// </summary>
		/// <param name="src">Source html.</param>
		/// <returns>Collection of HTMLImageElement matches.</returns>
		private static MatchCollection GetHtmlImgMatches(string src) {
			Regex regexForImgTag = new Regex(HtmlImageElementRegExp, RegexOptions.Singleline | RegexOptions.IgnoreCase);
			return regexForImgTag.Matches(src);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Parses src html text and returns found images in base64 representation.
		/// </summary>
		/// <param name="src">Source html.</param>
		/// <param name="imageParsers">Collection of parsers for different representation of the image sources.</param>
		/// <returns>Collection of the parsed images in base64 format with its source as a key.</returns>
		public static Dictionary<string, Base64Image> ExtractInlineImages(string src,
				IEnumerable<IBase64ImageParser> imageParsers) {
			Dictionary<string, Base64Image> result = new Dictionary<string, Base64Image>();
			int cidCounter = 0;
			foreach (Match imgMatch in GetHtmlImgMatches(src)) {
				Base64Image base64Image = null;
				string imgSrc = ExtractImageSource(imgMatch.Value);
				foreach (IBase64ImageParser parser in imageParsers) {
					if (parser.TryParse(imgSrc, out base64Image)) {
						break;
					}
				}
				if (base64Image != null) {
					if (!result.ContainsKey(imgSrc)) {
						cidCounter++;
						base64Image.Name = string.Format(ImgNamePattern, cidCounter);
						result[imgSrc] = base64Image;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Replaces inline images in source with theirs alias in InlineImages collection.
		/// </summary>
		/// <param name="src">Source html.</param>
		/// <param name="inlineImages">List of inline images.</param>
		/// <returns>Processed html.</returns>
		public static string ReplaceInlineImagesByContentId(string src, Dictionary<string, Base64Image> inlineImages) {
			foreach (KeyValuePair<string, Base64Image> image in inlineImages) {
				string imgIdentifier = string.Format(ImgIdentifierPattern, image.Value.Name);
				string imgOldSrc = string.Format(HtmlImageElementSrcPattern, image.Key);
				string imgNewSrc = string.Format(HtmlImageElementSrcPattern, imgIdentifier);
				src = src.Replace(imgOldSrc, imgNewSrc);
			}
			return src;
		}

		#endregion

	}
	#endregion

}

