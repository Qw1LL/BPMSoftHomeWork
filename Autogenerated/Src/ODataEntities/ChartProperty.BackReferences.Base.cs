namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ChartProperty

	/// <exclude/>
	public class ChartProperty : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ChartProperty(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChartProperty";
		}

		public ChartProperty(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ChartProperty";
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
		/// EntityId.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <exclude/>
		public Guid ChartAggregationTypeId {
			get {
				return GetTypedColumnValue<Guid>("ChartAggregationTypeId");
			}
			set {
				SetColumnValue("ChartAggregationTypeId", value);
				_chartAggregationType = null;
			}
		}

		/// <exclude/>
		public string ChartAggregationTypeName {
			get {
				return GetTypedColumnValue<string>("ChartAggregationTypeName");
			}
			set {
				SetColumnValue("ChartAggregationTypeName", value);
				if (_chartAggregationType != null) {
					_chartAggregationType.Name = value;
				}
			}
		}

		private ChartAggregationType _chartAggregationType;
		/// <summary>
		/// Display on lookup.
		/// </summary>
		public ChartAggregationType ChartAggregationType {
			get {
				return _chartAggregationType ??
					(_chartAggregationType = new ChartAggregationType(LookupColumnEntities.GetEntity("ChartAggregationType")));
			}
		}

		/// <summary>
		/// X-axis label.
		/// </summary>
		public string XAxisCaption {
			get {
				return GetTypedColumnValue<string>("XAxisCaption");
			}
			set {
				SetColumnValue("XAxisCaption", value);
			}
		}

		/// <summary>
		/// Y-axis label.
		/// </summary>
		public string YAxisCaption {
			get {
				return GetTypedColumnValue<string>("YAxisCaption");
			}
			set {
				SetColumnValue("YAxisCaption", value);
			}
		}

		/// <summary>
		/// Sorting type.
		/// </summary>
		public string OrderDirection {
			get {
				return GetTypedColumnValue<string>("OrderDirection");
			}
			set {
				SetColumnValue("OrderDirection", value);
			}
		}

		/// <summary>
		/// Sort by column value.
		/// </summary>
		public string OrderByChartPropertyColumn {
			get {
				return GetTypedColumnValue<string>("OrderByChartPropertyColumn");
			}
			set {
				SetColumnValue("OrderByChartPropertyColumn", value);
			}
		}

		/// <summary>
		/// Chart type.
		/// </summary>
		public string ChartSeriesKind {
			get {
				return GetTypedColumnValue<string>("ChartSeriesKind");
			}
			set {
				SetColumnValue("ChartSeriesKind", value);
			}
		}

		/// <exclude/>
		public Guid GroupByTypeDateTimeId {
			get {
				return GetTypedColumnValue<Guid>("GroupByTypeDateTimeId");
			}
			set {
				SetColumnValue("GroupByTypeDateTimeId", value);
				_groupByTypeDateTime = null;
			}
		}

		/// <exclude/>
		public string GroupByTypeDateTimeName {
			get {
				return GetTypedColumnValue<string>("GroupByTypeDateTimeName");
			}
			set {
				SetColumnValue("GroupByTypeDateTimeName", value);
				if (_groupByTypeDateTime != null) {
					_groupByTypeDateTime.Name = value;
				}
			}
		}

		private GroupByTypeDateTime _groupByTypeDateTime;
		/// <summary>
		/// Dates grouping type.
		/// </summary>
		public GroupByTypeDateTime GroupByTypeDateTime {
			get {
				return _groupByTypeDateTime ??
					(_groupByTypeDateTime = new GroupByTypeDateTime(LookupColumnEntities.GetEntity("GroupByTypeDateTime")));
			}
		}

		/// <summary>
		/// ModuleEntityId.
		/// </summary>
		public Guid ModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("ModuleEntityId");
			}
			set {
				SetColumnValue("ModuleEntityId", value);
			}
		}

		#endregion

	}

	#endregion

}

