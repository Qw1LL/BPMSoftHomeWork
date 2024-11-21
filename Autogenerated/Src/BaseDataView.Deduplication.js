define("BaseDataView", ["RightUtilities", "DuplicatesSearchUtilitiesV2", "DuplicatesMergeHelper", "SectionMergeHelper"],
	function(RightUtilities) {
		return {
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			mixins: {
				DuplicatesSearchUtilities: "BPMSoft.DuplicatesSearchUtilitiesV2",
				DuplicatesMergeHelper: "BPMSoft.DuplicatesMergeHelper",
				SectionMergeHelper: "BPMSoft.SectionMergeHelper"
			},
			messages: {
				/**
				 * @message Merge
				 * Merge records.
				 * @param {Object} Merge config.
				 */
				"Merge": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * True if user has search duplicates operation permissions.
				 */
				CanSearchDuplicatesOperation: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if enabled old deduplication feature.
				 */
				DeduplicationEnabled: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if enabled new bulk deduplication feature.
				 */
				BulkDeduplicationEnabled: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if 'search duplicates' button visible.
				 */
				canSearchDuplicates: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * True if user has merge duplicates operation permissions.
				 */
				CanMergeDuplicates: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.checkCanSearchDuplicates();
					RightUtilities.checkCanExecuteOperation({
						operation: "CanMergeDuplicates"
					}, function(canExecute) {
						this.$CanMergeDuplicates = canExecute;
					}.bind(this), this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.SectionMergeHelper#isMergeVisible
				 * @overridden
				 */
				isMergeVisible: function() {
					const canMergeDuplicates = Boolean(this.$CanMergeDuplicates);
					const baseIsMergeVisible = this.mixins.SectionMergeHelper.isMergeVisible.apply(this, arguments);
					return canMergeDuplicates && baseIsMergeVisible;
				},

				/**
				 * Checks can search duplicates operation.
				 * Sets 'canSearchDuplicates' attribute to viewmodel.
				 */
				checkCanSearchDuplicates: function() {
					this.fetchCanDeduplicationOperationPermission()
						.then(this.setCanSearchDuplicatesAttributes.bind(this));
				},

				/**
				 * Sets dependents attributes to viewmodel.
				 * @protected
				 */
				setCanSearchDuplicatesAttributes: function(canSearchDuplicatesOperation) {
					this.set("CanSearchDuplicatesOperation", canSearchDuplicatesOperation);
					this.set("BulkDeduplicationEnabled", this.getIsBulkDeduplicationEnabled());
					const isEnabled = canSearchDuplicatesOperation && this.$BulkDeduplicationEnabled;
					this.set("canSearchDuplicates", isEnabled);
				},

				/**
				 * @inheritdoc
				 * @overridden
				 */
				openDuplicatesModule: function() {
					this.mixins.DuplicatesSearchUtilities.openDuplicatesModule.call(this, this.entitySchemaName);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#getSectionActions
				 * @overriden
				 */
				getSectionActions: function() {
					let actionMenuItems = this.callParent(arguments);
					if (this.getIsDeduplicationEnable()) {
						this.addDuplicatesActionButton(actionMenuItems);
						this.addMergeActionButton(actionMenuItems);
					}
					return actionMenuItems;
				},

				/**
				 * Added duplicate action button to menu.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} actionMenuItems menu items.
				 */
				addDuplicatesActionButton: function(actionMenuItems) {
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Click": {"bindTo": "openDuplicatesModule"},
						"Caption": {"bindTo": "addDuplicatesActionButtonCaption"},
						"Visible": {"bindTo": "canSearchDuplicates"},
						"ImageConfig": this.get("Resources.Images.ShowDuplicatesBtnImage")
					}));
				},

				/**
				 * Gets caption of the action duplicate button.
				 * @protected
				 * @return {String} caption of the action duplicate button.
				 */
				addDuplicatesActionButtonCaption: function() {
					const moduleCaption = this.getModuleCaption() || BPMSoft.emptyString;
					const duplicatesActionCaptionPattern = this.get("Resources.Strings.DuplicatesActionCaptionPattern");
					const pattern = duplicatesActionCaptionPattern || BPMSoft.emptyString;
					return Ext.String.format(pattern, moduleCaption);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#subscribeSandboxEvents
				 * @overriden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					const moduleId = this.getMergeModuleId();
					this.sandbox.subscribe("Merge", function(config) {
						this.mergeRecords(config);
					}, this, [moduleId]);
				}
			}
		};
	}
);
