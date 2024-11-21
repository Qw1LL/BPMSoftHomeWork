define("DuplicatesWidgetViewModel", ["DuplicatesWidgetViewModelResources", "GoogleTagManagerUtilities"],
	function(resources, GoogleTagManagerUtilities) {
		Ext.define("BPMSoft.configuration.DuplicatesWidgetViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.DuplicatesWidgetViewModel",
			Ext: null,
			BPMSoft: null,
			sandbox: null,
			isOpeningPage: false,
			
			columns: {
				EntitySchemaName: { dataValueType: BPMSoft.DataValueType.TEXT },
				EntityId: { dataValueType: BPMSoft.DataValueType.TEXT },
				Duplicates: { dataValueType: BPMSoft.DataValueType.COLLECTION },
			},
			mixins: {},
			messages: {},

			/**
			 * Handles widget click event.
			 * @param {Object} data Widget data.
			 */
			onWidgetClick: function(data) {
				BPMSoft.chain(
					function(next) {
						this._checkCanUserReadAnyEntityRecord(next, data);
					},
					function(next, isAnyRecordReaded) {
						if (isAnyRecordReaded) {
							this._openDuplicatesCard(data);
						} else {
							const message = resources.localizableStrings.UserHasNoRightToReadRecords;
							BPMSoft.showInformation(message, null, null, {buttons: ["OK"]});
						}
					},
					this
				);
			},

			/**
			 * Check can user read any entity record.
			 * @param {function} callback Function.
			 * @param {object} data Widget data.
			 * @private
			 */
			_checkCanUserReadAnyEntityRecord(callback, data) {
				const esq = this._getEntityEsq(data);
				esq.getEntityCollection(function(result) {
					if (result.success) {
						Ext.callback(callback, this, [result.collection.getCount() > 0]);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_addGTMForDuplicatesWidget: function() {
				var data = this._getGTMDuplicatesWidgetData();
				GoogleTagManagerUtilities.actionModule(data);
			},

			/**
			 * @private
			 */
			_getGTMDuplicatesWidgetData: function() {
				return {
					action: "DuplicatesWidgetClick",
					moduleName: "DuplicatesWidgetModule",
					schemaName: "DuplicateWidget"
				};
			},

			/**
			 * Returns entity schema query with filter.
			 * @param {object} data Widget data.
			 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
			 * @private
			 */
			_getEntityEsq(data) {
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: data.entitySchemaName
				});
				esq.addColumn("Id");
				esq.filters.add("EntityIdInFilter", BPMSoft.createColumnInFilterWithParameters("Id", data.duplicates));
				return esq;
			},

			/**
			 * Opens duplicates card.
			 * @param {object} data Widget data.
			 * @private
			 */
			_openDuplicatesCard: function(data) {
				const duplicatesIds = data.duplicates || [];
				if (duplicatesIds.length === 0) {
					return;
				}
				if (this.isOpeningPage) {
					return;
				}
				this._addGTMForDuplicatesWidget();
				this.isOpeningPage = true;
				const currentEntityId = data.entityId;
				const hash = "CardModuleV2/WidgetDuplicatesPage/" + data.entitySchemaName;
				this.sandbox.publish("PushHistoryState", {
					hash: hash,
					stateObj: {
						DuplicateEntitiesIds: duplicatesIds,
						CurrentEntityId: currentEntityId,
						EntitySchemaName: data.entitySchemaName,
						BackHash: BPMSoft.router.Router.getHash(),
						BackState: BPMSoft.router.Router.getState()
					}
				});
			},
		});

		return BPMSoft.DuplicatesWidgetViewModel;

	});