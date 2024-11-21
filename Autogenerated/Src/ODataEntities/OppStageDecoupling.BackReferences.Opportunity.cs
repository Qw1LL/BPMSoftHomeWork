namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OppStageDecoupling

	/// <exclude/>
	public class OppStageDecoupling : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OppStageDecoupling(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppStageDecoupling";
		}

		public OppStageDecoupling(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OppStageDecoupling";
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
		public Guid CurrentStageId {
			get {
				return GetTypedColumnValue<Guid>("CurrentStageId");
			}
			set {
				SetColumnValue("CurrentStageId", value);
				_currentStage = null;
			}
		}

		/// <exclude/>
		public string CurrentStageName {
			get {
				return GetTypedColumnValue<string>("CurrentStageName");
			}
			set {
				SetColumnValue("CurrentStageName", value);
				if (_currentStage != null) {
					_currentStage.Name = value;
				}
			}
		}

		private OpportunityStage _currentStage;
		/// <summary>
		/// Текущая стадия.
		/// </summary>
		public OpportunityStage CurrentStage {
			get {
				return _currentStage ??
					(_currentStage = new OpportunityStage(LookupColumnEntities.GetEntity("CurrentStage")));
			}
		}

		/// <exclude/>
		public Guid AvailableStageId {
			get {
				return GetTypedColumnValue<Guid>("AvailableStageId");
			}
			set {
				SetColumnValue("AvailableStageId", value);
				_availableStage = null;
			}
		}

		/// <exclude/>
		public string AvailableStageName {
			get {
				return GetTypedColumnValue<string>("AvailableStageName");
			}
			set {
				SetColumnValue("AvailableStageName", value);
				if (_availableStage != null) {
					_availableStage.Name = value;
				}
			}
		}

		private OpportunityStage _availableStage;
		/// <summary>
		/// Доступная стадия.
		/// </summary>
		public OpportunityStage AvailableStage {
			get {
				return _availableStage ??
					(_availableStage = new OpportunityStage(LookupColumnEntities.GetEntity("AvailableStage")));
			}
		}

		#endregion

	}

	#endregion

}

