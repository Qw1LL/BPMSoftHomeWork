namespace BPMSoft.Configuration
{
	using System;
	using System.Security;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using global::Common.Logging;

	#region Class: BaseRecordExecutor

	public abstract class BaseRecordExecutor : IRecordOperationExecutor
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("MultiDelete");
		private readonly DBSecurityEngine _securityEngine;
		private readonly object _locker = new object();

		#endregion

		#region Fields: Protected

		protected readonly UserConnection _userConnection;
		protected readonly IDictionary<string, object> _parameters;
		protected SchemaRecordRightLevels RecordRightOperation;
		protected string RightExceptionMessage;

		#endregion

		#region Constructors: Protected

		protected BaseRecordExecutor(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			_parameters = parameters;
			_securityEngine = _userConnection.DBSecurityEngine;
		}

		#endregion

		#region Properties: Protected

		private Entity _entity;
		protected Entity Entity {
			get {
				return _entity;
			}
			set {
				if (value == null) {
					throw new ArgumentNullException("Entity");
				}
				_entity = value;
			}
		}

		#endregion

		#region Properties: Public

		public Exception OperationException {
			get;
			private set;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Clear exception of operation.
		/// </summary>
		protected virtual void ClearOperationException() {
			OperationException = null;
		}

		/// <summary>
		/// Execute operation on the entity.
		/// </summary>
		protected abstract void DeleteOperation();

		/// <summary>
		/// Check right for entity.
		/// <returns>Flag of has right.</returns>
		/// </summary>
		protected virtual bool CheckSchemaRecordRight() {
			var schemaRightLevel = _securityEngine.GetEntitySchemaRecordRightLevel(Entity.SchemaName,
				Entity.PrimaryColumnValue);
			var hasRight = (schemaRightLevel & RecordRightOperation) == RecordRightOperation;
			if (!hasRight) {
				OperationException = new SecurityException(RightExceptionMessage);
			}
			return hasRight;
		}

		#endregion

		#region Methods: Public

		public void Execute(Entity item) {
			lock (_locker) {
				Entity = item;
				if (CheckSchemaRecordRight()) {
					ClearOperationException();
					try {
						_log.Info(string.Format("Deleting entity: {0}, id: {1}", item.SchemaName, item.PrimaryColumnValue));
						DeleteOperation();
						_log.Info("Done");
					} catch (Exception ex) {
						_log.Info("False");
						OperationException = ex;
					}
				}
			}
		}

		#endregion
	}

	#endregion

}

