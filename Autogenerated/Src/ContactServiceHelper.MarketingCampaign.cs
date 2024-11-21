namespace BPMSoft.Configuration
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Threading;
	using SystemTasks = System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Configuration.MandrillService;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Tasks;
	using BPMSoft.Common.Json;
	using BPMSoft.Nui.ServiceModel.Extensions;

	#region UpdateContactsData

	/// <summary>
	/// Represents data to be used for async contacts update.
	/// </summary>
	public class UpdateContactsData
	{

		/// <summary>
		/// Collection of filters for update query.
		/// </summary>
		public string Filters { get; set; }

		/// <summary>
		/// Identifier of entity schema.
		/// </summary>
		public string EntitySchemaUid { get; set; }

		/// <summary>
		/// Current user culture.
		/// </summary>
		public string Culture { get; set; }

	}

	#endregion

	#region Class: ContactServiceHelper

	/// <summary>
	/// Helper class for contact service.
	/// </summary>
	public class ContactServiceHelper : IBackgroundTask<UpdateContactsData>, IUserConnectionRequired
	{
		#region Constructors: Public

		public ContactServiceHelper() {}

		public ContactServiceHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private UserConnection UserConnection;

		#endregion

		#region Properties: Public

		private RemindingUtilities _remindingUtilities;
		/// <summary>
		/// Utility methods for notification messages.
		/// </summary>
		public RemindingUtilities RemindingUtilities {
			get {
				return _remindingUtilities ??
					(_remindingUtilities = new RemindingUtilities());
			}
			set {
				_remindingUtilities = value;
			}
		}

		#endregion

		#region Methods: Private

		private string CreateReminding(EntitySchemaQuery contactEsq) {
			int totalContactCount = GetTotalContactCount(contactEsq);
			int applyingContactCount = GetApplyingContactCount(contactEsq);
			var remindingDescription = string.Format(GetLczStringValue("RemindingUpdateMessage"),
				applyingContactCount, totalContactCount);
			return remindingDescription;
		}

		private Update GetContactUpdate(Select contactsSelect) {
			Update contactUpdate = new Update(UserConnection, "Contact")
				.Set("IsNonActualEmail", Column.Parameter(false))
				.Where("Id").In(contactsSelect)
				.And("IsNonActualEmail").IsEqual(Column.Parameter(true)) as Update;
			return contactUpdate;
		}

		private Update GetContactCommunicationUpdate(Select contactsSelect) {
			Update contactCommunicationUpdate = new Update(UserConnection, "ContactCommunication")
				.Set("NonActual", Column.Parameter(false))
				.Set("NonActualReasonId", Column.Const(null))
				.Set("DateSetNonActual", Column.Const(null))
				.Where("CommunicationTypeId").IsEqual(Column.Parameter(Guid.Parse(CommunicationTypeConsts.EmailId)))
				.And("ContactId").In(contactsSelect) as Update;
			return contactCommunicationUpdate;
		}

		private EntitySchemaQuery GetContactEsq(string filters, Guid entitySchemaUId) {
			var jsonFilters = Json.Deserialize<BPMSoft.Nui.ServiceModel.DataContract.Filters>(filters);
			var esqFilters = jsonFilters.BuildEsqFilter(entitySchemaUId, UserConnection);
			var contactEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			contactEsq.UseAdminRights = false;
			contactEsq.PrimaryQueryColumn.IsVisible = true;
			contactEsq.Filters.Add(esqFilters);
			return contactEsq;
		}

		private int GetTotalContactCount(EntitySchemaQuery contactEsq) {
			contactEsq.ResetSelectQuery();
			contactEsq.PrimaryQueryColumn.IsVisible = false;
			var countFunction = contactEsq.CreateAggregationFunction(AggregationTypeStrict.Count,
				contactEsq.RootSchema.GetPrimaryColumnName());
			var contactCount = contactEsq.AddColumn(countFunction);
			var entityCollection = contactEsq.GetEntityCollection(UserConnection);
			contactEsq.RemoveColumn(contactCount.Name);
			return entityCollection.Count > 0
				? entityCollection[0].GetTypedColumnValue<int>(contactCount.Name)
				: 0;
		}

		private int GetApplyingContactCount(EntitySchemaQuery contactEsq) {
			contactEsq.ResetSelectQuery();
			var countFunction = contactEsq.CreateAggregationFunction(AggregationTypeStrict.Count,
				contactEsq.RootSchema.GetPrimaryColumnName());
			contactEsq.AddColumn(countFunction);
			var contactCommunicationSelect = new Select(UserConnection)
				.Column("SubContactCommunication", "Id").As("Id")
				.From("ContactCommunication").As("SubContactCommunication")
				.Where("SubContactCommunication", "ContactId").IsEqual("Contact", "Id")
				.And("SubContactCommunication", "CommunicationTypeId")
					.IsEqual(Column.Parameter(Guid.Parse(CommunicationTypeConsts.EmailId)))
				.And("SubContactCommunication", "NonActual").IsEqual(Column.Parameter(true)) as Select;
			var select = contactEsq.GetSelectQuery(UserConnection)
				.And()
				.Exists(contactCommunicationSelect) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					if (dr.Read()) {
						return UserConnection.DBTypeConverter.DBValueToInt(dr[0]);
					}
				}
			}
			return 0;
		}

		private string GetLczStringValue(string lczName) {
			var localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, "ContactService", localizableStringName);
			string value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		private void SetActualEmail(Dictionary<string, object> argsDictionary, string filters, string entitySchemaUIdAsString) {
			Thread.CurrentThread.CurrentCulture = (CultureInfo)argsDictionary["Culture"];
			var entitySchemaUId = new Guid(entitySchemaUIdAsString);
			try {
				EntitySchemaQuery contactEsq = GetContactEsq(filters, entitySchemaUId);
				Select contactsSelect = contactEsq.GetSelectQuery(UserConnection);
				Update contactCommunicationUpdate = GetContactCommunicationUpdate(contactsSelect);
				Update contactUpdate = GetContactUpdate(contactsSelect);
				string description = CreateReminding(contactEsq);
				contactCommunicationUpdate.Execute();
				contactUpdate.Execute();
				RemindingConfig remindingConfig = new RemindingConfig(entitySchemaUId);
				remindingConfig.Description = description;
				remindingConfig.AuthorId = remindingConfig.ContactId = UserConnection.CurrentUser.ContactId;
				this.RemindingUtilities.CreateReminding(UserConnection, remindingConfig);
			} catch(Exception e) {
				MandrillUtilities.Log.Error("[ContactService.SetActualEmailAction]: ", e);
				throw e;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sets NonActual sign of email to false.
		/// </summary>
		/// <param name="args">Parameters object for update query.</param>
		public void SetActualEmailAction(object args) {
			var argsDictionary = (Dictionary<string, object>)args;
			var filters = (string)argsDictionary["filters"];
			var entitySchemaUIdAsString = (string)argsDictionary["entitySchemaUId"];
			SetActualEmail(argsDictionary, filters, entitySchemaUIdAsString);
		}

		/// <summary>
		/// Sets NonActual sign of email to false.
		/// </summary>
		/// <param name="updateData"><see cref="UpdateContactsData">Parameters object for update query.</param>
		public void SetActualEmailAction(UpdateContactsData updateData) {
			var currentCulture = CultureInfo.GetCultureInfo(updateData.Culture);
			var argsDictionary = new Dictionary<string, object>();
			argsDictionary.Add("Culture", currentCulture);
			SetActualEmail(argsDictionary, updateData.Filters, updateData.EntitySchemaUid);
		}

		/// <summary>
		/// Updates contacts asynchroniosly.
		/// </summary>
		/// <param name="filters">Collection of filters for update query.</param>
		/// <param name="entitySchemaUId">Identifier of entity schema.</param>
		public SystemTasks.Task UpdateContactAsync(string filters, string entitySchemaUId) {
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			var args = new Dictionary<string, object>();
			args.Add("filters", filters);
			args.Add("entitySchemaUId", entitySchemaUId);
			args.Add("Culture", culture);
			return SystemTasks.Task.Factory.StartNew(SetActualEmailAction, args);
		}

		/// <summary>
		/// Updates contacts asynchroniosly.
		/// </summary>
		/// <param name="filters">Collection of filters for update query.</param>
		/// <param name="entitySchemaUId">Identifier of entity schema.</param>
		public void UpdateContactAsyncCore(string filters, string entitySchemaUId) {
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			var updateData = new UpdateContactsData {
				Filters = filters,
				EntitySchemaUid = entitySchemaUId,
				Culture = culture.Name
			};
			Task.StartNewWithUserConnection<ContactServiceHelper, UpdateContactsData>(updateData);
		}

		/// <summary>
		/// Method to run async update contacts action with user connection.
		/// </summary>
		/// <param name="data"><see cref="UpdateContactsData">Data to be used for async updating.</param>
		public void Run(UpdateContactsData parameters) {
			SetActualEmailAction(parameters);
		}

		/// <summary>
		/// Method to set user connection when run async task.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public void SetUserConnection(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion
	}

	#endregion
}

