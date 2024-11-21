namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;

	#region Class: LeadContactSynchronizer

	/// <summary>
	/// Syncronize contact throw lead process executing.
	/// </summary>
	public class LeadContactSynchronizer
	{
		#region Fields: Private

		private UserConnection _userConnection;
		private readonly List<string> _leadContactColumnNames;

		#endregion

		#region Constructor: Public

		public LeadContactSynchronizer(UserConnection userConnection) {
			_userConnection = userConnection;
			_leadContactColumnNames = new List<string> { "Contact", "MobilePhone", "Email", "JobId" };
		}

		#endregion

		#region Methods: Private

		private void UpdateQualifiedContact(Guid qualifiedContactId, List<KeyValuePair<string, object>> columnValues) {
			EntitySchema contactSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contactEntity = contactSchema.CreateEntity(_userConnection);
			if (contactEntity.FetchFromDB(qualifiedContactId)) {
				columnValues.ForEach(columnValue =>
					contactEntity.SetColumnValue(columnValue.Key, columnValue.Value));
				contactEntity.UseAdminRights = false;
				contactEntity.Save(false);
			}
		}

		private List<KeyValuePair<string, object>> GetContactColumnValues(IEnumerable<EntityColumnValue> leadChangedValues) {
			return leadChangedValues
				.Where(changedValue => _leadContactColumnNames.Contains(changedValue.Name))
				.Select(MapToContactColumnValues).ToList();
		}

		private KeyValuePair<string, object> MapToContactColumnValues(EntityColumnValue changedValue) {
			string key = changedValue.Name == "Contact" ? "Name" : changedValue.Name;
			return new KeyValuePair<string, object>(key, changedValue.Value);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Synchronize lead columns, which are corresponded with qualified lead contact.
		/// </summary>
		/// <param name="lead">Lead entity.</param>
		/// <param name="modifiedColumnValues">Lead modified columns.</param>
		public void SynchronizeContactData(Entity lead, EntityColumnValueCollection modifiedColumnValues) {
			Guid qualifiedContactId = lead.GetTypedColumnValue<Guid>("QualifiedContactId");
			if (qualifiedContactId != Guid.Empty) {
				List<KeyValuePair<string, object>> newContactValues = GetContactColumnValues(modifiedColumnValues);
				if (newContactValues.Any()) {
					UpdateQualifiedContact(qualifiedContactId, newContactValues);
				}
			}
		}

		#endregion
	}

	#endregion

}

