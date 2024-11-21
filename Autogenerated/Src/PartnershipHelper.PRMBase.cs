namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: PartnershipHelper

	/// <summary>
	/// Helper class for working with entity.
	/// </summary>
	public class PartnershipHelper
	{

		#region Constants: Private

		/// <summary>
		/// Dictionary of partnership parameter value types.
		/// </summary>
		private readonly Dictionary<Guid, string> PartnershipValueTypes =
			new Dictionary<Guid, string>() {
				{PRMBaseConstants.SpecificationTypeListId, "ListItemValue"},
				{PRMBaseConstants.SpecificationTypeDemicalId, "FloatValue"},
				{PRMBaseConstants.SpecificationTypeBooleanId, "BooleanValue"},
				{PRMBaseConstants.SpecificationTypeStringId, "StringValue"},
				{PRMBaseConstants.SpecificationTypeIntegerId, "IntValue"}
			};

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the class <see cref="PartnershipHelper"/>,
		/// using the specified user connection.</summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public PartnershipHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Wrapper on <see cref="Entity"/> Delete method for better testing.
		/// Deletes entity.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/></param>
		public virtual void DeleteParameterEntity(Entity entity) {
			entity.UseAdminRights = false;
			entity.Delete();
		}

		/// <summary>
		/// Recalculates all scores of current partnership obligation parameters.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> Id of partnership.</param>
		public void RecalculateAllScore(Guid partnershipId) {
			var obligationsEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "PartnershipParameter");
			obligationsEsq.Filters.Add(
				obligationsEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership", partnershipId));
			obligationsEsq.Filters.Add(
				obligationsEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParameterType",
				PRMBaseConstants.ObligationParameterTypeId));
			obligationsEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			obligationsEsq.AddColumn("PartnershipParameterType");
			obligationsEsq.AddColumn("IntValue");
			obligationsEsq.AddColumn("FloatValue");
			obligationsEsq.AddColumn("PartnerParamCategory");
			obligationsEsq.AddColumn("Score");
			obligationsEsq.UseAdminRights = false;
			EntityCollection obligationsCollection = obligationsEsq.GetEntityCollection(_userConnection);
			foreach (var target in obligationsCollection) {
				if (target.GetTypedColumnValue<Guid>("PartnershipParameterTypeId") == PRMBaseConstants.TargetPartnershipParamTypeId) {
					string targetScoreColumnName = target.GetTypedColumnValue<int>("IntValue") != 0 
						? "IntValue"
						: "FloatValue";
					var targetValue = target.GetTypedColumnValue<double>(targetScoreColumnName);
					if (targetValue > 0) {
						Entity currentParameter =
							obligationsCollection.FirstOrDefault(
								x => x.GetTypedColumnValue<Guid>("PartnershipParameterTypeId") == PRMBaseConstants.CurrentPartnershipParamTypeId &&
								x.GetTypedColumnValue<Guid>("PartnerParamCategoryId") == target.GetTypedColumnValue<Guid>("PartnerParamCategoryId"));
						if (currentParameter == null) {
							return;
						}
						var targetScore = target.GetTypedColumnValue<double>("Score");
						var currentValue = currentParameter.GetTypedColumnValue<double>(targetScoreColumnName);
						var currentScore = Convert.ToInt32(currentValue >= targetValue ? targetScore : Math.Round((targetScore / targetValue) * currentValue));
						
						var currentParameterId = currentParameter.GetTypedColumnValue<Guid>("Id");
						var update = new Update(_userConnection, "PartnershipParameter")
							.Set("Score", Column.Parameter(currentScore))
							.Where("Id").IsEqual(Column.Parameter(currentParameterId))
							.Execute();
					}
				}
			}
		}

		/// <summary>
		/// Set ScoreLeft for Partnership.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		public void SetPartnershipScoreLeft(Guid partnershipId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "PartnershipParameter");
			esq.UseAdminRights = false;
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership", partnershipId));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParameterType",
				PRMBaseConstants.ObligationParameterTypeId));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "PartnershipParameterType",
				PRMBaseConstants.CurrentPartnershipParamTypeId));
			string currentScoreColumnName = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Sum, "Score")).Name;
			var targetScoreColumnName = esq.AddColumn("Partnership.PartnerLevel.TargetScore").Name;
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			if (entityCollection.IsNotEmpty()) {
				var entity = entityCollection[0];
				int currentScore = entity.GetTypedColumnValue<int>(currentScoreColumnName);
				int targetScore = entity.GetTypedColumnValue<int>(targetScoreColumnName);
				var partnershipSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Partnership");
				var partnershipEntity = partnershipSchema.CreateEntity(_userConnection);
				if (partnershipEntity.FetchFromDB(partnershipId)) {
					partnershipEntity.SetColumnValue("ScoreLeft", targetScore - currentScore);
					partnershipEntity.UseAdminRights = false;
					partnershipEntity.Save(false);
				}
			}
		}

		/// <summary>
		/// Changes partnership level.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		public void ChangePartnershipLevel(Guid partnershipId) {
			EntitySchema partnershipSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Partnership");
			EntitySchemaQuery esq = new EntitySchemaQuery(partnershipSchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddAllSchemaColumns();
			esq.UseAdminRights = false;
			EntitySchemaQueryColumn tsCol = esq.AddColumn("PartnerLevel.TargetScore");
			EntitySchemaQueryColumn numberCol = esq.AddColumn("PartnerLevel.Number");
			Entity partnershipEntity = esq.GetEntity(_userConnection, partnershipId);
			if (partnershipEntity != null) {
				Guid obligationPrameterTypeId = PRMBaseConstants.ObligationParameterTypeId;
				Guid currentPartnershipParamTypeId = PRMBaseConstants.CurrentPartnershipParamTypeId;
				Select sumSelect =
					new Select(_userConnection).Column(Func.Sum("Score"))
						.As("ScoreSum")
						.From("PartnershipParameter")
						.Where("PartnershipId")
						.IsEqual(new QueryParameter(partnershipId))
						.And("PartnershipParameterTypeId")
						.IsEqual(new QueryParameter(currentPartnershipParamTypeId))
						.And("ParameterTypeId")
						.IsEqual(new QueryParameter(obligationPrameterTypeId)) as Select;
				double scoreSum = sumSelect.ExecuteScalar<double>();
				double targetScore = partnershipEntity.GetTypedColumnValue<double>(tsCol.Name);
				int currentNumber = partnershipEntity.GetTypedColumnValue<int>(numberCol.Name);
				if (targetScore <= scoreSum) {
					Guid partnerTypeId = partnershipEntity.GetTypedColumnValue<Guid>("PartnerTypeId");
					Select nextLevelSelect =
						new Select(_userConnection).Top(1)
							.Column("Id")
							.From("PartnerLevel")
							.Where("PartnerTypeId")
							.IsEqual(new QueryParameter(partnerTypeId))
							.And("Number")
							.IsGreater(new QueryParameter(currentNumber))
							.OrderByAsc("Number") as Select;
					Guid nextLevelId = nextLevelSelect.ExecuteScalar<Guid>();
					if (nextLevelId.IsNotEmpty()) {
						partnershipEntity.SetColumnValue("PartnerLevelId", nextLevelId);
						partnershipEntity.SetColumnValue("ScoreLeft", targetScore - scoreSum);
						partnershipEntity.UseAdminRights = false;
						partnershipEntity.Save();
					}
				}
			}
		}

		/// <summary>
		/// Returns collection of partnership level parameters.
		/// </summary>
		/// <param name="partnerLevelId"><see cref="Guid"/> of partner level.</param>
		/// <returns><see cref="EntityCollection"/> collection of partnership level parameters.</returns>
		public EntityCollection GetLevelPartnershipParameters(Guid partnerLevelId) {
			EntitySchemaQuery esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "LevelPartnershipParam");
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "PartnerLevel",
				partnerLevelId));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual,
				"StartDate", DateTime.UtcNow));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.GreaterOrEqual,
				"DueDate", DateTime.UtcNow));
			esq.AddAllSchemaColumns();
			esq.UseAdminRights = false;
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Returns collection of current partnership obligation parameters.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		/// <returns><see cref="EntityCollection"/> collection of partnership parameters.</returns>
		public EntityCollection GetCurrentObligations(Guid partnershipId) {
			var currentPartnershipParameters = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "PartnershipParameter");
			currentPartnershipParameters.Filters.Add(
				currentPartnershipParameters.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership",
				partnershipId));
			currentPartnershipParameters.Filters.Add(
				currentPartnershipParameters.CreateFilterWithParameters(FilterComparisonType.Equal, "PartnershipParameterType",
				PRMBaseConstants.CurrentPartnershipParamTypeId));
			currentPartnershipParameters.Filters.Add(
				currentPartnershipParameters.CreateFilterWithParameters(FilterComparisonType.Equal, "ParameterType",
				PRMBaseConstants.ObligationParameterTypeId));
			currentPartnershipParameters.AddAllSchemaColumns();
			return currentPartnershipParameters.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Adds new parameter obligation to partnership.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		/// <param name="partnerLevel"><see cref="Guid"/> of partner level.</param>
		/// <param name="currentPartnershipParameters"><see cref="EntityCollection"/> collection of current partnership parameters.</param>
		/// <param name="levelPartnershipParameters"><see cref="EntityCollection"/> collection of partnership level parameters.</param>
		public void AddNewCurrentObligations(Guid partnershipId, Guid partnerLevel, 
			EntityCollection currentPartnershipParameters, EntityCollection levelPartnershipParameters) {
			List<Guid> currentCategories = currentPartnershipParameters.Select(x => x.GetTypedColumnValue<Guid>("PartnerParamCategoryId")).ToList();
			var newObligations =
				levelPartnershipParameters.Where(x => x.GetTypedColumnValue<Guid>("PartnerParamCategoryId") == PRMBaseConstants.ObligationParameterTypeId &&
					!currentCategories.Contains(x.GetTypedColumnValue<Guid>("PartnerParamCategoryId"))).ToList();
			var partnershipParameterSchema = _userConnection.EntitySchemaManager.GetInstanceByName("PartnershipParameter");
			foreach (var obligation in newObligations) {
				var partnershipParameter = partnershipParameterSchema.CreateEntity(_userConnection);
				partnershipParameter.SetDefColumnValues();
				partnershipParameter.SetColumnValue("ParameterTypeId", PRMBaseConstants.ObligationParameterTypeId);
				partnershipParameter.SetColumnValue("PartnershipParameterTypeId", PRMBaseConstants.CurrentPartnershipParamTypeId);
				partnershipParameter.SetColumnValue("PartnershipId", partnershipId);
				partnershipParameter.SetColumnValue("PartnerLevelId", partnerLevel);
				partnershipParameter.SetColumnValue("PartnerParamCategoryId", obligation.GetTypedColumnValue<Guid>("PartnerParamCategoryId"));
				partnershipParameter.SetColumnValue("ParameterValueTypeId", obligation.GetTypedColumnValue<Guid>("ParameterValueTypeId"));
				partnershipParameter.Save();
			}
		}

		/// <summary>
		/// Adds new partnership parameters of target obligation type.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		/// <param name="partnerLevel"><see cref="Guid"/> of partner level.</param>
		/// <param name="levelPartnershipParameters"><see cref="EntityCollection"/> collection of partnership level parameters.</param>
		public void AddNewTargetObligations(Guid partnershipId, Guid partnerLevel, EntityCollection levelPartnershipParameters) {
			var newObligations = levelPartnershipParameters.Where(
				record => record.GetTypedColumnValue<Guid>("ParameterTypeId") == PRMBaseConstants.ObligationParameterTypeId).ToList();
			var partnershipParameterSchema = _userConnection.EntitySchemaManager.GetInstanceByName("PartnershipParameter");
			foreach (Entity obligation in newObligations) {
				var partnershipParameter = partnershipParameterSchema.CreateEntity(_userConnection);
				partnershipParameter.SetDefColumnValues();
				partnershipParameter.SetColumnValue("ParameterTypeId", PRMBaseConstants.ObligationParameterTypeId);
				partnershipParameter.SetColumnValue("PartnershipParameterTypeId", PRMBaseConstants.TargetPartnershipParamTypeId);
				partnershipParameter.SetColumnValue("PartnershipId", partnershipId);
				partnershipParameter.SetColumnValue("PartnerLevelId", partnerLevel);
				partnershipParameter.SetColumnValue("PartnerParamCategoryId", obligation.GetTypedColumnValue<Guid>("PartnerParamCategoryId"));
				partnershipParameter.SetColumnValue("ParameterValueTypeId", obligation.GetTypedColumnValue<Guid>("ParameterValueTypeId"));
				partnershipParameter.SetColumnValue("Score", obligation.GetTypedColumnValue<double>("Score"));
				partnershipParameter.SetColumnValue("IntValue", obligation.GetTypedColumnValue<int>("IntValue"));
				partnershipParameter.SetColumnValue("FloatValue", obligation.GetTypedColumnValue<double>("FloatValue"));
				partnershipParameter.SetColumnValue("StringValue", obligation.GetTypedColumnValue<string>("StringValue"));
				partnershipParameter.SetColumnValue("BooleanValue", obligation.GetTypedColumnValue<Boolean>("BooleanValue"));
				partnershipParameter.Save();
			}
		}

		/// <summary>
		/// Copies benefit partnership parameters.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		/// <param name="partnerLevel"><see cref="Guid"/> of partner level.</param>
		/// <param name="levelPartnershipParameters"><see cref="EntityCollection"/> collection of partnership level parameters.</param>
		public void CopyBenefitParameters(Guid partnershipId, Guid partnerLevel, EntityCollection levelPartnershipParameters) {
			var benefits = levelPartnershipParameters
				.Where(x => x.GetTypedColumnValue<Guid>("ParameterTypeId") == PRMBaseConstants.BenefitParameterTypeId).ToList();
			var partnershipParameterSchema = _userConnection.EntitySchemaManager.GetInstanceByName("PartnershipParameter");
			foreach (Entity benefit in benefits) {
				var partnershipParameter = partnershipParameterSchema.CreateEntity(_userConnection);
				partnershipParameter.SetDefColumnValues();
				partnershipParameter.SetColumnValue("ParameterTypeId", PRMBaseConstants.BenefitParameterTypeId);
				partnershipParameter.SetColumnValue("PartnershipParameterTypeId", PRMBaseConstants.CurrentPartnershipParamTypeId);
				partnershipParameter.SetColumnValue("PartnershipId", partnershipId);
				partnershipParameter.SetColumnValue("PartnerLevelId", partnerLevel);
				partnershipParameter.SetColumnValue("PartnerParamCategoryId", benefit.GetTypedColumnValue<Guid>("PartnerParamCategoryId"));
				partnershipParameter.SetColumnValue("ParameterValueTypeId", benefit.GetTypedColumnValue<Guid>("ParameterValueTypeId"));
				partnershipParameter.SetColumnValue("Score", benefit.GetTypedColumnValue<double>("Score"));
				partnershipParameter.SetColumnValue("IntValue", benefit.GetTypedColumnValue<int>("IntValue"));
				partnershipParameter.SetColumnValue("FloatValue", benefit.GetTypedColumnValue<double>("FloatValue"));
				partnershipParameter.SetColumnValue("StringValue", benefit.GetTypedColumnValue<string>("StringValue"));
				partnershipParameter.SetColumnValue("BooleanValue", benefit.GetTypedColumnValue<Boolean>("BooleanValue"));
				partnershipParameter.Save();
			}
		}


		/// <summary>
		/// Deletes current partnership parameteres categories.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		/// <param name="listOfNotDeletedCategoryId"><see cref="Array"/> of not deleted 
		/// <see cref="Guid"/> Id's of parameter categories.</param>
		public void DeleteCurrentCategory(Guid partnershipId, object[] listOfNotDeletedCategoryId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "PartnershipParameter");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership",
				partnershipId));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "PartnershipParameterType",
				PRMBaseConstants.CurrentPartnershipParamTypeId));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "PartnerParamCategory",
				listOfNotDeletedCategoryId));
			esq.UseAdminRights = false;
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			var deleteNotExistCategoryCopy = collection.Select(e => (PartnershipParameter)e).ToList();
			foreach (var notExist in deleteNotExistCategoryCopy) {
				DeleteParameterEntity(notExist);
			}
		}

		/// <summary>
		/// Deletes old partnership target parameters.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		public void DeleteOldTarget(Guid partnershipId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "PartnershipParameter");
			esq.AddAllSchemaColumns();
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership",
				partnershipId));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "PartnershipParameterType",
				PRMBaseConstants.TargetPartnershipParamTypeId));
			esq.UseAdminRights = false;
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			var collectionCopy = collection.Select(e => (PartnershipParameter)e).ToList();
			foreach (var target in collectionCopy) {
				DeleteParameterEntity(target);
			}
		}

		/// <summary>
		/// Deletes old partnership benefit parameters.
		/// </summary>
		/// <param name="partnershipId"><see cref="Guid"/> of partnership.</param>
		public void DeleteOldBenefits(Guid partnershipId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "PartnershipParameter");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership",
				partnershipId));
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParameterType",
				PRMBaseConstants.BenefitParameterTypeId));
			esq.UseAdminRights = false;
			EntityCollection collection = esq.GetEntityCollection(_userConnection);
			var collectionCopy = collection.Select(e => (PartnershipParameter)e).ToList();
			foreach (var benefit in collectionCopy) {
				DeleteParameterEntity(benefit);
			}
		}

		/// <summary>
		/// Returns column name of partnership parameter value type.
		/// </summary>
		/// <param name="parameterValueTypeId"><see cref="Guid"/> of partnership parameter
		/// specification value type.</param>
		/// <returns><see cref="string"/> column value name.</returns>
		public string GetColumnValueNameByType(Guid parameterValueTypeId) {
			if (PartnershipValueTypes.ContainsKey(parameterValueTypeId)) {
				return PartnershipValueTypes[parameterValueTypeId];
			};
			return PartnershipValueTypes[PRMBaseConstants.SpecificationTypeStringId];
		}

		/// <summary>
		/// Returns dictionary with conditions of partnership parameter history.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/> of <see cref="PartnershipParameter"/>.</param>
		/// <returns><see cref="Dictionary{TKey,TValue}"/>of string guid key value pair.</returns>
		public Dictionary<string, object> GetPartnerParamHistoryConditions(Entity entity) {
			return new Dictionary<string, object> {
				{ "Partnership", entity.GetTypedColumnValue<Guid>("PartnershipId") },
				{ "ParameterType", entity.GetTypedColumnValue<Guid>("ParameterTypeId") },
				{ "PartnershipParameterType", entity.GetTypedColumnValue<Guid>("PartnershipParameterTypeId")},
				{ "PartnerParamCategory", entity.GetTypedColumnValue<Guid>("PartnerParamCategoryId") },
				{ "EndDate", null}
			};
		}

		/// <summary>
		/// Set end date to history parameter of current partnership parameter.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/>Entity of <see cref="PartnershipParameter"/>.</param>
		public void SetParameterHistoryEndDate(Entity entity) {
			Dictionary<string, object> partnershipParamHistoryConditions;
			if (entity.IsInDeleting) {
				var partnershipParameterSchema = _userConnection.EntitySchemaManager.GetInstanceByName("PartnershipParameter");
				var deletingPartnershipParameterEntity = partnershipParameterSchema.CreateEntity(_userConnection);
				deletingPartnershipParameterEntity.FetchFromDB(entity.PrimaryColumnValue);
				partnershipParamHistoryConditions = GetPartnerParamHistoryConditions(deletingPartnershipParameterEntity);
			} else {
				partnershipParamHistoryConditions = GetPartnerParamHistoryConditions(entity);
			}
			var partnershipParameterHistorySchema = _userConnection.EntitySchemaManager.GetInstanceByName("PartnerParamHistory");
			var currentPartnershipParamHistoryEntity = partnershipParameterHistorySchema.CreateEntity(_userConnection);
			if (currentPartnershipParamHistoryEntity.FetchFromDB(partnershipParamHistoryConditions)) {
				currentPartnershipParamHistoryEntity.SetColumnValue("EndDate", DateTime.UtcNow);
				currentPartnershipParamHistoryEntity.UseAdminRights = false;
				currentPartnershipParamHistoryEntity.CreateUpdate().Execute();
			}
		}

		/// <summary>
		/// Copies column values of source entity to target entity, except primary column.
		/// </summary>
		/// <param name="sourceEntity"><see cref="Entity"/> source.</param>
		/// <param name="targetEntity"><see cref="Entity"/> target.</param>
		public void CopyColumnValues(Entity sourceEntity, Entity targetEntity) {
			var sourceSchemaColumns = sourceEntity.Schema.Columns;
			var primaryColumnName = sourceEntity.Schema.GetPrimaryColumnName();
			foreach (var schemaColumn in sourceSchemaColumns.Where(c => c.Name != primaryColumnName)) {
				if (sourceSchemaColumns.FindByName(schemaColumn.Name) != null) {
					targetEntity.SetColumnValue(schemaColumn, sourceEntity.GetColumnValue(schemaColumn));
				}
			}
		}

		/// <summary>
		/// Adds new history of partnership parameter.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/> of <see cref="PartnershipParameter"/>.</param>
		public void AddNewPartnershipParameterHistory(Entity entity) {
			var partnershipParameterHistorySchema = _userConnection.EntitySchemaManager.GetInstanceByName("PartnerParamHistory");
			SetParameterHistoryEndDate(entity);
			var newPartnershipParamHistoryEntity = partnershipParameterHistorySchema.CreateEntity(_userConnection);
			CopyColumnValues(entity, newPartnershipParamHistoryEntity);
			newPartnershipParamHistoryEntity.SetDefColumnValues();
			newPartnershipParamHistoryEntity.UseAdminRights = false;
			newPartnershipParamHistoryEntity.CreateInsert().Execute();
		}

		#endregion

	}

	#endregion

}

