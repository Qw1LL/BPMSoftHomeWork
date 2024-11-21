namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Enrichment.Interfaces;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: HashUpdater

	/// <summary>
	/// The class for updating outdated hashes of mined entities to the actual ones.
	/// </summary>
	public class HashUpdater
	{

		#region Class: TextEntityData

		private class TextEntityData
		{
			public Guid EteId;
			public string EteJsonData;
			public string EteHash;
			public string EteUpdatedHash;
			public Guid EedId;
			public string EedJsonData;
			public string EedUpdatedHash;
		}

		#endregion

		#region Fields: Private

		private static readonly Type[] _miningEntityTypes = {
			typeof(ContactEntity),
			typeof(CommunicationEntity),
			typeof(OrganizationEntity),
			typeof(AddressEntity),
			typeof(JobEntity)
		};

		private static readonly ILog _log = LogManager.GetLogger("EmailMining");

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public HashUpdater(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void Execute(Type type) {
			int actualVersion = MiningEntity.GetHashVersion(type);
			if (actualVersion == 0) {
				return;
			}
			List<TextEntityData> textEntityDatas = QueryNotActualTextEntities(type.Name, actualVersion);
			ActualizeTextEntityHash(textEntityDatas, type);
			UpdateDbData(textEntityDatas, actualVersion, type.Name);
		}

		private void ActualizeTextEntityHash(List<TextEntityData> textEntityDatas, Type type) {
			foreach (TextEntityData textEntityData in textEntityDatas) {
				string eteJsonData = textEntityData.EteJsonData;
				if (eteJsonData.IsNotNullOrEmpty()) {
					var entity = (MiningEntity)JsonConvert.DeserializeObject(eteJsonData, type);
					if (entity != null) {
						textEntityData.EteUpdatedHash = entity.GetHash();
					}
				}
				string eedJsonData = textEntityData.EedJsonData;
				if (eedJsonData.IsNotNullOrEmpty()) {
					TextEntities textEntities = JsonConvert.DeserializeObject<TextEntities>(eedJsonData);
					if (textEntities != null) {
						textEntityData.EedUpdatedHash = textEntities.GetHash();
					}
				}
			}
		}

		private List<TextEntityData> QueryNotActualTextEntities(string typeName, int actualVersion) {
			List<TextEntityData> textEntityDatas = new List<TextEntityData>();
			var select = (Select)new Select(_userConnection)
					.Column("ete", "Id").As("EteId")
					.Column("ete", "JsonData").As("EteJsonData")
					.Column("ete", "Hash").As("EteHash")
					.Column("ete", "EnrchEmailDataId").As("EedId")
					.Column("eed", "JsonData").As("EedJsonData")
				.From("EnrchTextEntity").As("ete")
					.InnerJoin("EnrchEmailData").As("eed").On("ete", "EnrchEmailDataId").IsEqual("eed", "Id")
				.Where("ete", "Type").IsEqual(Column.Parameter(typeName))
					.And("ete", "HashVersion").IsLess(Column.Parameter(actualVersion))
					.And("eed", "JsonData").Not().IsNull();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						textEntityDatas.Add(new TextEntityData {
							EteId = dataReader.GetColumnValue<Guid>("EteId"),
							EteJsonData = dataReader.GetColumnValue<string>("EteJsonData"),
							EteHash = dataReader.GetColumnValue<string>("EteHash"),
							EedId = dataReader.GetColumnValue<Guid>("EedId"),
							EedJsonData = dataReader.GetColumnValue<string>("EedJsonData")
						});
					}
				}
			}
			return textEntityDatas;
		}

		private void UpdateDbData(List<TextEntityData> textEntityDatas, int actualVersion, string typeName) {
			string messageFormat = "Hash update for type {0}. {1} updated to version {2}: {3}";
			int rowsAffected = UpdateEnrchTextEntity(textEntityDatas, actualVersion);
			_log.InfoFormat(messageFormat, typeName, "EnrchTextEntity", actualVersion, rowsAffected);
			rowsAffected = UpdateEnrchProcessedData(textEntityDatas);
			_log.InfoFormat(messageFormat, typeName, "EnrchProcessedData", actualVersion, rowsAffected);
			rowsAffected = UpdateEnrchEmailData(textEntityDatas);
			_log.InfoFormat(messageFormat, typeName, "EnrchEmailData", actualVersion, rowsAffected);
		}

		private int UpdateEnrchEmailData(List<TextEntityData> textEntityDatas) {
			int recordsAffected = 0;
			IEnumerable<KeyValuePair<Guid, string>> emailDatas = textEntityDatas
				.Select(data => new KeyValuePair<Guid, string>(data.EedId, data.EedUpdatedHash))
				.Distinct();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				foreach (KeyValuePair<Guid, string> emailData in emailDatas) {
					string hash = emailData.Value ?? string.Empty;
					Query update = new Update(_userConnection, "EnrchEmailData")
						.Set("Hash", Column.Parameter(hash))
						.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
						.Where("Id").IsEqual(Column.Parameter(emailData.Key));
					recordsAffected += update.Execute(dbExecutor);
				}
			}
			return recordsAffected;
		}

		private int UpdateEnrchProcessedData(List<TextEntityData> textEntityDatas) {
			int recordsAffected = 0;
			var hashValues = textEntityDatas
				.Select(data => new KeyValuePair<string, string>(data.EteHash, data.EteUpdatedHash))
				.Where(pair => pair.Key != pair.Value)
				.Distinct();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				foreach (KeyValuePair<string, string> hashValue in hashValues) {
					Query update = new Update(_userConnection, "EnrchProcessedData")
							.Set("TextEntityHash", Column.Parameter(hashValue.Value))
							.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
						.Where("TextEntityHash").IsEqual(Column.Parameter(hashValue.Key));
					recordsAffected += update.Execute(dbExecutor);
				}
			}
			return recordsAffected;
		}

		private int UpdateEnrchTextEntity(List<TextEntityData> textEntityDatas, int actualVersion) {
			int recordsAffected = 0;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				foreach (TextEntityData entityData in textEntityDatas) {
					string hash = entityData.EteUpdatedHash ?? string.Empty;
					Query update = new Update(_userConnection, "EnrchTextEntity")
							.Set("HashVersion", Column.Parameter(actualVersion))
							.Set("Hash", Column.Parameter(hash))
							.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
						.Where("Id").IsEqual(Column.Parameter(entityData.EteId));
					recordsAffected += update.Execute(dbExecutor);
				}
			}
			return recordsAffected;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Updates hashes of all known mining entities.
		/// </summary>
		public void Execute() {
			foreach (Type miningEntityType in _miningEntityTypes) {
				Execute(miningEntityType);
			}
		}

		#endregion

	}

	#endregion

}

