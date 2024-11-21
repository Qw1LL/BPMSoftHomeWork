namespace BPMSoft.Configuration.Mailing
{
	using System;
	using System.Linq;
	using System.IO;
	using System.Data;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.Text.RegularExpressions;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: FileServiceBase64ImageParser

	/// <summary>
	/// Represents class for parsing HTMLImageElement source that represented as relative uri string on internal 
	/// resource (that available via FileService) into <see cref="BPMSoft.Configuration.Mailing.Base64Image"/>.
	/// </summary>
	public class FileServiceBase64ImageParser : IBase64ImageParser
	{
		#region Constants: Private

		private const string EntitySchemaUIdParameterName = "entitySchemaUId";
		private const string RecordIdParameterName = "recordId";
		private const string UriPattern
			= @"^\.\.\/rest\/FileService\/GetFile\/(?<{0}>[0-9A-Fa-f\-]+)\/(?<{1}>[0-9A-Fa-f\-]+)";
		private readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		public FileServiceBase64ImageParser(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Regex GetRegex() {
			string regexStr = string.Format(UriPattern, EntitySchemaUIdParameterName, RecordIdParameterName);
			return new Regex(regexStr, RegexOptions.IgnoreCase);
		}

		private byte[] ReadData(Guid entitySchemaUId, Guid recordId) {
			var data = new byte[0];
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
			Entity entity = entitySchema.CreateEntity(UserConnection);
			Select selectData = new Select(UserConnection)
				.Column("Data")
				.From(entity.SchemaName)
				.Where("Id").IsEqual(Column.Parameter(recordId)) as Select;
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectData.ExecuteReader(executor)) {
					if (reader.Read()) {
						data = reader["Data"] as byte[];
					}
				}
			}
			return data;
		}

		private Guid GetRecordId(Match match) {
			string recordId = match.Groups[RecordIdParameterName].Value;
			return Guid.Parse(recordId);
		}

		private Guid GetEntitySchemaUId(Match match) {
			string entitySchemaUId = match.Groups[EntitySchemaUIdParameterName].Value;
			return Guid.Parse(entitySchemaUId);
		}

		private string GetImageMimeType(Image image) {
			ImageFormat format = image.RawFormat;
			ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(_ => _.FormatID == format.Guid);
			return codec.MimeType;
		}

		private Base64Image GetImage(Match match) {
			Guid entitySchemaUId = GetEntitySchemaUId(match);
			Guid recordId = GetRecordId(match);
			byte[] imageBytes = ReadData(entitySchemaUId, recordId);
			Image image;
			using (var ms = new MemoryStream(imageBytes)) {
				image = Image.FromStream(ms);
			}
			string content = Convert.ToBase64String(imageBytes);
			string mimeType = GetImageMimeType(image);
			return new Base64Image(mimeType, content);
		}

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
			var regExp = GetRegex();
			Match match = regExp.Match(src);
			if (match.Success) {
				try {
					image = GetImage(match);
					isParsed = true;
				} catch (Exception) { 
				}
			}
			return isParsed;
		}

		#endregion

	}

	#endregion

}
