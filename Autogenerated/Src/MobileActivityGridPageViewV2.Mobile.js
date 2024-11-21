BPMSoft.Configuration.ActivityGridModeTypes = {
	List: "tslist",
	Schedule: "tsschedule"
};

BPMSoft.Configuration.ActivitySchedulePeriods = {
	Day: 1,
	Week: 2,
	ThreeDay: 3,
	FiveDay: 5
};

Ext.define("BPMSoft.configuration.view.ActivityGridPage", {
	alternateClassName: "ActivityGridPage.View",
	extend: "BPMSoft.view.BaseGridPage.View",
	xtype: "activitygridpage",

	config: {

		id: "ActivityGridPage",

		grid: {
			xtype: BPMSoft.Configuration.ActivityGridModeTypes.Schedule,
			isFirePhantomItemEvents: true
		},

		ownerButton: false,

		refreshButton: false,

		periodSegmentedButton: false

	},

	/**
	 * Right filter container.
	 * @protected
	 * @type {Ext.Container}
	 */
	filterPanelRightContainer: null,

	/**
	 * @private
	 */
	getFilterPanelRightContainer: function() {
		if (!this.filterPanelRightContainer) {
			this.filterPanelRightContainer = Ext.create("Ext.Container", {
				layout: "hbox",
				docked: "right"
			});
			var filterPanel = this.getFilterPanel();
			filterPanel.add(this.filterPanelRightContainer);
		}
		return this.filterPanelRightContainer;
	},

	/**
	 * @private
	 */
	getActionStatusButton: function() {
		var actionsContaner = this.getActionsContainer();
		return actionsContaner.getComponent("actionStatus");
	},

	/**
	 * @protected
	 * @overridden
	 */
	applyGrid: function(newConfig) {
		if (!this.initializedByController) {
			return newConfig;
		}
		if (newConfig.xtype === BPMSoft.Configuration.ActivityGridModeTypes.Schedule) {
			newConfig.listeners = {
				scope: this,
				initialize: function(el) {
					this.fireEvent("initializegrid", el);
				}
			};
			newConfig.columnsBindingConfig = Ext.apply({}, newConfig.columnsBindingConfig, {
				title: this.getActivityTitle.bind(this)
			});
		}
		return this.callParent(arguments);
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-applier
	 */
	applyOwnerButton: function(newButton) {
		if (!newButton) {
			return false;
		}
		var config = {
			cls: "x-activity-grid-owner-button",
			iconCls: "",
			markerValue: "owner-button"
		};
		return Ext.factory(config, "Ext.Button", this.getOwnerButton());
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updateOwnerButton: function(newButton, oldButton) {
		if (newButton) {
			this.setOwnerButtonImage(null);
			var filterPanelRightContainer = this.getFilterPanelRightContainer();
			filterPanelRightContainer.insert(0, newButton);
		}
		if (oldButton) {
			Ext.destroy(oldButton);
		}
	},

	/* @protected
	 * @virtual
	 * @cfg-applier
	 */
	applyRefreshButton: function(value) {
		if (!value) {
			return false;
		}
		var config = {
			docked: "right",
			cls: "x-activity-grid-refresh-button",
			iconCls: "x-refresh-white-icon"
		};
		return Ext.factory(config, "Ext.Button", this.getRefreshButton());
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updateRefreshButton: function(newButton, oldButton) {
		if (oldButton) {
			Ext.destroy(oldButton);
		}
		if (newButton) {
			var navigationPanel = this.getNavigationPanel();
			navigationPanel.addButton(newButton);
		}
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-applier
	 */
	applyPeriodSegmentedButton: function(newValue, oldValue) {
		if (!newValue) {
			return false;
		}

		var config = {
			id: `${Ext.os.is.Phone ? 'SegmentedButtonMobile' : 'SegmentedButton'}`,
			cls: 'cf-activity-period-segmented-button',
			items: [
				{
					text: BPMSoft.LocalizableStrings.ActivityGridPageViewSchedulePeriodDay,
					itemId: BPMSoft.Configuration.ActivitySchedulePeriods.Day,
					markerValue: "day"
				},
				{
					text: '3 дня',
					itemId: BPMSoft.Configuration.ActivitySchedulePeriods.ThreeDay,
					markerValue: "threeDay"
				},
				{
					text: '5 дней',
					itemId: BPMSoft.Configuration.ActivitySchedulePeriods.FiveDay,
					markerValue: "fiveDay"
				},
				{
					text: BPMSoft.LocalizableStrings.ActivityGridPageViewSchedulePeriodWeek,
					itemId: BPMSoft.Configuration.ActivitySchedulePeriods.Week,
					markerValue: "week"
				}
			]
		};


		return Ext.factory(config, "Ext.SegmentedButton", oldValue);
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updatePeriodSegmentedButton: function(newSegmentedButton, oldSegmentedButton) {
		if (newSegmentedButton) {
			var filterPanelRightContainer = this.getFilterPanelRightContainer();
			filterPanelRightContainer.insert(0, newSegmentedButton);
		}
		if (oldSegmentedButton) {
			Ext.destroy(oldSegmentedButton);
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	getActivityTitle: function(record) {
		return record.get("Title");
	},

	createTodayButton: function() {
		return Ext.create("Ext.Button", {
			text: BPMSoft.LocalizableStrings.ActivityGridPageViewTodayCaption,
			markerValue: "today",
			cls: "x-button-primary-blue"
		});
	},

	setOwnerButtonImage: function(image) {
		var ownerButton = this.getOwnerButton();
		if (image) {
			ownerButton.removeCls("x-owner-default-image");
		} else {
			ownerButton.addCls("x-owner-default-image");
			image = BPMSoft.Configuration.getDefaultOwnerImage();
		}
		ownerButton.setIcon(image);
	},

	updateOwnerButtonPosition: function() {
		var ownerButton = this.getOwnerButton();
		if (!ownerButton) {
			return;
		}
		var filterPanelRightContainer = this.getFilterPanelRightContainer();
		filterPanelRightContainer.insert(0, ownerButton);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	isStateButtonDisabled: function() {
		return false;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onActionsButtonTap: function() {
		this.callParent(arguments);
		var actionStatusButton = this.getActionStatusButton();
		if (actionStatusButton) {
			actionStatusButton.hide();
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onActionsPickerHide: function() {
		this.callParent(arguments);
		var actionStatusButton = this.getActionStatusButton();
		if (actionStatusButton) {
			actionStatusButton.show();
		}
	}

}, function() {
	BPMSoft.util.writeStyles(
		"#ActivityGridPage .x-navigation-panel .x-title.cf-multi-modes .x-innerhtml:after {",
		BPMSoft.util.getImageStyleByImageId("MobileActivityGridPageViewV2IconArrowDown"),
		"}"
	);
	if (!BPMSoft.ApplicationUtils.isOnlineMode()) {
		BPMSoft.util.writeStyles(
			".x-navigation-panel.x-toolbar .x-button.x-activity-grid-owner-button.x-button-pressing {",
			"opacity: 1 !important;",
			"}"
		);
	}
});
