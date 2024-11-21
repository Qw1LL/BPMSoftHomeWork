namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SendingEmailProgress

	/// <exclude/>
	public class SendingEmailProgress : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SendingEmailProgress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SendingEmailProgress";
		}

		public SendingEmailProgress(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SendingEmailProgress";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Подготовлено получателей, кол-во.
		/// </summary>
		public int PreparedRecipientsCount {
			get {
				return GetTypedColumnValue<int>("PreparedRecipientsCount");
			}
			set {
				SetColumnValue("PreparedRecipientsCount", value);
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

		/// <exclude/>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// Email.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = new BulkEmail(LookupColumnEntities.GetEntity("BulkEmail")));
			}
		}

		/// <summary>
		/// Обработано получателей, кол-во.
		/// </summary>
		public int ProcessedRecipientCount {
			get {
				return GetTypedColumnValue<int>("ProcessedRecipientCount");
			}
			set {
				SetColumnValue("ProcessedRecipientCount", value);
			}
		}

		/// <summary>
		/// Получен первичный отклик, кол-во.
		/// </summary>
		public int ReceivedInitialResponseCount {
			get {
				return GetTypedColumnValue<int>("ReceivedInitialResponseCount");
			}
			set {
				SetColumnValue("ReceivedInitialResponseCount", value);
			}
		}

		#endregion

	}

	#endregion

}

