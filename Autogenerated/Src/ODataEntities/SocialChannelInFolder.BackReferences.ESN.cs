namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SocialChannelInFolder

	/// <exclude/>
	public class SocialChannelInFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SocialChannelInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialChannelInFolder";
		}

		public SocialChannelInFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SocialChannelInFolder";
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

		private SocialChannelFolder _folder;
		/// <summary>
		/// Folder.
		/// </summary>
		public SocialChannelFolder Folder {
			get {
				return _folder ??
					(_folder = new SocialChannelFolder(LookupColumnEntities.GetEntity("Folder")));
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
		public Guid SocialChannelId {
			get {
				return GetTypedColumnValue<Guid>("SocialChannelId");
			}
			set {
				SetColumnValue("SocialChannelId", value);
				_socialChannel = null;
			}
		}

		/// <exclude/>
		public string SocialChannelTitle {
			get {
				return GetTypedColumnValue<string>("SocialChannelTitle");
			}
			set {
				SetColumnValue("SocialChannelTitle", value);
				if (_socialChannel != null) {
					_socialChannel.Title = value;
				}
			}
		}

		private SocialChannel _socialChannel;
		/// <summary>
		/// Channel.
		/// </summary>
		public SocialChannel SocialChannel {
			get {
				return _socialChannel ??
					(_socialChannel = new SocialChannel(LookupColumnEntities.GetEntity("SocialChannel")));
			}
		}

		#endregion

	}

	#endregion

}

