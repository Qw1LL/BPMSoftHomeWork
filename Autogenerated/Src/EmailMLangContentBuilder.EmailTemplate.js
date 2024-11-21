define("EmailMLangContentBuilder", ["EmailTemplateMLangContentBuilderEnumsModule", "ContentBuilderHelper",
		"css!ContentBuilderCSS"],
	function(EMLangContentBuilderEnumsModule) {
		return {
			attributes: {
                /**
                 * Parent entity identifier.
                 */
				"ParentEntityId": {
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.EmailContentBuilder#getContentBuilderEnumsConfig
				 * @overriden
				 */
				getContentBuilderEnumsConfig: function(contentBuilderMode) {
					return EMLangContentBuilderEnumsModule.getContentBuilderConfig(contentBuilderMode);
				},

				/**
				 * @inheritdoc BPMSoft.EmailContentBuilder#initParameters
				 * @overriden
				 */
				initParameters: function() {
					this.callParent(arguments);
					var config = this.get("ContentBuilderConfig");
					var parameters = this.getParameters();
					config.TemplateBodyColumnName = parameters[4];
				},

				/**
				 * @inheritdoc BPMSoft.EmailContentBuilder#getContentSheetESQ
				 * @overriden
				 */
				getContentSheetESQ: function() {
					var esq = this.callParent(arguments);
					var contentBuilderConfig = this.get("ContentBuilderConfig");
					if (!this.Ext.isEmpty(contentBuilderConfig.ParentEntityColumnName)) {
						esq.addColumn(contentBuilderConfig.ParentEntityColumnName);
					}
					return esq;
				},

				/**
				 * @inheritdoc BPMSoft.EmailContentBuilder#setContentSheetConfig
				 * @overriden
				 */
				setContentSheetConfig: function(entity) {
					var contentBuilderConfig = this.get("ContentBuilderConfig");
					this.set("ParentEntityId", entity.get(contentBuilderConfig.ParentEntityColumnName).value);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.EmailContentBuilder#getParametersForEmailTemplateFile
				 * @overriden
				 */
				getParametersForEmailTemplateFile: function() {
					var parameters = this.callParent(arguments);
					var parentEntityId = this.get("ParentEntityId");
					if (parentEntityId) {
						parameters.EmailTemplate.value = parentEntityId;
					}
					return parameters;
				}
			}
		};
	});
