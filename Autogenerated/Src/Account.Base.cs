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

	#region Class: Account_BaseEventsProcess

	public partial class Account_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CreateCommunication(UserConnection userConnection, EntitySchema schema, string typeId, Guid primaryEntityId, string number) {
			var communication = schema.CreateEntity(userConnection);
			communication.SetDefColumnValues();
			communication.SetColumnValue("CommunicationTypeId", Guid.Parse(typeId));
			communication.SetColumnValue("AccountId", primaryEntityId);
			communication.SetColumnValue("Number", number);
			communication.Save();
		}

		public virtual bool SyncronizeAccountAddress() {
			return SynchronizeAddress();
		}

		public virtual Guid GetRelationTypeId() {
			return (Guid)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "ParentAccountRelationType");
		}

		public virtual Guid GetReverseRelationTypeId() {
			Guid reverseRelationTypeId = Guid.Empty;
			var relationTypeTableESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "RelationType");
			var idColumn = relationTypeTableESQ.AddColumn("Id");
			var reverseRelationTypeColumn = relationTypeTableESQ.AddColumn("ReverseRelationType.Id");
			var relationTypeEntity = relationTypeTableESQ.GetEntity(UserConnection, GetRelationTypeId());
			if (relationTypeEntity != null) {
				reverseRelationTypeId = relationTypeEntity.GetTypedColumnValue<Guid>(reverseRelationTypeColumn.Name);
			}
			return reverseRelationTypeId;
		}

		public virtual bool SynchronizeAddress() {
			var accountId = Entity.PrimaryColumnValue;
			var addressTypeId = Entity.GetTypedColumnValue<Guid>("AddressTypeId");
			var address = Entity.GetTypedColumnValue<string>("Address");
			var cityId = Entity.GetTypedColumnValue<Guid>("CityId");
			var regionId = Entity.GetTypedColumnValue<Guid>("RegionId");
			var countryId = Entity.GetTypedColumnValue<Guid>("CountryId");
			var zip = Entity.GetTypedColumnValue<string>("Zip");
			var gpsN = Entity.GetTypedColumnValue<string>("GPSN");
			var gpsE = Entity.GetTypedColumnValue<string>("GPSE");
			bool isEmptyAddressTypeId = addressTypeId.IsEmpty();
			bool isEmptyAddress = address.IsNullOrEmpty();
			bool isEmptyCityId = cityId.IsEmpty();
			bool isEmptyRegionId = regionId.IsEmpty();
			bool isEmptyCountryId = countryId.IsEmpty();
			bool isEmptyZip = zip.IsNullOrEmpty();
			bool isEmptyGPSN = gpsN.IsNullOrEmpty();
			bool isEmptyGPSE = gpsE.IsNullOrEmpty();
			if (isEmptyAddressTypeId && isEmptyAddress && isEmptyCityId &&
				isEmptyRegionId && isEmptyCountryId && isEmptyZip && isEmptyGPSN && isEmptyGPSE) {
				return true;
			}
			var addressESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "AccountAddress");
			addressESQ.UseAdminRights = false;
			var createdOnColumn = addressESQ.AddColumn("CreatedOn");
			addressESQ.AddAllSchemaColumns();
			createdOnColumn.OrderByAsc();
			var accountFilter = addressESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Account", accountId);
			addressESQ.Filters.Add(accountFilter);
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
				var accountAddress = addresses[0];
				var entityChanged = false;
				if (!isEmptyAddressTypeId && !accountAddress.GetTypedColumnValue<Guid>("AddressTypeId").Equals(addressTypeId)) {
					accountAddress.SetColumnValue("AddressTypeId", addressTypeId);
					entityChanged = true;
				}
				if (!accountAddress.GetTypedColumnValue<string>("Address").Equals(address)) {
					accountAddress.SetColumnValue("Address", address);
					entityChanged = true;
				}
				if (!isEmptyCityId && !accountAddress.GetTypedColumnValue<Guid>("CityId").Equals(cityId)) {
					accountAddress.SetColumnValue("CityId", cityId);
					entityChanged = true;
				}
				if (!isEmptyRegionId && !accountAddress.GetTypedColumnValue<Guid>("RegionId").Equals(regionId)) {
					accountAddress.SetColumnValue("RegionId", regionId);
					entityChanged = true;
				}
				if (!isEmptyCountryId && !accountAddress.GetTypedColumnValue<Guid>("CountryId").Equals(countryId)) {
					accountAddress.SetColumnValue("CountryId", countryId);
					entityChanged = true;
				}
				if (!accountAddress.GetTypedColumnValue<string>("Zip").Equals(zip)) {
					accountAddress.SetColumnValue("Zip", zip);
					entityChanged = true;
				}
				if (!accountAddress.GetTypedColumnValue<string>("GPSN").Equals(gpsN)) {
					accountAddress.SetColumnValue("GPSN", gpsN);
					entityChanged = true;
				}
				if (!accountAddress.GetTypedColumnValue<string>("GPSE").Equals(gpsE)) {
					accountAddress.SetColumnValue("GPSE", gpsE);
					entityChanged = true;
				}
				if (entityChanged) {
					accountAddress.Save();
				}
			} else {
				var schema = UserConnection.EntitySchemaManager.GetInstanceByName("AccountAddress");
				var accountAddressEntity = schema.CreateEntity(UserConnection);
				accountAddressEntity.SetDefColumnValues();
				accountAddressEntity.SetColumnValue("AccountId", accountId);
				accountAddressEntity.SetColumnValue("Primary", true);
				if (!isEmptyAddressTypeId) {
					accountAddressEntity.SetColumnValue("AddressTypeId", addressTypeId);
				}
				accountAddressEntity.SetColumnValue("Address", address);
				if (!isEmptyCityId) {
					accountAddressEntity.SetColumnValue("CityId", cityId);
				}
				if (!isEmptyRegionId) {
					accountAddressEntity.SetColumnValue("RegionId", regionId);
				}
				if (!isEmptyCountryId) {
					accountAddressEntity.SetColumnValue("CountryId", countryId);
				}
				accountAddressEntity.SetColumnValue("Zip", zip);
				accountAddressEntity.SetColumnValue("GPSN", gpsN);
				accountAddressEntity.SetColumnValue("GPSE", gpsE);
				if (accountAddressEntity.Validate()) {
					accountAddressEntity.Save();
				}
			}
			return true;
		}

		public virtual bool SynchronizeCommunication() {
			var helper = GetCommunicationSynchronizer();
			helper.SynchronizeCommunications();
			return true;
		}

		public virtual bool SynchronizeRelationship() {
			if (Entity.GetColumnValue("ParentId") != null || OldParentId != Guid.Empty) {
				Guid relationTypeId = GetRelationTypeId();
				Guid reverseRelationTypeId = GetReverseRelationTypeId();
				Guid accountId = Entity.GetTypedColumnValue<Guid>("Id");
				Guid parentId = Entity.GetTypedColumnValue<Guid>("ParentId");
				Guid searchParentId = OldParentId != Guid.Empty ? OldParentId : parentId;
				bool removeRelationship = parentId == Guid.Empty;
				Guid relationshipId = Guid.Empty;
				string parentAccountColumnName = "";
			
				Select select = (Select)new Select(UserConnection)
					.Column("Id")
					.Column("AccountAId")
					.Column("AccountBId")
					.From("Relationship")
					.Where()
						.OpenBlock()
							.OpenBlock("AccountAId").IsEqual(Column.Parameter(accountId))
							.And("AccountBId").IsEqual(Column.Parameter(searchParentId))
							.CloseBlock()
						.Or()
							.OpenBlock("AccountAId").IsEqual(Column.Parameter(searchParentId))
							.And("AccountBId").IsEqual(Column.Parameter(accountId))
							.CloseBlock()
						.CloseBlock()
					.And()
						.OpenBlock("RelationTypeId").IsEqual(Column.Parameter(relationTypeId))
						.Or("ReverseRelationTypeId").IsEqual(Column.Parameter(relationTypeId))
						.CloseBlock();
				using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
					using (IDataReader dataReader = select.ExecuteReader(executor)) {
						while (dataReader.Read()) {
							relationshipId = dataReader.GetColumnValue<Guid>("Id");
							if (dataReader.GetColumnValue<Guid>("AccountAId") == accountId) {
								parentAccountColumnName = "AccountBId";
							} else {
								parentAccountColumnName = "AccountAId";
							}
						}
					}
					if (removeRelationship && relationshipId != Guid.Empty) {
						Delete deleteRelationshipQuery = new Delete(UserConnection);
						deleteRelationshipQuery.From("Relationship");
						deleteRelationshipQuery.Where("Id").IsEqual(Column.Parameter(relationshipId));
						deleteRelationshipQuery.Execute(executor);
					} else {
						if (relationshipId != Guid.Empty) {
							Update updateRelationshipQuery = new Update(UserConnection, "Relationship");
							updateRelationshipQuery.Set(parentAccountColumnName, Column.Parameter(parentId));
							updateRelationshipQuery.Where("Id").IsEqual(Column.Parameter(relationshipId));
							updateRelationshipQuery.Execute(executor);
						} else if (parentId != Guid.Empty) {
							Insert insertRelationshipQuery = new Insert(UserConnection);
							insertRelationshipQuery.Into("Relationship");
							insertRelationshipQuery.Set("Active", Column.Parameter(true));
							insertRelationshipQuery.Set("AccountBId", Column.Parameter(accountId));
							insertRelationshipQuery.Set("RelationTypeId", Column.Parameter(relationTypeId));
							insertRelationshipQuery.Set("AccountAId", Column.Parameter(parentId));
							insertRelationshipQuery.Set("ReverseRelationTypeId", Column.Parameter(reverseRelationTypeId));
							insertRelationshipQuery.Execute(executor);
						}
					}
				}
			}
			return true;
		}

		public virtual CommunicationSynchronizer GetCommunicationSynchronizer() {
			CommunicationSynchronizer = CommunicationSynchronizer ?? ClassFactory.Get<CommunicationSynchronizer>(
				new ConstructorArgument("userConnection", UserConnection), new ConstructorArgument("entity", Entity));
			return (CommunicationSynchronizer) CommunicationSynchronizer;
		}

		public virtual void InitializeCommunicationSynchronizer() {
			var communicationColumns = new Dictionary<string, Guid> {
				{"Web", new Guid(CommunicationTypeConsts.WebId)},
				{"Fax", new Guid(CommunicationTypeConsts.FaxId)},
				{"Phone", new Guid(CommunicationTypeConsts.MainPhoneId)},
				{"AdditionalPhone", new Guid(CommunicationTypeConsts.AdditionalPhoneId)}
			};
			var helper = GetCommunicationSynchronizer();
			helper.InitializeCommunicationItems(communicationColumns);
		}

		public virtual void InitPrimaryContactAccount() {
			object primaryContactId = Entity.GetColumnValue("PrimaryContactId");
			if (primaryContactId == null) {
				return;
			}
			EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity primaryContact = contactSchema.CreateEntity(UserConnection);
			if (!primaryContact.FetchFromDB(primaryContactId) || primaryContact.GetColumnValue("AccountId") != null) {
				return;
			}
			primaryContact.SetColumnValue("AccountId", Entity.PrimaryColumnValue);
			primaryContact.Save();
		}

		public virtual void InitCanGenerateAnniversaryReminding() {
			bool isNew = Entity.StoringState == StoringObjectState.New;
			bool isPrimaryContactNotEmpty = Entity.GetTypedColumnValue<Guid>("PrimaryContactId").IsNotEmpty();
			var columns = GetAnniversaryDependentColumns();
			var changedColumns = Entity.GetChangedColumnValues();
			EntityChangedColumns =changedColumns.ToList();
			bool anniversaryColumnsChanged = changedColumns.Any(col => columns.Contains(col.Name));
			CanGenerateAnniversaryReminding = (isPrimaryContactNotEmpty || !isNew) && anniversaryColumnsChanged;
		}

		public virtual IEnumerable<string> GetAnniversaryDependentColumns() {
			return new[] { "PrimaryContactId", "OwnerId" };
		}

		public virtual void GenerateRemindings() {
			if (!CanGenerateAnniversaryReminding) {
				return;
			}
			Guid id = Entity.GetTypedColumnValue<Guid>("Id");
			AccountAnniversaryReminding remindingsGenerator = new AccountAnniversaryReminding(UserConnection, id);
			remindingsGenerator.Options = GetRemindingOptions();
			remindingsGenerator.GenerateActualRemindings();
		}

		public virtual IEnumerable<string> GetRemindingOptions() {
			var options = new List<string>();
			var changedColumns = EntityChangedColumns as List<EntityColumnValue> ?? new List<EntityColumnValue>();
			if (changedColumns.Any(col => col.Name == "OwnerId")) {
				options.AddRange(new[] {
					AccountAnniversaryReminding.AccountOption,
					AccountAnniversaryReminding.ContactOption
				});
			} else if (changedColumns.Any(col => col.Name == "PrimaryContactId")) {
				options.Add(AccountAnniversaryReminding.ContactOption);
			}
			return options;
		}

		#endregion

	}

	#endregion

}

