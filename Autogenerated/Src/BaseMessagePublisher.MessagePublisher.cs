using System;
using System.Collections.Generic;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{
	
	#region Class: BaseMessagePublisher

	public abstract class BaseMessagePublisher : IMessagePublisher
	{

		#region Fields: Private

		/// <summary>
		/// Dictionary of names and values of fields.
		/// </summary>
		private readonly Dictionary <string, string> _entityFieldsData;

		#endregion

		#region Fields: Protected

		protected string EntitySchemaName = string.Empty;
		
		protected readonly UserConnection UserConnection;

		#endregion

		#region Properties: Protected

		protected Guid EntityRecordId { get; set; }
		
		#endregion

		#region Constructor: Protected

		protected BaseMessagePublisher(UserConnection userConnection, Dictionary<string, string> entityFieldsData) {
			UserConnection = userConnection;
			_entityFieldsData = entityFieldsData;
			EntityRecordId = GetPrimatyColumnValue();
		}

		#endregion
		
		#region Methods: Private
		
		private Guid GetPrimatyColumnValue(){
			string primaryColumnValue = null;
			_entityFieldsData.TryGetValue("Id", out primaryColumnValue);
			return primaryColumnValue == null ? Guid.Empty : new Guid(primaryColumnValue);
		}
		
		#endregion
		
		#region Methods: Protected

		protected Entity GetEntity() {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(EntitySchemaName);
			var entity = schema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			if (!entity.FetchFromDB(EntityRecordId)) {
				entity = schema.CreateEntity(UserConnection);
				entity.SetDefColumnValues();
			}
			entity.UseAdminRights = true;
			foreach (var entityFieldData in _entityFieldsData) {
				entity.SetColumnValue(entityFieldData.Key, entityFieldData.Value);
			}
			return entity;
		}

		#endregion

		#region Methods: Public

		public virtual void Publish() {
			var entity = GetEntity();
			entity.Save();
		}

		#endregion

	}

	#endregion

	#region Interface: IMessagePublisher

	public interface IMessagePublisher
	{
		void Publish();
	}

	#endregion

}
