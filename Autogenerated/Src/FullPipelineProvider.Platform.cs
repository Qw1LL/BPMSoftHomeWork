namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Nui.ServiceModel.DataContract;

	#region Interface: IFullPipelineProvider 

	/// <summary>
	/// Provides methods for provider of full pipeline data.
	/// </summary>
	public interface IFullPipelineProvider
	{
		/// <summary>
		/// Returns all slices data of full pipeline by <see cref="FullPipelineEntityConfig"/>.
		/// </summary>
		/// <param name="entitiesConfig">Entities configuration.</param>
		/// <returns>Data of full pipeline by slices <see cref="FullPipelineSlice"/>.</returns>
		FullPipelineInfo GetAllSlicesData(IList<FullPipelineEntityConfig> entitiesConfig);

	}

	#endregion

	#region Class: FullPipelineProvider

	/// <summary>
	/// Provider of full pipeline data.
	/// </summary>
	[DefaultBinding(typeof(IFullPipelineProvider))]
	public class FullPipelineProvider: IFullPipelineProvider
	{

		#region Constants: Private

		private const decimal _baseStageConversion = 100m;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private IFullPipelineDataRetriever _dataRetriever;
		private IGetRepositoryFactory<CommonStageData> _stageRepositoryFactory;
		private ISysModuleStageHistoryRepository _stageHistoryRepository;
		private readonly Dictionary<FullPipelineSliceType, string> _elementValueNameMap = 
			new Dictionary<FullPipelineSliceType, string> {
				{ FullPipelineSliceType.Count, "CountInStage" },
				{ FullPipelineSliceType.ConversionToStage, "ConversionToStage" },
				{ FullPipelineSliceType.ConversionToFirstStage, "ConversionToFirstStage" },
			};

		#endregion

		#region Constructors: Public

		public FullPipelineProvider(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public IFullPipelineDataRetriever DataRetriever {
			get {
				return _dataRetriever ?? (_dataRetriever = GetDataRetriever());
			}
			set {
				if (_dataRetriever != null) {
					throw new ItemAlreadyExistException(nameof(DataRetriever));
				}
				value.CheckArgumentNull(nameof(DataRetriever));
				_dataRetriever = value;
			}
		}

		public IGetRepositoryFactory<CommonStageData> StageRepositoryFactory {
			get {
				return _stageRepositoryFactory ?? (_stageRepositoryFactory = GetStageRepositoryFactory());
			}
			set {
				if (_stageRepositoryFactory != null) {
					throw new ItemAlreadyExistException(nameof(StageRepositoryFactory));
				}
				value.CheckArgumentNull(nameof(StageRepositoryFactory));
				_stageRepositoryFactory = value;
			}
		}

		public ISysModuleStageHistoryRepository StageHistoryRepository {
			get {
				return _stageHistoryRepository ?? (_stageHistoryRepository = GetStageSettingsRepository());
			}
			set {
				if (_stageHistoryRepository != null) {
					throw new ItemAlreadyExistException(nameof(StageHistoryRepository));
				}
				value.CheckArgumentNull(nameof(StageHistoryRepository));
				_stageHistoryRepository = value;
			}
		}

		#endregion

		#region Methods: Private

		private IFullPipelineDataRetriever GetDataRetriever() {
			IFullPipelineQueryBuilder builder = GetBuilder();
			return ClassFactory.Get<IFullPipelineDataRetriever>(
				new ConstructorArgument("userConnection", _userConnection),
				new ConstructorArgument("builder", builder));
		}

		private IFullPipelineQueryBuilder GetBuilder() {
			IGetRepositoryFactory<CommonStageData> stageRepositoryFactory = StageRepositoryFactory;
			ISysModuleStageHistoryRepository stageSettingsRepository = StageHistoryRepository;
			return ClassFactory.Get<IFullPipelineQueryBuilder>(
				new ConstructorArgument("userConnection", _userConnection),
				new ConstructorArgument("stageRepositoryFactory", stageRepositoryFactory),
				new ConstructorArgument("stageSettingsRepository", stageSettingsRepository));
		}

		private ISysModuleStageHistoryRepository GetStageSettingsRepository() => 
			ClassFactory.Get<ISysModuleStageHistoryRepository>(
				new ConstructorArgument("userConnection", _userConnection));

		private IGetRepositoryFactory<CommonStageData> GetStageRepositoryFactory() =>
			ClassFactory.Get<IGetRepositoryFactory<CommonStageData>>(
				new ConstructorArgument("userConnection", _userConnection));

		private string GetElementValueNameBySliceType(FullPipelineSliceType sliceType) {
			return _elementValueNameMap[sliceType];
		}

		private IEnumerable<StagesInfo> GetStageInfos(IEnumerable<FullPipelineEntityConfig> entitiesConfig) {
			var result = new List<StagesInfo>();
			foreach (var entityConfig in entitiesConfig) {
				int maxNumber = result.Count;
				List<CommonStageData> stages = GetEntityStages(entityConfig.SchemaName)
					.OrderBy(member => member.Number).ToList();
				for (int i = 0; i < stages.Count; i++) {
					var stage = stages[i];
					result.Add(new StagesInfo {
						Id = stage.Id,
						Number = i + maxNumber,
						DisplayValue = stage.DisplayValue,
						SchemaName = entityConfig.SchemaName
					});
				}
			}
			return result;
		}

		private IEnumerable<CommonStageData> GetEntityStages(string schemaName) {
			var stageHistorySettings = StageHistoryRepository.Get(schemaName);
			var instance = StageRepositoryFactory.GetRepository(stageHistorySettings);
			return instance.GetAll();
		}

		private void AddCalculatedProperties(List<FullPipelineStageDataElement> elements, FullPipelineRow data) {
			if (data == null) {
				return;
			}
			data.CalculatedProperties.ForEach(keyValue => elements.Add(new FullPipelineStageDataElement {
				Name = keyValue.Key,
				Value = keyValue.Value
			}));
		}

		private decimal GetConversion(FullPipelineRow currentStage, FullPipelineRow baseStage) {
			if (currentStage == null) {
				return 0m;
			}
			if (baseStage == null || baseStage.OverallCount == 0) {
				return currentStage.OverallCount == 0m ? 0m : _baseStageConversion;
			}
			return (currentStage.OverallCount / baseStage.OverallCount) * 100;
		}

		private IEnumerable<FullPipelineSlice> GetSlicesByTypes(IEnumerable<FullPipelineSliceType> slicesTypes) {
			var slices = new List<FullPipelineSlice>();
			foreach (var item in slicesTypes) {
				slices.Add(new FullPipelineSlice {
					Type = item,
					Data = new List<FullPipelineStageData>()
				});
			}
			return slices;
		}

		private FullPipelineGroupedDataRow[] GetPreparedToCalculationsData(IEnumerable<FullPipelineRow> data,
			IEnumerable<StagesInfo> stageData) {
			var joinedData = from stageInfo in stageData
							 join stage in data on stageInfo.Id equals stage.StageId into joinData
							 from joinDataElement in joinData.DefaultIfEmpty()
							 select new FullPipelineGroupedDataRow {
								 StageData = stageInfo,
								 Data = joinDataElement
							 };
			return joinedData.OrderBy(e => e.StageData.Number).ToArray();
		}

		private IEnumerable<FullPipelineSlice> GetSlices(IEnumerable<FullPipelineRow> data,
				IEnumerable<StagesInfo> stageData, IEnumerable<FullPipelineSliceType> slicesTypes) {
			var slices = GetSlicesByTypes(slicesTypes);
			 var preparedData = GetPreparedToCalculationsData(data, stageData);
			var firstStage = preparedData[0];
			for (int i = 0; i < preparedData.Count(); i++) {
				var currentStage = preparedData[i];
				var currentStageData = currentStage?.Data;
				foreach (var slice in slices) {
					decimal sliceValue = 0m;
					string elementCountValueName = GetElementValueNameBySliceType(slice.Type) + "Count";
					switch (slice.Type) {
						case FullPipelineSliceType.Count:
							sliceValue = currentStageData?.CountInStage ?? 0m;
							break;
						case FullPipelineSliceType.ConversionToStage:
							var previousStage = preparedData[Math.Max(0, i - 1)];
							sliceValue = GetConversion(currentStageData, previousStage?.Data);
							AddConversionCount(currentStageData, elementCountValueName);
							break;
						case FullPipelineSliceType.ConversionToFirstStage:
							sliceValue = GetConversion(currentStageData, firstStage.Data);
							AddConversionCount(currentStageData, elementCountValueName);
							break;
					}
					List<FullPipelineStageDataElement> elements = new List<FullPipelineStageDataElement> {
						new FullPipelineStageDataElement {
							Name = GetElementValueNameBySliceType(slice.Type),
							Value = sliceValue
						}
					};
					AddCalculatedProperties(elements, currentStageData);
					slice.Data.Add(new FullPipelineStageData {
						StageId = currentStage.StageData.Id,
						Elements = elements
					});
				}
			}
			return slices;
		}

		private void AddConversionCount(FullPipelineRow currentStageData, string attributeName) {
			if (currentStageData != null) {
				currentStageData.CalculatedProperties[attributeName] = currentStageData.OverallCount;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns all slices data of full pipeline by <see cref="FullPipelineEntityConfig"/>.
		/// </summary>
		/// <param name="entitiesConfig">Entities configuration.</param>
		/// <returns>Data of full pipeline by slices <see cref="FullPipelineSlice"/>.</returns>
		public FullPipelineInfo GetAllSlicesData(IList<FullPipelineEntityConfig> entitiesConfig) {
			var result = new FullPipelineInfo();
			IEnumerable<FullPipelineRow> data = DataRetriever.DataRetrieve(entitiesConfig);
			var stageInfo = GetStageInfos(entitiesConfig);
			result.Slices = GetSlices(data, stageInfo, new [] {
				FullPipelineSliceType.Count,
				FullPipelineSliceType.ConversionToStage,
				FullPipelineSliceType.ConversionToFirstStage
			});
			result.StagesInfo = stageInfo;
			return result;
		}

		#endregion

	}

	#endregion

	#region Class: FullPipelineInfo

	[DataContract]
	public class FullPipelineInfo
	{
		[DataMember(Name = "slices")]
		public IEnumerable<FullPipelineSlice> Slices {
			get; set;
		}

		[DataMember(Name = "stagesInfo")]
		public IEnumerable<StagesInfo> StagesInfo {
			get; set;
		}

	}

	#endregion

	#region Class: StagesInfo

	[DataContract]
	public class StagesInfo
	{
		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "displayValue")]
		public string DisplayValue {
			get; set;
		}

		[DataMember(Name = "number")]
		public int Number {
			get; set;
		}

		[DataMember(Name = "schemaName")]
		public string SchemaName {
			get;
			internal set;
		}
	}

	#endregion

	#region Class: FullPipelineSlice

	[DataContract]
	public class FullPipelineSlice
	{
		[DataMember(Name = "type")]
		public FullPipelineSliceType Type { get; set; }

		[DataMember(Name = "data")]
		public List<FullPipelineStageData> Data { get; set; }
	}

	#endregion

	#region Class: FullPipelineStageData

	[DataContract]
	public class FullPipelineStageData
	{
		[DataMember(Name = "stageId")]
		public Guid StageId { get; set; }

		[DataMember(Name = "elements")]
		public List<FullPipelineStageDataElement> Elements { get; set; }
	}

	#endregion

	#region Class: FullPipelineStageDataElement

	[DataContract]
	public class FullPipelineStageDataElement
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "value")]
		public decimal Value { get; set; }
	}

	#endregion

	#region Class: FullPipelineEntityConfig

	[DataContract]
	public class FullPipelineEntityConfig
	{
		[DataMember(Name = "schemaName")]
		public string SchemaName { get; set; }

		[DataMember(Name = "connectedWith")]
		public FullPipelineEntityConnectedWithConfig ConnectedWith { get; set; }

		[DataMember(Name = "calculatedOperations")]
		public IEnumerable<CalculatedOperation> CalculatedOperations { get; set; }

		[DataMember(Name = "startDate")]
		public string StartDate { get; set; }

		[DataMember(Name = "dueDate")]
		public string DueDate { get; set; }

		[DataMember(Name = "filters")]
		public string Filters { get; set; }

		public Filters GetFilters() {
			return string.IsNullOrEmpty(Filters) ? new Filters() : JsonConvert.DeserializeObject<Filters>(Filters);
		}
	}

	#endregion

	#region Class: CalculatedOperation

	[DataContract]
	public class CalculatedOperation
	{
		[DataMember(Name = "operation")]
		public string Operation { get; set; }

		[DataMember(Name = "targetColumnName")]
		public string TargetColumnName { get; set; }
	}

	#endregion

	#region Class: FullPipelineEntityConnectedWithConfig

	[DataContract]
	public class FullPipelineEntityConnectedWithConfig
	{
		[DataMember(Name = "type")]
		public FullPipelineSchemaConnectionType Type { get; set; }

		[DataMember(Name = "schemaName")]
		public string SchemaName { get; set; }

		[DataMember(Name = "connectionSchemaName")]
		public string ConnectionSchemaName { get; set; }

		[DataMember(Name = "parentSchemaColumnName")]
		public string ParentSchemaColumnName { get; set; }

		[DataMember(Name = "childSchemaColumnName")]
		public string ChildSchemaColumnName { get; set; }
	}

	#endregion

	public class FullPipelineGroupedDataRow
	{
		public FullPipelineRow Data { get; set; }
		public StagesInfo StageData { get; set; }
	}

	#region Enum: FullPipelineSchemaConnectionType

	public enum FullPipelineSchemaConnectionType
	{
		Direct = 0,
		Reverse = 1,
		ManyToMany = 2
	}

	#endregion

	#region Enum: FullPipelineSliceType

	public enum FullPipelineSliceType
	{
		Count = 0,
		ConversionToFirstStage = 1,
		ConversionToStage = 2
	}

	#endregion

}

