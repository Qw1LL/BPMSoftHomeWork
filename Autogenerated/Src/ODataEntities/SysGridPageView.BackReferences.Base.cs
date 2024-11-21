namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysGridPageView

	/// <exclude/>
	public class SysGridPageView : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysGridPageView(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysGridPageView";
		}

		public SysGridPageView(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysGridPageView";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysGridPageView> SysGridPageViewCollectionByParent {
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

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private SysGridPageView _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysGridPageView Parent {
			get {
				return _parent ??
					(_parent = new SysGridPageView(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <exclude/>
		public Guid SysGridPageId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageId");
			}
			set {
				SetColumnValue("SysGridPageId", value);
				_sysGridPage = null;
			}
		}

		private SysGridPage _sysGridPage;
		/// <summary>
		/// List page.
		/// </summary>
		public SysGridPage SysGridPage {
			get {
				return _sysGridPage ??
					(_sysGridPage = new SysGridPage(LookupColumnEntities.GetEntity("SysGridPage")));
			}
		}

		/// <summary>
		/// Filter code.
		/// </summary>
		public string DataSourceFilterCode {
			get {
				return GetTypedColumnValue<string>("DataSourceFilterCode");
			}
			set {
				SetColumnValue("DataSourceFilterCode", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <exclude/>
		public Guid SysStoringStateId {
			get {
				return GetTypedColumnValue<Guid>("SysStoringStateId");
			}
			set {
				SetColumnValue("SysStoringStateId", value);
				_sysStoringState = null;
			}
		}

		/// <exclude/>
		public string SysStoringStateName {
			get {
				return GetTypedColumnValue<string>("SysStoringStateName");
			}
			set {
				SetColumnValue("SysStoringStateName", value);
				if (_sysStoringState != null) {
					_sysStoringState.Name = value;
				}
			}
		}

		private SysStoringObjectState _sysStoringState;
		/// <summary>
		/// Status.
		/// </summary>
		public SysStoringObjectState SysStoringState {
			get {
				return _sysStoringState ??
					(_sysStoringState = new SysStoringObjectState(LookupColumnEntities.GetEntity("SysStoringState")));
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

		#endregion

	}

	#endregion

}

