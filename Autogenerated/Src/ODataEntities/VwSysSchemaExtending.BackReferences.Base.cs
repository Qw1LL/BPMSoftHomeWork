namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSysSchemaExtending

	/// <exclude/>
	public class VwSysSchemaExtending : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysSchemaExtending(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSchemaExtending";
		}

		public VwSysSchemaExtending(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSysSchemaExtending";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// TopExtendingSchemaId.
		/// </summary>
		public Guid TopExtendingSchemaId {
			get {
				return GetTypedColumnValue<Guid>("TopExtendingSchemaId");
			}
			set {
				SetColumnValue("TopExtendingSchemaId", value);
			}
		}

		/// <summary>
		/// BaseSchemaId.
		/// </summary>
		public Guid BaseSchemaId {
			get {
				return GetTypedColumnValue<Guid>("BaseSchemaId");
			}
			set {
				SetColumnValue("BaseSchemaId", value);
			}
		}

		/// <summary>
		/// TopExtendingCaption.
		/// </summary>
		public string TopExtendingCaption {
			get {
				return GetTypedColumnValue<string>("TopExtendingCaption");
			}
			set {
				SetColumnValue("TopExtendingCaption", value);
			}
		}

		#endregion

	}

	#endregion

}

