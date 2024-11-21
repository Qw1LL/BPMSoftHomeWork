namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysSyncMetaData

	/// <exclude/>
	public class SysSyncMetaData : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysSyncMetaData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSyncMetaData";
		}

		public SysSyncMetaData(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysSyncMetaData";
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
		/// SyncSchemaName.
		/// </summary>
		public string SyncSchemaName {
			get {
				return GetTypedColumnValue<string>("SyncSchemaName");
			}
			set {
				SetColumnValue("SyncSchemaName", value);
			}
		}

		/// <summary>
		/// RemoteId.
		/// </summary>
		public string RemoteId {
			get {
				return GetTypedColumnValue<string>("RemoteId");
			}
			set {
				SetColumnValue("RemoteId", value);
			}
		}

		/// <summary>
		/// LocalId.
		/// </summary>
		public Guid LocalId {
			get {
				return GetTypedColumnValue<Guid>("LocalId");
			}
			set {
				SetColumnValue("LocalId", value);
			}
		}

		/// <summary>
		/// RemoteStoreId.
		/// </summary>
		public Guid RemoteStoreId {
			get {
				return GetTypedColumnValue<Guid>("RemoteStoreId");
			}
			set {
				SetColumnValue("RemoteStoreId", value);
			}
		}

		/// <summary>
		/// IsLocalDeleted (Delete Column).
		/// </summary>
		public bool IsLocalDeleted {
			get {
				return GetTypedColumnValue<bool>("IsLocalDeleted");
			}
			set {
				SetColumnValue("IsLocalDeleted", value);
			}
		}

		/// <summary>
		/// IsRemoteDeleted (Delete Column).
		/// </summary>
		public bool IsRemoteDeleted {
			get {
				return GetTypedColumnValue<bool>("IsRemoteDeleted");
			}
			set {
				SetColumnValue("IsRemoteDeleted", value);
			}
		}

		/// <summary>
		/// ModifiedInStoreId.
		/// </summary>
		public Guid ModifiedInStoreId {
			get {
				return GetTypedColumnValue<Guid>("ModifiedInStoreId");
			}
			set {
				SetColumnValue("ModifiedInStoreId", value);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public DateTime Version {
			get {
				return GetTypedColumnValue<DateTime>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// CreatedInStoreId.
		/// </summary>
		public Guid CreatedInStoreId {
			get {
				return GetTypedColumnValue<Guid>("CreatedInStoreId");
			}
			set {
				SetColumnValue("CreatedInStoreId", value);
			}
		}

		/// <summary>
		/// RemoteItemName.
		/// </summary>
		public string RemoteItemName {
			get {
				return GetTypedColumnValue<string>("RemoteItemName");
			}
			set {
				SetColumnValue("RemoteItemName", value);
			}
		}

		/// <summary>
		/// SchemaOrder.
		/// </summary>
		public int SchemaOrder {
			get {
				return GetTypedColumnValue<int>("SchemaOrder");
			}
			set {
				SetColumnValue("SchemaOrder", value);
			}
		}

		/// <summary>
		/// ExtraParameters.
		/// </summary>
		public string ExtraParameters {
			get {
				return GetTypedColumnValue<string>("ExtraParameters");
			}
			set {
				SetColumnValue("ExtraParameters", value);
			}
		}

		/// <summary>
		/// LocalState.
		/// </summary>
		public int LocalState {
			get {
				return GetTypedColumnValue<int>("LocalState");
			}
			set {
				SetColumnValue("LocalState", value);
			}
		}

		/// <summary>
		/// RemoteState.
		/// </summary>
		public int RemoteState {
			get {
				return GetTypedColumnValue<int>("RemoteState");
			}
			set {
				SetColumnValue("RemoteState", value);
			}
		}

		#endregion

	}

	#endregion

}

