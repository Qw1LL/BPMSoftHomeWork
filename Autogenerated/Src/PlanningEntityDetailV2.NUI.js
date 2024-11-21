define("PlanningEntityDetailV2", [],
		function() {
			return {
				messages: {
					/**
					 * @message DropResult
					 * Returns drop result.
					 * @return {Object} Drop result.
					 */
					"DropResult": {
						mode: this.BPMSoft.MessageMode.BROADCAST,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message UpdatePlaningDetailFilter
					 * Message handler filter events in detail.
					 */
					"UpdatePlaningDetailFilter": {
						mode: this.BPMSoft.MessageMode.BROADCAST,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetSectionFilters
					 * Returns seleted filters.
					 * @return {Object} Filters of section.
					 */
					"GetSectionFilters": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message GetGridSettingsInfo
					 * Returns informations of grid settings.
					 * @return {Object} informations of grid settings.
					 */
					"GetGridSettingsInfo": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GridSettingsChanged
					 * Informs about changing grid settings.
					 */
					"GridSettingsChanged": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

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
					 * Publishing message for HistoryState request.
					 */
					"GetHistoryState": {
						"mode": this.BPMSoft.MessageMode.PTP,
						"direction": this.BPMSoft.MessageDirectionType.PUBLISH
					},
					"GetDetailInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				attributes: {
					/**
					 * Last selected time drop-zone.
					 */
					"LastSelectedTimeDropZone": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Last selected date drop-zone.
					 */
					"LastSelectedDateDropZone": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Component of scheduler edit.
					 */
					"SchedulerEditComponent": {
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Component of scheduler item.
					 */
					"SchedulerItemComponent": {
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				properties: {
					/**
					 * Day constant.
					 */
					day: "day",

					/**
					 * Time constant.
					 */
					time: "time",

					/**
					 * Row count constant.
					 */
					rowCount: 15
				},
				methods: {
					/**
					 * @inheritdoc BaseGridDetailV2#init
					 * @overridden
					 */
					init: function() {
						this.set("RowCount", this.rowCount);
						this.set("Filter", this.Ext.create("BPMSoft.FilterGroup"));
						this.callParent(arguments);
						this.initComponents();
						this.subscribeMessages();
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getIsCardValid
					 * @overridden
					 */
					getIsCardValid: function() {
						return true;
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#initDetailOptions
					 * @overridden
					 */
					initDetailOptions: function() {
						this.callParent(arguments);
						this.set("IsDetailCollapsed", false);
					},

					/**
					 * Subscribes messages.
					 * @private
					 */
					subscribeMessages: function() {
						this.sandbox.subscribe("UpdatePlaningDetailFilter", this.onUpdatePlaningDetailFilter, this);
					},

					/**
					 * Handles response from server after updating email template.
					 * @protected
					 * @param {Object} filterItem Filter element.
					 * @param {String} filterItem.key Filter key.
					 * @param {BPMSoft.FilterGroup} filterItem.filters Filter group.
					 * @param {Object} filterItem.filtersValue Filter value.
					 */
					onUpdatePlaningDetailFilter: function(filterItem) {
						this.onFilterUpdate(filterItem.key, filterItem.filters, filterItem.filtersValue);
					},

					/**
					 * Returns profile key.
					 * @override
					 * @return {String} Key.
					 */
					getProfileKey: function() {
						return [this.name, this.entitySchemaName].join("_");
					},

					/**
					 * @inheritdoc GridUtilitiesV2#onFilterUpdate
					 * @override
					 */
					onFilterUpdate: function(filterKey, filterItem, filtersValue) {
						var args = arguments;
						var filters = this.get("DetailFilters");
						if (!this.Ext.isEmpty(filterKey) && this.Ext.isEmpty(filtersValue)) {
							if (filters.find(filterKey)) {
								filters.remove(filters.get(filterKey));
							}
							args = [];
						}
						this.callParent(args);
					},

					/**
					 * @inheritdoc GridUtilitiesV2#getFilters
					 * @overridden
					 */
					getFilters: function() {
						var filters = this.sandbox.publish("GetSectionFilters");
						if (!this.Ext.isEmpty(filters.filtersValue)) {
							this.setFilter(filters.key, filters.filtersValue);
						}
						return this.callParent(arguments);
					},

					/**
					 * Initialize components.
					 * @protected
					 */
					initComponents: function() {
						var itemComponent = this.Ext.create("BPMSoft.ScheduleItem");
						var editComponent = this.Ext.getCmp("ActivitySectionV2Scheduler");
						this.set("SchedulerItemComponent", itemComponent);
						this.set("SchedulerEditComponent", editComponent);
					},

					/**
					 * Returns sign of last selected drop-zone.
					 * @param {String} dropZoneId Identifier of drop-zone.
					 * @return {Boolean} Sign of last selected drop-zone.
					 */
					isLastSelectedDropZone: function(dropZoneId) {
						var lastSelectedTimeDropZone = this.get("LastSelectedTimeDropZone");
						var lastSelectedDateDropZone = this.get("LastSelectedDateDropZone");
						if (this.getIsExistNameInDropZone(dropZoneId, this.day)) {
							return (lastSelectedDateDropZone === dropZoneId && lastSelectedTimeDropZone);
						}
						if (this.getIsExistNameInDropZone(dropZoneId, this.time)) {
							return (lastSelectedTimeDropZone === dropZoneId && lastSelectedDateDropZone);
						}
					},

					/**
					 * Sets selected drop-zone.
					 * @param {String} dropZoneId Identifier of drop-zone.
					 */
					setSelectedDropZone: function(dropZoneId) {
						if (this.getIsExistNameInDropZone(dropZoneId, this.day)) {
							this.set("LastSelectedDateDropZone", dropZoneId);
						}
						if (this.getIsExistNameInDropZone(dropZoneId, this.time)) {
							this.set("LastSelectedTimeDropZone", dropZoneId);
						}
					},

					/**
					 * Returns flag that indicates drop zone.
					 * @param {String} dropZoneId Identifier of drop-zone.
					 * @param {String} name Find name.
					 * @return {Boolean} Sign of drop-zone.
					 */
					getIsExistNameInDropZone: function(dropZoneId, name) {
						return dropZoneId.indexOf(name) > -1;
					},

					/**
					 * Handles when drag-element over drop-zone.
					 * @param {Event} event Mouse event.
					 * @param {String} dropZoneId Identifier of drop-zone.
					 */
					onDragOver: function(event, dropZoneId) {
						if (!this.isLastSelectedDropZone(dropZoneId)) {
							this.setSelectedDropZone(dropZoneId);
							var schedulerEditComponent = this.get("SchedulerEditComponent");
							if (schedulerEditComponent.onMouseDown) {
								schedulerEditComponent.onMouseDown(event);
							}
						}
					},

					/**
					 * Returns drop zone date.
					 * @param {Event} event Mouse event.
					 * @return {Date} Drop zone date.
					 */
					getDropZoneDate: function(event) {
						var x = event.getX();
						var y = event.getY();
						var days = this.Ext.dd.DragDropManager.ids.day;
						var times = this.Ext.dd.DragDropManager.ids.time;
						var schedulerItemComponent = this.get("SchedulerItemComponent");
						var date = schedulerItemComponent.ddItemOverride.pointInsideDays([x, y], days);
						var time = schedulerItemComponent.ddItemOverride.pointInsideTimes([x, y], times);
						return new Date(date.year, date.month, date.day, time.hour, time.minute);
					},

					/**
					 * Handles when drag-element drop on drop-zone.
					 * @param {Event} event Mouse event.
					 * @param {String} dropZoneId Identifier of drop-zone.
					 * @param {Object} item Datas of drag-element.
					 */
					onDragDrop: function(event, dropZoneId, item) {
						if (!this.isLastSelectedDropZone(dropZoneId)) {
							this.setSelectedDropZone(dropZoneId);
							return;
						}
						this.set("LastSelectedTimeDropZone", null);
						this.set("LastSelectedDateDropZone", null);
						var dateObject = this.getDropZoneDate(event);
						this.publishDropResult(item, dateObject);
					},

					/**
					 * Publishes message of drop result.
					 * @param {Object} item Data of drag-element.
					 * @param {Date} dateObject Drop zone date
					 */
					publishDropResult: function(item, dateObject) {
						var config = {
							data: [
								{
									value: item.get("Id"),
									displayValue: item.get("Name")
								}
							],
							entitySchemaName: this.entitySchemaName,
							date: dateObject
						};
						this.sandbox.publish("DropResult", config);
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
					 * @overridden
					 */
					getCopyRecordMenuItem: this.BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
					 * @overridden
					 */
					getEditRecordMenuItem: this.BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
					 * @overridden
					 */
					getDeleteRecordMenuItem: this.BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
					 * @overridden
					 */
					getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
					 * @overridden
					 */
					addDetailWizardMenuItems: this.BPMSoft.emptyFn
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"dragActionsCode": 1,
							"dragDropGroupName": ["time-item", "day-item"],
							"showDropZoneHint": true,
							"isTarget": true,
							"dragOver": {"bindTo": "onDragOver"},
							"dragDrop": {"bindTo": "onDragDrop"}
						}
					},
					{
						"operation": "merge",
						"name": "AddRecordButton",
						"values": {"visible": false}
					},
					{
						"operation": "merge",
						"name": "AddTypedRecordButton",
						"values": {"visible": false}
					},
					{
						"operation": "merge",
						"name": "Detail",
						"values": {"caption": ""}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
