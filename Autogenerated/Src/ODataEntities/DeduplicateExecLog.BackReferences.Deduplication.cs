namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DeduplicateExecLog

	/// <exclude/>
	public class DeduplicateExecLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DeduplicateExecLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeduplicateExecLog";
		}

		public DeduplicateExecLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DeduplicateExecLog";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<DeduplicateExecLocker> DeduplicateExecLockerCollectionByConversation {
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
		/// ProcedureName.
		/// </summary>
		public string ProcedureName {
			get {
				return GetTypedColumnValue<string>("ProcedureName");
			}
			set {
				SetColumnValue("ProcedureName", value);
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

		/// <summary>
		/// ExecutedOn.
		/// </summary>
		public DateTime ExecutedOn {
			get {
				return GetTypedColumnValue<DateTime>("ExecutedOn");
			}
			set {
				SetColumnValue("ExecutedOn", value);
			}
		}

		/// <summary>
		/// CompletedOn.
		/// </summary>
		public DateTime CompletedOn {
			get {
				return GetTypedColumnValue<DateTime>("CompletedOn");
			}
			set {
				SetColumnValue("CompletedOn", value);
			}
		}

		/// <summary>
		/// SqlErrorCode.
		/// </summary>
		public int SqlErrorCode {
			get {
				return GetTypedColumnValue<int>("SqlErrorCode");
			}
			set {
				SetColumnValue("SqlErrorCode", value);
			}
		}

		/// <summary>
		/// SqlErrorMessage.
		/// </summary>
		public string SqlErrorMessage {
			get {
				return GetTypedColumnValue<string>("SqlErrorMessage");
			}
			set {
				SetColumnValue("SqlErrorMessage", value);
			}
		}

		#endregion

	}

	#endregion

}

