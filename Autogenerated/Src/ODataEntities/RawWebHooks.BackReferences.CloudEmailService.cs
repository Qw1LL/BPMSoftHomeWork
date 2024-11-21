namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: RawWebHooks

	/// <exclude/>
	public class RawWebHooks : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public RawWebHooks(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RawWebHooks";
		}

		public RawWebHooks(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "RawWebHooks";
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
		/// Failed.
		/// </summary>
		public bool Failed {
			get {
				return GetTypedColumnValue<bool>("Failed");
			}
			set {
				SetColumnValue("Failed", value);
			}
		}

		/// <summary>
		/// Тип.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		#endregion

	}

	#endregion

}

