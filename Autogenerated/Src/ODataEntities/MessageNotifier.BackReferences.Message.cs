namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MessageNotifier

	/// <exclude/>
	public class MessageNotifier : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MessageNotifier(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessageNotifier";
		}

		public MessageNotifier(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MessageNotifier";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CaseMessageHistory> CaseMessageHistoryCollectionByMessageNotifier {
			get;
			set;
		}

		public IEnumerable<LeadMessageHistory> LeadMessageHistoryCollectionByMessageNotifier {
			get;
			set;
		}

		public IEnumerable<ListenerByNotifier> ListenerByNotifierCollectionByMessageNotifier {
			get;
			set;
		}

		public IEnumerable<MessageNotifier> MessageNotifierCollectionByAliasNotifier {
			get;
			set;
		}

		public IEnumerable<MessageNotifierBySection> MessageNotifierBySectionCollectionByMessageNotifier {
			get;
			set;
		}

		public IEnumerable<VwMobileCaseMessageHistory> VwMobileCaseMessageHistoryCollectionByMessageNotifier {
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
		/// Схема.
		/// </summary>
		public Guid SchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaUId");
			}
			set {
				SetColumnValue("SchemaUId", value);
			}
		}

		/// <summary>
		/// Имя класса.
		/// </summary>
		public string ClassName {
			get {
				return GetTypedColumnValue<string>("ClassName");
			}
			set {
				SetColumnValue("ClassName", value);
			}
		}

		/// <exclude/>
		public Guid AliasNotifierId {
			get {
				return GetTypedColumnValue<Guid>("AliasNotifierId");
			}
			set {
				SetColumnValue("AliasNotifierId", value);
				_aliasNotifier = null;
			}
		}

		/// <exclude/>
		public string AliasNotifierName {
			get {
				return GetTypedColumnValue<string>("AliasNotifierName");
			}
			set {
				SetColumnValue("AliasNotifierName", value);
				if (_aliasNotifier != null) {
					_aliasNotifier.Name = value;
				}
			}
		}

		private MessageNotifier _aliasNotifier;
		/// <summary>
		/// Псевдоним механизма уведомления о сообщениях.
		/// </summary>
		public MessageNotifier AliasNotifier {
			get {
				return _aliasNotifier ??
					(_aliasNotifier = new MessageNotifier(LookupColumnEntities.GetEntity("AliasNotifier")));
			}
		}

		/// <summary>
		/// Имя класса для MessageHistoryV2.
		/// </summary>
		public string HistoryV2ClassName {
			get {
				return GetTypedColumnValue<string>("HistoryV2ClassName");
			}
			set {
				SetColumnValue("HistoryV2ClassName", value);
			}
		}

		#endregion

	}

	#endregion

}

