namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MLTrainSession

	/// <exclude/>
	public class MLTrainSession : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MLTrainSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLTrainSession";
		}

		public MLTrainSession(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MLTrainSession";
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
		/// Created on.
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
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
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
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
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
		/// Model.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = new MLModel(LookupColumnEntities.GetEntity("MLModel")));
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
		/// Status.
		/// </summary>
		public MLModelState State {
			get {
				return _state ??
					(_state = new MLModelState(LookupColumnEntities.GetEntity("State")));
			}
		}

		/// <summary>
		/// Model in use.
		/// </summary>
		public bool InUse {
			get {
				return GetTypedColumnValue<bool>("InUse");
			}
			set {
				SetColumnValue("InUse", value);
			}
		}

		/// <summary>
		/// Error message text.
		/// </summary>
		public string Error {
			get {
				return GetTypedColumnValue<string>("Error");
			}
			set {
				SetColumnValue("Error", value);
			}
		}

		/// <summary>
		/// Trained on.
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
		/// Train set size.
		/// </summary>
		public int TrainSetSize {
			get {
				return GetTypedColumnValue<int>("TrainSetSize");
			}
			set {
				SetColumnValue("TrainSetSize", value);
			}
		}

		/// <summary>
		/// Evaluation metric.
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
		/// Training time (min.).
		/// </summary>
		public int TrainingTimeMinutes {
			get {
				return GetTypedColumnValue<int>("TrainingTimeMinutes");
			}
			set {
				SetColumnValue("TrainingTimeMinutes", value);
			}
		}

		/// <summary>
		/// Ignore metric threshold mode.
		/// </summary>
		public bool IgnoreMetricThreshold {
			get {
				return GetTypedColumnValue<bool>("IgnoreMetricThreshold");
			}
			set {
				SetColumnValue("IgnoreMetricThreshold", value);
			}
		}

		/// <summary>
		/// Importance of model input columns.
		/// </summary>
		public string FeatureImportances {
			get {
				return GetTypedColumnValue<string>("FeatureImportances");
			}
			set {
				SetColumnValue("FeatureImportances", value);
			}
		}

		#endregion

	}

	#endregion

}

