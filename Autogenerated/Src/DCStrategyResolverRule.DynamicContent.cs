namespace BPMSoft.Configuration.DynamicContent
{
	using BPMSoft.Common;
	using BPMSoft.Configuration.DynamicContent.Models;

	#region Class: DCStrategyResolverRule

	/// <summary>
	/// Base class for a chain of rules. Is using to specify an instance of a concrete segmentation strategy.
	/// </summary>
	public abstract class DCStrategyResolverRule
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor to prepare last chain node without a next rule but with default
		/// <see cref="DCSegmentationStrategyBase"/> instance.
		/// </summary>
		/// <param name="context">An instance of <see cref="DCSegmentationContext"/> class.</param>
		/// <param name="defaultStrategy">Will be returned if no strategy specified.</param>
		/// /// <exception cref="ArgumentNullOrEmptyException">Thrown when <paramref name="context"/> is null.</exception>
		public DCStrategyResolverRule(DCSegmentationContext context, DCSegmentationStrategyBase defaultStrategy) {
			context.CheckArgumentNull(nameof(context));
			Context = context;
			DefaultStrategy = defaultStrategy;
		}

		/// <summary>
		/// Constructor to prepare medium chain node with the next rule.
		/// </summary>
		/// <param name="context">An instance of <see cref="DCSegmentationContext"/> class.</param>
		/// <param name="nextRule">Will be processed if no strategy specified.</param>
		/// <exception cref="ArgumentNullOrEmptyException">Thrown when <paramref name="context"/> is null.</exception>
		public DCStrategyResolverRule(DCSegmentationContext context, DCStrategyResolverRule nextRule) {
			context.CheckArgumentNull(nameof(context));
			Context = context;
			NextRule = nextRule;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// An instance of <see cref="DCSegmentationContext"/> class.
		/// </summary>
		protected DCSegmentationContext Context { get; }

		/// <summary>
		/// An instance of <see cref="DCStrategyResolverRule"/> that will be processed if no strategy specified.
		/// </summary>
		protected DCStrategyResolverRule NextRule { get; }

		/// <summary>
		/// Current instance of a default strategy.
		/// </summary>
		protected DCSegmentationStrategyBase DefaultStrategy { get; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// A lazy instance of <see cref="DCTemplateRepository{T}"/> class.
		/// </summary>
		private DCTemplateRepository<DCTemplateModel> _templateRepository;
		public DCTemplateRepository<DCTemplateModel> TemplateRepository {
			get => _templateRepository ??
				(_templateRepository = new DCTemplateRepository<DCTemplateModel>(Context.UserConnection));
			set => _templateRepository = value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Concrete implementation of a rule for a strategy resolving.
		/// </summary>
		/// <returns>An instance of <see cref="DCSegmentationStrategyBase"/> or <see cref="null"/>.</returns>
		public abstract DCSegmentationStrategyBase GetStrategyApplicableToRule();

		/// <summary>
		/// Defines segmentation strategy according to a specific rule.
		/// </summary>
		/// <returns>An instance of <see cref="DCSegmentationStrategyBase"/>.</returns>
		public DCSegmentationStrategyBase SpecifySegmentationStrategy() {
			var strategy = GetStrategyApplicableToRule();
			if (strategy == null) {
				if (NextRule == null) {
					return DefaultStrategy;
				}
				return NextRule.SpecifySegmentationStrategy();
			}
			return strategy;
		}

		#endregion

	}

	#endregion

}

