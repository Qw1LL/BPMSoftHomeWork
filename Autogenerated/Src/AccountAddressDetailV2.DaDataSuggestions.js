define("AccountAddressDetailV2", [], function() {
	return {
		entitySchemaName: "AccountAddress",
		diff: /**SCHEMA_DIFF*/ [] /**SCHEMA_DIFF*/,
		messages: {
			"UpdateAddressRow": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"SetNewMainAddress": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		methods: {

			subscribeGridEvents: function(){
				this.sandbox.subscribe("UpdateAddressRow", this.updateAddressRow, this);
				this.callParent();
			},

			

			updateAddressRow: function([address, primaryId, forceToInsert]){
				let collection = this.get("Collection");
				const addressItems = collection.collection.items;
				const alreadyExistAdresses = addressItems.filter((addressItem) => addressItem.get("Address") === address.Address)
				if(forceToInsert && primaryId){
					const primaryAddressItems = addressItems.filter((addressItem) => addressItem.get("Primary"))
					primaryId = primaryAddressItems[primaryAddressItems.length - 1].get("Id");
					address.Id = primaryId;
				}
				if(alreadyExistAdresses.length > 0){
					this.sandbox.publish("SetNewMainAddress", null)
					return;
				}
				const isCollectionEmpty = collection.isEmpty();
				collection.each((addressItem) => {
					addressItem.set("Primary", false);
				})
				if (isCollectionEmpty || (forceToInsert && !primaryId)){
					let rowConfig = this.getRowConfig();
					let viewModel = this.createViewModel({
						rowConfig: rowConfig,
						rawData: address,
						viewModel: {}
					});
					collection.add(address.Id, viewModel);
					if(isCollectionEmpty){
						this.set("IsGridEmpty", false)
						this.loadTempCollection();
					}
				} else if(primaryId){
					let primaryColumn = collection.get(primaryId)
					let addressKeys = Object.keys(address)
					for(addressKey of addressKeys){
						if(addressKey !== "Id"){
							primaryColumn.set(addressKey, address[addressKey])
						}
					}
				}  else {
					let firstUId = collection.collection.keys[0];
					let primaryColumn = collection.get(firstUId);
					let addressKeys = Object.keys(address)
					address.Id = firstUId;
					for(addressKey of addressKeys){
						primaryColumn.set(addressKey, address[addressKey])
					}
				}
				this.sandbox.publish("SetNewMainAddress", address)
			},

			getRowConfig: function(){
				return {
					Address: {dataValueType: 1, columnPath: 'Address'},
					AddressType: {dataValueType: 10, isLookup: true, referenceSchemaName: 'AddressType', columnPath: 'AddressType'},
					City: {dataValueType: 10, isLookup: true, referenceSchemaName: 'City', columnPath: 'City'},
					Country: {dataValueType: 10, isLookup: true, referenceSchemaName: 'Country', columnPath: 'Country'},
					EntryPointsCount: {dataValueType: 4, columnPath: 'EntryPointsCount'},
					GPSE: {dataValueType: 1, columnPath: 'GPSE'},
					GPSN: {dataValueType: 1, columnPath: 'GPSN'},
					Id: {dataValueType: 0, columnPath: 'Id'},
					Primary: {dataValueType: 12, columnPath: 'Primary'},
					Region: {dataValueType: 10, isLookup: true, referenceSchemaName: 'Region', columnPath: 'Region'},
					Zip: {dataValueType: 1, columnPath: 'Zip'}
				}
			}
		}
	};
});