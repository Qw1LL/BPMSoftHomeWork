define("UserCalendarMixin", ["UserCalendarMixinResources", "NetworkUtilities"], function(resources, NetworkUtilities) {
	Ext.define("BPMSoft.configuration.mixins.UserCalendarMixin", {
		alternateClassName: "BPMSoft.UserCalendarMixin",

		/**
		 * Initialize base personal calendar setting.
		 * @protected
		 * @virtual
		 */
		initSysSettingBaseUserCalendar: function() {
			this.BPMSoft.SysSettings.querySysSettingsItem("BaseUserCalendar", function(result) {
				this.set("BaseUserCalendarId", result.value);
			}, this);
		},

		/**
		 * Returns calendar info entity schema query.
		 * @protected
		 * @virtual
		 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
		 */
		getUserCalendarQuery: function() {
			var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "Calendar",
				rowCount: 1
			});
			this.initUserCalendarQueryColumns(esq);
			this.initUserCalendarQueryFilters(esq);
			return esq;
		},

		/**
		 * Initializes personal calendar.
		 * @private
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		initUserCalendar: function(callback, scope) {
			var esq = this.getUserCalendarQuery();
			esq.getEntityCollection(function(response) {
				var calendarId = null;
				if (response.success) {
					var collection = response.collection;
					if (collection && collection.getCount() > 0) {
						var calendar = collection.getByIndex(0);
						calendarId = calendar.get("Id");
					}
				} else {
					this.generateException(response.errorInfo);
				}
				this.set("UserCalendarId", calendarId);
				this.Ext.callback(callback, scope || this);
			}, this);
		},

		/**
		 * Generates exception message.
		 * @protected
		 * @param {Object} errorInfo Message.
		 */
		generateException: function(errorInfo) {
			throw new this.BPMSoft.UnknownException({
				message: errorInfo.message
			});
		},

		/**
		 * Initializes calendar query columns.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
		 */
		initUserCalendarQueryColumns: function(esq) {
			esq.addColumn("Id");
		},

		/**
		 * Handles calendar button click.
		 */
		onCalendarClick: function() {
			var recordId = this.getUserCalendarId(false);
			if (this.isEmpty(recordId)) {
				this.showConfirmationDialog(
						this.getConfirmationDialogContent(),
						this.calendarConfirmationDialogCallback, ["yes", "no"]);
			} else {
				this.openCalendarCard();
			}
		},

		/**
		 * Returns confirmation dialog content.
		 * @return {String} Content.
		 */
		getConfirmationDialogContent: function() {
			return resources.localizableStrings.NotExistUserCalendar;
		},

		/**
		 * Handles calendar confirmation dialog callback.
		 * @private
		 * @param {String} returnCode Message box buttons return code.
		 */
		calendarConfirmationDialogCallback: function(returnCode) {
			if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
				this.copyDefaultCalendar(this.openCalendarCard, this);
			}
		},

		/**
		 * Opens calendar page.
		 * @protected
		 * @virtual
		 */
		openCalendarCard: function() {
			var recordId = this.getUserCalendarId();
			var hash = NetworkUtilities.getEntityUrl("Calendar", recordId);
			this.sandbox.publish("PushHistoryState", {hash: hash});
		},

		/**
		 * Copies default base calendar.
		 * @protected
		 * @virtual
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		copyDefaultCalendar: function(callback, scope) {
			this.BPMSoft.chain(
					this.copyDefaultCalendarData,
					this.updateCalendarData,
					function() {
						this.Ext.callback(callback, scope || this);
					}, this
			);
		},

		/**
		 * Returns identifier of the default personal calendar.
		 * @return {Guid} identifier of the default personal calendar.
		 */
		getBaseUserCalendarId: function() {
			return this.get("BaseUserCalendarId");
		},

		/**
		 * Returns update query for calendar.
		 * @return {BPMSoft.UpdateQuery} Update query for calendar.
		 */
		getDefaultCalendarUpdateQuery: function() {
			var update = this.Ext.create("BPMSoft.UpdateQuery", {
				rootSchemaName: "Calendar"
			});
			update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Id", this.getUserCalendarId()));
			this.setUserCalendarParameterValues(update);
			return update;
		},

		/**
		 * Sends request to update copied calendar with values.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		updateCalendarData: function(callback, scope) {
			var update = this.getDefaultCalendarUpdateQuery();
			update.execute(function(response) {
				if (response.success) {
					callback.call(scope || this);
				} else {
					this.generateException(response.errorInfo);
				}
			}, this);
		},

		/**
		 * Sends request to copy calendar.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		copyDefaultCalendarData: function(callback, scope) {
			var requestConfig = this.getCopyCalendarRequestConfig();
			this.callService(requestConfig, function(response) {
				if (response && response.CloneCalendarResult &&
						response.CloneCalendarResult.CalendarId) {
					this.set("UserCalendarId", response.CloneCalendarResult.CalendarId);
					this.Ext.callback(callback, scope || this, [callback, scope]);
				} else {
					var message = response &&
							response.CloneCalendarResult &&
							response.CloneCalendarResult.errorInfo &&
							response.CloneCalendarResult.errorInfo.message;
					throw new this.BPMSoft.UnknownException({
						message: message
					});
				}
			}, this);
		},

		/**
		 * Returns identifier of the personal calendar.
		 * @protected
		 * @param {Boolean} [isNeedCreate] True if need to create.
		 * @return {Guid} Identifier of the personal calendar.
		 */
		getUserCalendarId: function(isNeedCreate) {
			var attributeName = "UserCalendarId";
			var result = this.get(attributeName);
			if (this.isEmpty(result) && isNeedCreate) {
				result = this.BPMSoft.generateGUID();
				this.set(attributeName, result);
			}
			return result;
		},

		/**
		 * Returns request objects for the copy.
		 * @protected
		 * @virtual
		 * @return {Object} Configuration object.
		 */
		getCopyCalendarRequestConfig: function() {
			var baseUserCalendar = this.getBaseUserCalendarId();
			return {
				serviceName: "CalendarService",
				methodName: "CloneCalendar",
				data: {
					calendarId: baseUserCalendar
				}
			};
		},

		/**
		 * Returns personal calendar template of the name.
		 * @protected
		 * @virtual
		 * @return {String} Personal calendar template of the name.
		 */
		getUserCalendarNameTemplate: function() {
			return resources.localizableStrings.UserCalendarNameTemplate;
		},

		/**
		 * Initializes calendar query filters.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
		 */
		initUserCalendarQueryFilters: this.BPMSoft.emptyFn,

		/**
		 * Sets parameter value to insert query.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.InsertQuery} insert Insert query.
		 */
		setUserCalendarParameterValues: this.BPMSoft.emptyFn,

		/**
		 * Returns name of the personal calendar.
		 * @protected
		 * @virtual
		 * @return {String} Name of the personal calendar.
		 */
		getUserCalendarName: this.BPMSoft.emptyFn
	});
	return this.Ext.create("BPMSoft.configuration.mixins.UserCalendarMixin");
});
