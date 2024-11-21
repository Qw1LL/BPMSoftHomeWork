namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MLSimilarCase

	/// <exclude/>
	public class MLSimilarCase : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MLSimilarCase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLSimilarCase";
		}

		public MLSimilarCase(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MLSimilarCase";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid PredictionQualityId {
			get {
				return GetTypedColumnValue<Guid>("PredictionQualityId");
			}
			set {
				SetColumnValue("PredictionQualityId", value);
				_predictionQuality = null;
			}
		}

		/// <exclude/>
		public string PredictionQualityName {
			get {
				return GetTypedColumnValue<string>("PredictionQualityName");
			}
			set {
				SetColumnValue("PredictionQualityName", value);
				if (_predictionQuality != null) {
					_predictionQuality.Name = value;
				}
			}
		}

		private MLPredictionQuality _predictionQuality;
		/// <summary>
		/// Качество прогноза.
		/// </summary>
		public MLPredictionQuality PredictionQuality {
			get {
				return _predictionQuality ??
					(_predictionQuality = new MLPredictionQuality(LookupColumnEntities.GetEntity("PredictionQuality")));
			}
		}

		/// <summary>
		/// Оценка похожести.
		/// </summary>
		public Decimal Score {
			get {
				return GetTypedColumnValue<Decimal>("Score");
			}
			set {
				SetColumnValue("Score", value);
			}
		}

		/// <summary>
		/// Дата прогноза.
		/// </summary>
		public DateTime PredictionDate {
			get {
				return GetTypedColumnValue<DateTime>("PredictionDate");
			}
			set {
				SetColumnValue("PredictionDate", value);
			}
		}

		/// <exclude/>
		public Guid MLModelId {
			get {
				return GetTypedColumnValue<Guid>("MLModelId");
			}
			set {
				SetColumnValue("MLModelId", value);
				_mLModel = null;
			}
		}

		/// <exclude/>
		public string MLModelName {
			get {
				return GetTypedColumnValue<string>("MLModelName");
			}
			set {
				SetColumnValue("MLModelName", value);
				if (_mLModel != null) {
					_mLModel.Name = value;
				}
			}
		}

		private MLModel _mLModel;
		/// <summary>
		/// Модель машинного обучения.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = new MLModel(LookupColumnEntities.GetEntity("MLModel")));
			}
		}

		/// <exclude/>
		public Guid SimilarCaseId {
			get {
				return GetTypedColumnValue<Guid>("SimilarCaseId");
			}
			set {
				SetColumnValue("SimilarCaseId", value);
				_similarCase = null;
			}
		}

		/// <exclude/>
		public string SimilarCaseNumber {
			get {
				return GetTypedColumnValue<string>("SimilarCaseNumber");
			}
			set {
				SetColumnValue("SimilarCaseNumber", value);
				if (_similarCase != null) {
					_similarCase.Number = value;
				}
			}
		}

		private Case _similarCase;
		/// <summary>
		/// Похожее обращение.
		/// </summary>
		public Case SimilarCase {
			get {
				return _similarCase ??
					(_similarCase = new Case(LookupColumnEntities.GetEntity("SimilarCase")));
			}
		}

		/// <exclude/>
		public Guid ParentCaseId {
			get {
				return GetTypedColumnValue<Guid>("ParentCaseId");
			}
			set {
				SetColumnValue("ParentCaseId", value);
				_parentCase = null;
			}
		}

		/// <exclude/>
		public string ParentCaseNumber {
			get {
				return GetTypedColumnValue<string>("ParentCaseNumber");
			}
			set {
				SetColumnValue("ParentCaseNumber", value);
				if (_parentCase != null) {
					_parentCase.Number = value;
				}
			}
		}

		private Case _parentCase;
		/// <summary>
		/// Родительское обращение.
		/// </summary>
		public Case ParentCase {
			get {
				return _parentCase ??
					(_parentCase = new Case(LookupColumnEntities.GetEntity("ParentCase")));
			}
		}

		#endregion

	}

	#endregion

}

