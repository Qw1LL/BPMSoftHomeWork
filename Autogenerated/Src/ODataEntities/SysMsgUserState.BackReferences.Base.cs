namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysMsgUserState

	/// <exclude/>
	public class SysMsgUserState : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysMsgUserState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserState";
		}

		public SysMsgUserState(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysMsgUserState";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysMsgUserStateInLib> SysMsgUserStateInLibCollectionBySysMsgUserState {
			get;
			set;
		}

		public IEnumerable<SysMsgUserStateReason> SysMsgUserStateReasonCollectionBySysMsgUserState {
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
		/// Код.
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
		/// Изображение.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		/// <summary>
		/// Только для отображения.
		/// </summary>
		public bool IsDisplayOnly {
			get {
				return GetTypedColumnValue<bool>("IsDisplayOnly");
			}
			set {
				SetColumnValue("IsDisplayOnly", value);
			}
		}

		/// <exclude/>
		public Guid IconId {
			get {
				return GetTypedColumnValue<Guid>("IconId");
			}
			set {
				SetColumnValue("IconId", value);
				_icon = null;
			}
		}

		/// <exclude/>
		public string IconName {
			get {
				return GetTypedColumnValue<string>("IconName");
			}
			set {
				SetColumnValue("IconName", value);
				if (_icon != null) {
					_icon.Name = value;
				}
			}
		}

		private SysMsgUserStateIcon _icon;
		/// <summary>
		/// Иконка.
		/// </summary>
		public SysMsgUserStateIcon Icon {
			get {
				return _icon ??
					(_icon = new SysMsgUserStateIcon(LookupColumnEntities.GetEntity("Icon")));
			}
		}

		/// <summary>
		/// Доступность оператора.
		/// </summary>
		public bool IsAvailableStatus {
			get {
				return GetTypedColumnValue<bool>("IsAvailableStatus");
			}
			set {
				SetColumnValue("IsAvailableStatus", value);
			}
		}

		#endregion

	}

	#endregion

}

