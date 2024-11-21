namespace BPMSoft.Configuration
{
	using BPMSoft.Configuration.CESModels;
	using System.Linq;
	using System.Collections.Generic;
	using BPMSoft.Configuration.Mailing;

	#region Class: CESUtilities

	/// <summary>
	/// Contains utility methods to work with CES.
	/// </summary>
	public static class CESUtilities 
	{
		
		#region Methods: Public

		/// <summary>
		/// Converts collection of <see cref="Mailing.Base64Image"/> to collection of <see cref="CES.image"/>.
		/// </summary>
		/// <param name="imageList">Collection of <see cref="Mailing.Base64Image"/>.</param>
		/// <returns>Collection of <see cref="CES.image"/>.</returns>
		public static IEnumerable<image> ToCESImage(this IEnumerable<Base64Image> imageList) {
			return imageList.Select<Base64Image, image>(item => item.ToCESImage());
		}

		/// <summary>
		/// Converts <see cref="Mailing.Base64Image"/> to <see cref="CES.image"/>.
		/// </summary>
		/// <param name="base64Image">Instance of <see cref="Mailing.Base64Image"/>.</param>
		/// <returns><see cref="CES.image"/>.</returns>
		public static image ToCESImage(this Base64Image base64Image) {
			return new image() {
				content = base64Image.Content,
				type = base64Image.MimeType,
				name = base64Image.Name
			};
		}

		/// <summary>
		/// Returns template size in bytes includiong attached images.
		/// </summary>
		/// <param name="messageTemplate">Template text.</param>
		/// <param name="messageImages">Template images.</param>
		/// <returns>Size in bytes.</returns>
		public static int GetTemplateSize(string messageTemplate, List<image> messageImages) {
			int result = System.Text.ASCIIEncoding.UTF8.GetByteCount(messageTemplate);
			if (messageImages == null) {
				return result;
			}
			foreach (var image in messageImages) {
				result += System.Text.ASCIIEncoding.UTF8.GetByteCount(image.name);
				result += System.Text.ASCIIEncoding.UTF8.GetByteCount(image.type);
				result += System.Text.ASCIIEncoding.UTF8.GetByteCount(image.content);
			}
			return result;
		}

		#endregion
	}

	#endregion
}

