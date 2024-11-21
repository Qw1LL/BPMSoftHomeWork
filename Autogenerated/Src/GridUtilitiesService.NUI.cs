namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Common;

	#region Class: GridUtilitiesServiceHandler

	public class GridUtilitiesServiceHandler
	{
		#region Constants: Private

		private const string CLASS_NAME = "GridUtilitiesService";
		private const int DEFAULT_NUMBER_ITEMS_RETURNED = 100;

		#endregion

		#region Contructors: Public

		public GridUtilitiesServiceHandler(UserConnection userConnection) {
			_userConnection = userConnection;
			SetResources();
		}

		#endregion

		#region Fields: Private

		private string _jobNamePattern;
		private string _jobGroupNamePattern;
		private UserConnection _userConnection;

		#endregion
		
		#region Methods: Private

		private void SetResources() {
			_jobNamePattern = GetLocalizableString(CLASS_NAME, "MultiDeleteJobNamePattern");
			_jobGroupNamePattern = GetLocalizableString(CLASS_NAME, "MultiDeleteJobGroupNamePattern");
		}

		#endregion

		#region Methods: Protected

		protected virtual string GetLocalizableString(string className, string resourceName) {
			var localizableString = string.Format("LocalizableStrings.{0}.Value", resourceName);
			string result = new LocalizableString(_userConnection.ResourceStorage,
				className, localizableString);
			return result;
		}

		protected IDictionary<string, object> GetParameters(string[] primaryColumnValues, string rootSchema,
				Dictionary<string, string> config) {
			var result = new Dictionary<String, Object>() {
				{ "RecordIds", primaryColumnValues },
				{ "SchemaName", rootSchema }
			};
			if (config.ContainsKey("operationKey")) {
				var operationKey = config["operationKey"];
				result.Add("OperationKey", new Guid(operationKey));
			}
			if (config.ContainsKey("operation")) {
				SetParametersOperationType(config["operation"], result);
			}
			if (config.ContainsKey("previousOperationKey")) {
				result.Add("PreviousOperationKey", new Guid(config["previousOperationKey"]));
				result.Add("IsDeleteAll", true);
			}
			return result;
		}

		protected virtual void SetParametersOperationType(string operation, Dictionary<string, object> result) {
			if (operation != null) {
				if (operation.Contains("Unlink")) {
					result.Add("IsUnlink", true);
				}
				if (operation.Contains("Cascade")) {
					result.Add("IsCascade", true);
				}
			}
		}

		#endregion

		#region Methods: Public

		public virtual string DeleteRecords(string[] primaryColumnValues, string rootSchema) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, rootSchema);
			esq.AddAllSchemaColumns();
			var primaryColumnFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, esq.RootSchema.PrimaryColumn.Name, primaryColumnValues);
			esq.Filters.Add(primaryColumnFilter);
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			bool isDbOperationException = false;
			bool isSecurityException = false;
			string exceptionMessage = null;
			bool success = false;
			var deletedItems = new List<Guid>(entities.Count);
			while (entities.Count > 0) {
				Entity entity = entities.First.Value;
				try {
					entity.Delete();
					deletedItems.Add(entity.PrimaryColumnValue);
					success = true;
				} catch (DbOperationException) {
					isDbOperationException = true;
					break;
				} catch (SecurityException) {
					isSecurityException = true;
					break;
				} catch (InvalidOperationException ex) {
					exceptionMessage = ex.Message;
					break;
				} catch (Exception ex) {
					exceptionMessage = ex.Message;
					break;
				}
			}
			var returnObject = new {
				Success = success,
				DeletedItems = deletedItems,
				IsSecurityException = isSecurityException,
				IsDbOperationException = isDbOperationException,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		public virtual string DeleteRecordsAsync(string[] primaryColumnValues, string rootSchema,
				Dictionary<string, string> config) {
			string exceptionMessage = null;
			bool success = true;
			string currentUserName = _userConnection.CurrentUser.Name;
			string className = typeof(MultiDeleteExecutor).Name;
			var jonGroup = String.Format(_jobGroupNamePattern, className);
			IDictionary<String, Object> parameters = GetParameters(primaryColumnValues, rootSchema, config);
			int numberItemsReturned = Core.Configuration.SysSettings.GetValue(_userConnection, "DefaultNumberItemsReturned", DEFAULT_NUMBER_ITEMS_RETURNED);
			try {
				if (primaryColumnValues.Length <= numberItemsReturned && !parameters.ContainsKey("IsDeleteAll")) {
					var multiDeleteExecutor = new MultiDeleteExecutor();
					multiDeleteExecutor.Execute(_userConnection, parameters);
				} else {
					AppScheduler.RemoveJob(typeof(MultiDeleteExecutor).AssemblyQualifiedName, jonGroup);
					AppScheduler.TriggerJob<MultiDeleteExecutor>(jonGroup, _userConnection.Workspace.Name,
					currentUserName, parameters);
				}
			} catch (Exception ex) {
				success = false;
				exceptionMessage = ex.Message;
				throw;
			}
			var returnObject = new {
				Success = success,
				ExceptionMessage = exceptionMessage,
				OperationKey = parameters["OperationKey"]
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		/// <summary>
		/// Returns array of primary column values from filters.
		/// </summary>
		/// <param name="rootSchema">Root schema name.</param>
		/// <param name="filterConfigs">Serialized filters config.</param>
		/// <returns></returns>
		public virtual string[] GetPrimaryColumnValuesFromFilters(string rootSchema,
				string filterConfigs) { 
			var filters = JsonConvert.DeserializeObject<BPMSoft.Nui.ServiceModel.DataContract.Filters>(filterConfigs);
			var select = new BPMSoft.Nui.ServiceModel.DataContract.SelectQuery {
				RootSchemaName = rootSchema,
				Filters = filters,
				UseLocalization = true
			};
			var esq = select.BuildEsq(_userConnection);
			var primaryColumnName = esq.RootSchema.GetPrimaryColumnName();
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			return entities.Select(x => x.GetTypedColumnValue<string>(primaryColumnName)).ToArray();
		}

		#endregion
	}
	#endregion

	#region Class: GridUtilitiesService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GridUtilitiesService : BaseService
	{

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteRecords", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string DeleteRecords(string[] primaryColumnValues, string rootSchema) {
			var utilities = Core.Factories.ClassFactory.Get<GridUtilitiesServiceHandler>();
			return utilities.DeleteRecords(primaryColumnValues, rootSchema);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteRecordsAsync", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string DeleteRecordsAsync(string[] primaryColumnValues, string rootSchema,
				string parameters = null, string filtersConfig = null) {
			var utilities = Core.Factories.ClassFactory.Get<GridUtilitiesServiceHandler>();
			var config = new Dictionary<string, string>();
			if (parameters != null) {
				config = Json.Deserialize<Dictionary<string, string>>(parameters);
			}
			if (filtersConfig != null) {
				primaryColumnValues = utilities.GetPrimaryColumnValuesFromFilters(rootSchema, filtersConfig);
			}
			return utilities.DeleteRecordsAsync(primaryColumnValues, rootSchema, config);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetLocalizedColumnCaptions", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, string> GetLocalizedColumnCaptions(string rootSchemaName, string[] columns) {
			var rootSchema = UserConnection.EntitySchemaManager.GetInstanceByName(rootSchemaName);
			var columnsLcz = new Dictionary<string, string>();
			foreach (var column in columns) {
				if (columnsLcz.ContainsKey(column)) {
					continue;
				}
				columnsLcz.Add(column, (string)rootSchema.GetSchemaColumnFullCaptionByPath(column));
			}
			return columnsLcz;
		}

		#endregion

	}

	#endregion

}

