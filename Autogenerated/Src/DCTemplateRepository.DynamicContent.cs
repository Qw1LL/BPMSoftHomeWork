namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: DCTemplateRepository

	/// <summary>
	/// Represents generic base repository which performs CRUD-operation on template.
	/// </summary>
	/// <typeparam name="T">Type of model for repository. It can be <see cref="DCTemplateModel"/> 
	/// or inheriting member.</typeparam>
	public class DCTemplateRepository<T> where T : DCTemplateModel, new()
	{

		#region Constants: Protected

		protected const string TemplateTableName = nameof(DCTemplate);
		protected const string ReplicaTableName = nameof(DCReplica);
		protected const string TemplateGroupTableName = nameof(DCTemplateGroup);
		protected const string TemplateBlockTableName = nameof(DCTemplateBlock);
		protected const string TemplateAttributeTableName = nameof(DCAttribute);
		protected const string AttributeInBlockTableName = nameof(DCAttributeInBlock);
		protected const string BlockInReplicaTableName = nameof(DCBlockInReplica);

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected UserConnection UserConnection { get; }

		protected DCRepositoryReadOptions<T, DCReplicaModel> DefaultReadOptions { get; set; } =
			new DCRepositoryReadOptions<T, DCReplicaModel>();

		#endregion

		#region Constructors: Protected

		/// <summary>
		/// Constructor with parameter.
		/// </summary>
		/// <param name="userConnection">Initialized user connection.</param>
		public DCTemplateRepository(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private EntityCollection GetEntities(string rootSchemaName, string columnNameForFilter, object filterValue,
				List<string> excludedColumnNames) {
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, rootSchemaName);
			var filter = entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				columnNameForFilter, filterValue);
			entitySchemaQuery.PrimaryQueryColumn.IsVisible = true;
			entitySchemaQuery.AddAllSchemaColumns();
			excludedColumnNames.ForEach(x => entitySchemaQuery.Columns.RemoveByName(x));
			entitySchemaQuery.Filters.Add(filter);
			return entitySchemaQuery.GetEntityCollection(UserConnection);
		}

		private EntityCollection GetEntities(string rootSchemaName, string columnNameForFilter, object filterValue) {
			return GetEntities(rootSchemaName, columnNameForFilter, filterValue, new List<string>());
		}

		private Entity GetEntity(string entityName) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
			return entitySchema.CreateEntity(UserConnection);
		}

		private void CopyTypeColumnValues(Entity source, Entity target) {
			var columnNames = source.GetColumnValueNames();
			var columns = source.Schema.Columns
				.Where(x => x.IsValueCloneable && columnNames.Contains(x.ColumnValueName));
			foreach (var column in columns) {
				target.SetColumnValue(column.ColumnValueName, source.GetColumnValue(column.ColumnValueName));
			}
		}

		private IDictionary<Guid, Guid> CopyEntities(IEnumerable<Entity> entities,
				Dictionary<string, object> replacedColumnValues) {
			var mapping = new Dictionary<Guid, Guid>();
			foreach (var entity in entities) {
				var newEntity = GetEntity(entity.SchemaName);
				newEntity.SetDefColumnValues();
				CopyTypeColumnValues(entity, newEntity);
				var newId = Guid.NewGuid();
				newEntity.SetColumnValue("Id", newId);
				if (replacedColumnValues != null) {
					foreach (var replacedColumnValue in replacedColumnValues) {
						newEntity.SetColumnValue(replacedColumnValue.Key, replacedColumnValue.Value);
					}
				}
				newEntity.Save();
				mapping.Add(entity.GetTypedColumnValue<Guid>("Id"), newId);
			}
			return mapping;
		}

		private void CopyBlockLinkedEntities(IEnumerable<Entity> entities, Guid newBlockId,
				string columnToMap, IDictionary<Guid, Guid> mapping) {
			foreach (var entity in entities) {
				var newEntity = entity.Schema.CreateEntity(UserConnection);
				newEntity.SetDefColumnValues();
				var oldMappingId = entity.GetTypedColumnValue<Guid>(columnToMap);
				newEntity.SetColumnValue("Id", Guid.NewGuid());
				newEntity.SetColumnValue("DCTemplateBlockId", newBlockId);
				newEntity.SetColumnValue(columnToMap, mapping[oldMappingId]);
				newEntity.Save();
			}
		}

		private void InsertTemplateEntity(T model) {
			var template = GetEntity(TemplateTableName);
			template.SetDefColumnValues();
			template.SetColumnValue("RecordId", model.RecordId);
			template.SetColumnValue("Id", model.Id);
			template.Save();
		}

		private void InsertTemplateGroups(T model) {
			foreach (var groupModel in model.Groups) {
				var group = GetEntity(TemplateGroupTableName);
				group.SetDefColumnValues();
				group.SetColumnValue("Id", groupModel.Id);
				group.SetColumnValue("Index", groupModel.Index);
				group.SetColumnValue("DCTemplateId", model.Id);
				group.Save();
			}
		}

		private void InsertTemplateAttributes(T model) {
			foreach (var attrModel in model.Attributes) {
				var attributeValueBytes = Encoding.UTF8.GetBytes(attrModel.Value);
				var attributeSchema = UserConnection.EntitySchemaManager.GetInstanceByName(TemplateAttributeTableName);
				var attributeEntity = attributeSchema.CreateEntity(UserConnection);
				attributeEntity.SetDefColumnValues();
				attributeEntity.SetColumnValue("Id", attrModel.Id);
				attributeEntity.SetColumnValue("Caption", attrModel.Caption);
				attributeEntity.SetColumnValue("TypeId", attrModel.TypeId);
				attributeEntity.SetBytesValue("Value", attributeValueBytes);
				attributeEntity.SetColumnValue("Index", attrModel.Index);
				attributeEntity.SetColumnValue("DCTemplateId", model.Id);
				attributeEntity.Save();
			}
		}

		private void InsertTemplateReplicas(T model) {
			foreach (var replicaModel in model.Replicas) {
				var replicaSchema = UserConnection.EntitySchemaManager.GetInstanceByName(ReplicaTableName);
				var replicaEntity = replicaSchema.CreateEntity(UserConnection);
				replicaEntity.SetDefColumnValues();
				replicaEntity.SetColumnValue("Id", replicaModel.Id);
				replicaEntity.SetColumnValue("Content", replicaModel.Content);
				replicaEntity.SetColumnValue("Mask", replicaModel.Mask);
				replicaEntity.SetColumnValue("DCTemplateId", model.Id);
				replicaEntity.SetColumnValue("Caption", replicaModel.Caption);
				replicaEntity.Save();
				LinkReplicaWithBlocks(model, replicaModel);
			}
		}

		private void InsertTemplateBlocks(T model) {
			foreach (var blockModel in model.Blocks) {
				var blockSchema = UserConnection.EntitySchemaManager.GetInstanceByName(TemplateBlockTableName);
				var blockEntity = blockSchema.CreateEntity(UserConnection);
				blockEntity.SetDefColumnValues();
				blockEntity.SetColumnValue("Id", blockModel.Id);
				blockEntity.SetColumnValue("Index", blockModel.Index);
				blockEntity.SetColumnValue("Priority", blockModel.Priority);
				blockEntity.SetColumnValue("IsDefault", blockModel.IsDefault);
				var group = model.Groups.FirstOrDefault(x => x.Index == blockModel.GroupIndex);
				if (group != null) {
					blockEntity.SetColumnValue("DCTemplateGroupId", group.Id);
				}
				blockEntity.Save();
				LinkBlockWithAttributes(model, blockModel);
			}
		}

		private void LinkBlockWithAttributes(T model, DCTemplateBlockModel block) {
			model.Attributes
				.Where(x => block.AttributeIndexes.Contains(x.Index))
				.ForEach(attr => {
					var schema = UserConnection.EntitySchemaManager.GetInstanceByName(AttributeInBlockTableName);
					var attrInBlock = schema.CreateEntity(UserConnection);
					attrInBlock.SetDefColumnValues();
					attrInBlock.SetColumnValue("DCAttributeId", attr.Id);
					attrInBlock.SetColumnValue("DCTemplateBlockId", block.Id);
					attrInBlock.Save();
				});
		}
		private void LinkReplicaWithBlocks(T model, DCReplicaModel replica) {
			model.Blocks
				.Where(x => replica.BlockIndexes.Contains(x.Index))
				.ForEach(block => {
					var schema = UserConnection.EntitySchemaManager.GetInstanceByName(BlockInReplicaTableName);
					var blockInReplica = schema.CreateEntity(UserConnection);
					blockInReplica.SetDefColumnValues();
					blockInReplica.SetColumnValue("DCReplicaId", replica.Id);
					blockInReplica.SetColumnValue("DCTemplateBlockId", block.Id);
					blockInReplica.Save();
				});
		}

		private Guid CopyTemplateEntity(Entity template) {
			var newTemplate = template.Schema.CreateEntity(UserConnection);
			newTemplate.SetDefColumnValues();
			var newTemplateId = Guid.NewGuid();
			newTemplate.SetColumnValue("Id", newTemplateId);
			newTemplate.Save();
			return newTemplateId;
		}

		private IDictionary<Guid, Guid> CopyGroups(Guid oldTemplateId, Guid newTemplateId) {
			var groups = GetEntities(TemplateGroupTableName, "DCTemplate", oldTemplateId);
			return CopyEntities(groups, new Dictionary<string, object> {
				{ "DCTemplateId", newTemplateId }
			});
		}

		private IDictionary<Guid, Guid> CopyAttributes(Guid oldTemplateId, Guid newTemplateId) {
			var attributes = GetEntities(TemplateAttributeTableName, "DCTemplate", oldTemplateId);
			return CopyEntities(attributes, new Dictionary<string, object> {
				{ "DCTemplateId", newTemplateId }
			});
		}
		private IDictionary<Guid, Guid> CopyBlocks(IDictionary<Guid, Guid> groupMapping) {
			var blocksMapping = new Dictionary<Guid, Guid>();
			foreach (var groupData in groupMapping) {
				var blocks = GetEntities(TemplateBlockTableName, "DCTemplateGroup", groupData.Key);
				var mapping = CopyEntities(blocks, new Dictionary<string, object> {
					{ "DCTemplateGroupId", groupData.Value }
				});
				blocksMapping.AddRangeIfNotExists(mapping);
			}
			return blocksMapping;
		}

		private IDictionary<Guid, Guid> CopyReplicas(Guid oldTemplateId, Guid newTemplateId) {
			var replicas = GetEntities(ReplicaTableName, "DCTemplate", oldTemplateId);
			return CopyEntities(replicas, new Dictionary<string, object> {
				{ "DCTemplateId", newTemplateId }
			});
		}

		private void CopyBlocksLinkedEntities(IDictionary<Guid, Guid> blocks, string rootSchemaName,
				string columnName, IDictionary<Guid, Guid> mapping) {
			foreach (var blockData in blocks) {
				var entities = GetEntities(rootSchemaName, "DCTemplateBlock", blockData.Key);
				CopyBlockLinkedEntities(entities, blockData.Value, columnName, mapping);
			}
		}

		private void CopyBlockInReplicas(IDictionary<Guid, Guid> blocks, IDictionary<Guid, Guid> replicas) {
			CopyBlocksLinkedEntities(blocks, BlockInReplicaTableName, "DCReplicaId", replicas);
		}

		private void CopyAttributeInBlocks(IDictionary<Guid, Guid> blocks, IDictionary<Guid, Guid> attributes) {
			CopyBlocksLinkedEntities(blocks, AttributeInBlockTableName, "DCAttributeId", attributes);
		}

		private IEnumerable<TModel> ConvertToModels<TModel>(IEnumerable<Entity> entities) where TModel : new() {
			var collection = new List<TModel>();
			foreach (var entity in entities) {
				collection.Add(ConvertToModel<TModel>(entity));
			}
			return collection;
		}

		private TModel ConvertToModel<TModel>(Entity entity) where TModel : new() {
			var columnNames = entity.GetColumnValueNames();
			var columnsToModel = entity.Schema.Columns
				.Where(x => x.IsValueCloneable
					&& columnNames.Contains(x.ColumnValueName))
				.Union(new[] { entity.Schema.PrimaryColumn });
			var model = new TModel();
			columnsToModel.ForEach(x => {
				model.TrySetPropertyValue(x.ColumnValueName, entity.GetColumnValue(x.ColumnValueName));
			});
			return model;
		}

		private IEnumerable<DCAttributeModel> ReadAttributes(Guid templateId) {
			var attributes = GetEntities(TemplateAttributeTableName, "DCTemplate", templateId);
			var models = ConvertToModels<DCAttributeModel>(attributes);
			models.ForEach(x => {
				var attribute = attributes.FirstOrDefault(a => a.GetTypedColumnValue<Guid>("Id") == x.Id);
				if (attribute != null) {
					var bytes = attribute.GetBytesValue("Value");
					x.Value = Encoding.UTF8.GetString(bytes);
				}
			});
			return models;
		}

		private IEnumerable<DCTemplateGroupModel> ReadTemplateGroups(Guid templateId) {
			var groups = GetEntities(TemplateGroupTableName, "DCTemplate", templateId);
			return ConvertToModels<DCTemplateGroupModel>(groups);
		}

		private IEnumerable<DCTemplateBlockModel> ReadTemplateBlocks(IEnumerable<DCTemplateGroupModel> groups) {
			var models = new List<DCTemplateBlockModel>();
			foreach (var group in groups) {
				var groupBlocks = GetEntities(TemplateBlockTableName, "DCTemplateGroup", group.Id);
				var blockModels = ConvertToModels<DCTemplateBlockModel>(groupBlocks);
				blockModels.ForEach(x => {
					x.GroupIndex = group.Index;
				});
				models.AddRange(blockModels);
			}
			return models;
		}

		private IEnumerable<DCReplicaModel> ReadReplicas(Guid templateId, DCTemplateReadOption options) {
			var excludedColumns = new List<string>();
			if (options.HasFlag(DCTemplateReadOption.ExcludeReplicaHtmlContent)) {
				excludedColumns.Add("Content");
			}
			var replicas = GetEntities(ReplicaTableName, "DCTemplate", templateId, excludedColumns);
			return ConvertToModels<DCReplicaModel>(replicas);
		}

		private void SetAttributeIndexesForBlocks(IEnumerable<DCTemplateBlockModel> blockModels,
				IEnumerable<DCAttributeModel> attributeModels) {
			blockModels.ForEach(x => {
				var attrIds = GetEntities(AttributeInBlockTableName, "DCTemplateBlock", x.Id)
						.Select(a => a.GetTypedColumnValue<Guid>("DCAttributeId"));
				x.AttributeIndexes = attributeModels
					.Where(a => attrIds.Contains(a.Id))
					.Select(a => a.Index)
					.ToArray();
			});
		}

		private void SetBlockIndexesForReplicas(IEnumerable<DCTemplateBlockModel> blockModels,
				IEnumerable<DCReplicaModel> replicaModels) {
			replicaModels.ForEach(x => {
				var blockIds = GetEntities(BlockInReplicaTableName, "DCReplica", x.Id)
						.Select(a => a.GetTypedColumnValue<Guid>("DCTemplateBlockId"));
				x.BlockIndexes = blockModels
					.Where(b => blockIds.Contains(b.Id))
					.Select(b => b.Index)
					.ToArray();
			});
		}

		private T GetTemplateModelWithLinkedEntities(Guid templateId,
				DCRepositoryReadOptions<T, DCReplicaModel> options, Entity template) {
			var groupModels = ReadTemplateGroups(templateId).ToList();
			var attributeModels = ReadAttributes(templateId).ToList();
			var blockModels = ReadTemplateBlocks(groupModels).ToList();
			var replicaModels = ReadReplicas(templateId, options.TemplateReadOptions).ToList();
			SetAttributeIndexesForBlocks(blockModels, attributeModels);
			SetBlockIndexesForReplicas(blockModels, replicaModels);
			var templateModel = new T {
				Id = template.GetTypedColumnValue<Guid>("Id"),
				RecordId = template.GetTypedColumnValue<Guid>("RecordId"),
				Attributes = options.TemplateReadOptions.HasFlag(DCTemplateReadOption.ExcludeAttributes)
					? new List<DCAttributeModel>()
					: attributeModels,
				Groups = groupModels,
				Blocks = blockModels,
				Replicas = replicaModels
			};
			return templateModel;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Inserts whole template with replicas to DB.
		/// </summary>
		/// <param name="model">Template contract.</param>
		protected virtual void InsertTemplate(T model) {
			InsertTemplateEntity(model);
			InsertTemplateGroups(model);
			InsertTemplateAttributes(model);
			InsertTemplateBlocks(model);
			InsertTemplateReplicas(model);
		}

		/// <summary>
		/// Deletes template entity. Other linked entities delete through cascade.
		/// </summary>
		/// <param name="templateId">Uniqueidentifier of template which need to delete.</param>
		/// <returns>Boolean result of operation.</returns>
		protected virtual bool DeleteTemplate(Guid templateId) {
			var template = GetEntity(TemplateTableName);
			if (template.FetchFromDB(templateId)) {
				return template.Delete();
			}
			return false;
		}

		/// <summary>
		/// Copies template and all linked entities. Relinks new entities with each other.
		/// </summary>
		/// <param name="templateId">Unique identifier of template to copy.</param>
		/// <returns>Unique identifier of the new entity.</returns>
		protected virtual Guid CopyTemplate(Guid templateId) {
			var template = GetEntity(TemplateTableName);
			if (!template.FetchFromDB(templateId)) {
				return Guid.Empty;
			}
			var newTemplateId = CopyTemplateEntity(template);
			var groupMapping = CopyGroups(templateId, newTemplateId);
			var attrMapping = CopyAttributes(templateId, newTemplateId);
			var blockMapping = CopyBlocks(groupMapping);
			var replicaMapping = CopyReplicas(templateId, newTemplateId);
			CopyBlockInReplicas(blockMapping, replicaMapping);
			CopyAttributeInBlocks(blockMapping, attrMapping);
			return newTemplateId;
		}

		/// <summary>
		/// Returns template model with linked entity models by template's unique identifier
		/// using <see cref="Entity"/>.
		/// </summary>
		/// <param name="templateId">Unique identifier of template to read.</param>
		/// <param name="options">Options flags for reads template.</param>
		/// <returns>Template model instance of type <see cref="DCTemplateModel"/></returns>
		protected virtual T ReadTemplate(Guid templateId, DCRepositoryReadOptions<T, DCReplicaModel> options) {
			var template = GetEntity(TemplateTableName);
			if(!template.FetchFromDB(templateId)) {
				return null;
			}
			return GetTemplateModelWithLinkedEntities(templateId, options, template);
		}

		/// <summary>
		/// Returns template model with linked entity models by template's linked entity identifier
		/// using <see cref="Entity"/>.
		/// </summary>
		/// <param name="recordId">Unique identifier of template linked entity.</param>
		/// <param name="options">Options flags for reads template.</param>
		/// <returns>Template model instance of type <see cref="DCTemplateModel"/></returns>
		protected virtual T ReadTemplateByRecordId(Guid recordId, DCRepositoryReadOptions<T, DCReplicaModel> options) {
			var template = GetEntity(TemplateTableName);
			if (!template.FetchFromDB("RecordId", recordId)) {
				return null;
			};
			var templateId = template.GetTypedColumnValue<Guid>("Id");
			return GetTemplateModelWithLinkedEntities(templateId, options, template);
		}

		/// <summary>
		/// Returns template model with linked entity models by template's unique identifier
		/// using <see cref="Entity"/>.
		/// </summary>
		/// <param name="templateId">Unique identifier of template to read.</param>
		/// <returns>Template model instance of type <see cref="DCTemplateModel"/>.</returns>
		protected virtual T ReadTemplate(Guid templateId) {
			return ReadTemplate(templateId, DefaultReadOptions);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves template from <paramref name="model"/>.
		/// When templete doesn't exist it inserts template and connected entities.
		/// Otherwise deletes all information by template and inserts it newly.
		/// </summary>
		/// <param name="model">Template model.</param>
		public void Save(T model) {
			model.CheckArgumentNull(nameof(model));
			DeleteTemplate(model.Id);
			InsertTemplate(model);
		}

		/// <summary>
		/// Copies teplate and linked entities.
		/// If there is no such record in DB method returns Guid.Empty.
		/// </summary>
		/// <param name="templateId">Uniqueidentifier of template which need to copy.</param>
		/// <returns>Uniqueidentifier of template copy.</returns>
		public Guid Copy(Guid templateId) {
			templateId.CheckArgumentEmpty(nameof(templateId));
			return CopyTemplate(templateId);
		}

		/// <summary>
		/// Deletes template and all linked entities.
		/// If there is no such record in DB method does nothing.
		/// </summary>
		/// <param name="templateId">Uniqueidentifier of template which need to delete.</param>
		/// <returns>Boolean result of operation.</returns>
		public bool Delete(Guid templateId) {
			templateId.CheckArgumentEmpty(nameof(templateId));
			return DeleteTemplate(templateId);
		}

		/// <summary>
		/// Returns template data model for specified tempate id by ESQ with rights checking. 
		/// If there is no template in DB or no rights to read method returns NULL.
		/// </summary>
		/// <param name="templateId">Unique identifier of template to read.</param>
		/// <returns>Template model of type <see cref="DCTemplateModel"/>.</returns>
		public T Read(Guid templateId) {
			templateId.CheckArgumentEmpty(nameof(templateId));
			return ReadTemplate(templateId);
		}

		/// <summary>
		/// Returns template data model for specified tempate id by ESQ with rights checking. 
		/// If there is no template in DB or no rights to read method returns NULL.
		/// Result model is formed on the basis of <paramref name="options"/>.
		/// </summary>
		/// <param name="templateId">Unique identifier of template to read.</param>
		/// <param name="options">Options flags for reads template.</param>
		/// <returns>Template model of type <see cref="DCTemplateModel"/>.</returns>
		public T Read(Guid templateId, DCRepositoryReadOptions<T, DCReplicaModel> options) {
			templateId.CheckArgumentEmpty(nameof(templateId));
			return ReadTemplate(templateId, options);
		}

		/// <summary>
		/// Returns template data model for specified linked record id by ESQ with rights checking. 
		/// If there is no template in DB or no rights to read method returns NULL.
		/// </summary>
		/// <param name="recordId">Unique identifier of template to read.</param>
		/// <param name="options">Options flags for reads template.</param>
		/// <returns>Template model of type <see cref="DCTemplateModel"/></returns>
		/// <exception cref="ArgumentNullOrEmptyException">Thrown when <paramref name="recordId"/> 
		/// equals <see cref="Guid.Empty"/>.</exception>
		public T ReadByRecordId(Guid recordId, DCRepositoryReadOptions<T, DCReplicaModel> options) {
			recordId.CheckArgumentEmpty(nameof(recordId));
			return ReadTemplateByRecordId(recordId, options);
		}

		#endregion

	}

	#endregion

}

