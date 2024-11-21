namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ScoringModel

	/// <exclude/>
	public class ScoringModel : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ScoringModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ScoringModel";
		}

		public ScoringModel(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ScoringModel";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ScoringModel> ScoringModelCollectionBySourceModel {
			get;
			set;
		}

		public IEnumerable<ScoringRule> ScoringRuleCollectionByScoringModel {
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
		/// Name.
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
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid SourceModelId {
			get {
				return GetTypedColumnValue<Guid>("SourceModelId");
			}
			set {
				SetColumnValue("SourceModelId", value);
				_sourceModel = null;
			}
		}

		/// <exclude/>
		public string SourceModelName {
			get {
				return GetTypedColumnValue<string>("SourceModelName");
			}
			set {
				SetColumnValue("SourceModelName", value);
				if (_sourceModel != null) {
					_sourceModel.Name = value;
				}
			}
		}

		private ScoringModel _sourceModel;
		/// <summary>
		/// Source model.
		/// </summary>
		public ScoringModel SourceModel {
			get {
				return _sourceModel ??
					(_sourceModel = new ScoringModel(LookupColumnEntities.GetEntity("SourceModel")));
			}
		}

		/// <exclude/>
		public Guid ScoringObjectId {
			get {
				return GetTypedColumnValue<Guid>("ScoringObjectId");
			}
			set {
				SetColumnValue("ScoringObjectId", value);
				_scoringObject = null;
			}
		}

		/// <exclude/>
		public string ScoringObjectName {
			get {
				return GetTypedColumnValue<string>("ScoringObjectName");
			}
			set {
				SetColumnValue("ScoringObjectName", value);
				if (_scoringObject != null) {
					_scoringObject.Name = value;
				}
			}
		}

		private VwSysModuleEntity _scoringObject;
		/// <summary>
		/// Scoring object.
		/// </summary>
		public VwSysModuleEntity ScoringObject {
			get {
				return _scoringObject ??
					(_scoringObject = new VwSysModuleEntity(LookupColumnEntities.GetEntity("ScoringObject")));
			}
		}

		/// <summary>
		/// Scoring parameter UId.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Scoring parameter.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		#endregion

	}

	#endregion

}

