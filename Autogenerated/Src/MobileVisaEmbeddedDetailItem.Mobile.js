/**
 * Embedded detail for visa.
 */
Ext.define("BPMSoft.configuration.controls.VisaEmbeddedDetailItem",{
	extend: "Ext.Component",
	xtype: "cfvisaedetailitem",

	config: {
		parentModelName: null,
		record: null,
	},

	/**
	 * @private
	 */
	component: null,

	/**
	 * @internal
	 */
	isEmbeddedDetailItem: true,

	/**
	 * @private
	 */
	getComponentConfig: function() {
		return {
			xtype: "container",
			layout: {
				type: "vbox"
			},
			items: [this.getObjectiveComponentConfig(), this.getButtonsPanelConfig()]
		};
	},

	/**
	 * @private
	 */
	getButtonsPanelConfig: function() {
		return {
			xtype: "container",
			docked: "bottom",
			layout: {
				pack: "start",
				align: "center",
				type: "hbox"
			},
			items: [{
				xtype: "button",
				text: BPMSoft.LS.VisaEmbeddedDetailItemApproveButton,
				flex: 1,
				iconAlign: "top",
				iconCls: "cf-visaedetail-approve-icon",
				listeners: {
					tap: this.onApproveButtonTap,
					scope: this
				}
			}, {
				xtype: "button",
				text: BPMSoft.LS.VisaEmbeddedDetailItemRejectButton,
				flex: 1,
				iconAlign: "top",
				iconCls: "cf-visaedetail-reject-icon",
				listeners: {
					tap: this.onRejectButtonTap,
					scope: this
				}
			}]
		};
	},

	/**
	 * @private
	 */
	getObjectiveComponentConfig: function() {
		var record = this.getRecord();
		var imageStyle = BPMSoft.ImageUtils.getModuleImageStyle(this.getParentModelName());
		var template =
			"<div  class=\"cf-visaedetail-objective\">" +
			"<div style=\"{1}\" class=\"cf-visaedetail-objective-image\"></div>" +
			"<div class=\"cf-visaedetail-objective-title\">{0}</div>" +
			"</div>";
		var objective = record.get("Objective");
		if (Ext.isEmpty(objective)) {
			objective = BPMSoft.LS.VisaEmbeddedDetailItemDefaultObjective;
		}
		var html = Ext.String.format(template, objective, imageStyle);
		return {
			xtype: "component",
			html: html
		};
	},

	/**
	 * @cfg-updater
	 * @param {BPMSoft.BaseModel} record.
	 */
	updateRecord: function(record) {
		Ext.destroy(this.component);
		if (record !== null) {
			this.component = Ext.factory(this.getComponentConfig());
			this.element.appendChild(this.component.element);
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @override
	 */
	initialize: function() {
		this.callParent(arguments);
		this.addCls(["x-edetail-item", "x-view-edetail-item", "cf-visaedetail"]);
	},

	/**
	 * Called when approve button has been tapped.
	 * @protected
	 * @virtual
	 */
	onApproveButtonTap: function() {
		var action = Ext.create("BPMSoft.configuration.VisaApproveAction");
		action.on("executionend", this.onVisaActionExecutionEnd, this);
		action.execute(this.getRecord(), {
			parentModelName: this.getParentModelName()
		});
	},

	/**
	 * Called when reject button has been tapped.
	 * @protected
	 * @virtual
	 */
	onRejectButtonTap: function() {
		var action = Ext.create("BPMSoft.configuration.VisaRejectAction");
		action.on("executionend", this.onVisaActionExecutionEnd, this);
		action.execute(this.getRecord(), {
			parentModelName: this.getParentModelName()
		});
	},

	/**
	 * Called when the visa action has completed.
	 * @protected
	 * @virtual
	 */
	onVisaActionExecutionEnd: function(action, result) {
		if (result) {
			this.hide();
		}
	}

});
