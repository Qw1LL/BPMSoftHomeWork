namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MLClassificationResult

	/// <exclude/>
	public class MLClassificationResult : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MLClassificationResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLClassificationResult";
		}

		public MLClassificationResult(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MLClassificationResult";
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

		/// <summary>
		/// Predicted entity Id.
		/// </summary>
		public Guid Key {
			get {
				return GetTypedColumnValue<Guid>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Predicted value.
		/// </summary>
		public Guid Value {
			get {
				return GetTypedColumnValue<Guid>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <summary>
		/// Predicted value probability.
		/// </summary>
		public Decimal Probability {
			get {
				return GetTypedColumnValue<Decimal>("Probability");
			}
			set {
				SetColumnValue("Probability", value);
			}
		}

		/// <summary>
		/// ML service model identifier.
		/// </summary>
		/// <remarks>
		/// Model instance Id.
		/// </remarks>
		public Guid ModelInstanceUId {
			get {
				return GetTypedColumnValue<Guid>("ModelInstanceUId");
			}
			set {
				SetColumnValue("ModelInstanceUId", value);
			}
		}

		/// <exclude/>
		public Guid ModelId {
			get {
				return GetTypedColumnValue<Guid>("ModelId");
			}
			set {
				SetColumnValue("ModelId", value);
				_model = null;
			}
		}

		/// <exclude/>
		public string ModelName {
			get {
				return GetTypedColumnValue<string>("ModelName");
			}
			set {
				SetColumnValue("ModelName", value);
				if (_model != null) {
					_model.Name = value;
				}
			}
		}

		private MLModel _model;
		/// <summary>
		/// ML model.
		/// </summary>
		public MLModel Model {
			get {
				return _model ??
					(_model = new MLModel(LookupColumnEntities.GetEntity("Model")));
			}
		}

		/// <summary>
		/// Prediction significance.
		/// </summary>
		public string Significance {
			get {
				return GetTypedColumnValue<string>("Significance");
			}
			set {
				SetColumnValue("Significance", value);
			}
		}

		#endregion

	}

	#endregion

}

