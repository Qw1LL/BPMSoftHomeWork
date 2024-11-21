namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: IntegrationLog

	/// <exclude/>
	public class IntegrationLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public IntegrationLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "IntegrationLog";
		}

		public IntegrationLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "IntegrationLog";
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
		public Guid IntegrationSystemId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationSystemId");
			}
			set {
				SetColumnValue("IntegrationSystemId", value);
				_integrationSystem = null;
			}
		}

		/// <exclude/>
		public string IntegrationSystemName {
			get {
				return GetTypedColumnValue<string>("IntegrationSystemName");
			}
			set {
				SetColumnValue("IntegrationSystemName", value);
				if (_integrationSystem != null) {
					_integrationSystem.Name = value;
				}
			}
		}

		private IntegrationSystem _integrationSystem;
		/// <summary>
		/// Integration system.
		/// </summary>
		public IntegrationSystem IntegrationSystem {
			get {
				return _integrationSystem ??
					(_integrationSystem = new IntegrationSystem(LookupColumnEntities.GetEntity("IntegrationSystem")));
			}
		}

		/// <summary>
		/// Session number.
		/// </summary>
		public int SessionNumber {
			get {
				return GetTypedColumnValue<int>("SessionNumber");
			}
			set {
				SetColumnValue("SessionNumber", value);
			}
		}

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <exclude/>
		public Guid DirectionId {
			get {
				return GetTypedColumnValue<Guid>("DirectionId");
			}
			set {
				SetColumnValue("DirectionId", value);
				_direction = null;
			}
		}

		/// <exclude/>
		public string DirectionName {
			get {
				return GetTypedColumnValue<string>("DirectionName");
			}
			set {
				SetColumnValue("DirectionName", value);
				if (_direction != null) {
					_direction.Name = value;
				}
			}
		}

		private IntegrationDirection _direction;
		/// <summary>
		/// Direction.
		/// </summary>
		public IntegrationDirection Direction {
			get {
				return _direction ??
					(_direction = new IntegrationDirection(LookupColumnEntities.GetEntity("Direction")));
			}
		}

		/// <exclude/>
		public Guid OperationId {
			get {
				return GetTypedColumnValue<Guid>("OperationId");
			}
			set {
				SetColumnValue("OperationId", value);
				_operation = null;
			}
		}

		/// <exclude/>
		public string OperationName {
			get {
				return GetTypedColumnValue<string>("OperationName");
			}
			set {
				SetColumnValue("OperationName", value);
				if (_operation != null) {
					_operation.Name = value;
				}
			}
		}

		private IntegrationOperation _operation;
		/// <summary>
		/// Operation.
		/// </summary>
		public IntegrationOperation Operation {
			get {
				return _operation ??
					(_operation = new IntegrationOperation(LookupColumnEntities.GetEntity("Operation")));
			}
		}

		/// <exclude/>
		public Guid ResultId {
			get {
				return GetTypedColumnValue<Guid>("ResultId");
			}
			set {
				SetColumnValue("ResultId", value);
				_result = null;
			}
		}

		/// <exclude/>
		public string ResultName {
			get {
				return GetTypedColumnValue<string>("ResultName");
			}
			set {
				SetColumnValue("ResultName", value);
				if (_result != null) {
					_result.Name = value;
				}
			}
		}

		private IntegrationResult _result;
		/// <summary>
		/// Result.
		/// </summary>
		public IntegrationResult Result {
			get {
				return _result ??
					(_result = new IntegrationResult(LookupColumnEntities.GetEntity("Result")));
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
		/// Error details.
		/// </summary>
		public string ErrorDescription {
			get {
				return GetTypedColumnValue<string>("ErrorDescription");
			}
			set {
				SetColumnValue("ErrorDescription", value);
			}
		}

		#endregion

	}

	#endregion

}

