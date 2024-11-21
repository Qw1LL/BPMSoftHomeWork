namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class: OmniChat_OmnichannelMessagingEventsProcess

	public partial class OmniChat_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Private

		private string GetContactName(Guid ContactId) {
			if (ContactId.IsEmpty()) {
				return "";
			}
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var select = new Select(UserConnection)
						.Column(contactSchema.GetPrimaryDisplayColumnName())
					.From("Contact")
					.Where("Id").IsEqual(Column.Parameter(ContactId)) as Select;
			return select.ExecuteScalar<string>();
		}

		private bool IsNameNullOrEmpty() {
			var nameObj = Entity.GetColumnValue("Name");

			if(nameObj is string name)
				return string.IsNullOrEmpty(name);

			return true;
		}
		#endregion

		#region Methods: Public

		public void CheckAndFillName() {
			if (IsNeedToFillName()) {
				Entity.SetColumnValue("Name", GetNameValue());
			}
		}

		public bool IsNeedToFillName() {
			List<string> ColumnNames = new List<string> { "CreatedOn", "ContactId" };
			return Entity.GetChangedColumnValues().Select(c => c.Name).Intersect(ColumnNames).Any() && IsNameNullOrEmpty();
		}

		public string GetNameValue() {
			var contact = GetContactName(Entity.GetTypedColumnValue<Guid>("ContactId"));
			var createdOn = Entity.GetTypedColumnValue<DateTime>("CreatedOn").ToString("dd-MM-yyyy HH:mm:ss");
			return $"{contact} - {createdOn}";
		}

		#endregion
		
	}

	#endregion

}

