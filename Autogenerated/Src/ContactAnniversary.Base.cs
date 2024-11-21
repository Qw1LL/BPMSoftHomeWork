namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: ContactAnniversary_BaseEventsProcess

	public partial class ContactAnniversary_BaseEventsProcess<TEntity>
	{
		#region Fields: Protected

		protected readonly Guid ContactAnniversaryAnniversaryTypeColumnUId = new Guid("93c29696-307b-45f3-a799-b51670bdfcb6");
		protected readonly Guid ContactAnniversaryDateColumnUId = new Guid("ce66aa7d-8443-4b5a-a7fe-a90ae4e809de");
		protected readonly Guid ContactBirthDateColumnUId = new Guid("3f08db69-6d2f-4b1c-87a4-acddc6c3b9d6");
		protected readonly Guid ContactAgeColumnUId = new Guid("bcdc7a32-4332-4caf-858d-0078b56856fe");

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Checks if type has changed and previous type == Birth Day
		/// </summary>
		/// <returns>boolean</returns>
		protected bool IsPreviousTypeWasBirthday => TypeOldValue.Equals(AnniversaryTypeConsts.BirthdayId) && !IsBirthdayType;

		/// <summary>
		/// Checks if record type == Birth Day
		/// </summary>
		/// <returns>boolean</returns>
		protected bool IsBirthdayType => Entity.GetTypedColumnValue<Guid>("AnniversaryTypeId").Equals(AnniversaryTypeConsts.BirthdayId);


		/// <summary>
		/// Checks if record type changed
		/// </summary>
		/// <returns>boolean</returns>
		protected bool IsTypeChanged => !Entity.GetTypedColumnValue<Guid>("AnniversaryTypeId").Equals(TypeOldValue);

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks if need update contact age.
		/// </summary>
		/// <returns>boolean</returns>
		protected virtual bool IsNeedUpdateContactAge() {
			bool isNeedActualizeAge = (bool)Core.Configuration.SysSettings.GetValue(UserConnection, "ActualizeAge");
			return IsDateOrTypeChanged() && isNeedActualizeAge;
		}

		/// <summary>
		/// Calculate contact age.
		/// </summary>
		/// <returns>Contact age</returns>
		protected virtual int CalculateContactAge() {
			DateTime birthDate = Entity.GetTypedColumnValue<DateTime>("Date");
			CalculateAgeHelper actualizeAgeHelper = ClassFactory.Get<CalculateAgeHelper>();
			return actualizeAgeHelper.GetFullAgeYears(birthDate);
		}

		/// <summary>
		/// Returns contact age.
		/// </summary>
		/// <returns>Contact age</returns>
		protected virtual int GetContactAge() {
			return IsNeedUpdateContactAge() ? CalculateContactAge() : 0;
		}


		/// <summary>
		/// Add type and mapping columns for sync Contact and ContactAnniversary items.
		/// </summary>
		/// <returns>Dictionary<Guid, Dictionary<Guid, object>></returns>
		protected virtual Dictionary<Guid, Dictionary<Guid, object>> GetConditionMappingColumns() {
			var anniversaryTypeCondition = new Dictionary<Guid, object> {
				{ ContactAnniversaryAnniversaryTypeColumnUId, (object)AnniversaryTypeConsts.BirthdayId }
			};

			return new Dictionary<Guid, Dictionary<Guid, object>> {
				{ ContactBirthDateColumnUId, anniversaryTypeCondition }
			};
		}

		/// <summary>
		/// Get columns for mapping Contact and ContactAnniversary
		/// </summary>
		/// <returns href="Dictionary<Guid, Guid>"></returns>
		protected virtual Dictionary<Guid, Guid> GetMappingColumns() {
			return new Dictionary<Guid, Guid> {
				{ ContactBirthDateColumnUId, ContactAnniversaryDateColumnUId }
			};
		}


		/// <summary>
		/// Check if current status is "Birthday" and date has changed 
		/// or 
		/// previous status not equal "Birthday" and current status is "Birthday"
		/// </summary>
		/// <returns>bool</returns>
		protected virtual bool IsDateOrTypeChanged() {
			return (IsBirthDateChanged || IsTypeChanged) && IsBirthdayType;
		}

		#endregion

		#region Methods: Public

		public virtual void UpdateContactModifedOn() {
			if (!IsBirthdayType) {
				return;
			}

			var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			var instance = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var entity = instance.CreateEntity(UserConnection);
			if (entity.FetchFromDB(contactId)) {
				entity.SetColumnValue("ModifiedOn", DateTime.UtcNow);
				entity.Save();
			}
		}

		public virtual void UpdateRemindingsExecute() {
			if (IsDateOrTypeChanged()) {
				var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
				var contactEntity = contactSchema.CreateEntity(UserConnection);
				if (Entity.ContactId.IsNotEmpty() && contactEntity.FetchFromDB(Entity.ContactId)) {
					BaseAnniversaryReminding remindingsGenerator = GetRemindingsGenerator(contactEntity);
					remindingsGenerator.GenerateActualRemindings();
				}
			}
		}

		public virtual BaseAnniversaryReminding GetRemindingsGenerator(Entity contactEntity) {
			if (contactEntity.GetTypedColumnValue<Guid>("TypeId") == ContactConsts.EmployeeTypeId) {
				return new EmployeeAnniversaryReminding(UserConnection, contactEntity.GetTypedColumnValue<Guid>("Id"));
			} else {
				var remindingInfo = new ContactAnniversaryRemindingInfo();
				remindingInfo.Initialize(contactEntity);
				return new ContactAnniversaryReminding(UserConnection, remindingInfo);
			}
		}

		/// <summary>
		/// Add default values for synchronization.
		/// </summary>
		public virtual void AddDefaultValues(Dictionary<Guid, object> defaultValues) {
			if (IsBirthdayType) {
				defaultValues.Add(ContactAgeColumnUId, GetContactAge());
			}
			if (IsPreviousTypeWasBirthday) {
				defaultValues.Add(ContactBirthDateColumnUId, null);
			}
		}


		public virtual void AddSyncContactData() {			
			var conditionMappingColumns = new Dictionary<
				Guid, Dictionary<Guid, object>>();
			var mappingColumns = new Dictionary<Guid, Guid>();
			var defaultValues = new Dictionary<Guid, object>();

			if (IsCurrentContactBirthday || IsBirthdayType) {
				conditionMappingColumns = GetConditionMappingColumns();
				mappingColumns = GetMappingColumns();
			}

			AddDefaultValues(defaultValues);

			SynchronizeContactData.ParentEntityColumnUId = Entity.Schema.Columns.GetByName("Contact").UId;
			SynchronizeContactData.ConditionMappingColumns = conditionMappingColumns;
			SynchronizeContactData.MappingColumns = mappingColumns;
			SynchronizeContactData.DefaultValues = defaultValues;
		}

		#endregion
	}

	#endregion

}

