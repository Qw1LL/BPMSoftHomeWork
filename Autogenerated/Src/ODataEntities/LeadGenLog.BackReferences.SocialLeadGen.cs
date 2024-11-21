namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LeadGenLog

	/// <exclude/>
	public class LeadGenLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LeadGenLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenLog";
		}

		public LeadGenLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LeadGenLog";
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
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <exclude/>
		public Guid LeadGenErrorTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenErrorTypeId");
			}
			set {
				SetColumnValue("LeadGenErrorTypeId", value);
				_leadGenErrorType = null;
			}
		}

		/// <exclude/>
		public string LeadGenErrorTypeName {
			get {
				return GetTypedColumnValue<string>("LeadGenErrorTypeName");
			}
			set {
				SetColumnValue("LeadGenErrorTypeName", value);
				if (_leadGenErrorType != null) {
					_leadGenErrorType.Name = value;
				}
			}
		}

		private LeadGenErrorType _leadGenErrorType;
		/// <summary>
		/// Error type.
		/// </summary>
		public LeadGenErrorType LeadGenErrorType {
			get {
				return _leadGenErrorType ??
					(_leadGenErrorType = new LeadGenErrorType(LookupColumnEntities.GetEntity("LeadGenErrorType")));
			}
		}

		/// <summary>
		/// Id интеграции.
		/// </summary>
		public Guid IntegrationId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <exclude/>
		public Guid LeadGenLogTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenLogTypeId");
			}
			set {
				SetColumnValue("LeadGenLogTypeId", value);
				_leadGenLogType = null;
			}
		}

		/// <exclude/>
		public string LeadGenLogTypeName {
			get {
				return GetTypedColumnValue<string>("LeadGenLogTypeName");
			}
			set {
				SetColumnValue("LeadGenLogTypeName", value);
				if (_leadGenLogType != null) {
					_leadGenLogType.Name = value;
				}
			}
		}

		private LeadGenLogType _leadGenLogType;
		/// <summary>
		/// Тип лога.
		/// </summary>
		public LeadGenLogType LeadGenLogType {
			get {
				return _leadGenLogType ??
					(_leadGenLogType = new LeadGenLogType(LookupColumnEntities.GetEntity("LeadGenLogType")));
			}
		}

		#endregion

	}

	#endregion

}

