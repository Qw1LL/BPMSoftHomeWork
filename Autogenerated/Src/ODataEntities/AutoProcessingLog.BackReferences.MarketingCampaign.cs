namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: AutoProcessingLog

	/// <exclude/>
	public class AutoProcessingLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AutoProcessingLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AutoProcessingLog";
		}

		public AutoProcessingLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AutoProcessingLog";
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
		/// Сообщение.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// ProcessingType.
		/// </summary>
		public string ProcessingType {
			get {
				return GetTypedColumnValue<string>("ProcessingType");
			}
			set {
				SetColumnValue("ProcessingType", value);
			}
		}

		/// <summary>
		/// Дата события.
		/// </summary>
		public DateTime ProcessingDate {
			get {
				return GetTypedColumnValue<DateTime>("ProcessingDate");
			}
			set {
				SetColumnValue("ProcessingDate", value);
			}
		}

		#endregion

	}

	#endregion

}

