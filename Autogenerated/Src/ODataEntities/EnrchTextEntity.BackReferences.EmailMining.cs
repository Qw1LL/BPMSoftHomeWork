namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: EnrchTextEntity

	/// <exclude/>
	public class EnrchTextEntity : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EnrchTextEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchTextEntity";
		}

		public EnrchTextEntity(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EnrchTextEntity";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<EnrchFoundAccount> EnrchFoundAccountCollectionByEnrchTextEntity {
			get;
			set;
		}

		public IEnumerable<EnrchFoundContact> EnrchFoundContactCollectionByEnrchTextEntity {
			get;
			set;
		}

		public IEnumerable<EnrchTextEntity> EnrchTextEntityCollectionByParent {
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
		public Guid EnrchEmailDataId {
			get {
				return GetTypedColumnValue<Guid>("EnrchEmailDataId");
			}
			set {
				SetColumnValue("EnrchEmailDataId", value);
				_enrchEmailData = null;
			}
		}

		/// <exclude/>
		public string EnrchEmailDataHash {
			get {
				return GetTypedColumnValue<string>("EnrchEmailDataHash");
			}
			set {
				SetColumnValue("EnrchEmailDataHash", value);
				if (_enrchEmailData != null) {
					_enrchEmailData.Hash = value;
				}
			}
		}

		private EnrchEmailData _enrchEmailData;
		/// <summary>
		/// Found in the e-mail data.
		/// </summary>
		public EnrchEmailData EnrchEmailData {
			get {
				return _enrchEmailData ??
					(_enrchEmailData = new EnrchEmailData(LookupColumnEntities.GetEntity("EnrchEmailData")));
			}
		}

		/// <summary>
		/// Data type.
		/// </summary>
		public string Type {
			get {
				return GetTypedColumnValue<string>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Relative part of enrichment service response.
		/// </summary>
		public string JsonData {
			get {
				return GetTypedColumnValue<string>("JsonData");
			}
			set {
				SetColumnValue("JsonData", value);
			}
		}

		/// <summary>
		/// Hash code of mined data item.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentHash {
			get {
				return GetTypedColumnValue<string>("ParentHash");
			}
			set {
				SetColumnValue("ParentHash", value);
				if (_parent != null) {
					_parent.Hash = value;
				}
			}
		}

		private EnrchTextEntity _parent;
		/// <summary>
		/// Parent entity.
		/// </summary>
		public EnrchTextEntity Parent {
			get {
				return _parent ??
					(_parent = new EnrchTextEntity(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <summary>
		/// Dupication status.
		/// </summary>
		public string DuplicationStatus {
			get {
				return GetTypedColumnValue<string>("DuplicationStatus");
			}
			set {
				SetColumnValue("DuplicationStatus", value);
			}
		}

		/// <summary>
		/// Source.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Version of hash.
		/// </summary>
		public int HashVersion {
			get {
				return GetTypedColumnValue<int>("HashVersion");
			}
			set {
				SetColumnValue("HashVersion", value);
			}
		}

		#endregion

	}

	#endregion

}

