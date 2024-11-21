namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OAuthAppScope

	/// <exclude/>
	public class OAuthAppScope : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OAuthAppScope(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthAppScope";
		}

		public OAuthAppScope(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OAuthAppScope";
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

		/// <summary>
		/// Scope.
		/// </summary>
		public string Scope {
			get {
				return GetTypedColumnValue<string>("Scope");
			}
			set {
				SetColumnValue("Scope", value);
			}
		}

		/// <exclude/>
		public Guid OAuth20AppId {
			get {
				return GetTypedColumnValue<Guid>("OAuth20AppId");
			}
			set {
				SetColumnValue("OAuth20AppId", value);
				_oAuth20App = null;
			}
		}

		/// <exclude/>
		public string OAuth20AppName {
			get {
				return GetTypedColumnValue<string>("OAuth20AppName");
			}
			set {
				SetColumnValue("OAuth20AppName", value);
				if (_oAuth20App != null) {
					_oAuth20App.Name = value;
				}
			}
		}

		private OAuthApplications _oAuth20App;
		/// <summary>
		/// OAuth 2.0 application.
		/// </summary>
		public OAuthApplications OAuth20App {
			get {
				return _oAuth20App ??
					(_oAuth20App = new OAuthApplications(LookupColumnEntities.GetEntity("OAuth20App")));
			}
		}

		#endregion

	}

	#endregion

}

