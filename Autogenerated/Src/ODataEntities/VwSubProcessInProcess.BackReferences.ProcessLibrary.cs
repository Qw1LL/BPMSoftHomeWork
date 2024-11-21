namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSubProcessInProcess

	/// <exclude/>
	public class VwSubProcessInProcess : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSubProcessInProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSubProcessInProcess";
		}

		public VwSubProcessInProcess(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSubProcessInProcess";
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
		public Guid HostProcessId {
			get {
				return GetTypedColumnValue<Guid>("HostProcessId");
			}
			set {
				SetColumnValue("HostProcessId", value);
				_hostProcess = null;
			}
		}

		/// <exclude/>
		public string HostProcessCaption {
			get {
				return GetTypedColumnValue<string>("HostProcessCaption");
			}
			set {
				SetColumnValue("HostProcessCaption", value);
				if (_hostProcess != null) {
					_hostProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _hostProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public VwProcessLib HostProcess {
			get {
				return _hostProcess ??
					(_hostProcess = new VwProcessLib(LookupColumnEntities.GetEntity("HostProcess")));
			}
		}

		/// <exclude/>
		public Guid ParentProcessId {
			get {
				return GetTypedColumnValue<Guid>("ParentProcessId");
			}
			set {
				SetColumnValue("ParentProcessId", value);
				_parentProcess = null;
			}
		}

		/// <exclude/>
		public string ParentProcessCaption {
			get {
				return GetTypedColumnValue<string>("ParentProcessCaption");
			}
			set {
				SetColumnValue("ParentProcessCaption", value);
				if (_parentProcess != null) {
					_parentProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _parentProcess;
		/// <summary>
		/// Parent version process.
		/// </summary>
		public VwProcessLib ParentProcess {
			get {
				return _parentProcess ??
					(_parentProcess = new VwProcessLib(LookupColumnEntities.GetEntity("ParentProcess")));
			}
		}

		/// <exclude/>
		public Guid SubProcessId {
			get {
				return GetTypedColumnValue<Guid>("SubProcessId");
			}
			set {
				SetColumnValue("SubProcessId", value);
				_subProcess = null;
			}
		}

		/// <exclude/>
		public string SubProcessCaption {
			get {
				return GetTypedColumnValue<string>("SubProcessCaption");
			}
			set {
				SetColumnValue("SubProcessCaption", value);
				if (_subProcess != null) {
					_subProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _subProcess;
		/// <summary>
		/// Sub-process.
		/// </summary>
		public VwProcessLib SubProcess {
			get {
				return _subProcess ??
					(_subProcess = new VwProcessLib(LookupColumnEntities.GetEntity("SubProcess")));
			}
		}

		/// <exclude/>
		public Guid ParentSubProcessId {
			get {
				return GetTypedColumnValue<Guid>("ParentSubProcessId");
			}
			set {
				SetColumnValue("ParentSubProcessId", value);
				_parentSubProcess = null;
			}
		}

		/// <exclude/>
		public string ParentSubProcessCaption {
			get {
				return GetTypedColumnValue<string>("ParentSubProcessCaption");
			}
			set {
				SetColumnValue("ParentSubProcessCaption", value);
				if (_parentSubProcess != null) {
					_parentSubProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _parentSubProcess;
		/// <summary>
		/// Parent version sub-process.
		/// </summary>
		public VwProcessLib ParentSubProcess {
			get {
				return _parentSubProcess ??
					(_parentSubProcess = new VwProcessLib(LookupColumnEntities.GetEntity("ParentSubProcess")));
			}
		}

		/// <exclude/>
		public Guid ActiveSubProcessId {
			get {
				return GetTypedColumnValue<Guid>("ActiveSubProcessId");
			}
			set {
				SetColumnValue("ActiveSubProcessId", value);
				_activeSubProcess = null;
			}
		}

		/// <exclude/>
		public string ActiveSubProcessCaption {
			get {
				return GetTypedColumnValue<string>("ActiveSubProcessCaption");
			}
			set {
				SetColumnValue("ActiveSubProcessCaption", value);
				if (_activeSubProcess != null) {
					_activeSubProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _activeSubProcess;
		/// <summary>
		/// Active version of sub-process.
		/// </summary>
		public VwProcessLib ActiveSubProcess {
			get {
				return _activeSubProcess ??
					(_activeSubProcess = new VwProcessLib(LookupColumnEntities.GetEntity("ActiveSubProcess")));
			}
		}

		#endregion

	}

	#endregion

}

