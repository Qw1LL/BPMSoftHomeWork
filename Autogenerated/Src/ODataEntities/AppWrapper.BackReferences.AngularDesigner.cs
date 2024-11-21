namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: AppWrapper

	/// <exclude/>
	public class AppWrapper : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AppWrapper(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AppWrapper";
		}

		public AppWrapper(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AppWrapper";
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

		/// <summary>
		/// FileName.
		/// </summary>
		public string FileName {
			get {
				return GetTypedColumnValue<string>("FileName");
			}
			set {
				SetColumnValue("FileName", value);
			}
		}

		public Guid PageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("PageSchemaUId");
			}
			set {
				SetColumnValue("PageSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid AppBuildId {
			get {
				return GetTypedColumnValue<Guid>("AppBuildId");
			}
			set {
				SetColumnValue("AppBuildId", value);
				_appBuild = null;
			}
		}

		private AppBuild _appBuild;
		/// <summary>
		/// AppBuild.
		/// </summary>
		public AppBuild AppBuild {
			get {
				return _appBuild ??
					(_appBuild = new AppBuild(LookupColumnEntities.GetEntity("AppBuild")));
			}
		}

		/// <summary>
		/// DisplayValue.
		/// </summary>
		public string DisplayValue {
			get {
				return GetTypedColumnValue<string>("DisplayValue");
			}
			set {
				SetColumnValue("DisplayValue", value);
			}
		}

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		#endregion

	}

	#endregion

}

