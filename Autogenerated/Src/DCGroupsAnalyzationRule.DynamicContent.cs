namespace BPMSoft.Configuration.DynamicContent
{
	using BPMSoft.Common;

	#region Class: DCGroupsAnalyzationRule

	/// <summary>
	/// Strategy resolver rule that analyses template groups.
	/// </summary>
	public class DCGroupsAnalyzationRule : DCStrategyResolverRule
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor to prepare medium chain node with the next rule.
		/// </summary>
		/// <param name="context">An instance of <see cref="DCSegmentationContext"/> class.</param>
		/// <param name="nextRule">Will be processed if no strategy specified.</param>
		public DCGroupsAnalyzationRule(DCSegmentationContext context, DCStrategyResolverRule nextRule)
				: base(context, nextRule) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Uses <see cref="DCCombiningStrategy"/> if there are no dynamic blocks.
		/// </summary>
		/// <returns>An instance of <see cref="DCCombiningStrategy"/> or <see cref="null"/>.</returns>
		public override DCSegmentationStrategyBase GetStrategyApplicableToRule() {
			if (Context.Template.Groups.IsNullOrEmpty()) {
				return new DCCombiningStrategy(Context);
			}
			return null;
		}

		#endregion

	}

	#endregion

}

