namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DCRecipientOp

	/// <exclude/>
	public class DCRecipientOp : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DCRecipientOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCRecipientOp";
		}

		public DCRecipientOp(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DCRecipientOp";
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
		/// EntityId.
		/// </summary>
		/// <remarks>
		/// An identifier of recipient.
		/// </remarks>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// GroupIndex.
		/// </summary>
		public int GroupIndex {
			get {
				return GetTypedColumnValue<int>("GroupIndex");
			}
			set {
				SetColumnValue("GroupIndex", value);
			}
		}

		/// <summary>
		/// BlockIndex.
		/// </summary>
		public int BlockIndex {
			get {
				return GetTypedColumnValue<int>("BlockIndex");
			}
			set {
				SetColumnValue("BlockIndex", value);
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
		/// SessionId.
		/// </summary>
		/// <remarks>
		/// An identifier of the segmentation session.
		/// </remarks>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		#endregion

	}

	#endregion

}

