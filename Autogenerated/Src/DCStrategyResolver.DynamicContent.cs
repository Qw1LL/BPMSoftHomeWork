namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using global::Common.Logging;

	#region Class: DCStrategyResolver

	/// <summary>
	/// Represents base class for all resolvers. The main responsibility is to define and to call an instance of
	/// <see cref="DCSegmentationStrategyBase"/>.
	/// </summary>
	public class DCStrategyResolver
	{

		#region Constructors: Public

		public DCStrategyResolver(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private ILog Logger => LogManager.GetLogger(nameof(DCStrategyResolver));

		private DCResolverTemplateValidator _templateValidator => new DCResolverTemplateValidator();

		#endregion

		#region Properties: Public

		/// <summary>
		/// 
		/// </summary>
		private DCTemplateRepository<DCTemplateModel> _templateRepository;
		public DCTemplateRepository<DCTemplateModel> TemplateRepository {
			get => _templateRepository ??
				(_templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection));
			set => _templateRepository = value;
		}

		/// <summary>
		/// Current instance of the <see cref="Core.UserConnection"/> class.
		/// </summary>
		public UserConnection UserConnection { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines an instance of the <see cref="DCSegmentationStrategyBase"/>.
		/// </summary>
		/// <param name="context">A set of common parameters and attributes.</param>
		public virtual DCSegmentationStrategyBase GetStrategy(DCSegmentationContext context) {
			context.CheckArgumentNull("context");
			var defaultStrategy = new DCGroupingStrategy(context);
			var recipientsAnalyzation = new DCRecipientsAnalyzationRule(context, defaultStrategy);
			var groupsAnalyzation = new DCGroupsAnalyzationRule(context, recipientsAnalyzation);
			var enabledStrategiesAnalyzation = new DCEnabledStrategiesAnalyzationRule(context, groupsAnalyzation);
			return enabledStrategiesAnalyzation.SpecifySegmentationStrategy();
		}

		/// <summary>
		/// Retrieves and calls a strategy for a single entity segmentation.
		/// </summary>
		/// <param name="template">An instance of <see cref="DCTemplateModel"/>. Reference for groups and blocks.</param>
		/// <param name="entityId">Identifier of a sigle entity, that have to be segmented.</param>
		/// <returns>Unique identifier of the template replica.</returns>
		public virtual Guid SegmentSingleEntity(DCTemplateModel template, Guid entityId) {
			var context = new DCSegmentationContext(template, UserConnection, entityId);
			context.ValidateForSingleEntitySegmentation();
			_templateValidator.Validate(context.Template, UserConnection);
			var strategy = GetStrategy(context);
			Logger.Info($"strategy={strategy.GetType().Name} entityId={entityId} recordId={template.RecordId}");
			return strategy.SegmentSingleEntity();
		}

		/// <summary>
		/// Retrieves and calls a strategy for an audience segmentation.
		/// </summary>
		/// <param name="context">Instance of <see cref="DCSegmentationContext"/></param>
		public virtual int SegmentAudience(DCSegmentationContext context) {
			context.ValidateForAudienceSegmentation();
			_templateValidator.Validate(context.Template, UserConnection);
			var strategy = GetStrategy(context);
			Logger.Info($"strategy={strategy.GetType().Name} recordId={context.Template.RecordId} " +
				$"targetTable={context.TargetTable}");
			try {
				return strategy.SegmentAudience();
			} finally {
				strategy.ClearOpData();
			}
		}

		#endregion

	}

	#endregion

}

