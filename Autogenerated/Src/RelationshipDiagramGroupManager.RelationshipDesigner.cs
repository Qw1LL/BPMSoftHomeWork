namespace BPMSoft.Configuration.RelationshipDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.RightsService;

	#region Class: RelationshipDiagramGroup

	[DataContract]
	public class RelationshipDiagramGroup
	{

		[DataMember(Name = "id")]
		public Guid Id;

		[DataMember(Name = "name")]
		public string Name;

		[DataMember(Name = "color")]
		public string Color;

		[DataMember(Name = "comment")]
		public string Comment = string.Empty;

		[DataMember(Name = "entities", EmitDefaultValue = false)]
		public List<RelationshipDiagramEntityInGroup> Entities;
	}

	#endregion

	#region Class: RelationshipDiagramGroupEntityRecordData

	[DataContract]
	public class RelationshipDiagramGroupEntityRecordData
	{

		[DataMember(Name = "id")]
		public Guid Id;

		[DataMember(Name = "name")]
		public string Name;

		[DataMember(Name = "type")]
		public string Type;

		[DataMember(Name = "image")]
		public string Image;
	}

	#endregion

	#region Class: RelationshipDiagramEntityInGroup

	[DataContract]
	public class RelationshipDiagramEntityInGroup
	{

		[DataMember(Name = "id")]
		public Guid Id;

		[DataMember(Name = "entityId")]
		public Guid EntityId;

		[DataMember(Name = "groupId")]
		public Guid GroupId;

		[DataMember(Name = "comment")]
		public string Comment = string.Empty;

		[DataMember(Name = "entityRecordData")]
		public RelationshipDiagramGroupEntityRecordData EntityRecordData;
	}

	#endregion

	#region Interface: IRelationshipDiagramGroupManager

	public interface IRelationshipDiagramGroupManager
	{
		List<RelationshipDiagramGroup> GetGroupsData();

		List<RelationshipDiagramGroup> GetGroupsDataForEntity(Guid entityId);

		void CreateGroup(RelationshipDiagramGroup group);

		void UpdateGroup(RelationshipDiagramGroup group);

		void DeleteGroup(Guid groupId);

		void CreateEntityInGroup(RelationshipDiagramEntityInGroup entityInGroup);

		void UpdateEntityInGroup(RelationshipDiagramEntityInGroup entityInGroup);

		void DeleteEntityInGroup(Guid entityId, Guid groupId);
	}

	#endregion

	#region Class: RelationshipDiagramGroupManager

	[DefaultBinding(typeof(IRelationshipDiagramGroupManager))]
	public class RelationshipDiagramGroupManager: IRelationshipDiagramGroupManager
	{
		private string _defaultEntityRecordImage = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iMzIiIGhlaWdodD0iMzIiIHZpZXdCb3g9IjAgMCAzMiAzMiI+PGRlZnM+PHN0eWxlPi5hLC5me2ZpbGw6bm9uZTt9LmF7c3Ryb2tlOiNlNGU0ZTQ7fS5ie2ZpbGw6I2ZmZjt9LmN7Y2xpcC1wYXRoOnVybCgjYSk7fS5ke2ZpbGw6IzAwNmNlMDtvcGFjaXR5OjAuNDt9LmV7c3Ryb2tlOm5vbmU7fTwvc3R5bGU+PGNsaXBQYXRoIGlkPSJhIj48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMyIiBoZWlnaHQ9IjMyIiByeD0iMTYiLz48L2NsaXBQYXRoPjwvZGVmcz48ZyB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwIDApIj48ZyB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwIDApIj48cmVjdCBjbGFzcz0iYiIgd2lkdGg9IjMyIiBoZWlnaHQ9IjMyIiByeD0iMTYiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDAgMCkiLz48ZyBjbGFzcz0iYyI+PHBhdGggY2xhc3M9ImQiIGQ9Ik0zMS42ODYsMzEuMWwtOS0zLjcyNS0uMzQzLTEuMDExYy0uMTE0LS4zNDYtLjI1Ny0uNjkyLS42LS43NzJhLjQyOC40MjgsMCwwLDEtLjI1Ny0uMzQ2bC0uMi0yYS41ODEuNTgxLDAsMCwxLC4xNzEtLjQyNiw0LjM5Miw0LjM5MiwwLDAsMCwxLjAyOS0yLjI2MiwxMC43ODUsMTAuNzg1LDAsMCwxLC40MjktMS4yNTFsLjQ4Ni0yLjM2OGMuMDU3LS4zMTkuMDI5LS41NTktLjM0My0uNjY1LS4xMTQtLjAyNy0uMi0uMTg2LS4yLS40MjZhMjUuMTU4LDI1LjE1OCwwLDAsMCwuMzE0LTQuMTc4QzIyLjk3MSwxMC4yMzcsMjEuOCw3LjMzNywxOC42LDcuNSwxMC4wODYsNS4xODIsMTAuNzE0LDkuMDQsNy43NzEsMTAuMTg0YTEuOSwxLjksMCwwLDAsMS44NTcuMzE5Yy0uMTQzLjEwNi0xLjE3MS4xNi0xLjY1NywyLjA3NWEyLjg0MywyLjg0MywwLDAsMSwxLjMxNC0uOTMxYy0uOTcxLjUwNi0uMDg2LDMuNTM5LS4wNTcsMy44MzJ2LjRjMCwuMTg2LS4wODYuNC0uMi40MjYtLjM3MS4xMzMtLjM3MS4zNzMtLjM0My42NjVsLjQ4NiwyLjM2OEExMC43ODYsMTAuNzg2LDAsMCwxLDkuNiwyMC41ODhhNC4zOTIsNC4zOTIsMCwwLDAsMS4wMjksMi4yNjIuNzI1LjcyNSwwLDAsMSwuMTcxLjQyNmwtLjIsMmMtLjAyOS4xMzMtLjE0My4zMTktLjI1Ny4zNDZhLjkzNy45MzcsMCwwLDAtLjYuNzcyTDkuNCwyNy40LjMxNCwzMS4xQS41NjUuNTY1LDAsMCwwLDAsMzEuNlYzNC43N0gzMlYzMS42YS41NjUuNTY1LDAsMCwwLS4zMTQtLjUwNiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCAtMi43NzEpIi8+PC9nPjwvZz48ZyBjbGFzcz0iYSIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCAwKSI+PHJlY3QgY2xhc3M9ImUiIHdpZHRoPSIzMiIgaGVpZ2h0PSIzMiIgcng9IjE2Ii8+PHJlY3QgY2xhc3M9ImYiIHg9IjAuNSIgeT0iMC41IiB3aWR0aD0iMzEiIGhlaWdodD0iMzEiIHJ4PSIxNS41Ii8+PC9nPjwvZz48L3N2Zz4=";

		private RightsHelper _rightsHelper;

		private IRelationshipDiagramManager _diagramManager;

		private UserConnection UserConnection {
			get; set;
		}

		protected RightsHelper RightsHelper =>
			_rightsHelper ?? (_rightsHelper =
				ClassFactory.Get<RightsHelper>(new ConstructorArgument("userConnection", UserConnection)));

		protected IRelationshipDiagramManager DiagramManager =>
			_diagramManager ?? (_diagramManager = ClassFactory.Get<RelationshipDiagramManager>());

		public RelationshipDiagramGroupManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		private Guid GetRelationshipEntityByRecordId(Guid recordId) {
			var select = new Select(UserConnection)
				.Column("Id")
				.From("RelationshipEntity")
				.Where("RecordId").IsEqual(Column.Parameter(recordId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						return reader.GetColumnValue<Guid>("Id");
					}
				}
			}
			return Guid.Empty;
		}

		protected Select GetGroupSelect() {
			return new Select(UserConnection)
				.Column("RelationshipGroup", "Id")
				.Column("RelationshipGroup", "Name")
				.Column("RelationshipGroup", "Color")
				.Column("RelationshipGroup", "Comment")
				.From("RelationshipGroup");
		}

		protected Select GetEntityInGroupSelect() {
			Guid currentUserCultureId = UserConnection.CurrentUser.SysCultureId;
			// TODO Need use diagram config to contact data
			return new Select(UserConnection)
				.Column("RelationshipEntity", "Id")
				.Column("RelationEntityInGroup", "Id").As("RelationEntityInGroupId")
				.Column("RelationEntityInGroup", "RelationshipGroupId")
				.Column("RelationEntityInGroup", "Comment")
				.Column("RelationshipEntity", "RecordId").As("EntityRecordId")
				.Column("RelationshipEntity", "SchemaUId").As("EntitySchemaUId")
				.Column("Contact", "Name").As("EntityRecordName")
				.Column(Func.IsNull(Column.SourceColumn("SJBL", "Name"), Column.SourceColumn("JB", "Name"))).As("EntityRecordJobName")
				.Column("SysImage", "Data").As("EntityRecordImage")
				.Column("SysImage", "MimeType").As("EntityRecordImageMimeType")
				.From("RelationshipEntity")
				.InnerJoin("RelationEntityInGroup")
					.On("RelationEntityInGroup", "RelationshipEntityId")
					.IsEqual("RelationshipEntity", "Id")
				.InnerJoin("Contact")
					.On("RelationshipEntity", "RecordId")
					.IsEqual("Contact", "Id")
				.LeftOuterJoin("Job").As("JB")
					.On("Contact", "JobId")
					.IsEqual("JB", "Id")
				.LeftOuterJoin("SysJobLcz").As("SJBL").On("JB", "Id").IsEqual("SJBL", "RecordId")
					.And("SJBL", "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId))
				.LeftOuterJoin("SysImage")
					.On("Contact", "PhotoId")
					.IsEqual("SysImage", "Id") as Select;
		}

		protected List<RelationshipDiagramGroup> ExecuteGroupSelectAndCreateList(Select groupSelect) {
			var list = new List<RelationshipDiagramGroup>();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = groupSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						list.Add(new RelationshipDiagramGroup {
							Id = reader.GetColumnValue<Guid>("Id"),
							Name = reader.GetColumnValue<string>("Name"),
							Color = reader.GetColumnValue<string>("Color"),
							Comment = reader.GetColumnValue<string>("Comment") ?? string.Empty,
						});
					}
				}
			}
			return list;
		}

		protected List<RelationshipDiagramEntityInGroup> ExecuteEntityInGroupSelectAndCreateList(Select groupsEntityData) {
			var list = new List<RelationshipDiagramEntityInGroup>();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = groupsEntityData.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var entityRecordId = reader.GetColumnValue<Guid>("EntityRecordId");
						// TODO Need use config data
						if (!RightsHelper.GetCanReadSchemaRecordRight("Contact", entityRecordId)) {
							continue;
						}
						var imageData = reader.GetColumnValue<byte[]>("EntityRecordImage");
						var imageMymeType = reader.GetColumnValue<string>("EntityRecordImageMimeType");
						list.Add(new RelationshipDiagramEntityInGroup {
							Id = reader.GetColumnValue<Guid>("RelationEntityInGroupId"),
							EntityId = reader.GetColumnValue<Guid>("Id"),
							GroupId = reader.GetColumnValue<Guid>("RelationshipGroupId"),
							Comment = reader.GetColumnValue<string>("Comment") ?? string.Empty,
							EntityRecordData = new RelationshipDiagramGroupEntityRecordData {
								Id = reader.GetColumnValue<Guid>("EntityRecordId"),
								Name = reader.GetColumnValue<string>("EntityRecordName"),
								Type = reader.GetColumnValue<string>("EntityRecordJobName"),
								Image = GetEntityRecordImage(imageData, imageMymeType)
							}
						});
					}
				}
			}
			return list;
		}

		protected string GetEntityRecordImage(byte[] imageData, string mimeType) {
			string defaultValue = _defaultEntityRecordImage;
			if (imageData == null || imageData.IsEmpty()) {
				return defaultValue;
			}
			try {
				var fileContent = Convert.ToBase64String(imageData);
				var result = $"data:{mimeType};base64,{fileContent}";
				return result;
			}
			catch (Exception e) {
				return defaultValue;
			}
		}

		protected List<RelationshipDiagramGroup> GetGroups() {
			var groupSelect = GetGroupSelect();
			return ExecuteGroupSelectAndCreateList(groupSelect);
		}

		protected List<RelationshipDiagramGroup> GetGroupsForEntity(Guid entityId) {
			var groupSelect = GetGroupSelect();
			groupSelect = groupSelect
					.InnerJoin("RelationEntityInGroup")
						.On("RelationEntityInGroup", "RelationshipGroupId")
						.IsEqual("RelationshipGroup", "Id")
					.Where("RelationEntityInGroup", "RelationshipEntityId")
						.IsEqual(Column.Parameter(entityId)) as Select;
			return ExecuteGroupSelectAndCreateList(groupSelect);
		}

		protected List<RelationshipDiagramGroup> AddEntitiesToGroup(List<RelationshipDiagramEntityInGroup> groupsEntityData,
				List<RelationshipDiagramGroup> groups) {
			if (groupsEntityData.Count == 0) {
				return groups;
			}
			foreach (var group in groups) {
				var groupEntityData = groupsEntityData.Where(ged => ged.GroupId.Equals(group.Id));
				group.Entities = groupEntityData.ToList();
			}
			return groups;
		}

		protected List<RelationshipDiagramEntityInGroup> GetGroupsEntityData() {
			var groupsEntityData = GetEntityInGroupSelect();
			return ExecuteEntityInGroupSelectAndCreateList(groupsEntityData);
		}

		protected List<RelationshipDiagramEntityInGroup> GetGroupsEntityDataForEntity(Guid entityId) {
			var groupSubSelect = new Select(UserConnection)
				.Column("RelationshipGroupId")
				.From("RelationEntityInGroup")
				.Where("RelationshipEntityId").IsEqual(Column.Parameter(entityId)) as Select;
			var groupsEntityData = GetEntityInGroupSelect();
			groupsEntityData = groupsEntityData
				.Where("RelationEntityInGroup", "RelationshipGroupId")
					.In(groupSubSelect) as Select;
			return ExecuteEntityInGroupSelectAndCreateList(groupsEntityData);
		}

		public List<RelationshipDiagramGroup> GetGroupsData() {
			var groups = GetGroups();
			if (groups.Count == 0) {
				return groups;
			}
			return AddEntitiesToGroup(GetGroupsEntityData(), groups);
		}

		public List<RelationshipDiagramGroup> GetGroupsDataForEntity(Guid entityId) {
			var groups = GetGroupsForEntity(entityId);
			if (groups.Count == 0) {
				return groups;
			}
			return AddEntitiesToGroup(GetGroupsEntityDataForEntity(entityId), groups);
		}

		public void CreateGroup(RelationshipDiagramGroup group) {
			var groupInsert = new Insert(UserConnection).Into("RelationshipGroup")
				.Set("Id", Column.Parameter(group.Id))
				.Set("Name", Column.Parameter(group.Name))
				.Set("Color", Column.Parameter(group.Color))
				.Set("Comment", Column.Parameter(group.Comment)) as Insert;
			groupInsert.Execute();
		}

		public void UpdateGroup(RelationshipDiagramGroup group) {
			var groupUpdate = new Update(UserConnection, "RelationshipGroup")
				.Set("Name", Column.Parameter(group.Name))
				.Set("Color", Column.Parameter(group.Color))
				.Set("Comment", Column.Parameter(group.Comment))
				.Where("Id").IsEqual(Column.Parameter(group.Id)) as Update;
			groupUpdate.Execute();
		}

		public void DeleteGroup(Guid groupId) {
			var clearGroup = new Delete(UserConnection)
				.From("RelationEntityInGroup")
				.Where("RelationshipGroupId").IsEqual(Column.Parameter(groupId)) as Delete;
			clearGroup.Execute();
			var deleteGroup = new Delete(UserConnection)
				.From("RelationshipGroup")
				.Where("Id").IsEqual(Column.Parameter(groupId)) as Delete;
			deleteGroup.Execute();
		}

		public void CreateEntityInGroup(RelationshipDiagramEntityInGroup entityInGroup) {
			if (entityInGroup.EntityId.IsEmpty() && !entityInGroup.EntityRecordData.Id.IsEmpty()) {
				var entityRecordId = entityInGroup.EntityRecordData.Id;
				var entityId = GetRelationshipEntityByRecordId(entityRecordId);
				if (entityId.IsEmpty()) {
					// TODO Need use diagramconfig for schemaName
					// TODO dont cross managers
					var createdResult = DiagramManager.CreateRelationshipEntityAndDiagramForRecord(entityRecordId, "Contact");
					entityId = createdResult.CreatedEntityId;
				}
				entityInGroup.EntityId = entityId;
			}
			var entityInGroupInsert = new Insert(UserConnection).Into("RelationEntityInGroup")
				.Set("RelationshipGroupId", Column.Parameter(entityInGroup.GroupId))
				.Set("RelationshipEntityId", Column.Parameter(entityInGroup.EntityId))
				.Set("Comment", Column.Parameter(entityInGroup.Comment)) as Insert;
			entityInGroupInsert.Execute();
		}

		public void UpdateEntityInGroup(RelationshipDiagramEntityInGroup entityInGroup) {
			var entityInGroupUpdate = new Update(UserConnection, "RelationEntityInGroup")
				.Set("Comment", Column.Parameter(entityInGroup.Comment))
				.Where("RelationshipEntityId").IsEqual(Column.Parameter(entityInGroup.EntityId))
				.And("RelationshipGroupId").IsEqual(Column.Parameter(entityInGroup.GroupId)) as Update;
			entityInGroupUpdate.Execute();
		}

		public void DeleteEntityInGroup(Guid entityId, Guid groupId) {
			var entityInGroupDelete = new Delete(UserConnection).From("RelationEntityInGroup")
				.Where("RelationshipGroupId").IsEqual(Column.Parameter(groupId))
				.And("RelationshipEntityId").IsEqual(Column.Parameter(entityId)) as Delete;
			entityInGroupDelete.Execute();
		}
	}

	#endregion
}

