namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: MLConfigurationScriptBuilder

	[DefaultBinding(typeof(ICustomConfigurationScriptBuilder), Name = "MLConfigurationScriptBuilder")]
	public class MLConfigurationScriptBuilder : ICustomConfigurationScriptBuilder
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("ML");

		#endregion

		#region Methods: Private

		private static List<IGrouping<string, MLModelConfig>> GetModelsGroupedByEntityName(
				UserConnection userConnection) {
			IMLModelLoader modelLoader = ClassFactory.Get<IMLModelLoader>();
			var schemaManager = userConnection.EntitySchemaManager;
			var models = modelLoader.LoadAllModels(userConnection, safe: true)
				.Where(item => {
					if (item.PredictedResultColumnName.IsNullOrEmpty()) {
						_log.Warn($"PredictedResultColumnName is empty for model {item.Id}{Environment.NewLine}"
							+ $"Metadata: {item.MetaData}{Environment.NewLine}"
							+ $"Entity schemaUid: {item.PredictionEntitySchemaId}{Environment.NewLine}");
						return false;
					}
					return true;
				})
				.GroupBy(config => {
					var entitySchema = schemaManager.FindInstanceByUId(config.PredictionEntitySchemaId);
					return entitySchema?.Name ?? "unknownSchema";
				})
				.ToList();
			return models;
		}

		private static string GetSerializedPredictableSchemas(
				Dictionary<string, MLPredictableSchemaModels> predictableSchemas) {
			var converters = new JsonConverter[] {new GuidJsonConverter()};
			var serializedPredictableSchemas = JsonConvert.SerializeObject(predictableSchemas,
				new JsonSerializerSettings {
					Converters = converters,
					NullValueHandling = NullValueHandling.Ignore
				});
			return serializedPredictableSchemas;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns predictable columns script.
		/// </summary>
		/// <returns>Predictable columns script.</returns>
		public string BuildScript(UserConnection userConnection) {
			const string emptyConfig = "BPMSoft.configuration.PredictableEntities = {}";
			try {
				var clientScript = (string)userConnection.ApplicationCache[MLConsts.PredictableEntitiesScriptKey];
				if (clientScript.IsNotNullOrEmpty()) {
					return clientScript;
				}
				if (!userConnection.LicHelper.GetHasOperationLicense(MLConsts.LicOperationCode)) {
					return emptyConfig;
				}
				var models = GetModelsGroupedByEntityName(userConnection);
				Dictionary<string, MLPredictableSchemaModels> predictableSchemas = models.ToDictionary(
					group => group.Key,
					group => new MLPredictableSchemaModels {
						SchemaName = group.Key,
						Models = group.ToDictionary(
							item => item.Id,
							item => new MetaDataMimic {
								Output = new ModelSchemaColumn {
									Name = item.PredictedResultColumnName
								}
							})
					});
				string serializedPredictableSchemas = GetSerializedPredictableSchemas(predictableSchemas);
				clientScript = $"BPMSoft.configuration.PredictableEntities = {serializedPredictableSchemas};";
				userConnection.ApplicationCache[MLConsts.PredictableEntitiesScriptKey] = clientScript;
				return clientScript;
			} catch (Exception e) {
				_log.Error($"Can't build config for ML models: {e}");
				return emptyConfig;
			}
		}

		#endregion

	}

	#endregion

	#region Class: MetaDataMimic

	/// <summary>
	/// Mimics essensial ml model metadata info for UI.
	/// </summary>
	[DataContract]
	public class MetaDataMimic
	{

		#region Properties: Public

		[DataMember(Name = "output")]
		public ModelSchemaColumn Output { get; set; }

		#endregion

	}

	#endregion

	#region Class: MLPredictableSchemaModels

	/// <summary>
	/// Represents ML models for entity schema.
	/// </summary>
	[DataContract]
	public class MLPredictableSchemaModels
	{
		/// <summary>
		/// Gets or sets the name of the schema.
		/// </summary>
		/// <value>
		/// The name of the schema.
		/// </value>
		[DataMember]
		public string SchemaName {
			private get;
			set;
		}

		/// <summary>
		/// Gets or sets the models.
		/// </summary>
		/// <value>
		/// The models.
		/// </value>
		[DataMember]
		public Dictionary<Guid, MetaDataMimic> Models {
			private get;
			set;
		}

	}

	#endregion


}

