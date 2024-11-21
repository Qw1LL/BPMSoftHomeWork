define("ReplicaCaptionBuilder", ["ReplicaCaptionBuilderResources", "DynamicContentEnums"],
		function(resources, DynamicContentEnums) {
	/**
	 * @class BPMSoft.configuration.ReplicaCaptionBuilder
	 */
	Ext.define("BPMSoft.configuration.ReplicaCaptionBuilder", {
		alternateClassName: "BPMSoft.ReplicaCaptionBuilder",

		/**
		 * Collection of dynamic content rule captions.
		 * @type {BPMSoft.Collection}
		 */
		filterAttributeNames: null,

		/**
		 * Collection of all dynamic content attributes.
		 * @type {BPMSoft.Collection}
		 */
		allAttributes: null,

		// #region Constructors: Public

		/**
		 * Constructor for BPMSoft.ReplicaCaptionBuilder class.
		 * @public
		 * @param {Array | BPMSoft.Collection} attributes List of attribute models.
		 */
		constructor: function(attributes) {
			this._initAttributes(attributes);
		},

		// #endregion

		// #region Methods: Private

		/**
		 * Inits attribute collections for current template.
		 * @private
		 * @param {Array | BPMSoft.Collection} attributes List of attribute models.
		 */
		_initAttributes: function(attributes) {
			this.filterAttributeNames = new BPMSoft.Collection();
			this.allAttributes = new BPMSoft.Collection();
			if (attributes instanceof Array || attributes instanceof BPMSoft.Collection) {
				BPMSoft.each(attributes, function(attr) {
					this.allAttributes.add(attr.Index, attr);
					if (attr.TypeId === DynamicContentEnums.DCAttributeTypes.FILTER) {
						this.filterAttributeNames.add(attr.Index, attr.Caption);
					}
				}, this);
			}
		},

		/**
		 * Returns info about default content existing at template.
		 * @private
		 * @param {Array} items Replica blocks.
		 * @returns {Boolean} Check result.
		 */
		_checkDefaultContent: function(items) {
			var hasDefaultContent = false;
			BPMSoft.each(items, function(block) {
				if (block.IsDefault) {
					hasDefaultContent = true;
					return false;
				}
			}, this);
			return hasDefaultContent;
		},

		/**
		 * Returns list of unique attribute names for replica.
		 * @private
		 * @param {Array} items Replica blocks.
		 * @returns {Array} List of attribute names.
		 */
		_getUniqueRuleNames: function(items) {
			var ruleNames = [];
			BPMSoft.each(items, function(block) {
				if (!BPMSoft.isEmpty(block.Attributes)) {
					var caption = this.getBlockRuleCaption(block.Attributes);
					if (!Ext.Array.contains(ruleNames, caption)) {
						ruleNames.push(caption);
					}
				}
			}, this);
			return ruleNames;
		},

		// #endregion

		// #region Methods: Protected

		/**
		 * Returns block rule caption by attributes' indexes.
		 * @protected
		 * @param {Array} indexes Block's attribute indexes.
		 * @returns {String} Block rule caption.
		 */
		getBlockRuleCaption: function(indexes) {
			var names = [];
			var separator = ", ";
			BPMSoft.each(indexes, function(index) {
				names.push(this.filterAttributeNames.get(index));
			}, this);
			return names.join(separator);
		},

		// #endregion

		// #region Methods: Public

		/**
		 * Returns caption for current replica.
		 * @public
		 * @param {Array} items Replica blocks.
		 * @returns {String} Replica caption.
		 */
		generateCaption: function(items) {
			if (BPMSoft.isEmpty(items)) {
				return resources.localizableStrings.EmptyReplicaName;
			}
			var hasDefaultContent = this._checkDefaultContent(items);
			var ruleNames = this._getUniqueRuleNames(items);
			if (BPMSoft.isEmpty(ruleNames) && hasDefaultContent) {
				return resources.localizableStrings.DefaultReplicaName;
			}
			if (BPMSoft.isEmpty(ruleNames) && !hasDefaultContent) {
				return resources.localizableStrings.StaticReplicaName;
			}
			return ruleNames.join(resources.localizableStrings.RuleNamesSeparator);
		}

		// #endregion

	});
});
