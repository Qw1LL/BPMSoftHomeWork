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
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.EntitySynchronization;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Contact_BaseEventsProcess

	public partial class Contact_BaseEventsProcess<TEntity>
	{

		#region Fields: Protected

		private bool? _isNeedUpdateAge;
		/// <summary>
		/// Get SysSettings value with code = "ActualizeAge".
		/// </summary>
		/// <returns>boolean</returns>
		protected virtual bool IsNeedUpdateAge {
			get
			{
				if (_isNeedUpdateAge == null) {
					_isNeedUpdateAge = (bool)Core.Configuration.SysSettings.GetValue(UserConnection, "ActualizeAge");
				}
				return (bool)_isNeedUpdateAge;
			}
		}
		#endregion

		#region Methods: Protected

		/// <summary>
		/// Check BirthDate column has changed.
		/// </summary>
		/// <returns>boolean</returns>
		protected virtual bool BirthDateColumnChanged() {
			return !Entity.GetTypedColumnValue<DateTime>("BirthDate").Equals(Entity.GetTypedOldColumnValue<DateTime>("BirthDate"));
		}


		/// <summary>
		/// Check if not needed to calculate and update contact age column:
		///  - SysSettings value with code = "ActualizeAge" == false
		///  - BirthDate column has not changed
		///  - BirthDate column equals DateTime.MinValue
		/// </summary>
		/// <returns>boolean</returns>
		protected virtual bool IsNotNeededToCalculateAge() {
			var birthdate = Entity.GetTypedColumnValue<DateTime>("BirthDate");
			return !IsNeedUpdateAge || !BirthDateColumnChanged() || birthdate.Equals(DateTime.MinValue);
		}

		#endregion

		#region Methods: Public

		public virtual void CloseCurrentJob() {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var schema = entitySchemaManager.GetInstanceByName("ContactCareer");
			var update = new BPMSoft.Core.DB.Update(UserConnection, schema.Name);
			var column = schema.Columns.GetByName("Current");
			update.Set(column.ColumnValueName, BPMSoft.Core.DB.Column.Parameter(false, column.DataValueType));
			column = schema.Columns.GetByName("DueDate");
			update.Set(column.ColumnValueName, BPMSoft.Core.DB.Column.Parameter(DateTime.Now, column.DataValueType));
			column = schema.Columns.GetByName("Contact");
			update.Where(column.ColumnValueName).IsEqual(BPMSoft.Core.DB.Column.Parameter(Entity.PrimaryColumnValue, column.DataValueType));
			column = schema.Columns.GetByName("Current");
			update.And(column.ColumnValueName).IsEqual(BPMSoft.Core.DB.Column.Parameter(true, column.DataValueType));
			column = schema.Columns.GetByName("Primary");
			update.And(column.ColumnValueName).IsEqual(BPMSoft.Core.DB.Column.Parameter(true, column.DataValueType));
			update.Execute();
		}

		public virtual void CreateCommunication(UserConnection userConnection, EntitySchema schema, string typeId, Guid primaryEntityId, string number, string socialMediaId) {
			var communication = schema.CreateEntity(userConnection);
			communication.SetDefColumnValues();
			communication.SetColumnValue("CommunicationTypeId", Guid.Parse(typeId));
			communication.SetColumnValue("ContactId", primaryEntityId);
			communication.SetColumnValue("Number", number);
			if (!socialMediaId.IsNullOrEmpty()) {
				communication.SetColumnValue("SocialMediaId", socialMediaId);
			}
			communication.Save();
		}

		public virtual bool SynchronizeContactAddress() {
			var contactId = Entity.PrimaryColumnValue;
			var addressTypeId = Entity.GetTypedColumnValue<Guid>("AddressTypeId");
			var address = Entity.GetTypedColumnValue<string>("Address");
			var cityId = Entity.GetTypedColumnValue<Guid>("CityId");
			var regionId = Entity.GetTypedColumnValue<Guid>("RegionId");
			var countryId = Entity.GetTypedColumnValue<Guid>("CountryId");
			var zip = Entity.GetTypedColumnValue<string>("Zip");
			bool isEmptyAddressTypeId = addressTypeId.IsEmpty();
			bool isEmptyAddress = address.IsNullOrEmpty();
			bool isEmptyCityId = cityId.IsEmpty();
			bool isEmptyRegionId = regionId.IsEmpty();
			bool isEmptyCountryId = countryId.IsEmpty();
			bool isEmptyZip = zip.IsNullOrEmpty();
			if (isEmptyAddressTypeId && isEmptyAddress && isEmptyCityId && isEmptyRegionId && isEmptyCountryId && isEmptyZip) {
				return true;
			}
			var addressESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactAddress");
			addressESQ.UseAdminRights = false;
			var createdOnColumn = addressESQ.AddColumn("CreatedOn");
			addressESQ.AddAllSchemaColumns();
			createdOnColumn.OrderByAsc();
			var contactFilter = addressESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Contact", contactId);
			addressESQ.Filters.Add(contactFilter);
			var primaryFilter = addressESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Primary", true);
			addressESQ.Filters.Add(primaryFilter);
			var options = new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = 1,
				PageableConditionValues = new Dictionary<string, object>()
			};
			var addresses = addressESQ.GetEntityCollection(UserConnection, options);
			if (addresses.Count > 0) {
				var contactAddress = addresses[0];
				var entityChanged = false;
				if (!addressTypeId.IsEmpty() && !contactAddress.GetTypedColumnValue<Guid>("AddressTypeId").Equals(addressTypeId) ) {
					contactAddress.SetColumnValue("AddressTypeId", addressTypeId);
					entityChanged = true;
				}
				if (!contactAddress.GetTypedColumnValue<string>("Address").Equals(address)) {
					contactAddress.SetColumnValue("Address", address);
					entityChanged = true;
				}
				if (!cityId.IsEmpty() && !contactAddress.GetTypedColumnValue<Guid>("CityId").Equals(cityId)) {
					contactAddress.SetColumnValue("CityId", cityId);
					entityChanged = true;
				}
				if (!regionId.IsEmpty() && !contactAddress.GetTypedColumnValue<Guid>("RegionId").Equals(regionId)) {
					contactAddress.SetColumnValue("RegionId", regionId);
					entityChanged = true;
				}
				if (!countryId.IsEmpty() && !contactAddress.GetTypedColumnValue<Guid>("CountryId").Equals(countryId)) {
					contactAddress.SetColumnValue("CountryId", countryId);
					entityChanged = true;
				}
				if (!contactAddress.GetTypedColumnValue<string>("Zip").Equals(zip)) {
					contactAddress.SetColumnValue("Zip", zip);
					entityChanged = true;
				}
				if (entityChanged) {
					contactAddress.Save();
				}
			} else {
				var schema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactAddress");
				var contactAddressEntity = schema.CreateEntity(UserConnection);
				contactAddressEntity.SetDefColumnValues();
				contactAddressEntity.SetColumnValue("ContactId", contactId);
				contactAddressEntity.SetColumnValue("Primary", true);
				if (!isEmptyAddressTypeId) {
					contactAddressEntity.SetColumnValue("AddressTypeId", addressTypeId);
				}
				contactAddressEntity.SetColumnValue("Address", address);
				if (!isEmptyCityId) {
					contactAddressEntity.SetColumnValue("CityId", cityId);
				}
				if (!isEmptyRegionId) {
					contactAddressEntity.SetColumnValue("RegionId", regionId);
				}
				if (!isEmptyCountryId) {
					contactAddressEntity.SetColumnValue("CountryId", countryId);
				}
				contactAddressEntity.SetColumnValue("Zip", zip);
				if (contactAddressEntity.Validate()) {
					contactAddressEntity.Save();
				}
			}
			return true;
		}

		public virtual bool SynchronizeCommunication() {
			var helper = GetCommunicationSynchronizer();
			helper.SynchronizeCommunications();
			return true;
		}

		public virtual void FillSgmOrNameField() {
			IEnumerable<EntityColumnValue> changedColumns = Entity.GetChangedColumnValues();
			if (NamePartColumnChanged(changedColumns, "Name")) {
				SetSgm(Entity as Contact);
			} else if (
				NamePartColumnChanged(changedColumns, "Surname") ||
				NamePartColumnChanged(changedColumns, "GivenName") ||
				NamePartColumnChanged(changedColumns, "MiddleName")) {
					SetName(Entity as Contact);
			}
		}

		public virtual void SetSgm(Contact contact) {
			if (contact == null) {
				return;
			}
			contact.FillSgmFields(GetContactConverter());
		}

		public virtual void SetName(Contact contact) {
			if (contact == null) {
				return;
			}
			contact.FillNameField(GetContactConverter());
		}

		public virtual IContactFieldConverter GetContactConverter() {
			IContactFieldConverter converter = ContactUtilities.GetContactConverter(UserConnection);
			return converter;
		}

		public virtual bool NamePartColumnChanged(IEnumerable<EntityColumnValue> changedColumns, string namePart) {
			return changedColumns.Any(column => {
				return
					column.Name == namePart &&
					column.Value != null &&
					!string.IsNullOrEmpty(column.Value.ToString()) &&
					!column.Value.Equals(column.OldValue);
			});
		}

		public virtual void AddCommunicationValue(Dictionary<Guid, string> communications, string communicationIdValue, string value) {
			if (value.IsNullOrEmpty()) {
				return;
			}
			communications.Add(new Guid(communicationIdValue), value);
		}

		public virtual bool GetIsSocialMediaId(Guid communicationTypeId) {
			var linkedInId = new Guid(CommunicationTypeConsts.LinkedInId);
			var twitterId = new Guid(CommunicationTypeConsts.TwitterId);
			var facebookId = new Guid(CommunicationTypeConsts.FacebookId);
			return communicationTypeId == linkedInId || communicationTypeId == twitterId || communicationTypeId == facebookId;
		}

		public virtual void CheckIsCareerChanged() {
			var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
			var departmentId = Entity.GetTypedColumnValue<Guid>("DepartmentId");
			var jobId = Entity.GetTypedColumnValue<Guid>("JobId");
			var decisionRoleId = Entity.GetTypedColumnValue<Guid>("DecisionRoleId");
			var jobTitle = Entity.GetTypedColumnValue<string>("JobTitle");
			var accountOldId = Entity.GetTypedOldColumnValue<Guid>("AccountId");
			var departmentOldId = Entity.GetTypedOldColumnValue<Guid>("DepartmentId");
			var jobOldId = Entity.GetTypedOldColumnValue<Guid>("JobId");
			var decisionRoleOldId = Entity.GetTypedOldColumnValue<Guid>("DecisionRoleId");
			var jobTitleOld = Entity.GetTypedOldColumnValue<string>("JobTitle");
			var careerIsChanged = accountId != accountOldId
				|| departmentId != departmentOldId
				|| jobId != jobOldId
				|| decisionRoleId != decisionRoleOldId
				|| jobTitle != jobTitleOld;
			var careerIsEmpty = accountId.IsEmpty() && departmentId.IsEmpty() && jobId.IsEmpty() && decisionRoleId.IsEmpty()
				&& jobTitle.IsNullOrEmpty();
			NeedDeleteCareer = careerIsChanged && careerIsEmpty;
			if (careerIsEmpty) {
					NeedInsertCareer = false;
					NeedUpdateCareer = false;
					return;
			}
			if ((accountId != accountOldId && accountOldId.IsNotEmpty())
				|| (departmentId != departmentOldId && departmentOldId.IsNotEmpty())
				|| (jobId != jobOldId && jobOldId.IsNotEmpty())
				|| (decisionRoleId != decisionRoleOldId && decisionRoleOldId.IsNotEmpty())
				|| (jobTitle != jobTitleOld && !jobTitleOld.IsNullOrEmpty())) {
					NeedInsertCareer = true;
					NeedUpdateCareer = false;
			} else if ((accountId != accountOldId && accountOldId.IsEmpty())
				|| (departmentId != departmentOldId && departmentOldId.IsEmpty())
				|| (jobId != jobOldId && jobOldId.IsEmpty())
				|| (decisionRoleId != decisionRoleOldId && decisionRoleOldId.IsEmpty())
				|| (jobTitle != jobTitleOld && jobTitleOld.IsNullOrEmpty())) {
					NeedUpdateCareer = true;
					NeedInsertCareer = false;
			}

			Select contactCareerCountSelect = new Select(UserConnection)
				.Column(Func.Count("Id"))
				.From("ContactCareer")
				.Where("ContactId").IsEqual(Column.Parameter(Entity.GetTypedColumnValue<Guid>("Id")))
				 as Select;
			if (jobTitle.IsNullOrEmpty()) {
				contactCareerCountSelect.And()
					.OpenBlock("JobTitle").IsEqual(Column.Parameter(jobTitle))
					.Or("JobTitle").IsNull().CloseBlock();
			} else {
				contactCareerCountSelect.And("JobTitle").IsEqual(Column.Parameter(jobTitle));
			}
			if (accountId.IsEmpty()) {
				contactCareerCountSelect.And("AccountId").IsNull();
			} else {
				contactCareerCountSelect.And("AccountId").IsEqual(Column.Parameter(accountId));
			}
			if (departmentId.IsEmpty()) {
				contactCareerCountSelect.And("DepartmentId").IsNull();
			} else {
				contactCareerCountSelect.And("DepartmentId").IsEqual(Column.Parameter(departmentId));
			}
			if (jobId.IsEmpty()) {
				contactCareerCountSelect.And("JobId").IsNull();
			} else {
				contactCareerCountSelect.And("JobId").IsEqual(Column.Parameter(jobId));
			}
			if (decisionRoleId.IsEmpty()) {
				contactCareerCountSelect.And("DecisionRoleId").IsNull();
			} else {
				contactCareerCountSelect.And("DecisionRoleId").IsEqual(Column.Parameter(decisionRoleId));
			}
			if (contactCareerCountSelect.ExecuteScalar<int>() > 0) {
				NeedInsertCareer = false;
			}
		}

		public virtual void ChangeCareer() {
			var careerSchema = UserConnection.EntitySchemaManager.GetInstanceByName("ContactCareer");
			var careerEntity = careerSchema.CreateEntity(UserConnection);
			if (NeedInsertCareer) {
				UpdateOldCareer();
				FillCareerDefaultValues(careerEntity);
				FillCareerEntity(careerEntity);
				careerEntity.Save();
			} else if (NeedUpdateCareer) {
				var contactCareerESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactCareer");
				contactCareerESQ.RowCount = 1;
				contactCareerESQ.AddAllSchemaColumns();
				var modifiedOnColumn = contactCareerESQ.AddColumn("ModifiedOn");
				modifiedOnColumn.OrderByDesc();
				contactCareerESQ.Filters.Add(contactCareerESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact",
					Entity.PrimaryColumnValue));
				contactCareerESQ.Filters.Add(contactCareerESQ.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Primary", true));
				var careerCollection = contactCareerESQ.GetEntityCollection(UserConnection);
				if (careerCollection.Count > 0) {
					careerEntity = careerCollection.First();
					FillCareerEntity(careerEntity);
				} else {
					FillCareerDefaultValues(careerEntity);
					FillCareerEntity(careerEntity);
				}
				careerEntity.Save();
			} else if (NeedDeleteCareer) {
				UpdateOldCareer();
			}

			var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
			if (PreviousAccountValue != accountId) {
				ActualizeContactCareerCurrentState();
			}
		}

		public virtual void UpdateOldCareer() {
			var updatePrimary = new Update(UserConnection, "ContactCareer")
				.Set("Primary", Column.Parameter(false))
				.Where("ContactId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue))
				.And("Current").IsEqual(Column.Parameter(true)) as Update;
			updatePrimary.Execute();
		}

		public virtual void FillCareerEntity(Entity careerEntity) {
			var accountId = Entity.GetColumnValue("AccountId");
			var departmentId = Entity.GetColumnValue("DepartmentId");
			var jobId =Entity.GetColumnValue("JobId");
			var decisionRoleId = Entity.GetColumnValue("DecisionRoleId");
			var jobTitle = Entity.GetColumnValue("JobTitle");
			careerEntity.SetColumnValue("AccountId", accountId);
			careerEntity.SetColumnValue("DepartmentId", departmentId);
			careerEntity.SetColumnValue("DecisionRoleId", decisionRoleId);
			careerEntity.SetColumnValue("JobId", jobId);
			careerEntity.SetColumnValue("JobTitle", jobTitle);
		}

		public virtual void FillCareerDefaultValues(Entity careerEntity) {
			careerEntity.SetDefColumnValues();
			careerEntity.SetColumnValue("ContactId", Entity.PrimaryColumnValue);
			careerEntity.SetColumnValue("Current", true);
			careerEntity.SetColumnValue("StartDate", UserConnection.CurrentUser.GetCurrentDateTime());
		}

		public virtual CommunicationSynchronizer GetCommunicationSynchronizer() {
			CommunicationSynchronizer = CommunicationSynchronizer ?? ClassFactory.Get<CommunicationSynchronizer>(
				new ConstructorArgument("userConnection", UserConnection), new ConstructorArgument("entity", Entity),
				new ConstructorArgument("primaryColumnName", "IsCreatedBySynchronization"));
			return (CommunicationSynchronizer) CommunicationSynchronizer;
		}

		public virtual void InitializeCommunicationSynchronizer() {
			var communicationColumns = new Dictionary<string, Guid> {
				{"Email", new Guid(CommunicationTypeConsts.EmailId)},
				{"Skype", new Guid(CommunicationTypeConsts.SkypeId)},
				{"HomePhone", new Guid(CommunicationTypeConsts.HomePhoneId)},
				{"MobilePhone", new Guid(CommunicationTypeConsts.MobilePhoneId)},
				{"Phone", new Guid(CommunicationTypeConsts.WorkPhoneId)}
			};
			var helper = GetCommunicationSynchronizer();
			helper.InitializeCommunicationItems(communicationColumns);
		}

		public virtual void ExecuteUpdateRemindings() {
			if (!CanGenerateAnniversaryReminding) {
				return;
			}
			BaseAnniversaryReminding remindingsGenerator = GetRemindingsGenerator(Entity);
			remindingsGenerator.GenerateActualRemindings();
		}

		public virtual void ExecuteDeleteRemindings() {
			Guid schemaUid = Entity.Schema.UId;
			BaseAnniversaryReminding remindingsGenerator = GetRemindingsGenerator(Entity);
			remindingsGenerator.DeleteRecordRemindings(schemaUid);
		}

		public virtual void SynchronizeContactName() {
			IColumnValuesSynchronizer synchronizer = CreateColumnValuesSynchronizer();
			ICollection<SynchronizationColumnMapping> columnMappings = new List<SynchronizationColumnMapping> {
				new SynchronizationColumnMapping {
					SourceColumnName = "Name",
					DestinationColumnName = "Name"
				}
			};
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager.FindInstanceByName("Employee"));
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", Entity.PrimaryColumnValue));
			foreach (var employee in esq.GetEntityCollection(UserConnection)) {
				synchronizer.SynchronizeEntities(Entity, employee, columnMappings);
				employee.Save();
			}
		}

		public virtual IEntitySynchronizationProvider CreateEntitySynchronizationProvider() {
			return ClassFactory.Get<EntitySynchronizationProvider>(new ConstructorArgument("userConnection", UserConnection));
		}

		public virtual IColumnValuesSynchronizer CreateColumnValuesSynchronizer() {
			return ClassFactory.Get<ColumnValuesSynchronizer>();
		}

		public virtual void ActualizeContactCareerCurrentState() {
			var contactCareerUpdate = new Update(UserConnection, "ContactCareer")
				.Where("ContactId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue))
				.And("AccountId").IsEqual(Column.Parameter(PreviousAccountValue)) as Update;
			SetContactCareerCurrentState(contactCareerUpdate);
			SetContactCareerDueDate(contactCareerUpdate);
		}

		protected virtual void SetContactCareerCurrentState(Update update) {
			update
				.Set("Current", Column.Parameter(false))
				.Execute();
		}

		protected virtual void SetContactCareerDueDate(Update update) {
			update
				.Set("DueDate", Column.Parameter(UserConnection.CurrentUser.GetCurrentDateTime()))
				.And("DueDate").IsNull()
				.Execute();
		}

		public virtual void InitCanGenerateAnniversaryReminding() {
			var columns = GetAnniversaryDependentColumns();
			bool isBirthDateNotEmpty = !Entity.GetTypedColumnValue<DateTime>("BirthDate").Equals(DateTime.MinValue);
			bool anniversaryColumnsChanged = Entity.GetChangedColumnValues().Any(col => columns.Contains(col.Name));
			CanGenerateAnniversaryReminding = anniversaryColumnsChanged && isBirthDateNotEmpty;
		}

		public virtual IEnumerable<string> GetAnniversaryDependentColumns() {
			return  new[] { "OwnerId", "AccountId", "TypeId" };
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
		/// Set current contact age, if it needed.
		/// </summary>
		public virtual void UpdateContactAge() {
			if (IsNotNeededToCalculateAge()) {
				return;
			}

			DateTime birthDate = Entity.GetTypedColumnValue<DateTime>("BirthDate");
			CalculateAgeHelper actualizeAgeHelper = ClassFactory.Get<CalculateAgeHelper>();
			int age = actualizeAgeHelper.GetFullAgeYears(birthDate);
			if (age >= 0) {
				Entity.SetColumnValue("Age", age);
			}
		}

		#endregion

	}

	#endregion

}

