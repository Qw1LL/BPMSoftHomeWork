namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailHourlyOpens

	/// <exclude/>
	public class BulkEmailHourlyOpens : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailHourlyOpens(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailHourlyOpens";
		}

		public BulkEmailHourlyOpens(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailHourlyOpens";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// BulkEmailId.
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
		/// DateMark.
		/// </summary>
		public DateTime DateMark {
			get {
				return GetTypedColumnValue<DateTime>("DateMark");
			}
			set {
				SetColumnValue("DateMark", value);
			}
		}

		/// <summary>
		/// EventsCount.
		/// </summary>
		public int EventsCount {
			get {
				return GetTypedColumnValue<int>("EventsCount");
			}
			set {
				SetColumnValue("EventsCount", value);
			}
		}

		#endregion

	}

	#endregion

}

