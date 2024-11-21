namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using BPMSoft.Core.Factories;

	#region Class: FindDuplicatesOnSaveRequest

	/// <summary>
	/// Find duplicates on save request data.
	/// </summary>
	[DataContract]
	public class FindDuplicatesRequest
	{

		#region Properties: Public

		[DataMember(Name = "schemaName", IsRequired = false)]
		public string SchemaName { get; set; }

		[DataMember(Name = "from", IsRequired = false)]
		public int? From { get; set; }

		[DataMember(Name = "size", IsRequired = false)]
		public int? Size { get; set; }

		[DataMember(Name = "model", IsRequired = false)]
		public List<DuplicatesColumnData> Model { get; set; }

		[DataMember(Name = "primaryColumnValue", IsRequired = false)]
		public Guid? PrimaryColumnValue { get; set; }

		[DataMember(Name = "columns", IsRequired = false)]
		public List<string> Columns { get; set; }
		
		[DataMember(Name = "type", IsRequired = false)]
		public DuplicatesRuleType Type { get; set; }

		[DataMember(Name = "rules", IsRequired = false)]
		public IEnumerable<DuplicatesRuleDTO> Rules { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			var findDuplicatesRequest2 = (FindDuplicatesRequest)obj;
			if (Model == null || findDuplicatesRequest2.Model == null) {
				return false;
			}
			if (Columns == null || findDuplicatesRequest2.Columns == null) {
				return false;
			}
			var defaultStringComparer = EqualityComparer<string>.Default;
			var result = defaultStringComparer.Equals(SchemaName, findDuplicatesRequest2.SchemaName);
			var modelSet = new HashSet<DuplicatesColumnData>(Model);
			var modelSet2 = new HashSet<DuplicatesColumnData>(findDuplicatesRequest2.Model);
			result = result && modelSet.SetEquals(modelSet2);
			result = result && PrimaryColumnValue == findDuplicatesRequest2.PrimaryColumnValue;
			var columnSet = new HashSet<string>(Columns);
			var columnSet2 = new HashSet<string>(findDuplicatesRequest2.Columns);
			return result && columnSet.SetEquals(columnSet2);
		}

		public override int GetHashCode() {
			var hashCode = 1146051140;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SchemaName);
			hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(From);
			hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(Size);
			hashCode = hashCode * -1521134295 + EqualityComparer<List<DuplicatesColumnData>>.Default.GetHashCode(Model);
			hashCode = hashCode * -1521134295 + EqualityComparer<Guid?>.Default.GetHashCode(PrimaryColumnValue);
			hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Columns);
			return hashCode;
		}

		#endregion

	}

	#endregion

	#region Enum: DuplicatesRuleType

	/// <summary>
	/// Duplicates rule used type
	/// </summary>
	public enum DuplicatesRuleType
	{
		Default = 0,
		OnlyActive = 1
	}
	
	#endregion

	#region Class: DuplicatesColumnData

	/// <summary>
	/// Column data for duplicates search.
	/// </summary>
	[DataContract]
	public class DuplicatesColumnData
	{
		#region Properties: Public

		[DataMember(Name = "schemaName", IsRequired = false)]
		public string SchemaName { get; set; }

		[DataMember(Name = "columnName", IsRequired = false)]
		public string ColumnName { get; set; }

		[DataMember(Name = "type", IsRequired = false)]
		public string Type { get; set; }

		[DataMember(Name = "value", IsRequired = false)]
		public List<string> Value { get; set; }

		#endregion

		#region Methods: Public

		public override int GetHashCode() {
			unchecked {
				var hashCode = 3;
				if (SchemaName != null) {
					hashCode = hashCode * 19 + SchemaName.GetHashCode();
				}
				if (Value != null) {
					foreach (var item in Value) {
						hashCode = hashCode * 19 + item.GetHashCode();
					}
				}
				if (Type == null) {
					hashCode = hashCode * 19 + ColumnName.GetHashCode();
				} else {
					hashCode = hashCode * 19 + Type.GetHashCode();
				}
				return hashCode;
			}
		}

		public override bool Equals(object obj) {
			return this.GetHashCode() == obj.GetHashCode();
		}

		#endregion

	}

	#endregion

	#region Class: FindSimilarRecordsFromStoredRequest

	/// <summary>
	/// Find similar records request.
	/// </summary>
	[DataContract]
	public class FindSimilarRecordsFromStoredRequest
	{

		#region Propeties: Public

		[DataMember(Name = "sourceId", IsRequired = false)]
		public Guid SourceId { get; set; }

		[DataMember(Name = "sourceSchemaName", IsRequired = false)]
		public string SourceSchemaName { get; set; }

		[DataMember(Name = "schemaName", IsRequired = false)]
		public string SchemaName { get; set; }

		#endregion

	}

	#endregion

	#region Class: DeduplicationServiceV2

	/// <summary>
	/// Represent class for deduplication service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DeduplicationServiceV2 : IReadOnlySessionState
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Deduplication");

		#endregion

		#region Properties: Protected

		private IDeduplicationManager _deduplicationManager;
		protected IDeduplicationManager DeduplicationManager {
			get {
				if (_deduplicationManager == null) {
					_deduplicationManager = ClassFactory.Get<IDeduplicationManager>();
				}
				return _deduplicationManager;
			}
		}

		#endregion

		#region Methods: Private

		private string FindDuplicatesSafety(FindDuplicatesRequest findDuplicatesOnSaveRequest) {
			var result = string.Empty;
			try {
				var duplicates = DeduplicationManager.FindDuplicates(findDuplicatesOnSaveRequest);
				result = JsonConvert.SerializeObject(duplicates);
			} catch (Exception ex) {
				_log.Error("There is error during searching duplicates", ex);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Web-method provide result of deduplication search on save.
		/// </summary>
		/// <param name="request">Request data.</param>
		/// <returns>List of found duplicates</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string FindDuplicatesOnSave(FindDuplicatesRequest findDuplicatesOnSaveRequest) {
			return FindDuplicatesSafety(findDuplicatesOnSaveRequest);
		}

		/// <summary>
		/// Web-method provide result of search similar leads.
		/// </summary>
		/// <param name="request">Request data.</param>
		/// <returns>List of found similar leads.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string FindSimilarLeads(FindDuplicatesRequest findDuplicatesOnSaveRequest) {
			return FindDuplicatesSafety(findDuplicatesOnSaveRequest);
		}

		/// <summary>
		/// Web-method provide result of searching similar records by stored source.
		/// </summary>
		/// <param name="findSimilarRecordsFromStoredRequest">Request data.</param>
		/// <returns>List of found similar records.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string FindSimilarRecordsFromStored(
				FindSimilarRecordsFromStoredRequest findSimilarRecordsFromStoredRequest) {
			var result = string.Empty;
			try {
				var duplicates = DeduplicationManager.FindSimilarRecordsFromStored(
					findSimilarRecordsFromStoredRequest);
				result = JsonConvert.SerializeObject(duplicates);
			} catch (Exception ex) {
				_log.Error("There is error during searching similar records", ex);
			}
			return result;
		}

		#endregion

	}

	#endregion

}
