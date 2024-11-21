define("SectionDashboardsViewModel", ["ext-base", "DashboardBuilder"],
	function() {
		/**
		 * @class BPMSoft.configuration.SectionDashboardsViewModel
		 * Section dashboard view model class.
		 */
		return Ext.define("BPMSoft.configuration.SectionDashboardsViewModel", {
			extend: "BPMSoft.BaseDashboardsViewModel",
			alternateClassName: "BPMSoft.SectionDashboardsViewModel",

			//region Methods: Private

			/**
			 * @private
			 */
			_onActiveViewChanged: function(activeViewName) {
				if (activeViewName !== this.$DashboardDataViewName) {
					var dashboardModuleId = this.getDashboardModuleId();
					this.sandbox.unloadModule(dashboardModuleId, "DashboardModuleContainer");
				}
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseDashboardsViewModel#initHeader
			 * @overridden
			 */
			initHeader: Ext.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseDashboardsViewModel#getMessages
			 * @overridden
			 */
			getMessages: function() {
				var messages = this.callParent(arguments);
				return Ext.apply(messages, {
					ActiveViewChanged: {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseDashboardsViewModel#subscribeSandboxMessages
			 * @overridden
			 */
			subscribeSandboxMessages: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("ActiveViewChanged", this._onActiveViewChanged, this);
			}

			//endregion

		});
	});
