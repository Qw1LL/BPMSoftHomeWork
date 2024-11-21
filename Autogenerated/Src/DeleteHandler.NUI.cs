namespace BPMSoft.Configuration {
	using System;
	using System.Security;
	using System.Reflection;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Configuration.RightsService;

	public class DeleteHandler : IDeleteHandler {

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly Entity _entity;
		private Exception _exception;
		private string _errorMessage = string.Empty;

		#endregion

		#region Constructors: Public

		public DeleteHandler(UserConnection userConnection, Entity entity) {
			_userConnection = userConnection;
			_entity = entity;
		}

		#endregion

		#region Properties: Private

		private RightsHelper _rightsHelper;
		private RightsHelper RightsHelper {
			get {
				if (_rightsHelper != null) {
					return _rightsHelper;
				}
				var args = new ConstructorArgument[] { 
					new ConstructorArgument("userConnection", _userConnection)
				};
				_rightsHelper = ClassFactory.Get<RightsHelper>(args);
				return _rightsHelper;
			}
		}

		#endregion

		#region Methods: Private

		private bool GetIsCanDeleteSchemaRecord(Guid recordUId) {
			var canDeleteRecord = RightsHelper.GetCanDeleteSchemaRecordRight(_entity.SchemaName, recordUId);
			if (!canDeleteRecord) {
				_exception = new SecurityException("EntitySchema.Exception.NoRightFor.Delete");
				_errorMessage = _exception.Message;
			}
			return canDeleteRecord;
		}

		private void Clear() {
			_exception = null;
			_errorMessage = string.Empty;
		}

		#endregion

		#region IDeleteHandler Members

		public Exception Exception {
			get {
				return _exception;
			}
		}

		public string ErrorMessage {
			get {
				return _errorMessage;
			}
		}

		public bool Delete(Guid recordId) {
			Clear();
			var success = true;
			var canDeleteRecord = GetIsCanDeleteSchemaRecord(recordId);
			if (!canDeleteRecord) {
				return false;
			}
			try {
				if (!_entity.Schema.IsDBView) {
					if(_entity.FetchFromDB(recordId)) { 
						_entity.Delete(recordId);
					}
				} else {
					var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, _entity.SchemaName);
					esq.AddAllSchemaColumns();
					Entity entity = esq.GetEntity(_userConnection, recordId);
					if (entity != null) {
						entity.Delete();
					}
				}
			} catch (InvalidOperationException ex) {
				_exception = ex;
				_errorMessage = ex.Message;
				success = false;
			} catch (SecurityException ex) {
				_exception = ex;
				_errorMessage = ex.Message;
				success = false;
			} catch (DbOperationException ex) {
				_exception = ex;
				_errorMessage = ex.Message;
				success = false;
			} catch (Exception ex) {
				_exception = ex;
				_errorMessage = ex.Message;
				success = false;
			}
			return success;
		}

		#endregion

	}

}

