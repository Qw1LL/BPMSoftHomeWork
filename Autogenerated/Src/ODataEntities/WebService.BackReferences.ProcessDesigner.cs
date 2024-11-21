namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: WebService

	/// <exclude/>
	public class WebService : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public WebService(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebService";
		}

		public WebService(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "WebService";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<WebServiceURL> WebServiceURLCollectionByWebService {
			get;
			set;
		}

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
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid WebServiceURLId {
			get {
				return GetTypedColumnValue<Guid>("WebServiceURLId");
			}
			set {
				SetColumnValue("WebServiceURLId", value);
				_webServiceURL = null;
			}
		}

		/// <exclude/>
		public string WebServiceURLURL {
			get {
				return GetTypedColumnValue<string>("WebServiceURLURL");
			}
			set {
				SetColumnValue("WebServiceURLURL", value);
				if (_webServiceURL != null) {
					_webServiceURL.URL = value;
				}
			}
		}

		private WebServiceURL _webServiceURL;
		/// <summary>
		/// Service address.
		/// </summary>
		public WebServiceURL WebServiceURL {
			get {
				return _webServiceURL ??
					(_webServiceURL = new WebServiceURL(LookupColumnEntities.GetEntity("WebServiceURL")));
			}
		}

		/// <summary>
		/// Service WSDL address.
		/// </summary>
		public string WSDLURL {
			get {
				return GetTypedColumnValue<string>("WSDLURL");
			}
			set {
				SetColumnValue("WSDLURL", value);
			}
		}

		/// <summary>
		/// WSDL.
		/// </summary>
		public string WSDL {
			get {
				return GetTypedColumnValue<string>("WSDL");
			}
			set {
				SetColumnValue("WSDL", value);
			}
		}

		/// <summary>
		/// Request timeout, sec.
		/// </summary>
		public int Timeout {
			get {
				return GetTypedColumnValue<int>("Timeout");
			}
			set {
				SetColumnValue("Timeout", value);
			}
		}

		/// <exclude/>
		public Guid HTTPAuthTypeId {
			get {
				return GetTypedColumnValue<Guid>("HTTPAuthTypeId");
			}
			set {
				SetColumnValue("HTTPAuthTypeId", value);
				_hTTPAuthType = null;
			}
		}

		/// <exclude/>
		public string HTTPAuthTypeName {
			get {
				return GetTypedColumnValue<string>("HTTPAuthTypeName");
			}
			set {
				SetColumnValue("HTTPAuthTypeName", value);
				if (_hTTPAuthType != null) {
					_hTTPAuthType.Name = value;
				}
			}
		}

		private HTTPAuthType _hTTPAuthType;
		/// <summary>
		/// Authentication type.
		/// </summary>
		public HTTPAuthType HTTPAuthType {
			get {
				return _hTTPAuthType ??
					(_hTTPAuthType = new HTTPAuthType(LookupColumnEntities.GetEntity("HTTPAuthType")));
			}
		}

		/// <summary>
		/// User login.
		/// </summary>
		public string Login {
			get {
				return GetTypedColumnValue<string>("Login");
			}
			set {
				SetColumnValue("Login", value);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string Password {
			get {
				return GetTypedColumnValue<string>("Password");
			}
			set {
				SetColumnValue("Password", value);
			}
		}

		/// <summary>
		/// Generate C# proxy classes.
		/// </summary>
		public bool GenerateProxy {
			get {
				return GetTypedColumnValue<bool>("GenerateProxy");
			}
			set {
				SetColumnValue("GenerateProxy", value);
			}
		}

		/// <summary>
		/// Namespace for proxy classes.
		/// </summary>
		public string Namespace {
			get {
				return GetTypedColumnValue<string>("Namespace");
			}
			set {
				SetColumnValue("Namespace", value);
			}
		}

		#endregion

	}

	#endregion

}

