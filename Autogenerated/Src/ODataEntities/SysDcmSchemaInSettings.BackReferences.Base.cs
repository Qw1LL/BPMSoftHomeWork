namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysDcmSchemaInSettings

	/// <exclude/>
	public class SysDcmSchemaInSettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysDcmSchemaInSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDcmSchemaInSettings";
		}

		public SysDcmSchemaInSettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysDcmSchemaInSettings";
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

		/// <exclude/>
		public Guid SysDcmSettingsId {
			get {
				return GetTypedColumnValue<Guid>("SysDcmSettingsId");
			}
			set {
				SetColumnValue("SysDcmSettingsId", value);
				_sysDcmSettings = null;
			}
		}

		private SysDcmSettings _sysDcmSettings;
		/// <summary>
		/// Настройки схемы кейса.
		/// </summary>
		public SysDcmSettings SysDcmSettings {
			get {
				return _sysDcmSettings ??
					(_sysDcmSettings = new SysDcmSettings(LookupColumnEntities.GetEntity("SysDcmSettings")));
			}
		}

		/// <summary>
		/// Идентификатор схемы кейса.
		/// </summary>
		public Guid SysDcmSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysDcmSchemaUId");
			}
			set {
				SetColumnValue("SysDcmSchemaUId", value);
			}
		}

		#endregion

	}

	#endregion

}

