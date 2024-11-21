namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ChatQueue

	/// <exclude/>
	public class ChatQueue : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ChatQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatQueue";
		}

		public ChatQueue(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ChatQueue";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Channel> ChannelCollectionByChatQueue {
			get;
			set;
		}

		public IEnumerable<ChatQueueOperator> ChatQueueOperatorCollectionByChatQueue {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByQueue {
			get;
			set;
		}

		public IEnumerable<OmniChatAction> OmniChatActionCollectionByChatQueue {
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

		/// <exclude/>
		public Guid OperatorRoutingRuleId {
			get {
				return GetTypedColumnValue<Guid>("OperatorRoutingRuleId");
			}
			set {
				SetColumnValue("OperatorRoutingRuleId", value);
				_operatorRoutingRule = null;
			}
		}

		/// <exclude/>
		public string OperatorRoutingRuleName {
			get {
				return GetTypedColumnValue<string>("OperatorRoutingRuleName");
			}
			set {
				SetColumnValue("OperatorRoutingRuleName", value);
				if (_operatorRoutingRule != null) {
					_operatorRoutingRule.Name = value;
				}
			}
		}

		private OperatorRoutingRules _operatorRoutingRule;
		/// <summary>
		/// Правило маршрутизации.
		/// </summary>
		public OperatorRoutingRules OperatorRoutingRule {
			get {
				return _operatorRoutingRule ??
					(_operatorRoutingRule = new OperatorRoutingRules(LookupColumnEntities.GetEntity("OperatorRoutingRule")));
			}
		}

		/// <summary>
		/// Одновременные чаты.
		/// </summary>
		public int SimultaneousChats {
			get {
				return GetTypedColumnValue<int>("SimultaneousChats");
			}
			set {
				SetColumnValue("SimultaneousChats", value);
			}
		}

		/// <summary>
		/// Таймаут до завершения чата, мин.
		/// </summary>
		public int ChatTimeout {
			get {
				return GetTypedColumnValue<int>("ChatTimeout");
			}
			set {
				SetColumnValue("ChatTimeout", value);
			}
		}

		/// <summary>
		/// Время ожидания в очереди.
		/// </summary>
		public int TimeToWaitInQueue {
			get {
				return GetTypedColumnValue<int>("TimeToWaitInQueue");
			}
			set {
				SetColumnValue("TimeToWaitInQueue", value);
			}
		}

		#endregion

	}

	#endregion

}

