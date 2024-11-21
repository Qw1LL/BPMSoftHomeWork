namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Core;
	using Core.Entities;

	#region Class: ContactLanguageRule

	/// <summary>
	/// Class, that provides language from contact user, that set in email template user task entity.
	/// </summary>
	public class EmailTemplateUserTaskSysAdminUnitLanguageRule : ILanguageRule
	{

		#region Properties: Public

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get; set;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="EmailTemplateUserTaskSysAdminUnitLanguageRule"/>.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/>instnce.</param>
		public EmailTemplateUserTaskSysAdminUnitLanguageRule(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Obtains language identifier from contact user, that set in email template user task.
		/// </summary>
		/// <inheritdoc />
		public Guid GetLanguageId(Guid entityRecordId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			var languageColumnName = esq.AddColumn("SysCulture.Language.Id").Name;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", entityRecordId));
			var sysAdminUnits = esq.GetEntityCollection(UserConnection);
			foreach (Entity sysAdminUnit in sysAdminUnits) {
				var languageId = sysAdminUnit.GetTypedColumnValue<Guid>(languageColumnName);
				return languageId;
				
			}
			return Guid.Empty;
		}

		#endregion

	}

	#endregion

}
