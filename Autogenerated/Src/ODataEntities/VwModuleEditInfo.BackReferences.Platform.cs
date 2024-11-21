namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwModuleEditInfo

	/// <exclude/>
	public class VwModuleEditInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwModuleEditInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwModuleEditInfo";
		}

		public VwModuleEditInfo(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwModuleEditInfo";
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
		/// ModuleCode.
		/// </summary>
		public string ModuleCode {
			get {
				return GetTypedColumnValue<string>("ModuleCode");
			}
			set {
				SetColumnValue("ModuleCode", value);
			}
		}

		/// <summary>
		/// TypeColumnValue.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// WorkspaceId.
		/// </summary>
		public Guid WorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("WorkspaceId");
			}
			set {
				SetColumnValue("WorkspaceId", value);
			}
		}

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// ActionKindCaptionLczId.
		/// </summary>
		public Guid ActionKindCaptionLczId {
			get {
				return GetTypedColumnValue<Guid>("ActionKindCaptionLczId");
			}
			set {
				SetColumnValue("ActionKindCaptionLczId", value);
			}
		}

		/// <summary>
		/// PageCaptionLczId.
		/// </summary>
		public Guid PageCaptionLczId {
			get {
				return GetTypedColumnValue<Guid>("PageCaptionLczId");
			}
			set {
				SetColumnValue("PageCaptionLczId", value);
			}
		}

		/// <summary>
		/// CultureId.
		/// </summary>
		public Guid CultureId {
			get {
				return GetTypedColumnValue<Guid>("CultureId");
			}
			set {
				SetColumnValue("CultureId", value);
			}
		}

		/// <summary>
		/// PageCaptionLcz.
		/// </summary>
		public string PageCaptionLcz {
			get {
				return GetTypedColumnValue<string>("PageCaptionLcz");
			}
			set {
				SetColumnValue("PageCaptionLcz", value);
			}
		}

		/// <summary>
		/// PageCaptionLczOld.
		/// </summary>
		public string PageCaptionLczOld {
			get {
				return GetTypedColumnValue<string>("PageCaptionLczOld");
			}
			set {
				SetColumnValue("PageCaptionLczOld", value);
			}
		}

		/// <summary>
		/// Default page caption.
		/// </summary>
		public string DefaultPageCaption {
			get {
				return GetTypedColumnValue<string>("DefaultPageCaption");
			}
			set {
				SetColumnValue("DefaultPageCaption", value);
			}
		}

		/// <summary>
		/// ModifiedOn.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		#endregion

	}

	#endregion

}

