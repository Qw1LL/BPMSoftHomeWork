namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MLModel

	/// <exclude/>
	public class MLModel : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MLModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModel";
		}

		public MLModel(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MLModel";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MLClassificationResult> MLClassificationResultCollectionByModel {
			get;
			set;
		}

		public IEnumerable<MLModelColumn> MLModelColumnCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<MLModelFile> MLModelFileCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<MLModelInFolder> MLModelInFolderCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<MLModelInTag> MLModelInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<MLPrediction> MLPredictionCollectionByModel {
			get;
			set;
		}

		public IEnumerable<MLSimilarCase> MLSimilarCaseCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<MLTrainSession> MLTrainSessionCollectionByMLModel {
			get;
			set;
		}

		public IEnumerable<RecommendedProduct> RecommendedProductCollectionByMLModel {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Переобучать через, дней.
		/// </summary>
		public int TrainFrequency {
			get {
				return GetTypedColumnValue<int>("TrainFrequency");
			}
			set {
				SetColumnValue("TrainFrequency", value);
			}
		}

		/// <summary>
		/// Время, когда экземпляр был обучен.
		/// </summary>
		public DateTime TrainedOn {
			get {
				return GetTypedColumnValue<DateTime>("TrainedOn");
			}
			set {
				SetColumnValue("TrainedOn", value);
			}
		}

		/// <summary>
		/// Время последней попытки обучения.
		/// </summary>
		public DateTime TriedToTrainOn {
			get {
				return GetTypedColumnValue<DateTime>("TriedToTrainOn");
			}
			set {
				SetColumnValue("TriedToTrainOn", value);
			}
		}

		/// <summary>
		/// Метаданные выборки дополнительных данных обучения.
		/// </summary>
		public string MetaData {
			get {
				return GetTypedColumnValue<string>("MetaData");
			}
			set {
				SetColumnValue("MetaData", value);
			}
		}

		/// <summary>
		/// Локализированная часть метаданных.
		/// </summary>
		public string MetaDataLcz {
			get {
				return GetTypedColumnValue<string>("MetaDataLcz");
			}
			set {
				SetColumnValue("MetaDataLcz", value);
			}
		}

		/// <summary>
		/// Выражение для выборки дополнительных данных обучения.
		/// </summary>
		public string TrainingSetQuery {
			get {
				return GetTypedColumnValue<string>("TrainingSetQuery");
			}
			set {
				SetColumnValue("TrainingSetQuery", value);
			}
		}

		/// <summary>
		/// Объект.
		/// </summary>
		public Guid RootSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("RootSchemaUId");
			}
			set {
				SetColumnValue("RootSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private MLModelState _state;
		/// <summary>
		/// Статус модели.
		/// </summary>
		public MLModelState State {
			get {
				return _state ??
					(_state = new MLModelState(LookupColumnEntities.GetEntity("State")));
			}
		}

		/// <summary>
		/// Ожидаемая точность.
		/// </summary>
		public Decimal InstanceMetric {
			get {
				return GetTypedColumnValue<Decimal>("InstanceMetric");
			}
			set {
				SetColumnValue("InstanceMetric", value);
			}
		}

		/// <summary>
		/// Нижний порог допустимого качества.
		/// </summary>
		public Decimal MetricThreshold {
			get {
				return GetTypedColumnValue<Decimal>("MetricThreshold");
			}
			set {
				SetColumnValue("MetricThreshold", value);
			}
		}

		/// <summary>
		/// Прогнозирование активно.
		/// </summary>
		public bool PredictionEnabled {
			get {
				return GetTypedColumnValue<bool>("PredictionEnabled");
			}
			set {
				SetColumnValue("PredictionEnabled", value);
			}
		}

		/// <summary>
		/// Текущая сессия обучения.
		/// </summary>
		public Guid TrainSessionId {
			get {
				return GetTypedColumnValue<Guid>("TrainSessionId");
			}
			set {
				SetColumnValue("TrainSessionId", value);
			}
		}

		/// <exclude/>
		public Guid MLProblemTypeId {
			get {
				return GetTypedColumnValue<Guid>("MLProblemTypeId");
			}
			set {
				SetColumnValue("MLProblemTypeId", value);
				_mLProblemType = null;
			}
		}

		/// <exclude/>
		public string MLProblemTypeName {
			get {
				return GetTypedColumnValue<string>("MLProblemTypeName");
			}
			set {
				SetColumnValue("MLProblemTypeName", value);
				if (_mLProblemType != null) {
					_mLProblemType.Name = value;
				}
			}
		}

		private MLProblemType _mLProblemType;
		/// <summary>
		/// Тип.
		/// </summary>
		public MLProblemType MLProblemType {
			get {
				return _mLProblemType ??
					(_mLProblemType = new MLProblemType(LookupColumnEntities.GetEntity("MLProblemType")));
			}
		}

		/// <summary>
		/// Текущий идентификатор экземпляра.
		/// </summary>
		public string ModelInstanceUId {
			get {
				return GetTypedColumnValue<string>("ModelInstanceUId");
			}
			set {
				SetColumnValue("ModelInstanceUId", value);
			}
		}

		/// <summary>
		/// Текст последней ошибки.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Дата вызова пакетного прогнозирования.
		/// </summary>
		public DateTime BatchPredictedOn {
			get {
				return GetTypedColumnValue<DateTime>("BatchPredictedOn");
			}
			set {
				SetColumnValue("BatchPredictedOn", value);
			}
		}

		/// <summary>
		/// Выражение для выборки дополнительных данных прогнозирования.
		/// </summary>
		public string BatchPredictionQuery {
			get {
				return GetTypedColumnValue<string>("BatchPredictionQuery");
			}
			set {
				SetColumnValue("BatchPredictionQuery", value);
			}
		}

		/// <summary>
		/// Целевая колонка.
		/// </summary>
		public Guid TargetColumnUId {
			get {
				return GetTypedColumnValue<Guid>("TargetColumnUId");
			}
			set {
				SetColumnValue("TargetColumnUId", value);
			}
		}

		/// <exclude/>
		public Guid BatchPredictionStartMethodId {
			get {
				return GetTypedColumnValue<Guid>("BatchPredictionStartMethodId");
			}
			set {
				SetColumnValue("BatchPredictionStartMethodId", value);
				_batchPredictionStartMethod = null;
			}
		}

		/// <exclude/>
		public string BatchPredictionStartMethodName {
			get {
				return GetTypedColumnValue<string>("BatchPredictionStartMethodName");
			}
			set {
				SetColumnValue("BatchPredictionStartMethodName", value);
				if (_batchPredictionStartMethod != null) {
					_batchPredictionStartMethod.Name = value;
				}
			}
		}

		private MLTaskStartMethod _batchPredictionStartMethod;
		/// <summary>
		/// Способ запуска пакетного прогнозирования.
		/// </summary>
		public MLTaskStartMethod BatchPredictionStartMethod {
			get {
				return _batchPredictionStartMethod ??
					(_batchPredictionStartMethod = new MLTaskStartMethod(LookupColumnEntities.GetEntity("BatchPredictionStartMethod")));
			}
		}

		/// <summary>
		/// Минимальное количество записей для обучения.
		/// </summary>
		public int TrainingMinimumRecordsCount {
			get {
				return GetTypedColumnValue<int>("TrainingMinimumRecordsCount");
			}
			set {
				SetColumnValue("TrainingMinimumRecordsCount", value);
			}
		}

		/// <summary>
		/// Максимальное количество записей для обучения.
		/// </summary>
		public int TrainingMaxRecordsCount {
			get {
				return GetTypedColumnValue<int>("TrainingMaxRecordsCount");
			}
			set {
				SetColumnValue("TrainingMaxRecordsCount", value);
			}
		}

		/// <summary>
		/// Колонка для сохранения результата прогнозирования.
		/// </summary>
		public Guid PredictedResultColumnUId {
			get {
				return GetTypedColumnValue<Guid>("PredictedResultColumnUId");
			}
			set {
				SetColumnValue("PredictedResultColumnUId", value);
			}
		}

		/// <exclude/>
		public Guid MLConfidentValueMethodId {
			get {
				return GetTypedColumnValue<Guid>("MLConfidentValueMethodId");
			}
			set {
				SetColumnValue("MLConfidentValueMethodId", value);
				_mLConfidentValueMethod = null;
			}
		}

		/// <exclude/>
		public string MLConfidentValueMethodName {
			get {
				return GetTypedColumnValue<string>("MLConfidentValueMethodName");
			}
			set {
				SetColumnValue("MLConfidentValueMethodName", value);
				if (_mLConfidentValueMethod != null) {
					_mLConfidentValueMethod.Name = value;
				}
			}
		}

		private MLConfidentValueMethod _mLConfidentValueMethod;
		/// <summary>
		/// Метод выбора прогнозируемого значения.
		/// </summary>
		public MLConfidentValueMethod MLConfidentValueMethod {
			get {
				return _mLConfidentValueMethod ??
					(_mLConfidentValueMethod = new MLConfidentValueMethod(LookupColumnEntities.GetEntity("MLConfidentValueMethod")));
			}
		}

		/// <summary>
		/// Нижний предел вероятности для выбора прогнозируемого значения.
		/// </summary>
		public Decimal ConfidentValueLowEdge {
			get {
				return GetTypedColumnValue<Decimal>("ConfidentValueLowEdge");
			}
			set {
				SetColumnValue("ConfidentValueLowEdge", value);
			}
		}

		/// <summary>
		/// Кому рекомендовать (Субъект).
		/// </summary>
		public string CFUserColumnPath {
			get {
				return GetTypedColumnValue<string>("CFUserColumnPath");
			}
			set {
				SetColumnValue("CFUserColumnPath", value);
			}
		}

		/// <summary>
		/// Что рекомендовать (Предмет).
		/// </summary>
		public string CFItemColumnPath {
			get {
				return GetTypedColumnValue<string>("CFItemColumnPath");
			}
			set {
				SetColumnValue("CFItemColumnPath", value);
			}
		}

		/// <summary>
		/// По какой колонке считать.
		/// </summary>
		public string CFInteractionValueColumnPath {
			get {
				return GetTypedColumnValue<string>("CFInteractionValueColumnPath");
			}
			set {
				SetColumnValue("CFInteractionValueColumnPath", value);
			}
		}

		/// <summary>
		/// Схема результата множественного прогноза.
		/// </summary>
		public Guid ListPredictResultSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ListPredictResultSchemaUId");
			}
			set {
				SetColumnValue("ListPredictResultSchemaUId", value);
			}
		}

		/// <summary>
		/// Колонка субъекта множественного прогноза.
		/// </summary>
		public string ListPredictResultSubjectColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultSubjectColumn");
			}
			set {
				SetColumnValue("ListPredictResultSubjectColumn", value);
			}
		}

		/// <summary>
		/// Колонка объекта множественного прогноза.
		/// </summary>
		public string ListPredictResultObjectColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultObjectColumn");
			}
			set {
				SetColumnValue("ListPredictResultObjectColumn", value);
			}
		}

		/// <summary>
		/// Колонка значения множественного прогноза.
		/// </summary>
		public string ListPredictResultValueColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultValueColumn");
			}
			set {
				SetColumnValue("ListPredictResultValueColumn", value);
			}
		}

		/// <summary>
		/// Колонка модели множественного прогноза.
		/// </summary>
		public string ListPredictResultModelColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultModelColumn");
			}
			set {
				SetColumnValue("ListPredictResultModelColumn", value);
			}
		}

		/// <summary>
		/// Колонка даты множественного прогноза.
		/// </summary>
		public string ListPredictResultDateColumn {
			get {
				return GetTypedColumnValue<string>("ListPredictResultDateColumn");
			}
			set {
				SetColumnValue("ListPredictResultDateColumn", value);
			}
		}

		/// <summary>
		/// Список количества факторов.
		/// </summary>
		public string FactorsCounts {
			get {
				return GetTypedColumnValue<string>("FactorsCounts");
			}
			set {
				SetColumnValue("FactorsCounts", value);
			}
		}

		/// <summary>
		/// Список параметров регуляризации.
		/// </summary>
		public string RegularizationValues {
			get {
				return GetTypedColumnValue<string>("RegularizationValues");
			}
			set {
				SetColumnValue("RegularizationValues", value);
			}
		}

		/// <summary>
		/// Объект для прогнозирования.
		/// </summary>
		public Guid PredictionSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("PredictionSchemaUId");
			}
			set {
				SetColumnValue("PredictionSchemaUId", value);
			}
		}

		/// <summary>
		/// Нижний порог оценки похожести.
		/// </summary>
		public Decimal LowerScoreThreshold {
			get {
				return GetTypedColumnValue<Decimal>("LowerScoreThreshold");
			}
			set {
				SetColumnValue("LowerScoreThreshold", value);
			}
		}

		/// <exclude/>
		public Guid LastTrainingErrorId {
			get {
				return GetTypedColumnValue<Guid>("LastTrainingErrorId");
			}
			set {
				SetColumnValue("LastTrainingErrorId", value);
				_lastTrainingError = null;
			}
		}

		/// <exclude/>
		public string LastTrainingErrorPattern {
			get {
				return GetTypedColumnValue<string>("LastTrainingErrorPattern");
			}
			set {
				SetColumnValue("LastTrainingErrorPattern", value);
				if (_lastTrainingError != null) {
					_lastTrainingError.Pattern = value;
				}
			}
		}

		private MLError _lastTrainingError;
		/// <summary>
		/// Последняя ошибка обучения.
		/// </summary>
		public MLError LastTrainingError {
			get {
				return _lastTrainingError ??
					(_lastTrainingError = new MLError(LookupColumnEntities.GetEntity("LastTrainingError")));
			}
		}

		#endregion

	}

	#endregion

}

