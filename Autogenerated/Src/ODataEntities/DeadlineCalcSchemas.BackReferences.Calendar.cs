namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DeadlineCalcSchemas

	/// <exclude/>
	public class DeadlineCalcSchemas : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DeadlineCalcSchemas(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeadlineCalcSchemas";
		}

		public DeadlineCalcSchemas(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DeadlineCalcSchemas";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<DeadlineCalcSchemas> DeadlineCalcSchemasCollectionByAlternativeRule {
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
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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
		/// Default.
		/// </summary>
		public bool Default {
			get {
				return GetTypedColumnValue<bool>("Default");
			}
			set {
				SetColumnValue("Default", value);
			}
		}

		/// <exclude/>
		public Guid AlternativeRuleId {
			get {
				return GetTypedColumnValue<Guid>("AlternativeRuleId");
			}
			set {
				SetColumnValue("AlternativeRuleId", value);
				_alternativeRule = null;
			}
		}

		/// <exclude/>
		public string AlternativeRuleName {
			get {
				return GetTypedColumnValue<string>("AlternativeRuleName");
			}
			set {
				SetColumnValue("AlternativeRuleName", value);
				if (_alternativeRule != null) {
					_alternativeRule.Name = value;
				}
			}
		}

		private DeadlineCalcSchemas _alternativeRule;
		/// <summary>
		/// Alternative schema.
		/// </summary>
		public DeadlineCalcSchemas AlternativeRule {
			get {
				return _alternativeRule ??
					(_alternativeRule = new DeadlineCalcSchemas(LookupColumnEntities.GetEntity("AlternativeRule")));
			}
		}

		/// <summary>
		/// Handler.
		/// </summary>
		public string Handler {
			get {
				return GetTypedColumnValue<string>("Handler");
			}
			set {
				SetColumnValue("Handler", value);
			}
		}

		#endregion

	}

	#endregion

}

