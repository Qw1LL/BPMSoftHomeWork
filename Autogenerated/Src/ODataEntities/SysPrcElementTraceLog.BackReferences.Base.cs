namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysPrcElementTraceLog

	/// <exclude/>
	public class SysPrcElementTraceLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysPrcElementTraceLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcElementTraceLog";
		}

		public SysPrcElementTraceLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysPrcElementTraceLog";
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
		/// TraceEvent.
		/// </summary>
		public int TraceEvent {
			get {
				return GetTypedColumnValue<int>("TraceEvent");
			}
			set {
				SetColumnValue("TraceEvent", value);
			}
		}

		/// <summary>
		/// ElementData.
		/// </summary>
		public string ElementData {
			get {
				return GetTypedColumnValue<string>("ElementData");
			}
			set {
				SetColumnValue("ElementData", value);
			}
		}

		/// <summary>
		/// ProcessData.
		/// </summary>
		public string ProcessData {
			get {
				return GetTypedColumnValue<string>("ProcessData");
			}
			set {
				SetColumnValue("ProcessData", value);
			}
		}

		/// <exclude/>
		public Guid SysProcessElementLogId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessElementLogId");
			}
			set {
				SetColumnValue("SysProcessElementLogId", value);
				_sysProcessElementLog = null;
			}
		}

		/// <exclude/>
		public string SysProcessElementLogCaption {
			get {
				return GetTypedColumnValue<string>("SysProcessElementLogCaption");
			}
			set {
				SetColumnValue("SysProcessElementLogCaption", value);
				if (_sysProcessElementLog != null) {
					_sysProcessElementLog.Caption = value;
				}
			}
		}

		private SysProcessElementLog _sysProcessElementLog;
		/// <summary>
		/// SysProcessElementLog.
		/// </summary>
		public SysProcessElementLog SysProcessElementLog {
			get {
				return _sysProcessElementLog ??
					(_sysProcessElementLog = new SysProcessElementLog(LookupColumnEntities.GetEntity("SysProcessElementLog")));
			}
		}

		#endregion

	}

	#endregion

}

