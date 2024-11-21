namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CasePriority

	/// <exclude/>
	public class CasePriority : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CasePriority(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CasePriority";
		}

		public CasePriority(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CasePriority";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Case> CaseCollectionByPriority {
			get;
			set;
		}

		public IEnumerable<CaseLifecycle> CaseLifecycleCollectionByPriority {
			get;
			set;
		}

		public IEnumerable<PriorityInSupportLevel> PriorityInSupportLevelCollectionByCasePriority {
			get;
			set;
		}

		public IEnumerable<TimeToPrioritize> TimeToPrioritizeCollectionByCasePriority {
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
		/// Приоритет.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Иконка.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		/// <summary>
		/// Значение времени реакции.
		/// </summary>
		public int ReactionTimeValue {
			get {
				return GetTypedColumnValue<int>("ReactionTimeValue");
			}
			set {
				SetColumnValue("ReactionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid ReactionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("ReactionTimeUnitId");
			}
			set {
				SetColumnValue("ReactionTimeUnitId", value);
				_reactionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string ReactionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("ReactionTimeUnitName");
			}
			set {
				SetColumnValue("ReactionTimeUnitName", value);
				if (_reactionTimeUnit != null) {
					_reactionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _reactionTimeUnit;
		/// <summary>
		/// Единица времени реакции.
		/// </summary>
		public TimeUnit ReactionTimeUnit {
			get {
				return _reactionTimeUnit ??
					(_reactionTimeUnit = new TimeUnit(LookupColumnEntities.GetEntity("ReactionTimeUnit")));
			}
		}

		/// <summary>
		/// Значение времени разрешения.
		/// </summary>
		public int SolutionTimeValue {
			get {
				return GetTypedColumnValue<int>("SolutionTimeValue");
			}
			set {
				SetColumnValue("SolutionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid SolutionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("SolutionTimeUnitId");
			}
			set {
				SetColumnValue("SolutionTimeUnitId", value);
				_solutionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string SolutionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("SolutionTimeUnitName");
			}
			set {
				SetColumnValue("SolutionTimeUnitName", value);
				if (_solutionTimeUnit != null) {
					_solutionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _solutionTimeUnit;
		/// <summary>
		/// Единица времени разрешения.
		/// </summary>
		public TimeUnit SolutionTimeUnit {
			get {
				return _solutionTimeUnit ??
					(_solutionTimeUnit = new TimeUnit(LookupColumnEntities.GetEntity("SolutionTimeUnit")));
			}
		}

		#endregion

	}

	#endregion

}

