namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ScoringRule

	/// <exclude/>
	public class ScoringRule : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ScoringRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ScoringRule";
		}

		public ScoringRule(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ScoringRule";
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
		/// Rule name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid ScoringModelId {
			get {
				return GetTypedColumnValue<Guid>("ScoringModelId");
			}
			set {
				SetColumnValue("ScoringModelId", value);
				_scoringModel = null;
			}
		}

		/// <exclude/>
		public string ScoringModelName {
			get {
				return GetTypedColumnValue<string>("ScoringModelName");
			}
			set {
				SetColumnValue("ScoringModelName", value);
				if (_scoringModel != null) {
					_scoringModel.Name = value;
				}
			}
		}

		private ScoringModel _scoringModel;
		/// <summary>
		/// Scoring model.
		/// </summary>
		public ScoringModel ScoringModel {
			get {
				return _scoringModel ??
					(_scoringModel = new ScoringModel(LookupColumnEntities.GetEntity("ScoringModel")));
			}
		}

		/// <summary>
		/// Filter.
		/// </summary>
		public string FilterData {
			get {
				return GetTypedColumnValue<string>("FilterData");
			}
			set {
				SetColumnValue("FilterData", value);
			}
		}

		/// <summary>
		/// Number of times applied.
		/// </summary>
		public int ScoringCount {
			get {
				return GetTypedColumnValue<int>("ScoringCount");
			}
			set {
				SetColumnValue("ScoringCount", value);
			}
		}

		/// <summary>
		/// Scoring points.
		/// </summary>
		public Decimal ScoringPoints {
			get {
				return GetTypedColumnValue<Decimal>("ScoringPoints");
			}
			set {
				SetColumnValue("ScoringPoints", value);
			}
		}

		/// <summary>
		/// Effective for, days.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		#endregion

	}

	#endregion

}

