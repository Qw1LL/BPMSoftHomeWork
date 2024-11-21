namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BaseProductInterest

	/// <exclude/>
	public class BaseProductInterest : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BaseProductInterest(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseProductInterest";
		}

		public BaseProductInterest(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BaseProductInterest";
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
		/// Product.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = new Product(LookupColumnEntities.GetEntity("Product")));
			}
		}

		/// <summary>
		/// Quantity.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Quoted on.
		/// </summary>
		public DateTime DateOfProposal {
			get {
				return GetTypedColumnValue<DateTime>("DateOfProposal");
			}
			set {
				SetColumnValue("DateOfProposal", value);
			}
		}

		/// <exclude/>
		public Guid ResultOfProposalId {
			get {
				return GetTypedColumnValue<Guid>("ResultOfProposalId");
			}
			set {
				SetColumnValue("ResultOfProposalId", value);
				_resultOfProposal = null;
			}
		}

		/// <exclude/>
		public string ResultOfProposalName {
			get {
				return GetTypedColumnValue<string>("ResultOfProposalName");
			}
			set {
				SetColumnValue("ResultOfProposalName", value);
				if (_resultOfProposal != null) {
					_resultOfProposal.Name = value;
				}
			}
		}

		private PropositionResult _resultOfProposal;
		/// <summary>
		/// Interest.
		/// </summary>
		public PropositionResult ResultOfProposal {
			get {
				return _resultOfProposal ??
					(_resultOfProposal = new PropositionResult(LookupColumnEntities.GetEntity("ResultOfProposal")));
			}
		}

		/// <summary>
		/// Comments.
		/// </summary>
		public string Comments {
			get {
				return GetTypedColumnValue<string>("Comments");
			}
			set {
				SetColumnValue("Comments", value);
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

		#endregion

	}

	#endregion

}

