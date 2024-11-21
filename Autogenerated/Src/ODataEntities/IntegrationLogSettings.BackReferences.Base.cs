namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: IntegrationLogSettings

	/// <exclude/>
	public class IntegrationLogSettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public IntegrationLogSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntegrationLogSettings";
		}

		public IntegrationLogSettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "IntegrationLogSettings";
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
		public Guid IntegrationSystemId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationSystemId");
			}
			set {
				SetColumnValue("IntegrationSystemId", value);
				_integrationSystem = null;
			}
		}

		/// <exclude/>
		public string IntegrationSystemName {
			get {
				return GetTypedColumnValue<string>("IntegrationSystemName");
			}
			set {
				SetColumnValue("IntegrationSystemName", value);
				if (_integrationSystem != null) {
					_integrationSystem.Name = value;
				}
			}
		}

		private IntegrationSystem _integrationSystem;
		/// <summary>
		/// Integration system.
		/// </summary>
		public IntegrationSystem IntegrationSystem {
			get {
				return _integrationSystem ??
					(_integrationSystem = new IntegrationSystem(LookupColumnEntities.GetEntity("IntegrationSystem")));
			}
		}

		/// <summary>
		/// Enable logging.
		/// </summary>
		public bool DoLog {
			get {
				return GetTypedColumnValue<bool>("DoLog");
			}
			set {
				SetColumnValue("DoLog", value);
			}
		}

		/// <summary>
		/// Log only errors.
		/// </summary>
		public bool LogOnlyErrors {
			get {
				return GetTypedColumnValue<bool>("LogOnlyErrors");
			}
			set {
				SetColumnValue("LogOnlyErrors", value);
			}
		}

		#endregion

	}

	#endregion

}

