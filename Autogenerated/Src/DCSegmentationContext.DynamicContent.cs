namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using Common;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: DCSegmentationContext

	/// <summary>
	/// Represents the context for instances of <see cref="DCSegmentationStrategyBase"/>.
	/// </summary>
	public class DCSegmentationContext
	{

		#region Constructors: Public

		/// <summary>
		/// Simple constructor for custom initialization.
		/// </summary>
		/// <param name="userConnection">An instance of <see cref="UserConnection"/>.</param>
		public DCSegmentationContext(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		/// <summary>
		/// Creates an instance of context, prepared for a signle entity segmentation.
		/// </summary>
		/// <param name="template">An instance of <see cref="DCTemplate"/>. Reference for groups and blocks.</param>
		/// <param name="userConnection">Current instance of <see cref="UserConnection"/>.</param>
		/// <param name="entityId">Identifier of a sigle entity, that have to be segmented.</param>
		public DCSegmentationContext(DCTemplateModel template, UserConnection userConnection, Guid entityId) {
			Template = template;
			UserConnection = userConnection;
			SourceEntityId = entityId;
			SourceAudience = null;
		}

		/// <summary>
		/// Creates an instance of context, prepared for an audience segmentation.
		/// </summary>
		/// <param name="template">An instance of <see cref="DCTemplate"/>. Reference for groups and blocks.</param>
		/// <param name="sourceAudience">Query with a list of identifiers, that have to be segmented.</param>
		/// <param name="sourceAlias">An alias of a source table/view.</param>
		/// <param name="sourceColumn">The name of an ID source column.</param>
		/// <param name="sourceColumnForFilter">The name of a source column to apply filter by.</param>
		/// <param name="targetTable">The name of a target table to store a result of segmentation.</param>
		/// <param name="entityIdTargetColumn">The name of a target column for entity ID.</param>
		/// <param name="replicaIdTargetColumn">The name of a target column for replica ID.</param>
		/// <param name="recordIdTargetColumn">The name of a target column for the related record ID.</param>
		public DCSegmentationContext(DCTemplateModel template, Select sourceAudience, string sourceAlias,
				string sourceColumn, string sourceColumnForFilter, string targetTable, string entityIdTargetColumn,
				string replicaIdTargetColumn, string recordIdTargetColumn) {
			Template = template;
			SourceAudience = sourceAudience;
			SourceAlias = sourceAlias;
			UserConnection = sourceAudience.UserConnection;
			EntityIdSourceColumn = sourceColumn;
			SourceColumnForFilter = sourceColumnForFilter;
			TargetTable = targetTable;
			EntityIdTargetColumn = entityIdTargetColumn;
			ReplicaIdTargetColumn = replicaIdTargetColumn;
			RecordIdTargetColumn = recordIdTargetColumn;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Source audience query. Select should contain an ID column with a source alias.
		/// </summary>
		public Select SourceAudience { get; set; }

		/// <summary>
		/// An alias of a source table/view.
		/// </summary>
		public string SourceAlias { get; set; }

		/// <summary>
		/// An alias of an internal SubSelect that contains <see cref="SourceColumnForFilter"/>.
		/// </summary>
		public string SourceAliasForFilter => SourceAlias.ConcatIfNotEmpty("F", string.Empty);

		/// <summary>
		/// Source entity ID.
		/// </summary>
		public Guid SourceEntityId { get; set; }

		/// <summary>
		/// An alias of a source table for an ID column.
		/// </summary>
		public string EntityIdSourceAlias { get; set; }

		/// <summary>
		/// Name of ID column from a source table.
		/// </summary>
		public string EntityIdSourceColumn { get; set; }

		/// <summary>
		/// The name of a source column to apply filter by.
		/// </summary>
		public string SourceColumnForFilter { get; set; }

		/// <summary>
		/// A name of a target table.
		/// </summary>
		public string TargetTable { get; set; }

		/// <summary>
		/// Name of entity ID column of a target table.
		/// </summary>
		public string EntityIdTargetColumn { get; set; }

		/// <summary>
		/// Name of replica ID column of a target table.
		/// </summary>
		public string ReplicaIdTargetColumn { get; set; }

		/// <summary>
		/// Name of related record ID column at the target table.
		/// </summary>
		public string RecordIdTargetColumn { get; set; }

		/// <summary>
		/// An instance of the <see cref="DCTemplateModel"/>.
		/// </summary>
		public DCTemplateModel Template { get; set; }

		/// <summary>
		/// An instance of the <see cref="Core.UserConnection"/>.
		/// </summary>
		public UserConnection UserConnection { get; set; }

		public int BatchSize { get; set; }

		#endregion

		#region Methods: Private

		private void ValidateTemplateWithDependencies() {
			Template.CheckDependencyNull("Template");
			Template.Blocks.CheckDependencyNull("Template.Blocks");
			Template.Groups.CheckDependencyNull("Template.Groups");
			Template.Attributes.CheckDependencyNull("Template.Attributes");
			Template.Replicas.CheckDependencyNull("Template.Replicas");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates properties needed for audience segmentation.
		/// </summary>
		/// <exception cref="ArgumentNullOrEmptyException">Throws when one of parameters is null or empty.</exception>
		public void ValidateForAudienceSegmentation() {
			ValidateTemplateWithDependencies();
			SourceAudience.CheckArgumentNull("SourceAudience");
			UserConnection.CheckArgumentNull("UserConnection");
			SourceAlias.CheckArgumentNull("SourceAlias");
			EntityIdSourceColumn.CheckArgumentNull("EntityIdSourceColumn");
			SourceColumnForFilter.CheckArgumentNull("SourceColumnForFilter");
			TargetTable.CheckArgumentNull("TargetTable");
			EntityIdTargetColumn.CheckArgumentNull("EntityIdTargetColumn");
			ReplicaIdTargetColumn.CheckArgumentNull("ReplicaIdTargetColumn");
			RecordIdTargetColumn.CheckArgumentNull("RecordIdTargetColumn");
		}

		/// <summary>
		/// Validates properties needed for single entity segmentation.
		/// </summary>
		/// <exception cref="ArgumentNullOrEmptyException">Throws when one of parameters is null or empty.</exception>
		public void ValidateForSingleEntitySegmentation() {
			ValidateTemplateWithDependencies();
			UserConnection.CheckArgumentNull("UserConnection");
			SourceEntityId.CheckArgumentNull("SourceEntityId");
		}

		#endregion

	}

	#endregion

}

