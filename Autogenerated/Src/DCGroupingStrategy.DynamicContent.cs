namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core.DB;

	#region Class: DCGroupingStrategy

	/// <summary>
	/// Represents grouping strategy for an audience segmentation.
	/// It is optimized to be used for medium audience size with less than 50k recipients.
	/// </summary>
	public class DCGroupingStrategy : DCSegmentationStrategyBase
	{

		#region Structure: DCBlockInfoModel

		/// <summary>
		/// Represents information about the blocks with the same attribute.
		/// </summary>
		private struct DCBlockInfoModel {

			#region Constructors: Public

			/// <summary>
			/// Creates block information model instance.
			/// </summary>
			/// <param name="attributeIndex">Unique index of filter attribute of the block.</param>
			/// <param name="priority">Priority of the block inside the template group.</param>
			/// <param name="blockIndexSum">Sum of the indexes of template blocks.</param>
			/// <param name="groupIndexSum">Sum of the indexes of template groups.</param>
			public DCBlockInfoModel(int attributeIndex, int priority, int blockIndexSum, int groupIndexSum) {
				AttributeIndex = attributeIndex;
				Priority = priority;
				BlockIndexSum = blockIndexSum;
				GroupIndexSum = groupIndexSum;
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// Unique index of filter attribute of the block.
			/// </summary>
			public int AttributeIndex { get; set; }

			/// <summary>
			/// Priority of the block inside the template group.
			/// </summary>
			public int Priority { get; set; }

			/// <summary>
			/// Sum of the indexes of template blocks.
			/// </summary>
			public int BlockIndexSum { get; set; }

			/// <summary>
			/// Sum of the indexes of template groups.
			/// </summary>
			public int GroupIndexSum { get; set; }

			#endregion

		}

		#endregion

		#region Structure: DCBlockInGroupModel

		/// <summary>
		/// Represents block sequence in group model.
		/// </summary>
		private struct DCBlockSequenceModel {

			#region Constructors: Public

			/// <summary>
			/// Creates block model instance for group of similar blocks.
			/// </summary>
			/// <param name="index">Unique index of block within the template.</param>
			/// <param name="groupIndex">Index of block parent group.</param>
			/// <param name="attributeIndex">Unique index of block filter attribute.</param>
			/// <param name="priority">Priority of block inside the group.</param>
			/// <param name="prevAttributeIndex">Unique index of filter attribute of the previous block.</param>
			/// <param name="prevSequenceIndex">Unique index of the sequence of the previous block.</param>
			public DCBlockSequenceModel(int index, int groupIndex, int attributeIndex, int priority,
					int prevAttributeIndex, int prevSequenceIndex) {
				Index = index;
				GroupIndex = groupIndex;
				AttributeIndex = attributeIndex;
				Priority = priority;
				SequenceIndex = 0;
				PrevAttributeIndex = prevAttributeIndex;
				PrevSequenceIndex = prevSequenceIndex;
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// Unique index within the template (power of 2 - for unique bitwise mask in replica).
			/// </summary>
			public int Index { get; set; }

			/// <summary>
			/// Index of parent group.
			/// </summary>
			public int GroupIndex { get; set; }

			/// <summary>
			/// Unique index of block filter attribute.
			/// </summary>
			public int AttributeIndex { get; set; }

			/// <summary>
			/// Unique index of block filter attribute from previous block in group.
			/// </summary>
			public int PrevAttributeIndex { get; set; }

			/// <summary>
			/// Unique index of group of the similar blocks.
			/// </summary>
			public int SequenceIndex { get; set; }

			/// <summary>
			/// Unique index of group of the similar blocks from previous block in group.
			/// </summary>
			public int PrevSequenceIndex { get; set; }

			/// <summary>
			/// Weight of block within group for replicas' sendind prority.
			/// </summary>
			public int Priority { get; set; }

			#endregion

		}

		#endregion

		#region Fields: Private

		private readonly Guid _sessionId = Guid.NewGuid();

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates resolver strategy instance with a predefined context.
		/// </summary>
		/// <param name="segmentationContext">A set of predefined parameters, which are using by strategies.</param>
		/// <exception cref="ArgumentNullOrEmptyException">When <paramref name="segmentationContext"/> is null.
		/// </exception>
		public DCGroupingStrategy(DCSegmentationContext segmentationContext) : base(segmentationContext) {
			segmentationContext.CheckArgumentNull(nameof(segmentationContext));
		}

		#endregion

		#region Methods: Private

		private int GetTotalRecipients() {
			var select = new Select(SegmentationContext.UserConnection)
				.Count(Column.Asterisk())
				.From(SegmentationContext.SourceAudience).As("TotalRecipients");
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<int>();
		}

		private Select GetFilterFromBlock(DCTemplateBlockModel block) =>
			SegmentationContext.Template.Attributes
				.FirstOrDefault(x => x.IsFilter() && (block.AttributeIndexes?.Contains(x.Index) ?? false))
				.ToFilter(SegmentationContext.UserConnection);

		private void ExtendAudienceSelectWithFilter(ref Select extendedAudienceSelect, Select filter) =>
			extendedAudienceSelect = (extendedAudienceSelect.HasCondition
				? extendedAudienceSelect
					.And(SegmentationContext.SourceAliasForFilter, SegmentationContext.SourceColumnForFilter)
					.In(filter)
				: extendedAudienceSelect
					.Where(SegmentationContext.SourceAliasForFilter, SegmentationContext.SourceColumnForFilter)
					.In(filter)) as Select;

		private void ExtendAudienceSelectWithExceptCondition(ref Select extendedAudienceSelect, int groupIndex) =>
			extendedAudienceSelect = (extendedAudienceSelect.HasCondition
				? extendedAudienceSelect
					.And("dc", "GroupIndex").IsNull()
					.LeftOuterJoin("DCRecipientOp").As("dc")
					.On("dc", "EntityId")
						.IsEqual(SegmentationContext.SourceAliasForFilter, SegmentationContext.EntityIdSourceColumn)
					.And(Column.SourceColumn("dc", "GroupIndex") & Column.Parameter(groupIndex))
						.IsEqual(Column.Parameter(groupIndex))
				: extendedAudienceSelect
					.LeftOuterJoin("DCRecipientOp").As("dc")
					.On("dc", "EntityId")
						.IsEqual(SegmentationContext.SourceAliasForFilter, SegmentationContext.EntityIdSourceColumn)
					.And(Column.SourceColumn("dc", "GroupIndex") & Column.Parameter(groupIndex))
						.IsEqual(Column.Parameter(groupIndex))
					.Where("dc", "GroupIndex").IsNull()) as Select;

		private InsertSelect BuildInsertSelect(DCTemplateBlockModel block, int groupIndex, Guid sessionId, bool isFirstSegment) {
			var withEntityColumnSelect = new Select(SegmentationContext.UserConnection)
				.Column(SegmentationContext.SourceAliasForFilter, SegmentationContext.EntityIdSourceColumn)
				.From(SegmentationContext.SourceAudience).As(SegmentationContext.SourceAliasForFilter);
			var extendedAudienceSelect = new Select(withEntityColumnSelect)
				.Column(Column.Parameter(sessionId)).As("SessionId")
				.Column(Column.Parameter(block.Index)).As("BlockIndex")
				.Column(Column.Parameter(groupIndex)).As("GroupIndex");
			if (!block.IsDefault) {
				var filter = GetFilterFromBlock(block);
				ExtendAudienceSelectWithFilter(ref extendedAudienceSelect, filter);
			}
			if (!isFirstSegment) {
				ExtendAudienceSelectWithExceptCondition(ref extendedAudienceSelect, groupIndex);
			}
			extendedAudienceSelect.SpecifyNoLockHints();
			var simpleInsert = new InsertSelect(SegmentationContext.UserConnection)
				.Into("DCRecipientOp")
				.Set("EntityId", "SessionId", "BlockIndex", "GroupIndex")
				.FromSelect(extendedAudienceSelect);
			return simpleInsert;
		}

		private InsertSelect BuildInsertSelectToResultTable(Guid sessionId) {
			var recipientsWithMaskSelect = new Select(SegmentationContext.UserConnection)
				.Column("EntityId").As("RecipientId")
				.Column(Func.Sum("BlockIndex")).As("Mask")
				.From("DCRecipientOp")
				.Where("SessionId").IsEqual(Column.Parameter(sessionId))
				.GroupBy("EntityId");
			var recipientsWithReplicasSelect = new Select(SegmentationContext.UserConnection)
				.Top(SegmentationContext.BatchSize)
				.Column("op", "RecipientId").As("RecipientId")
				.Column("dcr", "Id").As("DCReplicaId")
				.Column(Column.Parameter(SegmentationContext.Template.RecordId))
					.As(SegmentationContext.RecordIdTargetColumn)
				.From("DCReplica").As("dcr").InnerJoin(recipientsWithMaskSelect).As("op")
				.On("dcr", "Mask").IsEqual("op", "Mask")
				.Where("dcr", "DCTemplateId").IsEqual(Column.Parameter(SegmentationContext.Template.Id)) as Select;
			recipientsWithReplicasSelect.SpecifyNoLockHints();
			var insertSelect = new InsertSelect(SegmentationContext.UserConnection)
				.Into(SegmentationContext.TargetTable)
				.Set(SegmentationContext.EntityIdTargetColumn, SegmentationContext.ReplicaIdTargetColumn,
					SegmentationContext.RecordIdTargetColumn)
				.FromSelect(recipientsWithReplicasSelect);
			return insertSelect;
		}

		private Dictionary<int, DCBlockInfoModel> GetBlocksInfo() {
			var blockSequences = new List<DCBlockSequenceModel>();
			int sequenceIndex = 0;
			foreach (var group in SegmentationContext.Template.Groups) {
				IEnumerable<DCTemplateBlockModel> groupBlocks = SegmentationContext.Template.Blocks
					.Where(x => x.GroupIndex == group.Index).OrderBy(x => x.Priority);
				var prevBlock = new DCBlockSequenceModel();
				int priority = 1;
				foreach (var block in groupBlocks) {
					if (block.IsDefault || block.AttributeIndexes.Length == 0) {
						continue;
					}
					int groupIndex = (int)Math.Pow(2, block.GroupIndex);
					int attributeIndex = block.AttributeIndexes[0];
					var currentBlock = new DCBlockSequenceModel(block.Index, groupIndex, attributeIndex, priority,
						prevBlock.AttributeIndex, prevBlock.SequenceIndex);
					var similarBlock = blockSequences.FirstOrDefault(x => x.AttributeIndex == attributeIndex
						&& x.Priority == priority && x.PrevAttributeIndex == prevBlock.AttributeIndex
						&& x.PrevSequenceIndex == prevBlock.SequenceIndex);
					currentBlock.SequenceIndex = similarBlock.Equals(default(DCBlockSequenceModel))
						? sequenceIndex
						: similarBlock.SequenceIndex;
					blockSequences.Add(currentBlock);
					priority++;
					prevBlock = currentBlock;
				}
				sequenceIndex++;
			}
			return blockSequences.GroupBy(x => new { x.SequenceIndex, x.AttributeIndex })
				   .ToDictionary(x => x.Min(b => b.Index),
						x => new DCBlockInfoModel(x.Key.AttributeIndex, x.Min(b => b.Priority),
							x.Sum(b => b.Index), x.Sum(b => b.GroupIndex)));
		}

		private int PreprocessingAudienseSegments(Guid sessionId, int totalRecipients) {
			var totalAffectedRecords = 0;
			var isFirstSegment = true;
			var blocksInfoDict = GetBlocksInfo();
			foreach (var group in SegmentationContext.Template.Groups) {
				var affectedRecords = 0;
				foreach (var block in SegmentationContext.Template.Blocks.OrderBy(x => x.Priority)) {
					if (affectedRecords >= totalRecipients) {
						break;
					}
					if (block.GroupIndex != group.Index
							|| (!block.IsDefault && !blocksInfoDict.ContainsKey(block.Index))) {
						continue;
					}
					int groupIndex = (int)Math.Pow(2, block.GroupIndex);
					if (!block.IsDefault) {
						var blockInfo = blocksInfoDict[block.Index];
						block.Index = blockInfo.BlockIndexSum;
						groupIndex = blockInfo.GroupIndexSum;
					}
					var insertSelect = BuildInsertSelect(block, groupIndex, sessionId, isFirstSegment);
					affectedRecords += insertSelect.Execute();
					isFirstSegment = false;
				}
				totalAffectedRecords += affectedRecords;
			}
			return totalAffectedRecords;
		}

		private int ProcessAudienceSegmentation(Guid sessionId, int totalRecipients) {
			var totalAffectedRecords = PreprocessingAudienseSegments(sessionId, totalRecipients);
			var moveInsertSelect = BuildInsertSelectToResultTable(sessionId);
			return moveInsertSelect.Execute();
		}

		private void ExtendFilterWithEntityIdFilter(ref Select filter, Guid entityId) {
			filter = (filter.HasCondition
				? filter.And(filter.Columns.First()).IsEqual(Column.Parameter(entityId))
				: filter.Where(filter.Columns.First()).IsEqual(Column.Parameter(entityId))) as Select;
			filter.SpecifyNoLockHints();
		}

		private Guid GetSingleReplicaId() {
			var template = SegmentationContext.Template;
			var replicaMask = 0;
			foreach (var group in template.Groups) {
				foreach (var block in template.Blocks.OrderBy(x => x.Priority)) {
					if (block.GroupIndex != group.Index) {
						continue;
					}
					if (block.IsDefault) {
						replicaMask += block.Index;
						break;
					}
					var filter = template.Attributes
						.FirstOrDefault(x => x.IsFilter() && (block.AttributeIndexes?.Contains(x.Index) ?? false))
						?.ToFilter(SegmentationContext.UserConnection);
					ExtendFilterWithEntityIdFilter(ref filter, SegmentationContext.SourceEntityId);
					var entityIdFromDb = filter.ExecuteScalar<Guid>();
					if (entityIdFromDb.IsNotEmpty()) {
						replicaMask += block.Index;
						break;
					}
				}
			}
			var replica = template.Replicas.FirstOrDefault(x => x.Mask == replicaMask);
			return replica?.Id ?? Guid.Empty;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines which replica should be sent to recipient.
		/// </summary>
		public override int SegmentAudience() {
			var recipientsCount = GetTotalRecipients();
			if (recipientsCount == 0) {
				return 0;
			}
			return ProcessAudienceSegmentation(_sessionId, recipientsCount);
		}

		/// <summary>
		/// Defines which replica should be sent to recipient.
		/// </summary>
		/// <returns>Unique identifier of <see cref="DCReplica"/> entity or <see cref="Guid.Empty"/>.</returns>
		public override Guid SegmentSingleEntity() {
			if (SegmentationContext.SourceEntityId.IsEmpty()) {
				return Guid.Empty;
			}
			return GetSingleReplicaId();
		}

		/// <summary>
		/// Should remove all operational data.
		/// </summary>
		public override void ClearOpData() =>
			new Delete(SegmentationContext.UserConnection)
				.From("DCRecipientOp")
				.Where("SessionId").IsEqual(Column.Parameter(_sessionId))
				.Execute();

		#endregion

	}

	#endregion

}

