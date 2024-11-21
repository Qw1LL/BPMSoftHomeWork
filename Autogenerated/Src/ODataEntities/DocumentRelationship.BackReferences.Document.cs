namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DocumentRelationship

	/// <exclude/>
	public class DocumentRelationship : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DocumentRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DocumentRelationship";
		}

		public DocumentRelationship(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DocumentRelationship";
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
		public Guid DocumentAId {
			get {
				return GetTypedColumnValue<Guid>("DocumentAId");
			}
			set {
				SetColumnValue("DocumentAId", value);
				_documentA = null;
			}
		}

		/// <exclude/>
		public string DocumentANumber {
			get {
				return GetTypedColumnValue<string>("DocumentANumber");
			}
			set {
				SetColumnValue("DocumentANumber", value);
				if (_documentA != null) {
					_documentA.Number = value;
				}
			}
		}

		private Document _documentA;
		/// <summary>
		/// Документ.
		/// </summary>
		public Document DocumentA {
			get {
				return _documentA ??
					(_documentA = new Document(LookupColumnEntities.GetEntity("DocumentA")));
			}
		}

		/// <exclude/>
		public Guid DocumentBId {
			get {
				return GetTypedColumnValue<Guid>("DocumentBId");
			}
			set {
				SetColumnValue("DocumentBId", value);
				_documentB = null;
			}
		}

		/// <exclude/>
		public string DocumentBNumber {
			get {
				return GetTypedColumnValue<string>("DocumentBNumber");
			}
			set {
				SetColumnValue("DocumentBNumber", value);
				if (_documentB != null) {
					_documentB.Number = value;
				}
			}
		}

		private Document _documentB;
		/// <summary>
		/// Связанный документ.
		/// </summary>
		public Document DocumentB {
			get {
				return _documentB ??
					(_documentB = new Document(LookupColumnEntities.GetEntity("DocumentB")));
			}
		}

		#endregion

	}

	#endregion

}

