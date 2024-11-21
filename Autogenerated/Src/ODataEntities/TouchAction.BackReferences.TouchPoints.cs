namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: TouchAction

	/// <exclude/>
	public class TouchAction : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public TouchAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TouchAction";
		}

		public TouchAction(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "TouchAction";
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
		public Guid TouchId {
			get {
				return GetTypedColumnValue<Guid>("TouchId");
			}
			set {
				SetColumnValue("TouchId", value);
				_touch = null;
			}
		}

		/// <exclude/>
		public string TouchSessionId {
			get {
				return GetTypedColumnValue<string>("TouchSessionId");
			}
			set {
				SetColumnValue("TouchSessionId", value);
				if (_touch != null) {
					_touch.SessionId = value;
				}
			}
		}

		private Touch _touch;
		/// <summary>
		/// Web session.
		/// </summary>
		public Touch Touch {
			get {
				return _touch ??
					(_touch = new Touch(LookupColumnEntities.GetEntity("Touch")));
			}
		}

		/// <summary>
		/// Action start date.
		/// </summary>
		public DateTime ActionDate {
			get {
				return GetTypedColumnValue<DateTime>("ActionDate");
			}
			set {
				SetColumnValue("ActionDate", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Page URL.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private TouchActionType _type;
		/// <summary>
		/// Action type.
		/// </summary>
		public TouchActionType Type {
			get {
				return _type ??
					(_type = new TouchActionType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// User action identifier.
		/// </summary>
		public string ActionId {
			get {
				return GetTypedColumnValue<string>("ActionId");
			}
			set {
				SetColumnValue("ActionId", value);
			}
		}

		/// <summary>
		/// Type (string).
		/// </summary>
		public string TypeStr {
			get {
				return GetTypedColumnValue<string>("TypeStr");
			}
			set {
				SetColumnValue("TypeStr", value);
			}
		}

		/// <exclude/>
		public Guid WebPageId {
			get {
				return GetTypedColumnValue<Guid>("WebPageId");
			}
			set {
				SetColumnValue("WebPageId", value);
				_webPage = null;
			}
		}

		/// <exclude/>
		public string WebPageName {
			get {
				return GetTypedColumnValue<string>("WebPageName");
			}
			set {
				SetColumnValue("WebPageName", value);
				if (_webPage != null) {
					_webPage.Name = value;
				}
			}
		}

		private WebPage _webPage;
		/// <summary>
		/// Web page.
		/// </summary>
		public WebPage WebPage {
			get {
				return _webPage ??
					(_webPage = new WebPage(LookupColumnEntities.GetEntity("WebPage")));
			}
		}

		#endregion

	}

	#endregion

}

