namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: WebServiceV2InFolder

	/// <exclude/>
	public class WebServiceV2InFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public WebServiceV2InFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceV2InFolder";
		}

		public WebServiceV2InFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "WebServiceV2InFolder";
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
		public Guid FolderId {
			get {
				return GetTypedColumnValue<Guid>("FolderId");
			}
			set {
				SetColumnValue("FolderId", value);
				_folder = null;
			}
		}

		/// <exclude/>
		public string FolderName {
			get {
				return GetTypedColumnValue<string>("FolderName");
			}
			set {
				SetColumnValue("FolderName", value);
				if (_folder != null) {
					_folder.Name = value;
				}
			}
		}

		private WebServiceV2Folder _folder;
		/// <summary>
		/// Web Services folder.
		/// </summary>
		public WebServiceV2Folder Folder {
			get {
				return _folder ??
					(_folder = new WebServiceV2Folder(LookupColumnEntities.GetEntity("Folder")));
			}
		}

		/// <exclude/>
		public Guid WebServiceV2Id {
			get {
				return GetTypedColumnValue<Guid>("WebServiceV2Id");
			}
			set {
				SetColumnValue("WebServiceV2Id", value);
				_webServiceV2 = null;
			}
		}

		/// <exclude/>
		public string WebServiceV2Caption {
			get {
				return GetTypedColumnValue<string>("WebServiceV2Caption");
			}
			set {
				SetColumnValue("WebServiceV2Caption", value);
				if (_webServiceV2 != null) {
					_webServiceV2.Caption = value;
				}
			}
		}

		private VwWebServiceV2 _webServiceV2;
		/// <summary>
		/// Web Services.
		/// </summary>
		public VwWebServiceV2 WebServiceV2 {
			get {
				return _webServiceV2 ??
					(_webServiceV2 = new VwWebServiceV2(LookupColumnEntities.GetEntity("WebServiceV2")));
			}
		}

		#endregion

	}

	#endregion

}

