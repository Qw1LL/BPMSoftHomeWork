define("GeneralDetails", ["ext-base", "BPMSoft", "GeneralDetailsResources", "HtmlEditModule", "css!HtmlEditModule"],
		function(Ext, BPMSoft, resources) {

	var notesConfiguration = function(attributeName, detailConfig, controlConfig) {
		var noteDetail = {
			name: "notes",
			type: BPMSoft.ViewModelSchemaItem.GROUP,
			caption: resources.localizableStrings.NotesCaption,
			collapsed: true,
			collapsedchanged: { bindTo: "onDetailCollapsedChanged" },
			visible: true,
			leftWidth: "60%",
			rightWidth: "100%",
			wrapContainerClass: "control-group-container-notes",
			items: [
				{
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					captionVisible: false,
					name: attributeName,
					columnPath: attributeName,
					dataValueType: BPMSoft.DataValueType.TEXT,
					customConfig: {
						className: "BPMSoft.controls.HtmlEdit",
						margin: "24px 0px 0px",

						imageLoaded: { bindTo: "insertImagesToNotes" },
						images: { bindTo: "notesImagesCollection" }
					}
				}
			]
		};
		if (detailConfig || controlConfig) {
			Ext.Object.merge(noteDetail.items[0].customConfig, controlConfig);
			return Ext.Object.merge(noteDetail, detailConfig);
		} else {
			return noteDetail;
		}
	};

	var insertImagesToNotes = function InsertImages(files, scope) {
		BPMSoft.each(files, function(file) {
			var freader = new FileReader();
			freader.file = file;
			freader.onload = function(result) {
				var target = result.target;
				var file = target.file;
				var image = Ext.create("BPMSoft.BaseViewModel", {
					values: {
						fileName: file.name,
						url: target.result
					}
				});
				var imagesCollection = scope.get("notesImagesCollection");
				if (imagesCollection) {
					imagesCollection.add(imagesCollection.getUniqueKey(), image);
				}
			};
			freader.readAsDataURL(freader.file);
		}, scope);
	};

	var setNotesImagesCollection = function(scope) {
		scope.set("notesImagesCollection", new BPMSoft.BaseViewModelCollection());
	};

	function getFileEntitySchemaName(entityName) {
		return (entityName === "Lead") ? "File" + entityName : entityName + "File";
	}

	function getInFolderEntitySchemaName(entityName) {
		return entityName + "InFolder";
	}

	var fileConfiguration = function(filterPathName, visibleFunction, config) {
		var detailConfig = {
			schemaName: "FileDetailV2",
			entitySchemaName: getFileEntitySchemaName(filterPathName),
			filter: {
				masterColumn: "Id",
				detailColumn: filterPathName
			},
			/*visible: visibleFunction ? {bindTo: visibleFunction} : true,*/
			subscriber: function() {
			}
		};
		if (config) {
			Ext.apply(detailConfig, config);
		}
		return  detailConfig;
	};

	var visaConfiguration = function(filterPathName) {
		return {
			schemaName: "VisaDetailV2",
			entitySchemaName: filterPathName + "Visa",
			filter: {
				masterColumn: "Id",
				detailColumn: filterPathName
			}
		};
	};

	var inFolderConfiguration = function(filterPathName, folderVisibleFunction) {
		return {
			name: "inFolder",
			schemaName: "InFolderDetail",
			entitySchemaName: getInFolderEntitySchemaName(filterPathName),
			type: BPMSoft.ViewModelSchemaItem.DETAIL,
			filterPath: filterPathName,
			filterValuePath: "Id",
			caption: resources.localizableStrings.InFolderCaption,
			visible: folderVisibleFunction ? {
				bindTo: folderVisibleFunction
			} : true,
			leftWidth: "60%",
			rightWidth: "40%",
			wrapContainerClass: "control-group-container",
			collapsedchanged: { bindTo: "onDetailCollapsedChanged" }
		};
	};

	return {
		Notes: notesConfiguration,
		File: fileConfiguration,
		InFolder: inFolderConfiguration,
		insertImagesToNotes: insertImagesToNotes,
		setNotesImagesCollection: setNotesImagesCollection,
		Visa: visaConfiguration
	};
});
