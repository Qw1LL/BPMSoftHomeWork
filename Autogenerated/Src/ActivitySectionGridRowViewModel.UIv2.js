define("ActivitySectionGridRowViewModel", ["ext-base", "BPMSoft", "BaseSectionGridRowViewModel",
		"CheckModuleDestroyMixin"],
		function(Ext, BPMSoft) {

	/**
	 * @class BPMSoft.configuration.ActivitySectionGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.ActivitySectionGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.ActivitySectionGridRowViewModel",

		mixins: [
			"BPMSoft.CheckModuleDestroyMixin"
		],

		/**
		 * Debounce save entity function.
		 * Prevents multiple update activity when the fields have changed.
		 * @private
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		debounceSaveEntityFunc: BPMSoft.emptyFn,

		/**
		 * ########## ######## ########### ######### ### ######## # ##########.
		 * @return {String} ######## ########### ######### ### ######## # ##########.
		 */
		getScheduleItemHint: function() {
			var timeFormat = BPMSoft.Resources.CultureSettings.timeFormat;
			var startDate = Ext.Date.format(this.get("StartDate"), timeFormat);
			var dueDate = Ext.Date.format(this.get("DueDate"), timeFormat);
			var title = this.get("Title");
			var account = this.get("Account");
			var accountDisplayValue = (account) ? account.displayValue + ": " : "";
			return Ext.String.format("{0}-{1} {2}{3}", startDate, dueDate, accountDisplayValue, title);
		},

		/**
		 * ########## ###### ######## ##########.
		 * @return {BPMSoft.ScheduleItemStatus} ###### ######## ##########.
		 */
		getScheduleItemStatus: function() {
			var isFinished = this.get("Status.Finish");
			var dueDate = this.get("DueDate");
			if (dueDate <= new Date() && !isFinished) {
				return BPMSoft.ScheduleItemStatus.OVERDUE;
			} else if (isFinished) {
				return BPMSoft.ScheduleItemStatus.DONE;
			}
			return BPMSoft.ScheduleItemStatus.NEW;
		},

		/**
		 * ########## ######## ######### ######## # ##########.
		 * @return {String} ######## ######### ######## # ##########.
		 */
		getScheduleItemTitle: function() {
			var title = this.get("Title");
			var account = this.get("Account");
			var accountDisplayValue = (account) ? account.displayValue + ": " : "";
			return Ext.String.format("{0}{1}", accountDisplayValue, title);
		},

		/**
		 * inheritdoc BPMSoft.BaseGridRowViewModel#getEntitySchemaQuery
		 */
		getEntitySchemaQuery: function() {
			var esq = this.callParent(arguments);
			if (!esq.columns.contains("Status.Finish")) {
				esq.addColumn("Status.Finish");
			}
			return esq;
		},

		/**
		 * inheritdoc BPMSoft.BaseViewModel#setColumnValues
		 */
		setColumnValues: function(entity) {
			this.set("Status.Finish", entity.get("Status.Finish"));
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.debounceSaveEntityFunc = BPMSoft.debounce(this.saveEntity, 500);
		},

		/**
		 * ############ ####### ######### #### "######".
		 * @protected
		 * @param {Date} date ##### ######## ####.
		 */
		onStartDateChanged: function(date) {
			this.set("StartDate", date);
			this.debounceSaveEntityFunc(BPMSoft.emptyFn, this);
		},

		/**
		 * ############ ####### ######### #### "##########".
		 * @protected
		 * @param {Date} date ##### ######## ####.
		 */
		onDueDateChanged: function(date) {
			this.set("DueDate", date);
			this.debounceSaveEntityFunc(BPMSoft.emptyFn, this);
		},

		/**
		 * ############ ####### ######### #### "#########".
		 * @protected
		 */
		onTitleChanged: BPMSoft.emptyFn,

		/**
		 * ############ ####### ######### #### "#########".
		 * @protected
		 */
		onStatusChanged: BPMSoft.emptyFn

	});

	return BPMSoft.ActivitySectionGridRowViewModel;
});
