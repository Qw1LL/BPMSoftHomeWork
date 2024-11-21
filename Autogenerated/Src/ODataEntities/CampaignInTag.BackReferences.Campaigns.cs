namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignInTag

	/// <exclude/>
	public class CampaignInTag : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignInTag";
		}

		public CampaignInTag(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignInTag";
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
		public Guid TagId {
			get {
				return GetTypedColumnValue<Guid>("TagId");
			}
			set {
				SetColumnValue("TagId", value);
				_tag = null;
			}
		}

		/// <exclude/>
		public string TagName {
			get {
				return GetTypedColumnValue<string>("TagName");
			}
			set {
				SetColumnValue("TagName", value);
				if (_tag != null) {
					_tag.Name = value;
				}
			}
		}

		private CampaignTag _tag;
		/// <summary>
		/// Тег.
		/// </summary>
		public CampaignTag Tag {
			get {
				return _tag ??
					(_tag = new CampaignTag(LookupColumnEntities.GetEntity("Tag")));
			}
		}

		/// <exclude/>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
				_entity = null;
			}
		}

		/// <exclude/>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
				if (_entity != null) {
					_entity.Name = value;
				}
			}
		}

		private Campaign _entity;
		/// <summary>
		/// Объект.
		/// </summary>
		public Campaign Entity {
			get {
				return _entity ??
					(_entity = new Campaign(LookupColumnEntities.GetEntity("Entity")));
			}
		}

		#endregion

	}

	#endregion

}

