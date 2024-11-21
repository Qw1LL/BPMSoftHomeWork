define("OpportunityTimelineItemViewModel", ["BaseTimelineItemViewModel", "OpportunityTimelineItemViewModelResources"],
	function() {
		/**
		 * @class BPMSoft.configuration.OpportunityTimelineItemViewModel
		 * Opportunity timeline item view model class.
		 */
		Ext.define("BPMSoft.configuration.OpportunityTimelineItemViewModel", {
			alternateClassName: "BPMSoft.OpportunityTimelineItemViewModel",
			extend: "BPMSoft.BaseTimelineItemViewModel",

			// region Methods: Protected

			/**
			 * Returns Client caption.
			 * @protected
			 * @returns {String} Client caption.
			 */
			getClientCaption: function() {
				return this.$AccountName || this.$ContactName;
			},

			/**
			 * Initialize tile caption.
			 * @protected
			 */
			initTileCaption: function() {
				var caption, template = "";
				if (Ext.isEmpty(this.$TypeName)) {
					template = this.get("Resources.Strings.CaptionTemplateWithoutType");
					caption = Ext.String.format(template, this.$Caption, this.getClientCaption());
				} else {
					template = this.get("Resources.Strings.CaptionTemplate");
					caption = Ext.String.format(template, this.$Caption, this.getClientCaption(), this.$TypeName);
				}
				this.$Caption = caption;
			},

			/**
			 * @inheritdoc BPMSoft.BaseTimelineItemViewModel#initDefaultValues
			 * @override
			 */
			initDefaultValues: function() {
				this.callParent(arguments);
				this.initTileCaption();
			}

			// endregion

		});
	});
