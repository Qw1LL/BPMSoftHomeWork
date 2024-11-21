define("UriRequestBuilder", ["UriJsonConverter"], function() {
	return {
		attributes: {

			/**
			 * Request URI.
			 */
			Uri: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			/**
			 * Indicates if response parameters can be set up.
			 */
			SetupMethodType: { value: false }

		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_getUriParametersJson: function() {
				const uriConverter = new BPMSoft.UriJsonConverter();
				return uriConverter.convert(this.$Uri);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#getMergeOptions
			 * @override
			 */
			getMergeOptions: function() {
				return {
					skipUri: false,
					skipHttpMethodType: true
				};
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#parseMethod
			 * @override
			 */
			parseMethod: function() {
				var method;
				const metaDataConverter = this.Ext.create("BPMSoft.JsonServiceMetaDataConverter", {
					codePrefix: BPMSoft.ServiceSchemaManager.schemaNamePrefix
				});
				method = metaDataConverter.convert(this._getUriParametersJson());
				this.prepareUri(method);
				return method;
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritDoc BPMSoft.ModalBoxSchemaModule#init.
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						var moduleInfo = this.get("moduleInfo") || {};
						this.$Uri = moduleInfo.uri;
						this.parse();
						Ext.callback(callback, scope);
					}, this
				]);
			}

			//endregion
		}
	};
});
