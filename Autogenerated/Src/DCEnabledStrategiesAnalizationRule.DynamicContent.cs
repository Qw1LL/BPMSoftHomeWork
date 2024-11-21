namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using BPMSoft.Common;

	#region Class: DCEnabledStrategiesAnalyzationRule

	/// <summary>
	/// Strategy resolver rule that analyses the state of DCEnabledStrategies system setting.
	/// </summary>
	public class DCEnabledStrategiesAnalyzationRule : DCStrategyResolverRule
	{

		#region Enums: Protected

		/// <summary>
		/// Enabled segmentation strategies.
		/// </summary>
		[Flags]
		protected enum DCEnabledStrategies {
			None = 0,
			Grouping = 1,
			Combining = 2
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor to prepare last chain node without a next rule but with default
		/// <see cref="DCSegmentationStrategyBase"/> instance.
		/// </summary>
		/// <param name="context">An instance of <see cref="DCSegmentationContext"/> class.</param>
		/// <param name="defaultStrategy">Will be returned if no strategy specified.</param>
		public DCEnabledStrategiesAnalyzationRule(DCSegmentationContext context,
				DCSegmentationStrategyBase defaultStrategy) : base(context, defaultStrategy) {
		}

		/// <summary>
		/// Constructor to prepare medium chain node with the next rule.
		/// </summary>
		/// <param name="context">An instance of <see cref="DCSegmentationContext"/> class.</param>
		/// <param name="nextRule">Will be processed if no strategy specified.</param>
		public DCEnabledStrategiesAnalyzationRule(DCSegmentationContext context, DCStrategyResolverRule nextRule)
				: base(context, nextRule) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Includes flags of default supported segmentation strategies.
		/// </summary>
		protected DCEnabledStrategies DefaultEnabledStrategies =>
			DCEnabledStrategies.Grouping | DCEnabledStrategies.Combining;

		#endregion

		#region Methods: Private

		private DCEnabledStrategies GetEnabledStrategies() {
			var enabledStrategiesValue = Core.Configuration.SysSettings.GetValue(Context.UserConnection,
				"DCEnabledStrategies", (int)DefaultEnabledStrategies);
			return (DCEnabledStrategies)enabledStrategiesValue;
		}

		private string GetLczStringValue(string lczName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(Context.UserConnection.Workspace.ResourceStorage,
				nameof(DCEnabledStrategiesAnalyzationRule), localizableStringName);
			string value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Checks which segmentation strategies are enabled.
		/// When the only one strategy is specified returns it.
		/// When no enabled strategies - throws the exception.
		/// Otherwise calls next analization rules.
		/// </summary>
		/// <returns>An instance of <see cref="DCSegmentationStrategyBase"/> or <see cref="null"/>.</returns>
		/// <exception cref="Exception">Throws when:
		/// No segmentation strategy is enabled.
		/// There is unsupported code for enabled strategies.
		public override DCSegmentationStrategyBase GetStrategyApplicableToRule() {
			var enabledStrategies = GetEnabledStrategies();
			var message = GetLczStringValue("NoEnabledStrategiesErrorMessage");
			switch (enabledStrategies) {
				case DCEnabledStrategies.None:
					throw new Exception(message);
				case DCEnabledStrategies.Grouping:
					return new DCGroupingStrategy(Context);
				case DCEnabledStrategies.Combining:
					return new DCCombiningStrategy(Context);
				case DCEnabledStrategies.Grouping | DCEnabledStrategies.Combining:
					return null;
				default:
					throw new Exception(message);
			}
		}

		#endregion

	}

	#endregion

}

