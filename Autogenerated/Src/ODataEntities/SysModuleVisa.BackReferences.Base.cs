namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleVisa

	/// <exclude/>
	public class SysModuleVisa : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleVisa";
		}

		public SysModuleVisa(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleVisa";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Portal_SysModule> Portal_SysModuleCollectionBySysModuleVisa {
			get;
			set;
		}

		public IEnumerable<SysModule> SysModuleCollectionBySysModuleVisa {
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
		/// UseCustomNotificationProvider.
		/// </summary>
		public bool UseCustomNotificationProvider {
			get {
				return GetTypedColumnValue<bool>("UseCustomNotificationProvider");
			}
			set {
				SetColumnValue("UseCustomNotificationProvider", value);
			}
		}

		/// <summary>
		/// Visa schema identifier.
		/// </summary>
		public Guid VisaSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("VisaSchemaUId");
			}
			set {
				SetColumnValue("VisaSchemaUId", value);
			}
		}

		/// <summary>
		/// Section entity column identifier.
		/// </summary>
		public Guid MasterColumnUId {
			get {
				return GetTypedColumnValue<Guid>("MasterColumnUId");
			}
			set {
				SetColumnValue("MasterColumnUId", value);
			}
		}

		#endregion

	}

	#endregion

}

