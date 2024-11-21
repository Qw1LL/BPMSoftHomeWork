namespace BPMSoft.Configuration.Mailing
{
	using System;
	using System.Text.RegularExpressions;

	#region Class: Base64ImageParser

	/// <summary>
	/// Represents class for parsing HTMLImageElement source that represented as base64 string into 
	/// <see cref="BPMSoft.Configuration.Mailing.Base64Image"/>.
	/// </summary>
	public class Base64ImageParser : IBase64ImageParser
	{
		#region Constants: Private

		private const string MimeTypeSearchPattern = @"(?<=^data:)image/[a-z]+";
		private const string Base64Src = "data:image";
		private const string Base64MimeTypePattern = "data:{0};base64,";

		#endregion

		#region Methods: Public

		/// <summary>
		/// Converts the string representation of an image in a 
		/// <see cref="BPMSoft.Configuration.Mailing.Base64Image"/>.
		/// </summary>
		/// <param name="src">Source of an image to convert.</param>
		/// <param name="image">Instance of the <see cref="BPMSoft.Configuration.Mailing.Base64Image"/> if 
		/// parsing was successful, otherwise null.</param>
		/// <returns>Returns true if parsing was successful, otherwise false.</returns>
		public bool TryParse(string src, out Base64Image image) {
			image = null;
			bool isParsed = false;
			if (src.StartsWith(Base64Src, StringComparison.OrdinalIgnoreCase)) {
				var regExp = new Regex(MimeTypeSearchPattern, RegexOptions.Singleline);
				string mimeType = regExp.Match(src).Value;
				isParsed = !string.IsNullOrEmpty(mimeType);
				if (isParsed) {
					string base64Type = string.Format(Base64MimeTypePattern, mimeType);
					string content = src.Replace(base64Type, string.Empty);
					image = new Base64Image(mimeType, content);
				}
			}
			return isParsed;
		}

		#endregion

	}

	#endregion

}
