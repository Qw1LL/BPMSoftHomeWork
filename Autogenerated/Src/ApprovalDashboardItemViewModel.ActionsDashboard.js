define("ApprovalDashboardItemViewModel", ["ApprovalDashboardItemViewModelResources", "VisaHelper", "ConfigurationEnums",
		"ConfigurationConstants", "EntityDashboardItemViewModel"],
	function(resources, VisaHelper, ConfigurationEnums, ConfigurationConstants) {
		Ext.define("BPMSoft.configuration.ApprovalDashboardItemViewModel", {
			extend: "BPMSoft.EntityDashboardItemViewModel",
			alternateClassName: "BPMSoft.ApprovalDashboardItemViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			columns: {
				/**
				 * The text of the approve button caption.
				 */
				"ApproveButtonCaption": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: resources.localizableStrings.ApproveButtonCaption
				},

				/**
				 * The text of the reject button caption.
				 */
				"RejectButtonCaption": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: resources.localizableStrings.RejectButtonCaption
				},

				/**
				 * The text of the change approver button caption.
				 */
				"ChangeApproverButtonCaption": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: resources.localizableStrings.ChangeApproverButtonCaption
				}
			},

			messages: {
				/**
				 * @message ReloadDashboardItems
				 * Reloads dashboard items.
				 */
				"ReloadDashboardItems": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
				}
			},

			// region Methods: Private

			/**
			 * Sends reload dashboard items message.
			 * @private
			 */
			_sendReloadDashboardItemsMessage: function() {
				this.sandbox.publish("ReloadDashboardItems", {
					id: this.get("Id")
				});
			},

			/**
			 * Returns default mini page options.
			 * @private
			 * @param {ConfigurationConstants.VisaStatus} status Status.
			 * @return {Object} Configuration object for mini page.
			 */
			_getMiniPageOptions: function(status) {
				var valuePairs = [];
				valuePairs.push({
					name: "DefaultStatus",
					value: status
				});
				return {
					operation: ConfigurationEnums.CardStateV2.EDIT,
					valuePairs: valuePairs,
					miniPageSchemaName: "PreconfiguredApprovalPage"
				};
			},

			/**
			 * Returns entity schema instance.
			 * @private
			 * @param {Function} callback The callback function.
			 * @param {BPMSoft.BaseEntitySchema} callback.schema Entity schema instance.
			 * @param {Object} scope The scope of callback function.
			 */
			_getEntitySchema: function(callback, scope) {
				var schemaName = this.get("EntitySchemaName");
				this.sandbox.requireModuleDescriptors(["force!" + schemaName], function() {
					BPMSoft.require([schemaName], callback, scope);
				}, this);
			},

			/**
			 * Returns current schema entity.
			 * @private
			 * @param {BPMSoft.BaseEntitySchema} schema Entity schema instance.
			 * @param {Function} callback The callback function.
			 * @param {BPMSoft.BaseViewModel} callback.entity Current record entity.
			 * @param {Object} scope The scope of callback function.
			 */
			_getCurrentEntity: function(schema, callback, scope) {
				var select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchema: schema
				});
				var currentRecordId = this.get("Id");
				select.getEntity(currentRecordId, function(result) {
					callback.call(scope, result.entity);
				}, this);
			},

			/**
			 * Set approval entity status.
			 * @private
			 */
			_updateApprovalStatus: function(status, callback, scope) {
				this._getEntitySchema(function(schema) {
					this._getCurrentEntity(schema, function(entity) {
						VisaHelper.setStatus(entity, status, "", callback, scope);
					}, this);
				}, this);
			},

			/**
			 * @private
			 */
			_showMask: function() {
				this.showBodyMask();
			},

			/**
			 * @private
			 */
			_hideMask: function() {
				this.hideBodyMask();
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseViewModule#init
			 * @overridden
			 */
			init: function() {
				this.sandbox.registerMessages(this.messages);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseDashboardItemViewModel#initIconSrc
			 * @overridden
			 */
			initIconSrc: function() {
				this.set("IconSrc", resources.localizableImages.IconImage);
			},

			// endregion

			// region Methods: Public

			/**
			 * Returns button image config.
			 * @param {Object} config Configuration object.
			 * @param {String} config.imageName Image name.
			 * @return {Object}
			 */
			getButtonImageConfig: function(config) {
				var image = resources.localizableImages[config.imageName];
				return {
					"source": BPMSoft.ImageSources.URL,
					"url": BPMSoft.ImageUrlBuilder.getUrl(image)
				};
			},

			/**
			 * Approve button click handler.
			 */
			onApproveButtonClick: function() {
				this._showMask();
				var status = ConfigurationConstants.VisaStatus.positive;
				BPMSoft.SysSettings.querySysSettingsItem("AcceptApprovalWithoutComment", function(value) {
					if (value === true) {
						this._updateApprovalStatus(status, function() {
							this._hideMask();
							this._sendReloadDashboardItemsMessage();
						}, this);
					} else {
						var miniPageOptions = this._getMiniPageOptions(status);
						this.showMiniPage(miniPageOptions);
					}
				}, this);
			},

			/**
			 * Reject button click handler.
			 */
			onRejectButtonClick: function() {
				var status = ConfigurationConstants.VisaStatus.negative;
				var miniPageOptions = this._getMiniPageOptions(status);
				this.showMiniPage(miniPageOptions);
			},

			/**
			 * Change approver button click handler.
			 */
			onChangeApproverButtonClick: function() {
				this._showMask();
				const recordId = this.get("Id");
				const schemaName = this.get("EntitySchemaName");
				VisaHelper.changeVizierAction(recordId, schemaName, this.sandbox, null, function(result) {
					this._hideMask();
					if (result) {
						this._sendReloadDashboardItemsMessage();
					}
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseDashboardItemViewModel#getProcessElementUId
			 * @overridden
			 */
			getProcessElementUId: function() {
				return this.get("Id");
			},

			/**
			 * Returns item caption, if caption attribute is empty returns default value.
			 */
			getCaption: function() {
				return this.get("Caption") || resources.localizableStrings.DefaultCaption;
			}

			// endregion

		});
	});
