namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleStageHistory

	/// <exclude/>
	public class SysModuleStageHistory : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleStageHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleStageHistory";
		}

		public SysModuleStageHistory(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleStageHistory";
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

		/// <summary>
		/// Entity schema identifier.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Stage schema identifier.
		/// </summary>
		public Guid StageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("StageSchemaUId");
			}
			set {
				SetColumnValue("StageSchemaUId", value);
			}
		}

		/// <summary>
		/// History stages schema identifier.
		/// </summary>
		public Guid StageHistorySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("StageHistorySchemaUId");
			}
			set {
				SetColumnValue("StageHistorySchemaUId", value);
			}
		}

		/// <summary>
		/// Stage column identifier.
		/// </summary>
		public Guid StageColUId {
			get {
				return GetTypedColumnValue<Guid>("StageColUId");
			}
			set {
				SetColumnValue("StageColUId", value);
			}
		}

		/// <summary>
		/// Owner column identifier.
		/// </summary>
		public Guid OwnerColUId {
			get {
				return GetTypedColumnValue<Guid>("OwnerColUId");
			}
			set {
				SetColumnValue("OwnerColUId", value);
			}
		}

		/// <summary>
		/// Final stage column identifier.
		/// </summary>
		public Guid StageIsFinalColUId {
			get {
				return GetTypedColumnValue<Guid>("StageIsFinalColUId");
			}
			set {
				SetColumnValue("StageIsFinalColUId", value);
			}
		}

		/// <summary>
		/// Successful column identifier.
		/// </summary>
		public Guid StageIsSuccessfulColUId {
			get {
				return GetTypedColumnValue<Guid>("StageIsSuccessfulColUId");
			}
			set {
				SetColumnValue("StageIsSuccessfulColUId", value);
			}
		}

		/// <summary>
		/// Order column identifier.
		/// </summary>
		public Guid StageOrderColUId {
			get {
				return GetTypedColumnValue<Guid>("StageOrderColUId");
			}
			set {
				SetColumnValue("StageOrderColUId", value);
			}
		}

		/// <summary>
		/// Column identifier of transition start to the stage .
		/// </summary>
		public Guid StageHistoryStartDateColUId {
			get {
				return GetTypedColumnValue<Guid>("StageHistoryStartDateColUId");
			}
			set {
				SetColumnValue("StageHistoryStartDateColUId", value);
			}
		}

		/// <summary>
		/// Column identifier of transition end to the stage .
		/// </summary>
		public Guid StageHistoryDueDateColUId {
			get {
				return GetTypedColumnValue<Guid>("StageHistoryDueDateColUId");
			}
			set {
				SetColumnValue("StageHistoryDueDateColUId", value);
			}
		}

		/// <summary>
		/// Column identifier of transition owner to the stage .
		/// </summary>
		public Guid StageHistoryOwnerColUId {
			get {
				return GetTypedColumnValue<Guid>("StageHistoryOwnerColUId");
			}
			set {
				SetColumnValue("StageHistoryOwnerColUId", value);
			}
		}

		/// <summary>
		/// Column identifier of sign historical stage .
		/// </summary>
		public Guid StageHistoryHistoricalColUId {
			get {
				return GetTypedColumnValue<Guid>("StageHistoryHistoricalColUId");
			}
			set {
				SetColumnValue("StageHistoryHistoricalColUId", value);
			}
		}

		/// <summary>
		/// Column identifier of main entity.
		/// </summary>
		public Guid StageHistoryMainEntityColUId {
			get {
				return GetTypedColumnValue<Guid>("StageHistoryMainEntityColUId");
			}
			set {
				SetColumnValue("StageHistoryMainEntityColUId", value);
			}
		}

		/// <summary>
		/// Column identifier of stage.
		/// </summary>
		public Guid StageHistoryStageColUId {
			get {
				return GetTypedColumnValue<Guid>("StageHistoryStageColUId");
			}
			set {
				SetColumnValue("StageHistoryStageColUId", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		#endregion

	}

	#endregion

}

