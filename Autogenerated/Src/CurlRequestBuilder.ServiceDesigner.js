define("CurlRequestBuilder", ["CurlJsonConverter"], function() {
	return {
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_prepareMethodType: function(method) {
				this.$ParsedMethodType = {
					displayValue: method.request.findHttpMethodTypeName(),
					value: method.request.httpMethodType
				};
				delete this.changedValues.ParsedMethodType;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#getMergeOptions
			 * @override
			 */
			getMergeOptions: function() {
				return {
					skipUri: !this.changedValues.ParsedMethodUri,
					skipHttpMethodType: false,
					useAuth: this.$ParsedMethod.useAuthInfo
				};
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#parseMethod
			 * @override
			 */
			parseMethod: function() {
				var result;
				if (this.$InputData) {
					var curlToJsonConverter = this.Ext.create("BPMSoft.CurlJsonConverter");
					var json = curlToJsonConverter.convert(this.$InputData);
					if (json) {
						var jsonToParametersConverter = this.Ext.create("BPMSoft.JsonServiceMetaDataConverter", {
							codePrefix: BPMSoft.ServiceSchemaManager.schemaNamePrefix
						});
						result = jsonToParametersConverter.convert(json);
						this.prepareUri(result);
						this._prepareMethodType(result);
					}
				}
				return result;
			}

			//endregion

		}
	};
});
