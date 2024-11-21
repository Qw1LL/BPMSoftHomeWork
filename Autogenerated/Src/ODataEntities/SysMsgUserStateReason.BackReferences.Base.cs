namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysMsgUserStateReason

	/// <exclude/>
	public class SysMsgUserStateReason : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysMsgUserStateReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserStateReason";
		}

		public SysMsgUserStateReason(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysMsgUserStateReason";
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
		/// Name.
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
		/// Description.
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
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
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
		/// Image.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		/// <exclude/>
		public Guid SysMsgUserStateId {
			get {
				return GetTypedColumnValue<Guid>("SysMsgUserStateId");
			}
			set {
				SetColumnValue("SysMsgUserStateId", value);
				_sysMsgUserState = null;
			}
		}

		/// <exclude/>
		public string SysMsgUserStateName {
			get {
				return GetTypedColumnValue<string>("SysMsgUserStateName");
			}
			set {
				SetColumnValue("SysMsgUserStateName", value);
				if (_sysMsgUserState != null) {
					_sysMsgUserState.Name = value;
				}
			}
		}

		private SysMsgUserState _sysMsgUserState;
		/// <summary>
		/// User status.
		/// </summary>
		public SysMsgUserState SysMsgUserState {
			get {
				return _sysMsgUserState ??
					(_sysMsgUserState = new SysMsgUserState(LookupColumnEntities.GetEntity("SysMsgUserState")));
			}
		}

		#endregion

	}

	#endregion

}

