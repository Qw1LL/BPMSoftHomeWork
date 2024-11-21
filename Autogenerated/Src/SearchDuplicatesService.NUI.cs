namespace BPMSoft.Configuration.SearchDuplicatesService
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using System.Xml;
	using Quartz;
	using Quartz.Impl.Triggers;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;

	#region DataContract

	[DataContract]
	public class SingleRequest {
		[DataMember]
		public Guid Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string AlternativeName { get; set; }
		[DataMember]
		public List<RequestCommunication> Communication { get; set; }
	}

	[DataContract]
	public class RequestCommunication {
		[DataMember]
		public Guid Id { get; set; }
		[DataMember]
		public string Number { get; set; }
		[DataMember]
		public Guid CommunicationTypeId { get; set; }
	}

	[DataContract]
	public class SearchStatus {
		[DataMember]
		public string Code { get; set; }
		[DataMember]
		public decimal Percent { get; set; }
		[DataMember]
		public DateTime ChangeOn { get; set; }
	}

	[DataContract]
	public class CommunicationModel {
		[DataMember]
		public Guid Id { get; set; }
		[DataMember]
		public Guid CommunicationTypeId { get; set; }
		[DataMember]
		public string Number { get; set; }
		[DataMember]
		public string SocialMediaId { get; set; }
	}

	[DataContract]
	public class AddressModel {
		[DataMember]
		public Guid Id { get; set; }
		[DataMember]
		public Guid AddressTypeId { get; set; }
		[DataMember]
		public Guid CountryId { get; set; }
		[DataMember]
		public Guid RegionId { get; set; }
		[DataMember]
		public Guid CityId { get; set; }
		[DataMember]
		public string Address { get; set; }
		[DataMember]
		public string Zip { get; set; }
	}

	[DataContract]
	public class MergeReturn {
		[DataMember]
		public int Code { get; set; }
		[DataMember]
		public string Description { get; set; }
	}

	[DataContract]
	public class TimeSchedule {
		[DataMember]
		public string SelectedDays { get; set; }
		[DataMember]
		public string Hours { get; set; }
		[DataMember]
		public string Minutes { get; set; }
	}

	#endregion

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SearchDuplicatesService : BaseService, IReadOnlySessionState
	{

		#region Methods: Public
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetAccountPerformSearchOnSave() {
			return (bool)getSettingsParameter("Account", "PerformSearchOnSave");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetContactPerformSearchOnSave() {
			return (bool)getSettingsParameter("Contact", "PerformSearchOnSave");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> FindAccountDuplicates(SingleRequest request) {
			return getDuplicates("Account", request);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> GetAccountDuplicatesParents(int skip) {
			return getDuplicates("Account", skip);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> FindContactDuplicates(SingleRequest request) {
			return getDuplicates("Contact", request);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> GetContactDuplicatesParents(int skip) {
			return getDuplicates("Contact", skip);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool SetAccountDuplicates(bool isNotDuplicate, List<Guid> notDuplicateList, SingleRequest request) {
			return SetLocalDuplicate("Account", notDuplicateList, request);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool SetContactDuplicates(bool isNotDuplicate, List<Guid> notDuplicateList, SingleRequest request) {
			return SetLocalDuplicate("Contact", notDuplicateList, request);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus GetAccountSearchStatus() {
			return getSearchStatus("Account");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus GetContactSearchStatus() {
			return getSearchStatus("Contact");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus AccountSearchStop() {
			return searchStop("Account");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus ContactSearchStop() {
			return searchStop("Contact");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus AccountSearchStart() {
			return searchStart("Account");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus ContactSearchStart() {
			return searchStart("Contact");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus ScheduleAccountSearch(TimeSchedule timeSchedule) {
			return ScheduleSearch("Account", timeSchedule);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RemoveAccountSchedule() {
			RemoveSchedule("Account");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SearchStatus ScheduleContactSearch(TimeSchedule timeSchedule) {
			return ScheduleSearch("Contact", timeSchedule);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RemoveContactSchedule() {
			RemoveSchedule("Contact");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public MergeReturn MergeAccountDuplicates(Guid id, List<Guid> duplicates,
			List<CommunicationModel> communication, List<AddressModel> address) {
			return mergeDuplicates("Account", id, duplicates, communication, address);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public MergeReturn MergeContactDuplicates(Guid id, List<Guid> duplicates,
			List<CommunicationModel> communication, List<AddressModel> address) {
			return mergeDuplicates("Contact", id, duplicates, communication, address);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SetAccountAsCheckeds(Guid id, List<Guid> duplicates) {
			setAsCheckeds("Account", id, duplicates);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SetContactAsCheckeds(Guid id, List<Guid> duplicates) {
			setAsCheckeds("Contact", id, duplicates);
		}
		
		#endregion

		#region Methods: Private

		private XmlDocument GetPreparedXml(SingleRequest request) {
			XmlDocument xml = new XmlDocument();
			XmlElement elementRows = xml.CreateElement("rows");
			List<RequestCommunication> communicationsList = request.Communication ?? new List<RequestCommunication>();
			foreach (RequestCommunication communication in communicationsList) {
				XmlElement elementRow = xml.CreateElement("row");
				XmlElement elementCommunicationTypeId = xml.CreateElement("CommunicationTypeId");
				elementCommunicationTypeId.InnerText = communication.CommunicationTypeId.ToString();
				XmlElement elementNumber = xml.CreateElement("Number");
				elementNumber.InnerText = communication.Number;
				elementRow.AppendChild(elementCommunicationTypeId);
				elementRow.AppendChild(elementNumber);
				AddElementsToRow(xml, elementRow, request);
				elementRows.AppendChild(elementRow);
			}
			if (communicationsList.Count < 1) {
				XmlElement elementRow = xml.CreateElement("row");
				AddElementsToRow(xml, elementRow, request);
				elementRows.AppendChild(elementRow);
			}
			xml.AppendChild(elementRows);
			return xml;
		}

		private void AddElementsToRow(XmlDocument xml, XmlElement elementRow, SingleRequest request) {
			XmlElement elementName = xml.CreateElement("Name");
			elementName.InnerText = request.Name;
			elementRow.AppendChild(elementName);
			if (request.Id != Guid.Empty) {
				XmlElement elementId = xml.CreateElement("Id");
				elementId.InnerText = request.Id.ToString();
				elementRow.AppendChild(elementId);
			}
		}
		
		private List<Guid> getDuplicates(string entitySchemaName, SingleRequest request) {
			List<Guid> responce = new List<Guid>();
			List<Guid> checkeds = new List<Guid>();
			bool searchByModifiedOnly = (bool)getSettingsParameter(entitySchemaName, "SearchByModifiedOnly");
			if (request.Id != Guid.Empty) {
				var esqChecked = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
					string.Format("Vw{0}Duplicate", entitySchemaName));
				var entityColumn = esqChecked.AddColumn("Entity2");
				esqChecked.Filters.Add(esqChecked.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Entity1", request.Id));
				esqChecked.Filters.Add(esqChecked.CreateFilterWithParameters(FilterComparisonType.Equal,
					"StatusOfDuplicate", "00401284-F36B-1410-918D-20CF308CCED1"));
				var checkedEntities = esqChecked.GetEntityCollection(UserConnection);
				if (checkedEntities.Count > 0) {
					foreach (Entity entity in checkedEntities) {
						var entityIdColumn = entity.Schema.Columns.GetByName(entityColumn.Name);
						Guid entityId = entity.GetTypedColumnValue<Guid>(entityIdColumn.ColumnValueName);
						checkeds.Add(entityId);
					}
				}
			}
			
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				entitySchemaName);
			var idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			var filtersGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			var nameFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Name", request.Name);
			filtersGroup.Add(nameFilter);
			if (entitySchemaName == "Account" && request.AlternativeName != null && request.AlternativeName.Length > 0) {
				filtersGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"AlternativeName", request.AlternativeName));
			}
			esq.Filters.Add(filtersGroup);
			if (request.Id != Guid.Empty) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual,
					esq.RootSchema.GetPrimaryColumnName(), request.Id));
			}
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				foreach (Entity entity in entities) {
					Guid entityId = entity.GetTypedColumnValue<Guid>(idColumn.Name);
					if (!checkeds.Contains(entityId)) {
						responce.Add(entityId);
					}
				}
			}
			if (request.Communication != null && request.Communication.Count > 0) {
				List<string> numbers = new List<string>();
				foreach (RequestCommunication item in request.Communication) {
					numbers.Add(item.Number);
				}
				var esqCom = new EntitySchemaQuery(UserConnection.EntitySchemaManager, 
					string.Format("{0}Communication", entitySchemaName));
				var objectIdColumn = esqCom.AddColumn(esqCom.RootSchema.GetPrimaryColumnName());
				var objectColumn = esqCom.AddColumn(entitySchemaName);
				if (entitySchemaName == "Contact") {
					esqCom.Filters.Add(esqCom.CreateFilterWithParameters(FilterComparisonType.NotEqual,
						"CommunicationType", new object[] { "3DDDB3CC-53EE-49C4-A71F-E9E257F59E49",
							"9A7AB41B-67CC-DF11-9B2A-001D60E938C6"}));
				}
				esqCom.Filters.Add(esqCom.CreateFilterWithParameters(FilterComparisonType.Equal, "Number", numbers));
				esqCom.Filters.Add(esqCom.CreateFilterWithParameters(FilterComparisonType.NotEqual, entitySchemaName, request.Id));
				var entitiesCom = esqCom.GetEntityCollection(UserConnection);
				if (entitiesCom.Count > 0) {
					foreach (Entity entity in entitiesCom) {
						var objectEsqColumn = entity.Schema.Columns.GetByName(objectColumn.Name);
						Guid entityId = entity.GetTypedColumnValue<Guid>(objectEsqColumn.ColumnValueName);
						if (!responce.Contains(entityId) && !checkeds.Contains(entityId) && entityId != Guid.Empty) {
							responce.Add(entityId);
						}
					}
				}
			}
			return responce;
		}
		
		private List<Guid> getDuplicates(string entitySchemaName, int skip) {
			List<Guid> responce = new List<Guid>();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				string.Format("{0}Duplicate", entitySchemaName));
			var entityColumn = esq.AddColumn("Entity1");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"StatusOfDuplicate", "F19D417E-F36B-1410-918D-20CF308CCED1"));
			esq.IsDistinct = true;
			esq.RowCount = 15 + skip;
			esq.SkipRowCount = skip;
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				foreach (Entity entity in entities) {
					var entityIdColumn = entity.Schema.Columns.GetByName(entityColumn.Name);
					Guid entityId = entity.GetTypedColumnValue<Guid>(entityIdColumn.ColumnValueName);
					responce.Add(entityId);
				}
			}
			return responce;
		}
		
		private bool SetLocalDuplicate(string entitySchemaName, List<Guid> notDuplicateList,
			SingleRequest request) {
			List<Guid> duplicates = getDuplicates(entitySchemaName, request);
			if (duplicates.Count == 0) {
				return true;
			}
			if (notDuplicateList == null) {
				notDuplicateList = new List<Guid>();
			}
			List<Guid> checkeds = new List<Guid>();
			if (request.Id != Guid.Empty && duplicates.Count > 0) {
				var esqChecked = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
					string.Format("Vw{0}Duplicate", entitySchemaName));
				var entityColumn = esqChecked.AddColumn("Entity2");
				esqChecked.Filters.Add(esqChecked.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Entity1", request.Id));
				esqChecked.Filters.Add(esqChecked.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Entity2", duplicates.Cast<object>()));
				var checkedEntities = esqChecked.GetEntityCollection(UserConnection);
				if (checkedEntities.Count > 0) {
					foreach (Entity entity in checkedEntities) {
						var entityIdColumn = entity.Schema.Columns.GetByName(entityColumn.Name);
						Guid entityId = entity.GetTypedColumnValue<Guid>(entityIdColumn.ColumnValueName);
						checkeds.Add(entityId);
					}
				}
			}
			foreach (Guid objectId in duplicates) {
				Guid status = new Guid("F19D417E-F36B-1410-918D-20CF308CCED1");
				if (notDuplicateList.Contains(objectId)) {
					status = new Guid("00401284-F36B-1410-918D-20CF308CCED1");
				}
				string entityDuplicateName = string.Format("{0}Duplicate", entitySchemaName);
				if (checkeds.Contains(objectId)) {
					if (notDuplicateList.Contains(objectId)) {
						var updateFront = new Update(UserConnection, entityDuplicateName)
							.Set("StatusOfDuplicateId", Column.Parameter(status))
							.Where("Entity1Id").IsEqual(Column.Parameter(request.Id))
							.And("Entity2Id").IsEqual(Column.Parameter(objectId));
						updateFront.Execute();
						var updateBack = new Update(UserConnection, entityDuplicateName)
							.Set("StatusOfDuplicateId", Column.Parameter(status))
							.Where("Entity2Id").IsEqual(Column.Parameter(request.Id))
							.And("Entity1Id").IsEqual(Column.Parameter(objectId));
						updateFront.Execute();
					}
				} else {
					EntitySchema duplicateSchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityDuplicateName);
					Entity duplicateEntityFirst = duplicateSchema.CreateEntity(UserConnection);
					duplicateEntityFirst.SetDefColumnValues();
					duplicateEntityFirst.SetColumnValue("CreatedOn", DateTime.Now);
					duplicateEntityFirst.SetColumnValue("Entity1Id", request.Id);
					duplicateEntityFirst.SetColumnValue("Entity2Id", objectId);
					duplicateEntityFirst.SetColumnValue("StatusOfDuplicateId", status);
					duplicateEntityFirst.Save();
					/*Entity duplicateEntitySecond = duplicateSchema.CreateEntity(userConnection);
					duplicateEntitySecond.SetDefColumnValues();
					duplicateEntitySecond.SetColumnValue("CreatedOn", DateTime.Now);
					duplicateEntitySecond.SetColumnValue("Entity1Id", objectId);
					duplicateEntitySecond.SetColumnValue("Entity2Id", request.Id);
					duplicateEntitySecond.SetColumnValue("StatusOfDuplicateId", status);
					duplicateEntitySecond.Save();*/
				}
			}
			return true;
		}
		
		private object getSettingsParameter(string entitySchemaName, string columnName) {
			object response = null;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				"DuplicatesSearchParameter");
			var objectColumn = esq.AddColumn(columnName);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SchemaToSearchName", entitySchemaName));
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				var column = entities[0].Schema.Columns.GetByName(objectColumn.Name);
				response = entities[0].GetTypedColumnValue<object>(column.ColumnValueName);
			}
			return response;
		}
		
		private SearchStatus getSearchStatus(string entitySchemaName) {
			SearchStatus responce = new SearchStatus();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				"GlobalDuplicateSearchState");
			var processedColumn = esq.AddColumn("ProcessedCount");
			var totalColumn = esq.AddColumn("TotalCount");
			var dateColumn = esq.AddColumn("SearchStatusChangedOn");
			var codeColumn = esq.AddColumn("SearchStatus.Code");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SchemaToSearchName", entitySchemaName));
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				var processedColumnSchema = entities[0].Schema.Columns.GetByName(processedColumn.Name);
				int processed = entities[0].GetTypedColumnValue<int>(processedColumnSchema.ColumnValueName);
				var totalColumnSchema = entities[0].Schema.Columns.GetByName(totalColumn.Name);
				int total = entities[0].GetTypedColumnValue<int>(totalColumnSchema.ColumnValueName);
				responce.Percent = (total > 0 )? Math.Round((decimal)((processed * 100) / total), 2) : 0m;
				var dateColumnSchema = entities[0].Schema.Columns.GetByName(dateColumn.Name);
				responce.ChangeOn = entities[0].GetTypedColumnValue<DateTime>(dateColumnSchema.ColumnValueName);
				var codeColumnSchema = entities[0].Schema.Columns.GetByName(codeColumn.Name);
				responce.Code = entities[0].GetTypedColumnValue<string>(codeColumnSchema.ColumnValueName);
			}
			return responce;
		}
		
		private SearchStatus searchStart(string entitySchemaName) {
			searchUpdate(entitySchemaName, "Finished");
			string jobProcessName = string.Format("StartGlobal{0}DuplicatesSearch", entitySchemaName);
			AppScheduler.ScheduleImmediateProcessJob("DuplicatesSearchJob", "DuplicatesSearchGroup", 
				jobProcessName, UserConnection.Workspace.Name, UserConnection.CurrentUser.Name);
			SearchStatus responce = new SearchStatus();
			responce.ChangeOn = DateTime.Now;
			responce.Code = "InProgress";
			responce.Percent = 0;
			return responce;
		}
		
		private SearchStatus ScheduleSearch(string entitySchemaName, TimeSchedule timeSchedule) {
			searchUpdate(entitySchemaName, "Finished");
			string jobProcessName = string.Format("StartGlobal{0}DuplicatesSearch", entitySchemaName);
			AppScheduler.RemoveJob(entitySchemaName + "DuplicatesSearchJob", "DuplicatesSearchGroup");
			IJobDetail job = AppScheduler.CreateProcessJob(entitySchemaName + "DuplicatesSearchJob",
				"DuplicatesSearchGroup",
				jobProcessName,
				UserConnection.Workspace.Name,
				UserConnection.CurrentUser.Name);
				ICronTrigger trigger = new CronTriggerImpl(entitySchemaName + "DuplicatesSearchJob", "DuplicatesSearchGroup",
					string.Format("0 {0} {1} ? * {2}", timeSchedule.Minutes, timeSchedule.Hours, timeSchedule.SelectedDays));
				trigger.TimeZone = TimeZoneInfo.Utc;
				AppScheduler.Instance.ScheduleJob(job, trigger);
				SearchStatus responce = new SearchStatus();
				responce.ChangeOn = DateTime.Now;
				responce.Code = "InProgress";
				responce.Percent = 0;
				return responce;
		}
		
		private void RemoveSchedule(string entitySchemaName) {
			AppScheduler.RemoveJob(entitySchemaName + "DuplicatesSearchJob", "DuplicatesSearchGroup");
		}
		
		private SearchStatus searchStop(string entitySchemaName) {
			searchUpdate(entitySchemaName, "Suspended");
			return getSearchStatus(entitySchemaName);
		}
		
		private void searchUpdate(string entitySchemaName, string SearchStatusCode) {
			Update update = new Update(UserConnection, "GlobalDuplicateSearchState")
				.Set("SearchStatusId",
					new Select(UserConnection).Top(1)
						.Column("Id")
					.From("GlobalDuplicateSearchStatus")
					.Where("Code").IsEqual(Column.Parameter(SearchStatusCode)))
				.Where("SchemaToSearchName").IsEqual(Column.Parameter(entitySchemaName)) as Update;
			update.Execute();
		}
		
		private MergeReturn mergeDuplicates(string entitySchemaName, Guid id, List<Guid> duplicates,
			List<CommunicationModel> communicationList, List<AddressModel> addressList) {
			MergeReturn mergeReturn = new MergeReturn();
			
			//Communication
			
			if (entitySchemaName == "Contact") {
				var update = new Update(UserConnection, entitySchemaName)
					.Set("Email", Column.Const(string.Empty))
					.Set("Skype", Column.Const(string.Empty))
					.Set("HomePhone", Column.Const(string.Empty))
					.Set("MobilePhone", Column.Const(string.Empty))
					.Set("Phone", Column.Const(string.Empty))
					.Where("Id").IsEqual(Column.Parameter(id));
				update.Execute();
			} else if (entitySchemaName == "Account") {
				var update = new Update(UserConnection, entitySchemaName)
					.Set("Web", Column.Const(string.Empty))
					.Set("Phone", Column.Const(string.Empty))
					.Set("AdditionalPhone", Column.Const(string.Empty))
					.Set("Fax", Column.Const(string.Empty))
					.Where("Id").IsEqual(Column.Parameter(id));
				update.Execute();
			}
			
			string communicationSchemaName = string.Format("{0}Communication", entitySchemaName);
			EntitySchema communicationSchema = UserConnection.EntitySchemaManager.GetInstanceByName(communicationSchemaName);
			var communicationEntityColumnName = communicationSchema.Columns.GetByName(entitySchemaName).ColumnValueName;
			var deleteCommunication = new Delete(UserConnection)
				.From(communicationSchemaName)
				.Where(communicationEntityColumnName).IsEqual(Column.Parameter(id))
				.Or(communicationEntityColumnName).In(Column.Parameters(duplicates.ToArray()));
			deleteCommunication.Execute();
			
			foreach(CommunicationModel communication in communicationList) {
				Entity commEntity = communicationSchema.CreateEntity(UserConnection);
				commEntity.SetDefColumnValues();
				commEntity.SetColumnValue("Id", communication.Id);
				commEntity.SetColumnValue("CreatedOn", DateTime.Now);
				commEntity.SetColumnValue("CommunicationTypeId", communication.CommunicationTypeId);
				commEntity.SetColumnValue("Number", communication.Number);
				commEntity.SetColumnValue("SocialMediaId", communication.SocialMediaId);
				commEntity.SetColumnValue(communicationEntityColumnName, id);
				commEntity.Save();
			}
			//Address
			string addressSchemaName = string.Format("{0}Address", entitySchemaName);
			EntitySchema addressSchema = UserConnection.EntitySchemaManager.GetInstanceByName(addressSchemaName);
			var addressEntityColumnName = addressSchema.Columns.GetByName(entitySchemaName).ColumnValueName;
			var deleteAddress = new Delete(UserConnection)
				.From(addressSchemaName)
				.Where(addressEntityColumnName).IsEqual(Column.Parameter(id))
				.Or(addressEntityColumnName).In(Column.Parameters(duplicates.ToArray()));
			deleteAddress.Execute();
			foreach(AddressModel address in addressList) {
				Entity addressEntity = addressSchema.CreateEntity(UserConnection);
				addressEntity.SetDefColumnValues();
				addressEntity.SetColumnValue("Id", address.Id);
				addressEntity.SetColumnValue("CreatedOn", DateTime.Now);
				addressEntity.SetColumnValue("AddressTypeId", address.AddressTypeId);
				if (address.CountryId != Guid.Empty) {
					addressEntity.SetColumnValue("CountryId", address.CountryId);
				}
				if (address.RegionId != Guid.Empty) {
					addressEntity.SetColumnValue("RegionId", address.RegionId);
				}
				if (address.CityId != Guid.Empty) {
					addressEntity.SetColumnValue("CityId", address.CityId);
				}
				addressEntity.SetColumnValue("Address", address.Address);
				addressEntity.SetColumnValue("Zip", address.Zip);
				addressEntity.SetColumnValue(addressEntityColumnName, id);
				addressEntity.Save();
			}
			
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entitySchemaName);
			string entitiesToMerge = string.Empty;
			mergeReturn.Code = -1;
			mergeReturn.Description = "";
			foreach (var mergeId in duplicates) {
				
				entitiesToMerge += mergeId.ToString("D").ToUpper() + ",";
			}
			var dataValueTypeManager = (DataValueTypeManager)UserConnection.AppManagerProvider.GetManager("DataValueTypeManager");
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_MergeDuplicates");
			storedProcedure.WithParameter(Column.Parameter(id));
			storedProcedure.WithParameter(Column.Parameter(entitiesToMerge.Trim(',')));
			storedProcedure.WithParameter(Column.Parameter(entitySchema.RealUId));
			storedProcedure.WithParameter(Column.Parameter(UserConnection.Workspace.Id));
			storedProcedure.WithOutputParameter("return_value", dataValueTypeManager.GetInstanceByName("Integer"));
			storedProcedure.WithOutputParameter("error_message", dataValueTypeManager.GetInstanceByName("Text"));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction(IsolationLevel.ReadUncommitted);
				storedProcedure.Execute(dbExecutor);
				if (storedProcedure.Parameters.Count > 0) {
					mergeReturn.Code = (int)storedProcedure.Parameters[0].Value;
					mergeReturn.Description = storedProcedure.Parameters[1].Value as string;
				}
				dbExecutor.CommitTransaction();	
			}
			return mergeReturn;
		}
		
		private void setAsCheckeds(string entitySchemaName, Guid id, List<Guid> duplicates) {
			Guid status = new Guid("00401284-F36B-1410-918D-20CF308CCED1");
			string entityDuplicateName = string.Format("{0}Duplicate", entitySchemaName);
			Update updateFirst = (new Update(UserConnection, entityDuplicateName)
				.Set("StatusOfDuplicateId", Column.Parameter(status))
				.Where("Entity1Id").IsEqual(Column.Parameter(id))
				.And("Entity2Id").In(Column.Parameters(duplicates.ToArray()))) as Update;
			updateFirst.Execute();
			Update updateSecond = (new Update(UserConnection, entityDuplicateName)
				.Set("StatusOfDuplicateId", Column.Parameter(status))
				.Where("Entity2Id").IsEqual(Column.Parameter(id))
				.And("Entity1Id").In(Column.Parameters(duplicates.ToArray()))) as Update;
			updateSecond.Execute();
		}
		#endregion
	}
}
