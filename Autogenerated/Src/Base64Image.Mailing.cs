namespace BPMSoft.Configuration.Mailing
{
	#region Class: Base64Image
	
	/// <summary>
	/// Image represented as base64 string.
	/// </summary>
	public class Base64Image
	{
		#region Constructors: Public
	
		/// <param name="mimeType">MIME-type of the image.</param>
		/// <param name="content">Content of the image.</param>
		public Base64Image(string mimeType, string content)
			: this(string.Empty, mimeType, content) {
		}
	
		/// <param name="name">Name of the image.</param>
		/// <param name="mimeType">MIME-type of the image.</param>
		/// <param name="content">Content of the image.</param>
		public Base64Image(string name, string mimeType, string content) {
			Name = name;
			MimeType = mimeType;
			Content = content;
		}
	
		#endregion
	
		#region Properties: Public
	
		/// <summary>
		/// Name of the image.
		/// </summary>
		public string Name {
			get;
			set;
		}
	
		/// <summary>
		/// Mime-type of the image.
		/// </summary>
		public string MimeType {
			get;
			set;
		}
	
		/// <summary>
		/// Content of the image.
		/// </summary>
		public string Content {
			get;
			set;
		}
	
		#endregion
	}
	
	#endregion
}
