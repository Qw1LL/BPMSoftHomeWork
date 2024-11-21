define("ViewModelSchemaDesignerSchema", ["TimelineManager"], function() {
	return {
		attributes: {},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				var parentInitMethod = this.getParentMethod();
				this.BPMSoft.TimelineManager.initialize(function() {
					parentInitMethod.call(this, callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseModulePageV2#hasTimelineConfig
			 * @override
			 */
			hasTimelineConfig: function() {
				var designedPageSchema = this.get("Schema");
				var timelinePageConfig =
					this.BPMSoft.TimelineManager.getTimelinePageConfig(designedPageSchema.schemaName);
				return !this.isEmpty(timelinePageConfig);
			}

			// endregion

		}
	};
});
