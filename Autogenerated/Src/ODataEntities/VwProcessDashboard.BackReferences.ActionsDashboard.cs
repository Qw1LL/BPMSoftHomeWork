namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwProcessDashboard

	/// <exclude/>
	public class VwProcessDashboard : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwProcessDashboard(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessDashboard";
		}

		public VwProcessDashboard(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwProcessDashboard";
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

		/// <exclude/>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
				_processElement = null;
			}
		}

		private SysProcessElementData _processElement;
		/// <summary>
		/// Process element.
		/// </summary>
		public SysProcessElementData ProcessElement {
			get {
				return _processElement ??
					(_processElement = new SysProcessElementData(LookupColumnEntities.GetEntity("ProcessElement")));
			}
		}

		/// <exclude/>
		public Guid ProcessDataId {
			get {
				return GetTypedColumnValue<Guid>("ProcessDataId");
			}
			set {
				SetColumnValue("ProcessDataId", value);
				_processData = null;
			}
		}

		private SysProcessData _processData;
		/// <summary>
		/// Process.
		/// </summary>
		public SysProcessData ProcessData {
			get {
				return _processData ??
					(_processData = new SysProcessData(LookupColumnEntities.GetEntity("ProcessData")));
			}
		}

		/// <summary>
		/// ModifiedOn.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Process name.
		/// </summary>
		public string ProcessName {
			get {
				return GetTypedColumnValue<string>("ProcessName");
			}
			set {
				SetColumnValue("ProcessName", value);
			}
		}

		/// <summary>
		/// Element caption.
		/// </summary>
		public string ElementCaption {
			get {
				return GetTypedColumnValue<string>("ElementCaption");
			}
			set {
				SetColumnValue("ElementCaption", value);
			}
		}

		/// <summary>
		/// EntitySchemaUId.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// EntityId.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// ProcessElementEntitySchemaUId.
		/// </summary>
		public Guid ProcessElementEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementEntitySchemaUId");
			}
			set {
				SetColumnValue("ProcessElementEntitySchemaUId", value);
			}
		}

		/// <summary>
		/// ProcessElementEntityId.
		/// </summary>
		public Guid ProcessElementEntityId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementEntityId");
			}
			set {
				SetColumnValue("ProcessElementEntityId", value);
			}
		}

		/// <summary>
		/// ProcessElementSchemaUId.
		/// </summary>
		public Guid ProcessElementSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementSchemaUId");
			}
			set {
				SetColumnValue("ProcessElementSchemaUId", value);
			}
		}

		/// <summary>
		/// CreatedOn.
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

		/// <exclude/>
		public Guid ElementOwnerId {
			get {
				return GetTypedColumnValue<Guid>("ElementOwnerId");
			}
			set {
				SetColumnValue("ElementOwnerId", value);
				_elementOwner = null;
			}
		}

		/// <exclude/>
		public string ElementOwnerName {
			get {
				return GetTypedColumnValue<string>("ElementOwnerName");
			}
			set {
				SetColumnValue("ElementOwnerName", value);
				if (_elementOwner != null) {
					_elementOwner.Name = value;
				}
			}
		}

		private Contact _elementOwner;
		/// <summary>
		/// Element owner.
		/// </summary>
		public Contact ElementOwner {
			get {
				return _elementOwner ??
					(_elementOwner = new Contact(LookupColumnEntities.GetEntity("ElementOwner")));
			}
		}

		/// <exclude/>
		public Guid ProcessOwnerId {
			get {
				return GetTypedColumnValue<Guid>("ProcessOwnerId");
			}
			set {
				SetColumnValue("ProcessOwnerId", value);
				_processOwner = null;
			}
		}

		/// <exclude/>
		public string ProcessOwnerName {
			get {
				return GetTypedColumnValue<string>("ProcessOwnerName");
			}
			set {
				SetColumnValue("ProcessOwnerName", value);
				if (_processOwner != null) {
					_processOwner.Name = value;
				}
			}
		}

		private Contact _processOwner;
		/// <summary>
		/// Process owner.
		/// </summary>
		public Contact ProcessOwner {
			get {
				return _processOwner ??
					(_processOwner = new Contact(LookupColumnEntities.GetEntity("ProcessOwner")));
			}
		}

		/// <summary>
		/// Process schema element identifier.
		/// </summary>
		public Guid ProcessSchemaElementUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaElementUId");
			}
			set {
				SetColumnValue("ProcessSchemaElementUId", value);
			}
		}

		#endregion

	}

	#endregion

}

