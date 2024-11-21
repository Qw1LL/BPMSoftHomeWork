/**
 * ConditionalSequenceFlow edit page schema.
 * Parent: BaseProcessSchemaElementPropertiesPage
 */
define("ActivityConditionalSequenceFlowEditPage", ["BPMSoft", "ActivityConditionalSequenceFlowEditPageResources"
], function(BPMSoft, resources) {
	return {
		messages: {
			/**
			 * @message ProcessActivitiesSelectedResultsChanged
			 * Publish selected results of ConditionalSequenceFlow element.
			 */
			"ProcessActivitiesSelectedResultsChanged": {
				"direction": BPMSoft.MessageDirectionType.PUBLISH,
				"mode": BPMSoft.MessageMode.PTP
			},

			/**
			 * @message GetConditionalSequenceFlowData
			 * Request previous ProcessActivity and conditions for designer ConditionalSequenceFlow.
			 */
			"GetConditionalSequenceFlowData": {
				"direction": BPMSoft.MessageDirectionType.PUBLISH,
				"mode": BPMSoft.MessageMode.PTP
			}
		},
		attributes: {
			/**
			 * Collection of possible results for conditional sequence flow.
			 * @type {BPMSoft.ViewModelCollection}
			 */
			ProcessActivityResultsCollection: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Selected results for conditional sequence flow. Key - ProcessActivity uId, value - object of
			 * key-value pairs conditions.
			 * @type {Object}
			 */
			SelectedResults: {
				dataValueType: BPMSoft.DataValueType.OBJECT
			},

			/**
			 * Label caption for edit page.
			 * @type {String}
			 */
			ProcessActivitiesResultsCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * Request previous ProcessActivity element, designed conditions and edit page schema name for
			 * ProcessActivity.
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					var activityResultsCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					activityResultsCollection.on("itemChanged", this.onActivityResultChanged, this);
					this.set("ProcessActivityResultsCollection", activityResultsCollection);
					var sandbox = this.sandbox;
					var sequenceFlowData = sandbox.publish("GetConditionalSequenceFlowData",
						null, [sandbox.id]);
					var processActivity = sequenceFlowData.processActivityElement;
					var selectedResults = sequenceFlowData.selectedResults;
					this.set("ProcessActivity", processActivity);
					this.set("SelectedResults", selectedResults);
					var processActivitiesResultsCaption =
						this.getProcessActivitiesResultsCaption(processActivity);
					this.set("ProcessActivitiesResultsCaption", processActivitiesResultsCaption);
					this.loadActivityResultsCollection(sequenceFlowData.resultParameterValues, selectedResults);
					callback.call(scope);
				}, this]);
			},

			/**
			 * For each possible process activity result parameter value creates view model, initialize it by
			 * condition designed before and adds to ProcessActivityResultsCollection.
			 * @param {Object} resultParameterValues Key-value pairs of possible result parameter values.
			 * @param {Object} selectedResults Conditions designed before.
			 */
			loadActivityResultsCollection: function(resultParameterValues, selectedResults) {
				var activityResultsCollection = this.get("ProcessActivityResultsCollection");
				var processActivity = this.get("ProcessActivity");
				var collection = Ext.create("BPMSoft.Collection");
				var results = selectedResults[processActivity.uId] || [];
				BPMSoft.each(resultParameterValues, function(caption, uId) {
					var markerValue = this.Ext.String.format("{0}{1} {2}", "activityResult-", uId, caption);
					var viewModel = this.createActivityResultViewModel({
						uId: uId,
						caption: caption,
						checked: (results.indexOf(uId) > -1),
						resultMarkerValue: markerValue
					});
					collection.add(uId, viewModel);
				}, this);
				activityResultsCollection.loadAll(collection);
			},

			/**
			 * Returns text for description label. Text makes from resource
			 * ProcessActivitiesResultsCaption template and process activity element caption. If caption is
			 * empty used element name.
			 * @param {BPMSoft.ProcessUserTaskSchema} processActivity ProcessActivity element.
			 * @return {String}
			 * @private
			 */
			getProcessActivitiesResultsCaption: function(processActivity) {
				var caption = resources.localizableStrings.ProcessActivitiesResultsCaption;
				var processActivityCaption = processActivity.caption.getValue();
				if (processActivityCaption === "") {
					processActivityCaption = processActivity.name;
				}
				return BPMSoft.getFormattedString(caption, processActivityCaption);
			},

			/**
			 * Change event handler of activity results collection item. Calculate SelectedResult attribute and
			 * publish ProcessActivitiesSelectedResultsChanged message.
			 * @private
			 */
			onActivityResultChanged: function() {
				var processActivity = this.get("ProcessActivity");
				var activityResultsCollection = this.get("ProcessActivityResultsCollection");
				var selectedResults = {};
				var results = selectedResults[processActivity.uId] = [];
				var resultsCaptions = [];
				activityResultsCollection.each(function(activityResultViewModel) {
					var activityResult = activityResultViewModel.get("Checked");
					if (activityResult === true) {
						var resultUId = activityResultViewModel.get("UId");
						var resultCaption = activityResultViewModel.get("Caption");
						resultsCaptions.push(resultCaption);
						results.push(resultUId);
					}
				}, this);
				this.set("SelectedResults", selectedResults);
				var sandbox = this.sandbox;
				sandbox.publish("ProcessActivitiesSelectedResultsChanged", {
					selectedResults: selectedResults,
					resultsCaptions: resultsCaptions
				}, [sandbox.id]);
			},

			/**
			 * Creates and return viewModel for activity result item.
			 * @param {Object} columnValues Initialize column values. Key - column name, value - column value.
			 * Possible keys is uId, caption and checked.
			 * @return {BPMSoft.BaseViewModel}
			 */
			createActivityResultViewModel: function(columnValues) {
				var activityResultViewModel = Ext.create("BPMSoft.BaseViewModel", {
					columns: {
						UId: {
							dataValueType: BPMSoft.DataValueType.GUID
						},
						Checked: {
							dataValueType: BPMSoft.DataValueType.BOOLEAN
						},
						Caption: {
							dataValueType: BPMSoft.DataValueType.TEXT
						}
					},
					values: {
						UId: columnValues.uId,
						Caption: columnValues.caption,
						Checked: (columnValues.checked === true),
						resultMarkerValue: columnValues.resultMarkerValue
					}
				});
				activityResultViewModel.sandbox = this.sandbox;
				return activityResultViewModel;
			},

			/**
			 * @protected
			 */
			onActivityResultItemClick: function(uId) {
				const collection = this.get("ProcessActivityResultsCollection");
				if (collection) {
					const item = collection.get(uId);
					item.set("Checked", !item.get("Checked"));
				}
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ActivityResultsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["activity-results-list"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderLabel",
				"parentName": "ActivityResultsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["results-caption"]
					},
					"caption": {
						"bindTo": "ProcessActivitiesResultsCaption"
					},
				}
			},
			{
				"operation": "insert",
				"name": "ActivityResultsCollection",
				"parentName": "ActivityResultsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID,
					"markerValue": "ActivityResultsCollection",
					"idProperty": "UId",
					"dataItemIdPrefix": "activityResult",
					"selectableRowCss": "activity-result",
					"collection": {"bindTo": "ProcessActivityResultsCollection"},
					"onItemClick": {"bindTo": "onActivityResultItemClick"},
					"rowCssSelector": ".activity-result",
					"defaultItemConfig": {
						"className": "BPMSoft.Container",
						"items": [
							{
								"className": "BPMSoft.CheckBoxEdit",
								"checked": {"bindTo": "Checked"},
								"markerValue": {"bindTo": "resultMarkerValue"}
							},
							{
								"className": "BPMSoft.Label",
								"caption": {"bindTo": "Caption"}
							}
						]
					},
					"generator": "ContainerListGenerator.generatePartial"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
