namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: PortalMessageFileCleaner

	public class PortalMessageFileCleaner
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="PortalMessageFileCleaner"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public PortalMessageFileCleaner(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Deletes portal message file by given identifier of portal message file.
		/// </summary>
		/// <param name="portalMessageFileId">Identifier of portal message file.</param>
		/// <returns>True, if file was deleted, otherwise - false.</returns>
		public bool DeletePortalMessageFile(Guid portalMessageFileId) {
			return new Delete(_userConnection)
				.From("PortalMessageFile")
					.Where("Id")
						.IsEqual(Column.Parameter(portalMessageFileId))
					.And("CreatedById")
						.IsEqual(Column.Parameter(_userConnection.CurrentUser.ContactId))
				.Execute() > 0 ? true : false;
		}

		#endregion

	}

	#endregion

}
