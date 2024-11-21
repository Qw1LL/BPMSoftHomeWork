namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OAuthResourceInClient

	/// <exclude/>
	public class OAuthResourceInClient : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OAuthResourceInClient(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthResourceInClient";
		}

		public OAuthResourceInClient(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OAuthResourceInClient";
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
		public Guid OAuthResourceId {
			get {
				return GetTypedColumnValue<Guid>("OAuthResourceId");
			}
			set {
				SetColumnValue("OAuthResourceId", value);
				_oAuthResource = null;
			}
		}

		/// <exclude/>
		public string OAuthResourceDisplayName {
			get {
				return GetTypedColumnValue<string>("OAuthResourceDisplayName");
			}
			set {
				SetColumnValue("OAuthResourceDisplayName", value);
				if (_oAuthResource != null) {
					_oAuthResource.DisplayName = value;
				}
			}
		}

		private OAuthResource _oAuthResource;
		/// <summary>
		/// OAuth resource.
		/// </summary>
		public OAuthResource OAuthResource {
			get {
				return _oAuthResource ??
					(_oAuthResource = new OAuthResource(LookupColumnEntities.GetEntity("OAuthResource")));
			}
		}

		/// <exclude/>
		public Guid OAuthClientId {
			get {
				return GetTypedColumnValue<Guid>("OAuthClientId");
			}
			set {
				SetColumnValue("OAuthClientId", value);
				_oAuthClient = null;
			}
		}

		/// <exclude/>
		public string OAuthClientName {
			get {
				return GetTypedColumnValue<string>("OAuthClientName");
			}
			set {
				SetColumnValue("OAuthClientName", value);
				if (_oAuthClient != null) {
					_oAuthClient.Name = value;
				}
			}
		}

		private OAuthClientApp _oAuthClient;
		/// <summary>
		/// OAuth client.
		/// </summary>
		public OAuthClientApp OAuthClient {
			get {
				return _oAuthClient ??
					(_oAuthClient = new OAuthClientApp(LookupColumnEntities.GetEntity("OAuthClient")));
			}
		}

		#endregion

	}

	#endregion

}

