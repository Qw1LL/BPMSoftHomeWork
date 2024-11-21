namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using BPMSoft.Core.DB;

	#region Class: DCRecipientsAnalyzationRule

	/// <summary>
	/// Creates resolver strategy instance depending on recipients.
	/// </summary>
	public class DCRecipientsAnalyzationRule : DCStrategyResolverRule
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor to prepare last chain node without a next rule but with default
		/// <see cref="DCSegmentationStrategyBase"/> instance.
		/// </summary>
		/// <param name="context">An instance of <see cref="DCSegmentationContext"/> class.</param>
		/// <param name="defaultStrategy">Will be returned if no strategy specified.</param>
		public DCRecipientsAnalyzationRule(DCSegmentationContext context, DCSegmentationStrategyBase defaultStrategy)
				: base(context, defaultStrategy) {
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// Maximum size of an audience for the DCGroupingStrategy.
		/// </summary>
		private int MaxRecipientsForGroupingStrategy {
			get {
				var value = Core.Configuration.SysSettings.GetValue(Context.UserConnection,
					"MaxRecipientsForGroupingStrategy", 50000);
				return Math.Max(value, 0);
			}
		}

		#endregion

		#region Methods: Private

		private int GetTotalRecipients(Select sourceAudience) {
			var select = new Select(sourceAudience.UserConnection)
				.Count(Column.Asterisk())
				.From(sourceAudience).As("TotalRecipients");
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<int>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Concrete implementation of a rule for a strategy resolving.
		/// </summary>
		/// <returns>An instance of <see cref="DCSegmentationStrategyBase"/> or <see cref="null"/>.</returns>
		public override DCSegmentationStrategyBase GetStrategyApplicableToRule() {
			var recipientsCount = 1;
			if (Context.SourceAudience != null) {
				recipientsCount = GetTotalRecipients(Context.SourceAudience);
			}
			switch (recipientsCount) {
				case int count when count <= 0:
					return default(DCSegmentationStrategyBase);
				case int count when count > 0 && count <= MaxRecipientsForGroupingStrategy:
					return new DCGroupingStrategy(Context);
				default:
					return new DCCombiningStrategy(Context);
			}
		}

		#endregion

	}

	#endregion

}

