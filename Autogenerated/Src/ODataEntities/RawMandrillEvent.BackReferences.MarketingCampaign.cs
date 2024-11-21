namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: RawMandrillEvent

	/// <exclude/>
	public class RawMandrillEvent : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public RawMandrillEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RawMandrillEvent";
		}

		public RawMandrillEvent(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "RawMandrillEvent";
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

		#endregion

	}

	#endregion

}

