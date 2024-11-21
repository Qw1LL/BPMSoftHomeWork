define("DcmSchemaStagePermission", ["ext-base", "BPMSoft"],
	function(Ext, BPMSoft) {
		Ext.define("BPMSoft.Designers.DcmSchemaStagePermission", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.DcmSchemaStagePermission",

			/**
			 * Collection of allowed SysAdminUnit identifiers changed stage.
			 * @type {BPMSoft.Collection}
			 */
			permissions: null,

			/**
			 * Collection of editable container list items.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			containerListItems: null,

			/**
			 * Separator for permission string.
			 */
			_separator: ",",

			/**
			 * Constructor for DcmSchemaStagePermission class.
			 */
			constructor: function() {
				this.callParent(arguments);
				BPMSoft.chain(
					this._initPermissions,
					this._initContainerItems,
					this
				);
			},

			// region Methods: Private

			/**
			 * Initialize container items collection.
			 * @private
			 * @param callback {Function} Callback function.
			 * @param scope {Object} Callback scope.
			 */
			_initContainerItems: function(callback, scope) {
				const select = this._getContainerItemsEsq();
				select.getEntityCollection(function(result) {
					if (result.success) {
						this.containerListItems = result.collection;
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Transformed string permissions to collection.
			 * @private
			 * @param callback {Function} Callback function.
			 * @param scope {Object} Callback scope.
			 */
			_initPermissions: function(callback, scope) {
				const permissionsString = this.permissions;
				const collection = Ext.create("BPMSoft.Collection");
				if (Ext.isString(permissionsString) && permissionsString) {
					const permissionsIds = permissionsString.split(this._separator);
					permissionsIds.forEach(function (id) {
						collection.add(id, id);
					}, this);
				}
				this.permissions = collection;
				Ext.callback(callback, scope);
			},

			/**
			 * Get ESQ for selecting SysAdminUnit.
			 * @private
			 * @return {BPMSoft.EntitySchemaQuery} ESQ for selecting SysAdminUnit.
			 */
			_getContainerItemsEsq: function() {
				const select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysAdminUnit",
					clientESQCacheParameters: {
						cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
						cacheGroup: "DcmStages",
						cacheItemName: "DcmStage"
					}
				});
				select.addColumn("Id");
				select.addColumn("Name");
				return select;
			},

			// endregion

			// region Methods: Protected

			/**
			 * Get transformed permissions collection.
			 * @protected
			 * @return {string} Transformed permissions collection.
			 */
			getPermissionsString: function() {
				const keys = this.permissions.getKeys();
				return keys.join(this._separator);
			},

			/**
			 * Gets collection for filling container.
			 * @protected
			 * @return {BPMSoft.BaseViewModelCollection} Collection for filling container.
			 */
			getContainerItems: function() {
				return this.containerListItems;
			},

			/**
			 * Reload permissions collection data.
			 * @protected
			 * @param {BPMSoft.Collection} collection Items that will be initialized permissions collection.
			 */
			reloadPermissions: function(collection) {
				this.permissions.reloadAll(collection);
			},

			/**
			 * Return true, if stage permissions already contains selected permissions.
			 * @protected
			 * @param {String} key Permission key.
			 * @return {boolean} True if stage permissions contains in SyAdminUnit.
			 */
			contains: function(key) {
				return this.permissions.contains(key);
			},

			/**
			 * Clear permissions collection - enabled readOnly stage state.
			 * @protected
			 */
			clearPermissions: function() {
				this.permissions.clear();
			}

			// endregion

		});

		return BPMSoft.Designers.DcmSchemaStagePermission;
	}
);
