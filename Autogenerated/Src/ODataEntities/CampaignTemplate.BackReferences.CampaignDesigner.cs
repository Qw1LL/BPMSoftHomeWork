namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignTemplate

	/// <exclude/>
	public class CampaignTemplate : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignTemplate";
		}

		public CampaignTemplate(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignTemplate";
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
		/// Дата создания.
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
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
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
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
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
		public Guid PreviewImageId {
			get {
				return GetTypedColumnValue<Guid>("PreviewImageId");
			}
			set {
				SetColumnValue("PreviewImageId", value);
				_previewImage = null;
			}
		}

		/// <exclude/>
		public string PreviewImageName {
			get {
				return GetTypedColumnValue<string>("PreviewImageName");
			}
			set {
				SetColumnValue("PreviewImageName", value);
				if (_previewImage != null) {
					_previewImage.Name = value;
				}
			}
		}

		private SysImage _previewImage;
		/// <summary>
		/// PreviewImage.
		/// </summary>
		public SysImage PreviewImage {
			get {
				return _previewImage ??
					(_previewImage = new SysImage(LookupColumnEntities.GetEntity("PreviewImage")));
			}
		}

		/// <summary>
		/// Конфиг шаблона.
		/// </summary>
		public string TemplateConfig {
			get {
				return GetTypedColumnValue<string>("TemplateConfig");
			}
			set {
				SetColumnValue("TemplateConfig", value);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		#endregion

	}

	#endregion

}

