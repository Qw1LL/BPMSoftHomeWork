namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LandingObjectDefaults

	/// <exclude/>
	public class LandingObjectDefaults : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LandingObjectDefaults(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LandingObjectDefaults";
		}

		public LandingObjectDefaults(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LandingObjectDefaults";
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
		public Guid LandingId {
			get {
				return GetTypedColumnValue<Guid>("LandingId");
			}
			set {
				SetColumnValue("LandingId", value);
				_landing = null;
			}
		}

		/// <exclude/>
		public string LandingName {
			get {
				return GetTypedColumnValue<string>("LandingName");
			}
			set {
				SetColumnValue("LandingName", value);
				if (_landing != null) {
					_landing.Name = value;
				}
			}
		}

		private GeneratedWebForm _landing;
		/// <summary>
		/// Landing.
		/// </summary>
		public GeneratedWebForm Landing {
			get {
				return _landing ??
					(_landing = new GeneratedWebForm(LookupColumnEntities.GetEntity("Landing")));
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string DisplayValue {
			get {
				return GetTypedColumnValue<string>("DisplayValue");
			}
			set {
				SetColumnValue("DisplayValue", value);
			}
		}

		/// <summary>
		/// Field UId.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Field.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		/// <summary>
		/// Lookup column value.
		/// </summary>
		public Guid GuidValue {
			get {
				return GetTypedColumnValue<Guid>("GuidValue");
			}
			set {
				SetColumnValue("GuidValue", value);
			}
		}

		/// <summary>
		/// Text value.
		/// </summary>
		public string TextValue {
			get {
				return GetTypedColumnValue<string>("TextValue");
			}
			set {
				SetColumnValue("TextValue", value);
			}
		}

		/// <summary>
		/// Integer value.
		/// </summary>
		public int IntegerValue {
			get {
				return GetTypedColumnValue<int>("IntegerValue");
			}
			set {
				SetColumnValue("IntegerValue", value);
			}
		}

		/// <summary>
		/// Float value.
		/// </summary>
		public Decimal FloatValue {
			get {
				return GetTypedColumnValue<Decimal>("FloatValue");
			}
			set {
				SetColumnValue("FloatValue", value);
			}
		}

		/// <summary>
		/// Boolean value.
		/// </summary>
		public bool BooleanValue {
			get {
				return GetTypedColumnValue<bool>("BooleanValue");
			}
			set {
				SetColumnValue("BooleanValue", value);
			}
		}

		/// <summary>
		/// DateTime value.
		/// </summary>
		public DateTime DateTimeValue {
			get {
				return GetTypedColumnValue<DateTime>("DateTimeValue");
			}
			set {
				SetColumnValue("DateTimeValue", value);
			}
		}

		#endregion

	}

	#endregion

}

