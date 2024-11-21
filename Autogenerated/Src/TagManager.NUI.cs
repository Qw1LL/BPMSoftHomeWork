namespace BPMSoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: TagManager

	/// <summary>
	/// Saves entity tags.
	/// </summary>
	public class TagManager
	{

		#region Constants: Private

		private const string TagEntityNameTemplate = "{0}Tag";
		private const string EntityInTagNameTemplate = "{0}InTag";

		#endregion

		#region Constructors: Public

		public TagManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		private UserConnection _userConnection;

		protected UserConnection UserConnection {
			get {
				return _userConnection;
			}
			set {
				value.CheckArgumentNull("userConnection");
				_userConnection = value;
			}
		}

		protected EntitySchemaManager EntitySchemaManager {
			get {
				return UserConnection.EntitySchemaManager;
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual Guid GetTagId(string entityName, string tagName, Guid tagType) {
			string tagEntityName = string.Format(TagEntityNameTemplate, entityName);
			EntitySchema tagSchema = EntitySchemaManager.GetInstanceByName(tagEntityName);
			Entity tagEntity = tagSchema.CreateEntity(UserConnection);
			if (!tagEntity.FetchPrimaryInfoFromDB("Name", tagName)) {
				tagEntity.SetDefColumnValues();
				if (tagType != default(Guid)){
					tagEntity.SetColumnValue("TypeId", tagType);
				}
				tagEntity.SetColumnValue("Id", Guid.NewGuid());
				tagEntity.SetColumnValue("Name", tagName);
				tagEntity.Save(false);
			}
			return tagEntity.PrimaryColumnValue;
		}

		protected virtual Guid SaveTags(string entityName, string tagName, List<Guid> recordIds, Guid tagType) {
			Guid tagId = GetTagId(entityName, tagName, tagType);
			string entityInTagSchemaName = string.Format(EntityInTagNameTemplate, entityName);
			EntitySchema entityInTagSchema = EntitySchemaManager.GetInstanceByName(entityInTagSchemaName);
			foreach (Guid recordId in recordIds) {
				Entity entity = entityInTagSchema.CreateEntity(UserConnection);
				entity.SetColumnValue("EntityId", recordId);
				entity.SetColumnValue("TagId", tagId);
				entity.Save(false);
			}
			return tagId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sets the entity tags.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="tagName">Name of the tag.</param>
		/// <param name="recordIds">The entity record ids.</param>
		/// <returns>Tag identifier.</returns>
		public Guid SetEntityTags(string entityName, string tagName, List<Guid> recordIds, 
				Guid tagType = default(Guid)) {
			return SaveTags(entityName, tagName, recordIds, tagType);
		}

		#endregion

	}

	#endregion

}
