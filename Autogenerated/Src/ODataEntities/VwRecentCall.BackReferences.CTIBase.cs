namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwRecentCall

	/// <exclude/>
	public class VwRecentCall : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwRecentCall(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRecentCall";
		}

		public VwRecentCall(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwRecentCall";
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

		/// <exclude/>
		public Guid CallId {
			get {
				return GetTypedColumnValue<Guid>("CallId");
			}
			set {
				SetColumnValue("CallId", value);
				_call = null;
			}
		}

		/// <exclude/>
		public string CallCaption {
			get {
				return GetTypedColumnValue<string>("CallCaption");
			}
			set {
				SetColumnValue("CallCaption", value);
				if (_call != null) {
					_call.Caption = value;
				}
			}
		}

		private Call _call;
		/// <summary>
		/// Call.
		/// </summary>
		public Call Call {
			get {
				return _call ??
					(_call = new Call(LookupColumnEntities.GetEntity("Call")));
			}
		}

		/// <summary>
		/// CreatedById.
		/// </summary>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
			}
		}

		#endregion

	}

	#endregion

}

