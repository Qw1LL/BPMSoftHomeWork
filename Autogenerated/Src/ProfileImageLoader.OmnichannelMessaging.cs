namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.IO;
	using System.Net;
	using BPMSoft.Core;
	using BPMSoft.Core.ImageAPI;

	#region Class: ProfileImageLoader

	/// <summary>
	/// Class, that loads profile photo.
	/// </summary>
	public class ProfileImageLoader
	{
		#region Properties: Private

		private readonly IImageAPI _imageApi;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection	{
			get;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileImageLoader"/> class.
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/>.</param>
		/// </summary>
		public ProfileImageLoader(UserConnection userConnection)	{
			UserConnection = userConnection;
			_imageApi = new ImageAPI(UserConnection);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads profile photo from url.
		/// <param name="url">Url for downloading.</param>
		/// <param name="imageName">Image name.</param>
		/// <returns>Image identifier.</returns>
		/// </summary>
		public Guid GetProfilePhotoIdByUrl(string url, string imageName) {
			var imageId = Guid.NewGuid();
			WebRequest imageRequest = WebRequest.Create(url);
			using (WebResponse webResponse = imageRequest.GetResponse()) {
				using (Stream webResponseStream = webResponse.GetResponseStream()) {
					using (var imageMemoryStream = new MemoryStream())	{
						webResponseStream.CopyTo(imageMemoryStream);
						_imageApi.Save(imageMemoryStream, "image/png", imageName, imageId);
					}
				}
			}
			return imageId;
		}

		/// <summary>
		/// Saves profile image.
		/// </summary>
		/// <param name="stream">Stream of image data.</param>
		/// <param name="imageName">Name of image.</param>
		/// <returns>Saved image identifier.</returns>
		public Guid SaveImage(Stream stream, string imageName) {
			var imageId = Guid.NewGuid();
			_imageApi.Save(stream, "image/png", imageName, imageId);
			return imageId;
		}

		#endregion

	}

	#endregion
}
