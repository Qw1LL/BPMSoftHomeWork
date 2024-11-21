namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: EventProduct

	/// <exclude/>
	public class EventProduct : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EventProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventProduct";
		}

		public EventProduct(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EventProduct";
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
		public Guid EventId {
			get {
				return GetTypedColumnValue<Guid>("EventId");
			}
			set {
				SetColumnValue("EventId", value);
				_event = null;
			}
		}

		/// <exclude/>
		public string EventName {
			get {
				return GetTypedColumnValue<string>("EventName");
			}
			set {
				SetColumnValue("EventName", value);
				if (_event != null) {
					_event.Name = value;
				}
			}
		}

		private Event _event;
		/// <summary>
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = new Event(LookupColumnEntities.GetEntity("Event")));
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
		public Guid BrandId {
			get {
				return GetTypedColumnValue<Guid>("BrandId");
			}
			set {
				SetColumnValue("BrandId", value);
				_brand = null;
			}
		}

		/// <exclude/>
		public string BrandName {
			get {
				return GetTypedColumnValue<string>("BrandName");
			}
			set {
				SetColumnValue("BrandName", value);
				if (_brand != null) {
					_brand.Name = value;
				}
			}
		}

		private Brand _brand;
		/// <summary>
		/// Бренд.
		/// </summary>
		public Brand Brand {
			get {
				return _brand ??
					(_brand = new Brand(LookupColumnEntities.GetEntity("Brand")));
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Note {
			get {
				return GetTypedColumnValue<string>("Note");
			}
			set {
				SetColumnValue("Note", value);
			}
		}

		#endregion

	}

	#endregion

}

