namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwProductInLeadType

	/// <exclude/>
	public class VwProductInLeadType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwProductInLeadType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProductInLeadType";
		}

		public VwProductInLeadType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwProductInLeadType";
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
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = new Product(LookupColumnEntities.GetEntity("Product")));
			}
		}

		/// <exclude/>
		public Guid ProductFolderId {
			get {
				return GetTypedColumnValue<Guid>("ProductFolderId");
			}
			set {
				SetColumnValue("ProductFolderId", value);
				_productFolder = null;
			}
		}

		/// <exclude/>
		public string ProductFolderName {
			get {
				return GetTypedColumnValue<string>("ProductFolderName");
			}
			set {
				SetColumnValue("ProductFolderName", value);
				if (_productFolder != null) {
					_productFolder.Name = value;
				}
			}
		}

		private ProductFolder _productFolder;
		/// <summary>
		/// Группа продукта.
		/// </summary>
		public ProductFolder ProductFolder {
			get {
				return _productFolder ??
					(_productFolder = new ProductFolder(LookupColumnEntities.GetEntity("ProductFolder")));
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = new LeadType(LookupColumnEntities.GetEntity("LeadType")));
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid ProductTypeInLeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("ProductTypeInLeadTypeId");
			}
			set {
				SetColumnValue("ProductTypeInLeadTypeId", value);
				_productTypeInLeadType = null;
			}
		}

		/// <exclude/>
		public string ProductTypeInLeadTypeName {
			get {
				return GetTypedColumnValue<string>("ProductTypeInLeadTypeName");
			}
			set {
				SetColumnValue("ProductTypeInLeadTypeName", value);
				if (_productTypeInLeadType != null) {
					_productTypeInLeadType.Name = value;
				}
			}
		}

		private ProductTypeInLeadType _productTypeInLeadType;
		/// <summary>
		/// Тип записи.
		/// </summary>
		public ProductTypeInLeadType ProductTypeInLeadType {
			get {
				return _productTypeInLeadType ??
					(_productTypeInLeadType = new ProductTypeInLeadType(LookupColumnEntities.GetEntity("ProductTypeInLeadType")));
			}
		}

		#endregion

	}

	#endregion

}

