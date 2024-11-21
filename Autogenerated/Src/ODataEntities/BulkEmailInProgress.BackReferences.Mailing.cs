namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailInProgress

	/// <exclude/>
	public class BulkEmailInProgress : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailInProgress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailInProgress";
		}

		public BulkEmailInProgress(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailInProgress";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Сессия.
		/// </summary>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Рассылка.
		/// </summary>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
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

		/// <summary>
		/// Подготовлено.
		/// </summary>
		public int PreparedToSendCount {
			get {
				return GetTypedColumnValue<int>("PreparedToSendCount");
			}
			set {
				SetColumnValue("PreparedToSendCount", value);
			}
		}

		/// <summary>
		/// Изменено.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Отправлено.
		/// </summary>
		public int SendCount {
			get {
				return GetTypedColumnValue<int>("SendCount");
			}
			set {
				SetColumnValue("SendCount", value);
			}
		}

		#endregion

	}

	#endregion

}

