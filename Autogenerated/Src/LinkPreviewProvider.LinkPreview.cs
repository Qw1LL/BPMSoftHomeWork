using System;
using System.Text;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using Newtonsoft.Json;

namespace BPMSoft.Configuration
{
	#region Class: LinkPreviewProvider

	/// <summary>
	/// Class for provide link preview data.
	/// </summary>
	public class LinkPreviewProvider
	{
		
		#region Constants: Private

		/// <summary>
		/// Link preview info data entity schema name.
		/// </summary>
		const string _linkPreviewDataEntityName = "LinkPreviewData";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates new LinkPreviewProvider instance.
		/// </summary>
		/// <param name="userConnection">UserConnection instance.</param>
		/// <returns>LinkPreviewProvider instance.</returns>
		public LinkPreviewProvider(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Save link preview info by entity record id.
		/// </summary>
		/// <param name="linkPreviewInfo">Link preview info.</param>
		/// <param name="entityRecordId">Entity record id.</param>
		/// <returns>New link preview info record id.</returns>
		public Guid SaveLinkPreviewInfo(LinkPreviewInfo linkPreviewInfo, Guid entityRecordId) {
			string data = JsonConvert.SerializeObject(linkPreviewInfo);
			Guid id = Guid.NewGuid();
			var insert = 
				new Insert(_userConnection)
				.Into(_linkPreviewDataEntityName)
					.Set("Id", Column.Parameter(id))
					.Set("Url", Column.Parameter(linkPreviewInfo.Url))
					.Set("EntityId", Column.Parameter(entityRecordId))
					.Set("Data", Column.Parameter(Encoding.UTF8.GetBytes(data)));
			insert.Execute();
			return id;
		}

		/// <summary>
		/// Delete link preview info by entity record id.
		/// </summary>
		/// <param name="entityRecordId">Entity record id.</param>
		public void DeleteLinkPreviewInfo(Guid entityRecordId) {
			var delete = 
				new Delete(_userConnection)
				.From(_linkPreviewDataEntityName)
				.Where("EntityId").IsEqual(Column.Parameter(entityRecordId));
			delete.Execute();
		}

		#endregion
	}

	#endregion
}
