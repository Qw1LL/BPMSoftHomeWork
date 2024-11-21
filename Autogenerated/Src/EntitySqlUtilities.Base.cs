namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	public class EntitySqlGenerator 
	{
		UserConnection _userConnection;
		
		public EntitySqlGenerator(UserConnection userConnection) {
			_userConnection = userConnection;
		}
		
		public EntitySqlGenerator(UserConnection userConnection, Dictionary<Guid, Guid> entities) {
			_userConnection = userConnection;
			foreach (var entity in entities) {
				Entities.Add(entity.Key, entity.Value);
			}
		}
		
		private Dictionary<Guid, Guid> _entities;
		public Dictionary<Guid, Guid> Entities {
			get {
				return _entities ?? (_entities = new Dictionary<Guid, Guid>());
			}
		}
		
		public string GetEntitySqlText(Guid entitySchemaId, Guid entityId) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaId);
			var entity = entitySchema.CreateEntity(_userConnection);
			if (entity.FetchFromDB(entityId)) {
				foreach (var column in entitySchema.Columns) {
					if (column.DataValueType is BinaryDataValueType) {
						//entity.SetBytesValue(column.ColumnValueName, entity.GetBytesValue(column.ColumnValueName));
					} else {
						entity.SetColumnValue(column, entity.GetColumnValue(column));
					}
				}
				var insert = entity.CreateInsert();
				insert.BuildParametersAsValue = true;
				return insert.GetSqlText();
			} else {
				return string.Empty;
			}
		}
		
		public string GetSqlText() {
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var entity in Entities) {
				stringBuilder.Append(GetEntitySqlText(entity.Value, entity.Key));
			}
			return stringBuilder.ToString();
		}
		
		public byte[] GetBytes() {
			string sqlText = GetSqlText();
			return Encoding.UTF8.GetBytes(sqlText);
		}
	}
}
