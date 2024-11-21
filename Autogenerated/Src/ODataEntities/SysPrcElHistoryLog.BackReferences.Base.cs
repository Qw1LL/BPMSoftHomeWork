namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysPrcElHistoryLog

	/// <exclude/>
	public class SysPrcElHistoryLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysPrcElHistoryLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcElHistoryLog";
		}

		public SysPrcElHistoryLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysPrcElHistoryLog";
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
		/// Column 1.
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
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime CompleteDate {
			get {
				return GetTypedColumnValue<DateTime>("CompleteDate");
			}
			set {
				SetColumnValue("CompleteDate", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private SysProcessStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		public SysProcessStatus Status {
			get {
				return _status ??
					(_status = new SysProcessStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public string Type {
			get {
				return GetTypedColumnValue<string>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		/// <summary>
		/// Error details.
		/// </summary>
		public string ErrorDescription {
			get {
				return GetTypedColumnValue<string>("ErrorDescription");
			}
			set {
				SetColumnValue("ErrorDescription", value);
			}
		}

		/// <summary>
		/// Duration, minutes.
		/// </summary>
		public Decimal DurationInMinutes {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMinutes");
			}
			set {
				SetColumnValue("DurationInMinutes", value);
			}
		}

		/// <summary>
		/// Duration, days.
		/// </summary>
		public Decimal DurationInDays {
			get {
				return GetTypedColumnValue<Decimal>("DurationInDays");
			}
			set {
				SetColumnValue("DurationInDays", value);
			}
		}

		/// <summary>
		/// Duration, hours.
		/// </summary>
		public Decimal DurationInHours {
			get {
				return GetTypedColumnValue<Decimal>("DurationInHours");
			}
			set {
				SetColumnValue("DurationInHours", value);
			}
		}

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		/// <exclude/>
		public string SysProcessName {
			get {
				return GetTypedColumnValue<string>("SysProcessName");
			}
			set {
				SetColumnValue("SysProcessName", value);
				if (_sysProcess != null) {
					_sysProcess.Name = value;
				}
			}
		}

		private SysPrcHistoryLog _sysProcess;
		/// <summary>
		/// Process instance.
		/// </summary>
		public SysPrcHistoryLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = new SysPrcHistoryLog(LookupColumnEntities.GetEntity("SysProcess")));
			}
		}

		/// <summary>
		/// Diagram item.
		/// </summary>
		public Guid SchemaElementUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaElementUId");
			}
			set {
				SetColumnValue("SchemaElementUId", value);
			}
		}

		/// <summary>
		/// Duration, milliseconds.
		/// </summary>
		public Decimal DurationInMilliseconds {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMilliseconds");
			}
			set {
				SetColumnValue("DurationInMilliseconds", value);
			}
		}

		/// <summary>
		/// Node Identifier.
		/// </summary>
		/// <remarks>
		/// Identifies current execution node.
		/// </remarks>
		public string NodeId {
			get {
				return GetTypedColumnValue<string>("NodeId");
			}
			set {
				SetColumnValue("NodeId", value);
			}
		}

		#endregion

	}

	#endregion

}

