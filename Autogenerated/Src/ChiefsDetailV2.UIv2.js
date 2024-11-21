define("ChiefsDetailV2", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "VwSysAdminUnit",
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc UsersDetailV2#initData
				 * @overridden
				 */
				initData: function() {
					this.callParent(arguments);
					this.subscribeEvents();
				},

				/**
				 * ######### ######## ## ####### ### ######.
				 */
				subscribeEvents: function() {
					this.sandbox.subscribe("GetChiefId", function() {
						return {
							parent: this.get("ChiefRole"),
							defaultValues: this.get("DefaultValues")
						};
					}, this, [this.getUsersDetailSandboxId()]);
					this.sandbox.subscribe("UpdateChiefDetail", function() {
						this.loadGridData();
					}, this, [this.sandbox.id]);
				},

				/**
				 * @inheritdoc UsersDetailV2#getTargetRoleId
				 * @overridden
				 */
				getTargetRoleId: function() {
					return this.get("ChiefRole");
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonEnabled
				 * @overridden
				 */
				getAddRecordButtonEnabled: function() {
					return this.get("IsAddRecordEnabled");
				},

				/**
				 * @inheritdoc GridUtilitiesV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					var isEmpty = this.Ext.isEmpty(this.get("SelectedNodesPrimaryColumnValues"));
					if (isEmpty) {
						this.set("gridEmpty", isEmpty);
						this.getGridData().clear();
					}
					if (this.get("ServiceDataLoaded")) {
						if (!isEmpty) {
							this.callParent(arguments);
						}
						this.set("ServiceDataLoaded", false);
						return;
					}
					this.selectChiefUnits(this.loadGridData);
				},

				/**
				 * ##### ######### ###### # ####, ####### ########## ############# ###### ############# ### ########
				 * #############.
				 * @protected
				 * @param {Function} callback ####### ######### ######, ####### ########## ##### ####,
				 * ### ######### ######.
				 */
				selectChiefUnits: function(callback) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "VwSysAdminUnit"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("ParentRole");
					esq.addColumn("SysAdminUnitType");
					esq.filters.add("ParentRoleFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "ParentRole", this.get("MasterRecordId")));
					esq.filters.add("TypeFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitType",
						ConfigurationConstants.SysAdminUnit.TypeGuid.Manager));
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							if (response.collection.getCount() === 0) {
								this.set("SelectedNodesPrimaryColumnValues", []);
								this.sandbox.publish("GetChiefsSysAdminUnits", null, [this.sandbox.id]);
								this.set("IsAddRecordEnabled", false);
							} else {
								var result = response.collection.getItems()[0];
								var id = result.get("Id");
								this.set("SelectedNodesPrimaryColumnValues", [id]);
								this.set("ChiefRole", id);
								this.sandbox.publish("GetChiefsSysAdminUnits", {
									SysAdminUnitType: result.get("SysAdminUnitType").value,
									ParentRole: result.get("ParentRole").value,
									Name: result.get("Name"),
									Id: id
								}, [this.sandbox.id]);
								this.set("IsAddRecordEnabled", true);
							}
							this.set("ServiceDataLoaded", true);
							if (this.Ext.isFunction(callback)) {
								callback.call(this);
							}
						}
					}, this);
				},

				/**
				 * @inheritdoc BaseGridDetailV2#getFilters
				 * @overridden
				 **/
				getFilters: function() {
					var filters = this.get("DetailFilters");
					var serializationInfo = filters.getDefSerializationInfo();
					serializationInfo.serializeFilterManagerInfo = true;
					var deserializedFilters = BPMSoft.deserialize(filters.serialize(serializationInfo));
					deserializedFilters.addItem(this.BPMSoft.createColumnInFilterWithParameters(
						"[SysUserInRole:SysUser:Id].[SysAdminUnit:Id:SysRole].Id",
						this.get("SelectedNodesPrimaryColumnValues")));
					return deserializedFilters;
				}
			},
			messages: {
				"GetChiefsSysAdminUnits": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * ############ ### ######## ############## ####### #### ############.
				 */
				"GetChiefId": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * ############ ### #########, ### #### ######### ### ####### #### # ##### ############# ######.
				 */
				"UpdateChiefDetail": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			}
		};
	});
