namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DeduplicateExecLocker

	/// <exclude/>
	public class DeduplicateExecLocker : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DeduplicateExecLocker(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeduplicateExecLocker";
		}

		public DeduplicateExecLocker(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DeduplicateExecLocker";
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
		/// EntitySchemaName.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <exclude/>
		public Guid ConversationId {
			get {
				return GetTypedColumnValue<Guid>("ConversationId");
			}
			set {
				SetColumnValue("ConversationId", value);
				_conversation = null;
			}
		}

		/// <exclude/>
		public string ConversationProcedureName {
			get {
				return GetTypedColumnValue<string>("ConversationProcedureName");
			}
			set {
				SetColumnValue("ConversationProcedureName", value);
				if (_conversation != null) {
					_conversation.ProcedureName = value;
				}
			}
		}

		private DeduplicateExecLog _conversation;
		/// <summary>
		/// Conversation.
		/// </summary>
		public DeduplicateExecLog Conversation {
			get {
				return _conversation ??
					(_conversation = new DeduplicateExecLog(LookupColumnEntities.GetEntity("Conversation")));
			}
		}

		/// <exclude/>
		public Guid OperationId {
			get {
				return GetTypedColumnValue<Guid>("OperationId");
			}
			set {
				SetColumnValue("OperationId", value);
				_operation = null;
			}
		}

		/// <exclude/>
		public string OperationName {
			get {
				return GetTypedColumnValue<string>("OperationName");
			}
			set {
				SetColumnValue("OperationName", value);
				if (_operation != null) {
					_operation.Name = value;
				}
			}
		}

		private DeduplicateOperation _operation;
		/// <summary>
		/// Operation.
		/// </summary>
		public DeduplicateOperation Operation {
			get {
				return _operation ??
					(_operation = new DeduplicateOperation(LookupColumnEntities.GetEntity("Operation")));
			}
		}

		/// <summary>
		/// IsInProgress.
		/// </summary>
		public bool IsInProgress {
			get {
				return GetTypedColumnValue<bool>("IsInProgress");
			}
			set {
				SetColumnValue("IsInProgress", value);
			}
		}

		#endregion

	}

	#endregion

}

