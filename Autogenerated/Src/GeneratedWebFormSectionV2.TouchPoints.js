 define("GeneratedWebFormSectionV2", function() {
		return {
			entitySchemaName: "GeneratedWebForm",
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#initEditPages
				 * @override
				 */
				 initEditPages: function() {
					if (this.getIsFeatureEnabled("FormSubmitGeneratedWebForm")) {
						return this.callParent(arguments);
					}
					var collection = Ext.create("BPMSoft.BaseViewModelCollection");
					var entityStructure = this.getEntityStructure(this.entitySchemaName);
					if (entityStructure) {
						var editPages = entityStructure.pages.filter(function(page) {
							return page.cardSchema !== "FormSubmitGeneratedWebFormPageV2";
						});
						BPMSoft.each(editPages, function(editPage) {
							var typeUId = editPage.UId || BPMSoft.GUID_EMPTY;
							collection.add(typeUId, Ext.create("BPMSoft.BaseViewModel", {
								values: {
									Id: typeUId,
									Caption: editPage.caption,
									Click: {bindTo: "addRecord"},
									Tag: typeUId,
									SchemaName: editPage.cardSchema
								}
							}));
						}, this);
						this.set("EditPages", collection);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
