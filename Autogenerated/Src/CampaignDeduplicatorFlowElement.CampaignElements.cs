namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;

	#region Class: CampaignDeduplicatorFlowElement

	/// <summary>
	/// Executable part of deduplicator element.
	/// </summary>
	public class CampaignDeduplicatorFlowElement : CampaignFlowElement
	{

		#region Fields: Private

		private readonly Guid ContactSchemaUId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");
		private readonly List<Guid> SupportedParticipantStatuses = new List<Guid> {
				CampaignConstants.CampaignParticipantParticipatingStatusId,
				CampaignConstants.CampaignParticipantExitedStatusId,
				CampaignConstants.CampaignParticipantReachedGoalStatusId,
				CampaignConstants.CampaignParticipantInProgressStatusId,
				CampaignConstants.CampaignParticipantErrorStatusId
		};

		#endregion

		#region Properties: Public

		/// <summary>
		/// Column definition to search duplicates by.
		/// </summary>
		public CampaignDeduplicatorRule Rule { get; set; }

		/// <summary>
		/// Defines if articipants with empty data will be suspended.
		/// </summary>
		public bool SuspendParticipantsWithEmptyValues { get; set; }

		#endregion

		#region Methods: Private

		private void ExtendWithEmptyFilter(ref Select select, CampaignDeduplicatorRule rule) {
			var ruleColumn = select.Columns.FindByAlias("Rule");
			select.Where(ruleColumn).IsNull();
			var schema = UserConnection.EntitySchemaManager.FindItemByUId(rule.EntitySchemaUId);
			var column = schema.Instance.GetSchemaColumnByPath(rule.ColumnPath);
			if (column.ValueType == typeof(string)) {
				select.Or(Func.Len(ruleColumn.SourceColumnAlias)).IsEqual(Column.Parameter(0));
			} else if (column.ValueType == typeof(Guid)) {
				select.Or(ruleColumn).IsEqual(Column.Parameter(Guid.Empty));
			}
		}

		private void ExtendWithNotEmptyFilter(ref Select select, CampaignDeduplicatorRule rule) {
			var ruleColumn = select.Columns.FindByAlias("Rule");
			select.Where(ruleColumn).Not().IsNull();
			var schema = UserConnection.EntitySchemaManager.FindItemByUId(rule.EntitySchemaUId);
			var column = schema.Instance.GetSchemaColumnByPath(rule.ColumnPath);
			if (column.ValueType == typeof(string)) {
				select.And(Func.Len(ruleColumn.SourceColumnAlias)).IsGreater(Column.Parameter(0));
			} else if (column.ValueType == typeof(Guid)) {
				select.And(ruleColumn).IsNotEqual(Column.Parameter(Guid.Empty));
			}
		}

		private Select GetRuleSelectQuery(CampaignDeduplicatorRule rule) {
			var schema = UserConnection.EntitySchemaManager.FindItemByUId(rule.EntitySchemaUId);
			if (schema == null) {
				throw new Exception($"Schema with UId {rule.EntitySchemaUId} not found");
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schema.Name) {
				UseAdminRights = true
			};
			esq.Columns.Clear();
			esq.AddColumn("Id");
			var ruleColumn = esq.AddColumn(rule.ColumnPath);
			ruleColumn.SetForcedQueryColumnValueAlias("Rule");
			var select = esq.GetSelectQuery(UserConnection);
			select.SpecifyNoLockHints();
			return select;
		}

		private Select GetJoinedRuleAndParticipantSelect(Select sourceSelect, Select ruleSelect,
				CampaignDeduplicatorRule rule) {
			var select = (rule.EntitySchemaUId == ContactSchemaUId
				? sourceSelect
					.InnerJoin(ruleSelect).As("RuleSelect").On("RuleSelect", "Id").IsEqual("cp", "ContactId")
					.Where("cp", "CampaignId").IsEqual(Column.Parameter(CampaignId))
				: sourceSelect
					.InnerJoin(CampaignParticipantInfoTable).As("cpi")
					.On("cp", "Id").IsEqual("cpi", "CampaignParticipantId")
					.InnerJoin(ruleSelect).As("RuleSelect")
					.On("RuleSelect", "Id").IsEqual("cpi", "LinkedEntityId")
					.Where("cpi", "EntityObjectId").IsEqual(Column.Parameter(rule.EntitySchemaUId))
					.And("cp", "CampaignId").IsEqual(Column.Parameter(CampaignId))) as Select;
			return select;
		}

		private Select GetDuplicatesSelect(CampaignDeduplicatorRule rule) {
			var ruleSelect = GetRuleSelectQuery(rule);
			ExtendWithNotEmptyFilter(ref ruleSelect, rule);
			var sourceSelect = new Select(UserConnection)
					.Column("cp", "Id").As("Id")
					.Column("cp", "CampaignItemId").As("CampaignItemId")
					.Column(new WindowQueryFunction(
						new RowNumberQueryFunction(),
						new QueryColumnExpression("RuleSelect", "Rule"),
						new QueryColumnExpression("cp", "CreatedOn")
					)).As("DuplicatesNumber")
					.From(CampaignParticipantTable).As("cp");
			 var select = GetJoinedRuleAndParticipantSelect(sourceSelect, ruleSelect, rule);
			select.And("cp", "StatusId").In(Column.Parameters(SupportedParticipantStatuses));
			return select;
		}

		private List<Guid> GetDuplicatedParticipants(CampaignDeduplicatorRule rule) {
			var duplicatesSubSelect = GetDuplicatesSelect(rule);
			var duplicatedParticipantsSelect = new Select(UserConnection)
				.Column("sub", "Id")
				.From(duplicatesSubSelect).As("sub")
				.Where("sub", "DuplicatesNumber").IsGreater(Column.Parameter(1))
				.And("sub", "CampaignItemId").IsEqual(Column.Parameter(CampaignItemId)) as Select;
			duplicatedParticipantsSelect.SpecifyNoLockHints();
			return duplicatedParticipantsSelect
				.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id"))
				.ToList();
		}

		private List<Guid> GetParticipantsWithEmptyValues(CampaignDeduplicatorRule rule) {
			var ruleSelect = GetRuleSelectQuery(rule);
			ExtendWithEmptyFilter(ref ruleSelect, rule);
			var sourceSelect = new Select(UserConnection)
					.Column("cp", "Id").As("Id")
					.From(CampaignParticipantTable).As("cp");
			var emptyParticipantsSelect = GetJoinedRuleAndParticipantSelect(sourceSelect, ruleSelect, rule);
			emptyParticipantsSelect
				.And("cp", "CampaignItemId").IsEqual(Column.Parameter(CampaignItemId))
				.And("cp", "StepCompleted").IsEqual(Column.Parameter(false));
			emptyParticipantsSelect.SpecifyNoLockHints();
			return emptyParticipantsSelect
				.ExecuteEnumerable(r => r.GetColumnValue<Guid>("Id"))
				.ToList();
		}

		private void SuspendParticipants(List<Guid> participants) {
			int participantsCount = participants.Count;
			int batchSize = 400;
			int processedCount = 0;
			while (processedCount < participantsCount) {
				var batch = participants.GetRange(processedCount,
					Math.Min(batchSize, participantsCount - processedCount));
				if (batch.Count == 0) {
					break;
				}
				var update = new Update(UserConnection, CampaignParticipantTable)
					.Set("StatusId", Column.Parameter(CampaignConstants.CampaignParticipantSuspendedStatusId))
					.Where("Id").In(Column.Parameters(batch)) as Update;
				update.WithHints(new RowLockHint());
				update.Execute();
				processedCount += batchSize;
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element.
		/// </summary>
		/// <param name="context">The execution context.</param>
		/// <returns>Number of processed participants.</returns>
		protected override int SafeExecute(ProcessExecutingContext context) {
			using (var dbExecutor = UserConnection.EnsureDBConnection(QueryKind.Limited)) {
				dbExecutor.StartTransaction(IsolationLevel.ReadCommitted);
				try {
					var participantsToSuspend = new List<Guid>();
					if (SuspendParticipantsWithEmptyValues) {
						participantsToSuspend = GetParticipantsWithEmptyValues(Rule);
					}
					var duplicates = GetDuplicatedParticipants(Rule);
					participantsToSuspend.AddRangeIfNotExists(duplicates);
					SuspendParticipants(participantsToSuspend);
					var result = base.SafeExecute(context);
					dbExecutor.CommitTransaction();
					return result;
				} catch (Exception) {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		#endregion

	}

	#endregion

}

