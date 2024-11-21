define("PartnershipModule", ["BaseSchemaModuleV2"],
	function() {

		/**
		 * @class BPMSoft.configuration.PartnershipModule
		 * Module, which is analyze availability of active partnership and choose next view for render.
		 */
		return Ext.define("BPMSoft.configuration.PartnershipModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.PartnershipModule",
			messages: {
				/**
				 * @message PushHistoryState
				 * Notification that the history state has been changed.
				 */
				"PushHistoryState": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetHistoryState
				 * Message to get current history state.
				 */
				"GetHistoryState": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				* @message ReplaceHistoryState
				* Message to replace current history state.
				*/
				"ReplaceHistoryState": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.BROADCAST
				}
			},

			/**
			 * Default pages for rendering partnership data.
			 */
			defaultPartnershipClientSchemas: {
				sectionSchema: "PortalPartnershipSection",
				cardSchema: "PortalPartnershipPage"
			},

			/**
			* @inheritdoc BPMSoft.BaseSchemaModule#init
			* @override
			*/
			init: function() {
				this.sandbox.registerMessages(this.messages);
				this.navigatePartnerToNextView();
			},

			/**
			* Navigate partner to card of active partnership or section with message about no active partnership.
			* @protected
			*/
			navigatePartnerToNextView: function() {
				const esq = this.getActivePartnershipEsq();
				esq.getEntityCollection(function(response) {
					if (response) {
						const collection = response.collection;
						collection.isEmpty() ? this.openPartnershipSection() : this.openActivePartnership(collection);
					}
				}, this);
			},

			/**
			* Open section with message about no active partnership.
			* @protected
			*/
			openPartnershipSection: function() {
				const sectionSchema = this.getClientSchemaByName("sectionSchema");
				const path = this.BPMSoft.combinePath("SectionModuleV2", sectionSchema);
				const historyStateConfig = {hash: path};
				this.sandbox.publish("ReplaceHistoryState", historyStateConfig);
			},

			/**
			 * Returns client schemas for partnership.
			 * @protected
			 * @param {String} schemaName Name of client schema that is needed for rendering.
			 */
			getClientSchemaByName: function(schemaName) {
				const partnershipStructure = BPMSoft.configuration.ModuleStructure.Partnership;
				return partnershipStructure && partnershipStructure[schemaName]
					? partnershipStructure[schemaName] : this.defaultPartnershipClientSchemas[schemaName];
			},


			/**
			* Navigate partner to card of active partnership.
			* @protected
			* @param {BPMSoft.Collection} collection Collection of Partnership records.
			*/
			openActivePartnership: function(collection) {
				const activePartnershipId = collection.first().$Id;
				const cardSchema = this.getClientSchemaByName("cardSchema");
				const path = this.BPMSoft.combinePath("CardModuleV2", cardSchema,
					BPMSoft.ConfigurationEnums.CardOperation.EDIT, activePartnershipId);
				const historyStateConfig = {
					hash: path
				};
				this.sandbox.publish("ReplaceHistoryState", historyStateConfig);
			},

			/**
			* Returns EntitySchemaQuery for Partnership entity with filter by Active columns.
			* @protected
			* @returns {BPMSoft.EntitySchemaQuery} esq
			*/
			getActivePartnershipEsq: function() {
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "Partnership"
				});
				esq.addColumn("Id");
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"IsActive", true));
				return esq;
			}
		});

	});
