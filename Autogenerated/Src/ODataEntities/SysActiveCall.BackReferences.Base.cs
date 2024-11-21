namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysActiveCall

	/// <exclude/>
	public class SysActiveCall : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysActiveCall(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysActiveCall";
		}

		public SysActiveCall(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysActiveCall";
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
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Call Id in ASC.
		/// </summary>
		public string IntegrationId {
			get {
				return GetTypedColumnValue<string>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
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
		/// Call Id in DB.
		/// </summary>
		public Call Call {
			get {
				return _call ??
					(_call = new Call(LookupColumnEntities.GetEntity("Call")));
			}
		}

		/// <exclude/>
		public Guid ParentCallId {
			get {
				return GetTypedColumnValue<Guid>("ParentCallId");
			}
			set {
				SetColumnValue("ParentCallId", value);
				_parentCall = null;
			}
		}

		/// <exclude/>
		public string ParentCallCaption {
			get {
				return GetTypedColumnValue<string>("ParentCallCaption");
			}
			set {
				SetColumnValue("ParentCallCaption", value);
				if (_parentCall != null) {
					_parentCall.Caption = value;
				}
			}
		}

		private Call _parentCall;
		/// <summary>
		/// Outgoing call Id in DB.
		/// </summary>
		public Call ParentCall {
			get {
				return _parentCall ??
					(_parentCall = new Call(LookupColumnEntities.GetEntity("ParentCall")));
			}
		}

		/// <summary>
		/// From.
		/// </summary>
		public string CallerId {
			get {
				return GetTypedColumnValue<string>("CallerId");
			}
			set {
				SetColumnValue("CallerId", value);
			}
		}

		/// <summary>
		/// To.
		/// </summary>
		public string CalledId {
			get {
				return GetTypedColumnValue<string>("CalledId");
			}
			set {
				SetColumnValue("CalledId", value);
			}
		}

		/// <summary>
		/// Transferring number.
		/// </summary>
		public string RedirectingId {
			get {
				return GetTypedColumnValue<string>("RedirectingId");
			}
			set {
				SetColumnValue("RedirectingId", value);
			}
		}

		/// <summary>
		/// Number being transferred.
		/// </summary>
		public string RedirectionId {
			get {
				return GetTypedColumnValue<string>("RedirectionId");
			}
			set {
				SetColumnValue("RedirectionId", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Current on hold placing moment.
		/// </summary>
		public DateTime CurrentHoldStartTime {
			get {
				return GetTypedColumnValue<DateTime>("CurrentHoldStartTime");
			}
			set {
				SetColumnValue("CurrentHoldStartTime", value);
			}
		}

		/// <summary>
		/// Current call start moment.
		/// </summary>
		public DateTime CurrentTalkStartTime {
			get {
				return GetTypedColumnValue<DateTime>("CurrentTalkStartTime");
			}
			set {
				SetColumnValue("CurrentTalkStartTime", value);
			}
		}

		/// <summary>
		/// Date of call.
		/// </summary>
		public DateTime ConnectionStartTime {
			get {
				return GetTypedColumnValue<DateTime>("ConnectionStartTime");
			}
			set {
				SetColumnValue("ConnectionStartTime", value);
			}
		}

		/// <summary>
		/// Duration.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Time to connect.
		/// </summary>
		public int BeforeConnectionTime {
			get {
				return GetTypedColumnValue<int>("BeforeConnectionTime");
			}
			set {
				SetColumnValue("BeforeConnectionTime", value);
			}
		}

		/// <summary>
		/// Conversation time.
		/// </summary>
		public int TalkTime {
			get {
				return GetTypedColumnValue<int>("TalkTime");
			}
			set {
				SetColumnValue("TalkTime", value);
			}
		}

		/// <summary>
		/// On hold time.
		/// </summary>
		public int HoldTime {
			get {
				return GetTypedColumnValue<int>("HoldTime");
			}
			set {
				SetColumnValue("HoldTime", value);
			}
		}

		/// <summary>
		/// Status.
		/// </summary>
		public string State {
			get {
				return GetTypedColumnValue<string>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <summary>
		/// Context of call.
		/// </summary>
		public string CallContext {
			get {
				return GetTypedColumnValue<string>("CallContext");
			}
			set {
				SetColumnValue("CallContext", value);
			}
		}

		/// <summary>
		/// Context type.
		/// </summary>
		public string CallContextType {
			get {
				return GetTypedColumnValue<string>("CallContextType");
			}
			set {
				SetColumnValue("CallContextType", value);
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <exclude/>
		public Guid DirectionId {
			get {
				return GetTypedColumnValue<Guid>("DirectionId");
			}
			set {
				SetColumnValue("DirectionId", value);
				_direction = null;
			}
		}

		/// <exclude/>
		public string DirectionName {
			get {
				return GetTypedColumnValue<string>("DirectionName");
			}
			set {
				SetColumnValue("DirectionName", value);
				if (_direction != null) {
					_direction.Name = value;
				}
			}
		}

		private CallDirection _direction;
		/// <summary>
		/// Direction.
		/// </summary>
		public CallDirection Direction {
			get {
				return _direction ??
					(_direction = new CallDirection(LookupColumnEntities.GetEntity("Direction")));
			}
		}

		#endregion

	}

	#endregion

}

