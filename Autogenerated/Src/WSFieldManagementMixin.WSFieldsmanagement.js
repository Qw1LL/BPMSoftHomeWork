define("WSFieldManagementMixin", ["LoadProcessModules", "WSFieldManagementMixinResources", "jQuery", "WSInputMask", "ext-base", "BPMSoft", "sandbox"],
function(LoadProcessModules, resources) {
	var maskTimeout;
	var colorTimeout;
	var isPatternsRights = false, isColorRights = false;
	
	/**
	 * @class BPMSoft.configuration.mixins.WSFieldManagementMixin
	 */
	Ext.define("BPMSoft.configuration.mixins.WSFieldManagementMixin", {
		alternateClassName: "BPMSoft.WSFieldManagementMixin",
		
		colorTimeout: 0,
		
		/**
		* Обработка данных фильтра
		*/
		
		getFilterCollectionResult: function(FilterData, scope){
			var andOpertation = true;
			if (FilterData.logicalOperation == 1){
				andOpertation = false;
			}
			
			var $this = this;
			var result = false;
			//Проверяем коллекцию
			
			var collectionItems = [];
			FilterData.collection.items.forEach(function(item) {
				if (item.isEnabled){
					collectionItems.push(item);
				}
			});
			
			var collectionResults = [];
			collectionItems.forEach(function(item) {
					//Колонка на странице
					var column = "";
					
					if (item.leftExpression){
						if (item.leftExpression.columnPath){
							column = item.leftExpression.columnPath;
						}
					}
					
					if (column){
						//Массив вариантов
						if (item.rightExpressions || item.rightExpression){
							//if (item.rightExpressions.length){
								var rightExpressions = [];
								if (item.rightExpressions){
									rightExpressions = item.rightExpressions;
								} else {
									rightExpressions.push(item.rightExpression);
								}
								rightExpressions.forEach(function(rightitem) {
									if (rightitem.parameter){
										if (rightitem.parameter.value || (rightitem.parameter.value === false)){
											//Справочник
											if (rightitem.parameter.value.value){
												if (scope.get(column)){
													var comparisonResult = $this.getFilterComparisonResult(scope.get(column).value, rightitem.parameter.value.value, item.comparisonType);
													if (comparisonResult){
														collectionResults.push(comparisonResult);
													}
												}
											} else {
												var comparisonResult = $this.getFilterComparisonResult(scope.get(column), rightitem.parameter.value, item.comparisonType);
												if (comparisonResult){
													collectionResults.push(comparisonResult);
												}
											}
										}
									}
								});
							//}
						} else {
							//Один вариант
							if (item.rightExpression){
								
								var rightExpression = item.rightExpression;
								if (rightExpression.parameter){
									if (rightExpression.parameter.value){
										//Справочник
										if (rightExpression.parameter.value.value){
											if (scope.get(column)){
												var comparisonResult = $this.getFilterComparisonResult(scope.get(column).value, rightExpression.parameter.value.value, item.comparisonType);
												if (comparisonResult){
													collectionResults.push(comparisonResult);
												}
											}
										} else {
											var comparisonResult = $this.getFilterComparisonResult(scope.get(column), rightExpression.parameter.value, item.comparisonType);
											if (comparisonResult){
												collectionResults.push(comparisonResult);
											}
										}
									}
								}
							} else {
								var comparisonResult = $this.getFilterComparisonResult(scope.get(column), undefined, item.comparisonType);
								if (comparisonResult){
									collectionResults.push(comparisonResult);
								}
							}
						}
					} else {
						//Вложенный фильтр
						if (item.collection){
							var insideFilterResult = $this.getFilterCollectionResult(item, scope);
							collectionResults.push(insideFilterResult);
						}
					}
			});
			
			var collectionFinishResults = [];
			collectionResults.forEach(function(item) {
				if (item){
					collectionFinishResults.push(item);
				}
			});
			
			if (collectionFinishResults.length){
				if (collectionItems.length == collectionFinishResults.length){
					result = true;
				} else {
					if (!andOpertation){
						result = true;
					}
				}
			}
			return result;
		},
		
		//Сравнение
		getFilterComparisonResult: function(columnvalue, value, type){
			var result = false;
			switch (type) {
				//Не Заполнен
				case 1: {
					if (!columnvalue){
						result = true;
					}
					break;
				};
				//заполнен
				case 2: {
					if (columnvalue){
						result = true;
					}
					break;
				};
				//Равенство
				case 3: {
					if (columnvalue == value){
						result = true;
					}
					break;
				};
				//Не равенство
				case 4: {
					if (columnvalue != value){
						result = true;
					}
					break;
				};
				//Меньше
				case 5: {
					if (columnvalue < value){
						result = true;
					}
					break;
				};
				//Меньше или равно
				case 6: {
					if (columnvalue <= value){
						result = true;
					}
					break;
				};
				//Больше
				case 7: {
					if (columnvalue > value){
						result = true;
					}
					break;
				};
				//Больше или равно
				case 8: {
					if (columnvalue >= value){
						result = true;
					}
					break;
				};
				//начинается на
				case 9: {
					if (columnvalue.indexOf(value) == 0){
						result = true;
					}
					break;
				};
				//Не начинается на
				case 10: {
					if (columnvalue.indexOf(value) != 0){
						result = true;
					}
					break;
				};
				//Содержит
				case 11: {
					if (columnvalue.indexOf(value) !== -1){
						result = true;
					}
					break;
				};
				//Не содержит
				case 12: {
					if (columnvalue.indexOf(value) == -1){
						result = true;
					}
					break;
				};
				//Оканчивается на
				case 13: {
					if (columnvalue.substr(- (value.length)) == value){
						result = true;
					}
					break;
				};
				//Не оканчивается на
				case 14: {
					if (columnvalue.substr(- (value.length)) != value){
						result = true;
					}
					break;
				};
				default:
					break;
			}
			return result;
		},
		
		//Получение массива колонок
		getColumnsList: function(FilterData, resultArray){
			var $this = this;
			if (FilterData.collection && FilterData.isEnabled){
				if (FilterData.collection.items){
					if (FilterData.collection.items.length){
						FilterData.collection.items.forEach(function(item) {
							if (item.leftExpression){
								if (item.leftExpression.columnPath){
									resultArray.push(item.leftExpression.columnPath);
								}
							}
							//Вложенный фильтр
							if (item.collection){
								var insideFilterResult = $this.getColumnsList(item, resultArray);
								if (insideFilterResult.length){
									insideFilterResult.forEach(function(insideitem) {
										resultArray.push(insideitem);
									});
								}
							}
						});
					}
				}
			}
			return this.getUnique(resultArray);
		},
		
		//Уникализация массива
		getUnique: function (arr) {
		    var i = 0, current, length = arr.length, unique = [];
		    for (; i < length; i++) {
		    	current = arr[i];
		    	if (!~unique.indexOf(current)) {
		    		unique.push(current);
		    	}
		    }
		    return unique;
		},
		
		// ==== Цвета
		
		//Обновление полей
		reloadColors: function(){
			clearTimeout(colorTimeout);
			this.set("colorTimeout","");
			if (!isColorRights){
				return false;
			}
			
			var color = jQuery("input.hascolor");
			var color = jQuery(".hascolor");
			color.each(function (index, element) {
				jQuery(this).attr("style","");
				jQuery(this).closest(".base-edit").attr("style","");
				jQuery(this).closest(".control-wrap").attr("style","");
				jQuery(this).closest(".control-wrap").find("a").attr("style","");
			});
		},
		
		//Получение данных для окраски полей
		getFieldsColors: function(){
			this.reloadColors();
        	this.set("colorTimeout","");
        	if (!this.entitySchemaName){
        		return false;
        	}
            var $this = this;
            var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
			    rootSchemaName: "WSColourOfField"
			});
			
			esq.addColumn("WSColumnCode");
			esq.addColumn("WSName");
			//esq.addColumn("WSFolder");
			//esq.addColumn("WSFolder.Name","Name");
			esq.addColumn("WSColor");
			esq.addColumn("WSContact");
			esq.addColumn("WSColorFont");
			esq.addColumn("WSSerializedFilter");
			
			var subFilter = BPMSoft.createFilterGroup();
			subFilter.setLogicalOperation(1);
			subFilter.add("ServiceItemFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSFolder.Name", this.entitySchemaName));
			subFilter.add("WSModuleNameFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSModuleName", this.entitySchemaName));
			esq.filters.add("subFilter",subFilter);
			
			esq.filters.add("ContactFilter2", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSContact", BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
			esq.filters.add("ServiceItemFilter2", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSActive", true));
			esq.filters.add("TypeFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColorRuleType", "a08d7efd-6ca5-4ba3-86bb-35d4ebd7e02e"));
			
			esq.getEntityCollection(function (result) {
			    if (!result.success) {
			        // обработка/логирование ошибки, например
			        console.log("Ошибка запроса данных");
			        return;
			    }
			    var columnsRegExp = [];
			    result.collection.each(function(item) {
			    	var columnsRegExpData = {};
			    	columnsRegExpData.WSColumnCode = item.get("WSColumnCode");
			    	columnsRegExpData.WSColor = item.get("WSColor");
			    	columnsRegExpData.WSColorFont = item.get("WSColorFont");
			    	columnsRegExpData.WSSerializedFilter = item.get("WSSerializedFilter");
			    	columnsRegExp.push(columnsRegExpData);
				});
				
				columnsRegExp.forEach(function(item) {
				    if (item.WSColor != ""){
					    $this.set(item.WSColumnCode + "WSColor",item.WSColor);
				    }
				    if (item.WSColorFont != ""){
					    $this.set(item.WSColumnCode + "WSColorFont",item.WSColorFont);
				    }
				    if ((item.WSColor != "") || (item.WSColorFont != "")){
				    	$this.set(item.WSColumnCode + "WSColorFilterRule",item.WSSerializedFilter);
				    }
				});
				if (columnsRegExp.length){
					isColorRights = true;
					$this.loadColorColumns(true, columnsRegExp);
				}
				
				//Тест - получение списка всех ролей пользователя
				var usresq = Ext.create("BPMSoft.EntitySchemaQuery", {
                    rootSchemaName: "SysUserInRole"
                });
                var usrfilter = this.BPMSoft.createColumnFilterWithParameter(
                        this.BPMSoft.ComparisonType.EQUAL,
                        "SysUser",
                        BPMSoft.core.enums.SysValue.CURRENT_USER.value
                );
                
                usresq.filters.addItem(usrfilter);
                usresq.addColumn("SysRole");
                usresq.addColumn("[SysAdminUnit:Id:SysRole].Name", "AuName");
                usresq.addColumn("[SysAdminUnit:Id:SysRole].ParentRole", "Parent");
                usresq.getEntityCollection(function(response) {
                 	if (!response.success) {
                        console.log("Ошибка запроса данных");
                        return;
                    }
                    
                    var Roles = [];
                    response.collection.each(function(item) {
                   		Roles.push(item.get("SysRole").value);
                    });
                    
                    var funcesq = Ext.create("BPMSoft.EntitySchemaQuery", {
	                    rootSchemaName: "SysFuncRoleInOrgRole"
	                });
	                
	                funcesq.filters.add("FuncRoleFilter", $this.BPMSoft.createColumnInFilterWithParameters("OrgRole", Roles));
	                funcesq.addColumn("FuncRole");
	                
	                funcesq.getEntityCollection(function(funcresponse) {
	                 	if (!funcresponse.success) {
	                        console.log("Ошибка запроса данных");
	                        return;
	                    }
	                    
	                    funcresponse.collection.each(function(funcitem) {
	                    	
	                    	var isInRole = false;
		                    Roles.forEach(function(roleitem, i, arr) {
								if (roleitem == funcitem.get("FuncRole").value){
									isInRole = true;
								}
							});
	                    	
	                    	if (!isInRole){
	                   			Roles.push(funcitem.get("FuncRole").value);
	                    	}
	                    });
	                    
	                    //Далее ищем есть ли раскрашивания с ролями
	                    var coloresq = Ext.create("BPMSoft.EntitySchemaQuery", {
						    rootSchemaName: "WSColourOfField"
						});
						
						coloresq.addColumn("WSColumnCode");
						coloresq.addColumn("WSName");
						//coloresq.addColumn("WSFolder");
						//coloresq.addColumn("WSFolder.Name","Name");
						coloresq.addColumn("WSColor");
						coloresq.addColumn("WSContact");
						coloresq.addColumn("WSColorFont");
						coloresq.addColumn("ModifiedOn");
						coloresq.addColumn("WSSerializedFilter");
						
						var subFilter = BPMSoft.createFilterGroup();
						subFilter.setLogicalOperation(1);
						subFilter.add("ServiceItemFilter", $this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSFolder.Name", $this.entitySchemaName));
						subFilter.add("WSModuleNameFilter", $this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSModuleName", $this.entitySchemaName));
						coloresq.filters.add("subFilter",subFilter);
						
						coloresq.filters.add("RoleFilter2", $this.BPMSoft.createColumnInFilterWithParameters("WSRole", Roles));
						coloresq.filters.add("ServiceItemFilter2", $this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSActive", true));
						coloresq.filters.add("TypeFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColorRuleType", "a08d7efd-6ca5-4ba3-86bb-35d4ebd7e02e"));
						
						coloresq.getEntityCollection(function (colorresult) {
						    if (!colorresult.success) {
						        // обработка/логирование ошибки, например
						        console.log("Ошибка запроса данных");
						        return;
						    }
						    
						    //columnsRegExp = [];
						    colorresult.collection.each(function(coloritem) {
						    	
						    	var newColumn = true;
						    	columnsRegExp.forEach(function(columnsRegExpitem){
						    		if ((columnsRegExpitem.WSColumnCode == coloritem.get("WSColumnCode")) && (columnsRegExpitem.WSSerializedFilter == coloritem.get("WSSerializedFilter")) ){
						    			newColumn = false;
						    		}
						    	});
						    	if (newColumn){
							    	var columnsRegExpData = {};
							    	columnsRegExpData.WSColumnCode = coloritem.get("WSColumnCode");
							    	columnsRegExpData.WSColor = coloritem.get("WSColor");
							    	columnsRegExpData.WSColorFont = coloritem.get("WSColorFont");
							    	columnsRegExpData.ModifiedOn = coloritem.get("ModifiedOn");
							    	columnsRegExpData.WSSerializedFilter = coloritem.get("WSSerializedFilter");
							    	columnsRegExp.push(columnsRegExpData);
						    	}
							});
							
							//Что делать, если несколько??
							//Сначала самые последние по изменению
							columnsRegExp.sort(function compareAge(A, B) {
						    	return A.ModifiedOn - B.ModifiedOn;
						    });
							
							columnsRegExp.forEach(function(item) {
								
								if (item.WSColor != ""){
									if (!$this.get(item.WSColumnCode + "WSColor")){
									    $this.set(item.WSColumnCode + "WSColor",item.WSColor);
								    }
								}
							    if (item.WSColorFont != ""){
							    	if (!$this.get(item.WSColumnCode + "WSColorFont")){
								    	$this.set(item.WSColumnCode + "WSColorFont",item.WSColorFont);
							    	}
							    }
							    
							    if ((item.WSColor != "") || (item.WSColorFont != "")){
							    	if (!$this.get(item.WSColumnCode + "WSColorFilterRule")){
							    		$this.set(item.WSColumnCode + "WSColorFilterRule",item.WSSerializedFilter);
							    	}
							    }
							});
							if (columnsRegExp.length){
								isColorRights = true;
								$this.loadColorColumns(true, columnsRegExp);
							}
						}, this);
	                    
	                }, this);
	                
                }, this);
				
			},this);
		},
		
		//Загрузка цветов
		loadColorColumns: function(load, columnsRegExp, isColorRightsFromFunction){
			if (!isColorRights && !isColorRightsFromFunction){
				return false;
			}
        	var $this = this;
        	
        	if (!this.entitySchema){
        		var color = jQuery(".hascolor");
				color.each(function (index, element) {
					jQuery(this).removeClass("hascolor");
				});
        		return false;
        	}
        	
        	var $this = this;
        	var columns = this.entitySchema.columns;
        	var colorColumns = [];
        	
			var color = jQuery(".hascolor");
			color.each(function (index, element) {
				jQuery(this).removeClass("hascolor");
			});
			
			if (columnsRegExp){
				$this.set("WSColorColumnsRegExp", JSON.stringify(columnsRegExp));
			} else {
				if ($this.get("WSColorColumnsRegExp") && ($this.get("WSColorColumnsRegExp") != "[]")){
					columnsRegExp = JSON.parse($this.get("WSColorColumnsRegExp"));
				}
			}
        	//Перебор
        	if (columnsRegExp){
                columnsRegExp.forEach(function(columnitem){
                	//for (key in columns) {
                        if (/*columns[key].columnPath == */columnitem.WSColumnCode){
							$this.set(columnitem.WSColumnCode + "isHasColor",false);

							if ( (columnitem.WSColor) || (columnitem.WSColorFont) ){

								var FilterResult = true;
								if ((columnitem.WSSerializedFilter)){
									if ((columnitem.WSSerializedFilter) != ""){
										if (JSON.stringify(JSON.parse((columnitem.WSSerializedFilter))) != "{}"){
											var FilterData = BPMSoft.deserialize(columnitem.WSSerializedFilter);
											if (FilterData.collection && FilterData.isEnabled){
												if (FilterData.collection.items){
													if (FilterData.collection.items.length){
														FilterResult = $this.getFilterCollectionResult(FilterData, $this);
													}
												}
											}
										}
									}
								}

								if (FilterResult){
									var colorColumnsData = {};
									colorColumnsData.columnPath = columnitem.WSColumnCode;//columns[key].columnPath;
									colorColumnsData.WSColor = columnitem.WSColor;
									colorColumnsData.WSColorFont = columnitem.WSColorFont;
									colorColumns.push(colorColumnsData);
								}
							}
                        }
					//}
                });
        	}
        	
			clearTimeout(colorTimeout);
			
			if (colorColumns.length){
				$this.loadColor(colorColumns);
			}
        },
        
        loadColor: function(columnsArray){
        	
        	var $this = this;
        	
        	for (var k = 0; k<columnsArray.length; k++){
				
				var input = columnsArray[k].columnPath;
				var WSColor = columnsArray[k].WSColor;
				var WSColorFont = columnsArray[k].WSColorFont;
				
				var color = jQuery("input[id*='ST" + input + "ND']");
				
				color.each(function (index, element) {
					if (!jQuery(this).hasClass("hascolor")){
						if (WSColor){
							if (WSColor.charAt(0) != "#"){
								WSColor = "#" + WSColor;
							}
							jQuery(this).css("background-color", "transparent");
							jQuery(this).closest(".base-edit").css("background-color", "transparent");
							jQuery(this).closest(".control-wrap").css("background-color", WSColor);
						}
						if (WSColorFont){
							if (WSColorFont.charAt(0) != "#"){
								WSColorFont = "#" + WSColorFont;
							}
							jQuery(this).css("color", WSColorFont);
							jQuery(this).closest(".control-wrap").find("a").css("color", WSColorFont);
						}
						jQuery(this).addClass("hascolor");
						$this.set(input + "isHasColor",true);
						columnsArray[k].isLoad = true;
					}
				});
        	}
        	
        	var allLoads = true;
        	for (var k = 0; k<columnsArray.length; k++){
        		if (!columnsArray[k].isLoad){
        			allLoads = false;
        		}
        	}
        	if (!allLoads){
	        	clearTimeout(colorTimeout);
	        	colorTimeout = setTimeout(function() {$this.loadColor(columnsArray);}, 100);
        	}
        	
		},
		
		getGridColors: function(callback, typeGuid){
			var $this = this;
			var columnsRegExp = [], columnsArray = [];
            var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
			    rootSchemaName: "WSColourOfField"
			});
			
			esq.addColumn("WSColumnCode");
			esq.addColumn("WSName");
			//esq.addColumn("WSFolder");
			//esq.addColumn("WSFolder.Name","Name");
			esq.addColumn("WSColor");
			esq.addColumn("WSContact");
			esq.addColumn("WSColorFont");
			esq.addColumn("WSSerializedFilter");
			esq.addColumn("WSColorRuleType");
			
			var WSPriority = esq.addColumn("WSPriority", "WSPriority");
			WSPriority.orderPosition = 0;
			WSPriority.orderDirection = BPMSoft.OrderDirection.DESC;
			
			var subFilter = BPMSoft.createFilterGroup();
			subFilter.setLogicalOperation(1);
			subFilter.add("ServiceItemFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSFolder.Name", this.entitySchemaName));
			subFilter.add("WSModuleNameFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSModuleName", this.entitySchemaName));
			esq.filters.add("subFilter",subFilter);
			
			esq.filters.add("ContactFilter2", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSContact", BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
			esq.filters.add("ServiceItemFilter2", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSActive", true));
			
			var typeFilter = this.BPMSoft.createFilterGroup();
			typeFilter.setLogicalOperation(1);
				
			typeFilter.add("sectionFilter",  this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColorRuleType", typeGuid));
			typeFilter.add("allGridsFilter",  this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColorRuleType", "89859b04-cf8c-451e-ae36-ba7ab1957285"));
			
			esq.filters.add("TypeFilter", typeFilter);
			
			esq.getEntityCollection(function (result) {
			    if (!result.success) {
			        // обработка/логирование ошибки, например
			        console.log("Ошибка запроса данных");
			        if (callback) {
		               callback.call($this);
		            }
			        return;
			    }
			    
				//Сначала - для отдельных деталей
			    result.collection.each(function(item) {
			    	if (item.get("WSColorRuleType")){
			    		if (item.get("WSColorRuleType").value == typeGuid){
					    	var columnsRegExpData = {};
					    	columnsRegExpData.WSColor = item.get("WSColor");
					    	columnsRegExpData.WSColorFont = item.get("WSColorFont");
					    	columnsRegExpData.WSSerializedFilter = item.get("WSSerializedFilter");
					    	columnsRegExp.push(columnsRegExpData);
					    	if (item.get("WSSerializedFilter")){
						    	var FilterData = BPMSoft.deserialize(item.get("WSSerializedFilter"));
						    	columnsArray = $this.getColumnsList(FilterData, columnsArray);
					    	}
			    		}
			    	}
				});
				
				//Потом - общие правила
				result.collection.each(function(item) {
			    	
			    	if (item.get("WSColorRuleType")){
			    		if (item.get("WSColorRuleType").value == "89859b04-cf8c-451e-ae36-ba7ab1957285"){
			    			
			    			var isUpdate = true;
					    	columnsRegExp.forEach(function(columnitem, i) {
					    		if (columnitem.WSSerializedFilter == item.get("WSSerializedFilter")){
					    			isUpdate = false;
					    		}
					    	});
			    			
			    			if (isUpdate){
						    	var columnsRegExpData = {};
						    	columnsRegExpData.WSColor = item.get("WSColor");
						    	columnsRegExpData.WSColorFont = item.get("WSColorFont");
						    	columnsRegExpData.WSSerializedFilter = item.get("WSSerializedFilter");
						    	columnsRegExp.push(columnsRegExpData);
						    	if (item.get("WSSerializedFilter")){
							    	var FilterData = BPMSoft.deserialize(item.get("WSSerializedFilter"));
							    	columnsArray = $this.getColumnsList(FilterData, columnsArray);
						    	}
			    			}
			    		}
			    	}
				});
				
				//Тест - получение списка всех ролей пользователя
				var usresq = Ext.create("BPMSoft.EntitySchemaQuery", {
                    rootSchemaName: "SysUserInRole"
                });
                var usrfilter = this.BPMSoft.createColumnFilterWithParameter(
                        this.BPMSoft.ComparisonType.EQUAL,
                        "SysUser",
                        BPMSoft.core.enums.SysValue.CURRENT_USER.value
                );
                
                usresq.filters.addItem(usrfilter);
                usresq.addColumn("SysRole");
                usresq.addColumn("[SysAdminUnit:Id:SysRole].Name", "AuName");
                usresq.addColumn("[SysAdminUnit:Id:SysRole].ParentRole", "Parent");
                usresq.getEntityCollection(function(response) {
                 	if (!response.success) {
                        console.log("Ошибка запроса данных");
                        if (callback) {
		                    callback.call($this);
		                }
                        return;
                    }
                    
                    var Roles = [];
                    response.collection.each(function(item) {
                   		Roles.push(item.get("SysRole").value);
                    });
                    
                    var funcesq = Ext.create("BPMSoft.EntitySchemaQuery", {
	                    rootSchemaName: "SysFuncRoleInOrgRole"
	                });
	                
	                funcesq.filters.add("FuncRoleFilter", $this.BPMSoft.createColumnInFilterWithParameters("OrgRole", Roles));
	                funcesq.addColumn("FuncRole");
	                
	                funcesq.getEntityCollection(function(funcresponse) {
	                 	if (!funcresponse.success) {
	                        console.log("Ошибка запроса данных");
	                        return;
	                    }
	                    
	                    funcresponse.collection.each(function(funcitem) {
	                    	
	                    	var isInRole = false;
		                    Roles.forEach(function(roleitem, i, arr) {
								if (roleitem == funcitem.get("FuncRole").value){
									isInRole = true;
								}
							});
	                    	
	                    	if (!isInRole){
	                   			Roles.push(funcitem.get("FuncRole").value);
	                    	}
	                    });
	                    
	                    //Далее ищем есть ли раскрашивания с ролями
	                    var coloresq = Ext.create("BPMSoft.EntitySchemaQuery", {
						    rootSchemaName: "WSColourOfField"
						});
						
						coloresq.addColumn("WSColumnCode");
						coloresq.addColumn("WSName");
						//coloresq.addColumn("WSFolder");
						//coloresq.addColumn("WSFolder.Name","Name");
						coloresq.addColumn("WSColor");
						coloresq.addColumn("WSContact");
						coloresq.addColumn("WSColorFont");
						coloresq.addColumn("WSSerializedFilter");
						coloresq.addColumn("WSColorRuleType");
						
						var WSRolePriority = esq.addColumn("WSPriority", "WSPriority");
						WSRolePriority.orderPosition = 0;
						WSRolePriority.orderDirection = BPMSoft.OrderDirection.DESC;
						
						var modifiedOnColumn = coloresq.addColumn("ModifiedOn", "ModifiedOn");
						modifiedOnColumn.orderPosition = 0;
						modifiedOnColumn.orderDirection = BPMSoft.OrderDirection.DESC;
						
						var subFilter = BPMSoft.createFilterGroup();
						subFilter.setLogicalOperation(1);
						subFilter.add("ServiceItemFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSFolder.Name", this.entitySchemaName));
						subFilter.add("WSModuleNameFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSModuleName", this.entitySchemaName));
						coloresq.filters.add("subFilter",subFilter);
						
						coloresq.filters.add("RoleFilter2", $this.BPMSoft.createColumnInFilterWithParameters("WSRole", Roles));
						coloresq.filters.add("ServiceItemFilter2", $this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSActive", true));
						
						var typeColorFilter = this.BPMSoft.createFilterGroup();
						typeColorFilter.setLogicalOperation(1);
							
						typeColorFilter.add("sectionFilter",  this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColorRuleType", typeGuid));
						typeColorFilter.add("allGridsFilter",  this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColorRuleType", "89859b04-cf8c-451e-ae36-ba7ab1957285"));
						
						coloresq.filters.add("TypeFilter", typeColorFilter);
						
						coloresq.getEntityCollection(function (colorresult) {
						    if (!colorresult.success) {
						        // обработка/логирование ошибки, например
						        console.log("Ошибка запроса данных");
						        if (callback) {
				                    callback.call($this);
				                }
						        return;
						    }
						    
						    //Сначала - для отдельных деталей
						    colorresult.collection.each(function(coloritem) {
						    	
						    	if (coloritem.get("WSColorRuleType")){
						    		if (coloritem.get("WSColorRuleType").value == typeGuid){
								    	var isUpdate = true;
								    	columnsRegExp.forEach(function(columnitem, i) {
								    		if (columnitem.WSSerializedFilter == coloritem.get("WSSerializedFilter")){
								    			isUpdate = false;
								    		}
								    	});
								    	if (isUpdate){
									    	var columnsRegExpData = {};
									    	columnsRegExpData.WSColor = coloritem.get("WSColor");
									    	columnsRegExpData.WSColorFont = coloritem.get("WSColorFont");
									    	columnsRegExpData.WSSerializedFilter = coloritem.get("WSSerializedFilter");
									    	columnsRegExp.push(columnsRegExpData);
								    	}
								    	if (coloritem.get("WSSerializedFilter")){
									    	var FilterData = BPMSoft.deserialize(coloritem.get("WSSerializedFilter"));
									    	columnsArray = $this.getColumnsList(FilterData, columnsArray);
								    	}
						    		}
						    	}
							});
							
							//После - общее
						    colorresult.collection.each(function(coloritem) {
						    	
						    	if (coloritem.get("WSColorRuleType")){
						    		if (coloritem.get("WSColorRuleType").value == "89859b04-cf8c-451e-ae36-ba7ab1957285"){
								    	var isUpdate = true;
								    	columnsRegExp.forEach(function(columnitem, i) {
								    		if (columnitem.WSSerializedFilter == coloritem.get("WSSerializedFilter")){
								    			isUpdate = false;
								    		}
								    	});
								    	if (isUpdate){
									    	var columnsRegExpData = {};
									    	columnsRegExpData.WSColor = coloritem.get("WSColor");
									    	columnsRegExpData.WSColorFont = coloritem.get("WSColorFont");
									    	columnsRegExpData.WSSerializedFilter = coloritem.get("WSSerializedFilter");
									    	columnsRegExp.push(columnsRegExpData);
									    	
									    	if (coloritem.get("WSSerializedFilter")){
										    	var FilterData = BPMSoft.deserialize(coloritem.get("WSSerializedFilter"));
										    	columnsArray = $this.getColumnsList(FilterData, columnsArray);
									    	}
								    	}
						    		}
						    	}
							});
							
							$this.set("colorColumnsArray",JSON.stringify(columnsArray));
							columnsRegExp.forEach(function(item, i) {
								var count = i+1;
							    if (item.WSColor != ""){
								    $this.set("WSColor" + count.toString(),item.WSColor);
							    }
							    if (item.WSColorFont != ""){
								    $this.set("WSColorFont" + count.toString(),item.WSColorFont);
							    }
							    
							    if ((item.WSColor != "") || (item.WSColorFont != "")){
							    	$this.set("WSColorFilterRule" + count.toString(),item.WSSerializedFilter);
							    }
							    
							    $this.set("maxColorFilterNum",count);
							});
						    
			   				if (callback) {
			                    callback.call($this);
			                }
							
						},this);
	                },this);
				},this);
			},this);
		},
		
		addColorGridDataColumns: function(esq){
			
			if (this.get("colorColumnsArray")){
				if ( (this.get("colorColumnsArray") != "") && (this.get("colorColumnsArray") != "[]") ){
					var colorColumnsArray = JSON.parse(this.get("colorColumnsArray"));
					colorColumnsArray.forEach(function(item) {
						esq.addColumn(item);
					});
				}
			}
		},
		
		setColorToResonceItem: function(item){
			var $this = this;
            if (this.get("maxColorFilterNum") > 0){
            	var maxColorFilterNum = this.get("maxColorFilterNum");
            	for (var i = 1; i<=maxColorFilterNum; i++){
            		
            		if ( $this.get("WSColor" + i) || $this.get("WSColorFont" + i) ){
						var FilterResult = true;
						if ($this.get("WSColorFilterRule" + i)){
							if ($this.get("WSColorFilterRule" + i) != ""){
								if (JSON.stringify(JSON.parse($this.get("WSColorFilterRule" + i)).items) != "{}"){
									var FilterData = BPMSoft.deserialize($this.get("WSColorFilterRule" + i));
									if (FilterData.collection && FilterData.isEnabled){
										if (FilterData.collection.items){
											if (FilterData.collection.items.length){
												FilterResult = $this.getFilterCollectionResult(FilterData, item);
												
											}
										}
									}
								}
							}
						}
						if (FilterResult){
							item.customStyle = null;
							item.customStyle = {
		                        "color": $this.get("WSColorFont" + i),
		                        "background": $this.get("WSColor" + i)
		                    };
						}
					}
            	}
            }
		},
		
		// ======================= Маски
		
		//Обновление масок
		reloadMasks: function(){
			clearTimeout(maskTimeout);
			this.set("maskTimeout","");
			this.set("countLoads",0);
		},
		
		resetPatterns: function(columnName, columnValue){
			if (isPatternsRights){
				this.reloadMasks();
				
				var $this = this;
				
				this.loadColumns(true);
				
				if (this.get("PatternCollection")){
					this.getCollectionPatternsData();
				}
			}
		},
		
		getPatternsData: function(){
			this.set("maxColumnValue",1);
        	this.set("maskTimeout","");
        	
            var $this = this;
            var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
			    rootSchemaName: "WSPattern"
			});
			
			esq.addColumn("WSColumnCode");
			esq.addColumn("WSRegular");
			esq.addColumn("WSNotes");
			esq.addColumn("WSName");
			//esq.addColumn("WSFolder");
			esq.addColumn("WSMask");
			//esq.addColumn("WSFolder.Name","Name");
			esq.addColumn("WSLookupCode");
			esq.addColumn("WSLookupGuid");
			esq.addColumn("WSJSCode");
			esq.addColumn("WSPermitSymbols");
			esq.addColumn("WSSerializedFilter");
			
			var subFilter = BPMSoft.createFilterGroup();
			subFilter.setLogicalOperation(1);
			subFilter.add("ServiceItemFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSFolder.Name", this.entitySchemaName));
			subFilter.add("WSModuleNameFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSModuleName", this.entitySchemaName));
			esq.filters.add("subFilter",subFilter);
			
			esq.filters.add("ServiceItemFilter2", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSIsActive", true));
			
			esq.getEntityCollection(function (result) {
			    if (!result.success) {
			        // обработка/логирование ошибки, например
			        console.log("Ошибка запроса данных");
			        return;
			    }
			    $this.set("PatternCollection",result.collection);
			    $this.getCollectionPatternsData();
			},this);
		},
		
		getCollectionPatternsData: function(){
			
			var patternsCollection = this.get("PatternCollection");
			var $this = this;
			
			var columnsRegExp = [];
		    patternsCollection.each(function(item) {
		    	var columnsRegExpData = {};
		    	columnsRegExpData.WSColumnCode = item.get("WSColumnCode");
		    	columnsRegExpData.WSRegExp = item.get("WSRegular");
		    	columnsRegExpData.WSNotes = item.get("WSNotes");
		    	columnsRegExpData.WSMask = item.get("WSMask");
		    	columnsRegExpData.WSLookupCode = item.get("WSLookupCode");
		    	columnsRegExpData.WSLookupGuid = item.get("WSLookupGuid");
		    	columnsRegExpData.WSPermitSymbols = item.get("WSPermitSymbols");
		    	columnsRegExpData.WSJSCode = item.get("WSJSCode").replace(/\r?\n/g, "");
		    	columnsRegExpData.WSSerializedFilter = item.get("WSSerializedFilter");
		    	columnsRegExp.push(columnsRegExpData);
		    	
		    	$this.set("usePatterns",true);
			});
			
			columnsRegExp.forEach(function(item, i) {
				
		    	if (item.WSLookupCode == ""){
			    	
			    	for (validkey in $this.validationConfig) {
		    			if (validkey == item.WSColumnCode){
		    				$this.validationConfig[validkey] = [];
		    			}
		    		}
			    	
			    	var FilterResult = true;
					if (item.WSSerializedFilter){
						if (item.WSSerializedFilter != ""){
							if (JSON.stringify(JSON.parse(item.WSSerializedFilter).items) != "{}"){
								var FilterData = BPMSoft.deserialize(item.WSSerializedFilter);
								if (FilterData.collection && FilterData.isEnabled){
									if (FilterData.collection.items){
										if (FilterData.collection.items.length){
											FilterResult = $this.getFilterCollectionResult(FilterData, $this);
										}
									}
								}
							}
						}
					}
			    	
			    	if (FilterResult){
			    		
			    		$this.set(item.WSColumnCode + "WSPatternFilterRule",item.WSSerializedFilter);
						$this.set(item.WSColumnCode + "ErrorText",item.WSNotes);
						$this.set(item.WSColumnCode + "Permit",item.WSPermitSymbols);
						$this.set(item.WSColumnCode + "Mask",item.WSMask);
						
						$this.set(item.WSColumnCode + "ErrorText",item.WSNotes);
				    	$this.set(item.WSColumnCode + "Permit",item.WSPermitSymbols);
				    	
				    	if (item.WSJSCode != ""){
				    		$this.set(item.WSColumnCode + "WSJSCode",item.WSJSCode);
				    	}
				    	
				    	if (item.WSRegExp != ""){
				    		$this.set(item.WSColumnCode + "RegExp",item.WSRegExp);
				    	}
			    		
			    		if ($this.get(item.WSColumnCode + "WSJSCode") || $this.get(item.WSColumnCode + "RegExp")){
						    $this.addColumnValidator(item.WSColumnCode, function(value){
								var invalidMessage = "";
				                var isValid = true;
				                var number = value || $this.get(item.WSColumnCode);
				                
				                if ($this.get(item.WSColumnCode + "RegExp")){
					                isValid = (Ext.isEmpty(number) ||
					                    new RegExp($this.get(item.WSColumnCode + "RegExp")).test(number));
				                }
				                
				                //Тут проверка по коду WSJSCode    
				                var isJSValid = true;
				                if ($this.get(item.WSColumnCode + "WSJSCode")){
				                	var isJSValids = function(){
				                		try{
				                			var scope = $this;
							                return eval("(function() {" + $this.get(item.WSColumnCode + "WSJSCode") + "})();");
				                		} catch(e){
				                			console.log(e);
				                			return true;
				                		}
				                	}
				                	isJSValid = isJSValids();
				                }
				                
				                isValid = isValid && isJSValid;
				                
				                if (!isValid) {
				                	var errorMessage = $this.get(item.WSColumnCode + "ErrorText");
				                	if (!errorMessage){
				                		errorMessage = $this.get("Resources.Strings.StandardErrorCaption");
				                	}
				                    invalidMessage = errorMessage;
				                }
				                return {
				                    invalidMessage: invalidMessage
				                };
							});
			    		}
						$this.validateColumn(item.WSColumnCode);
			    	} else {
			    		$this.set(item.WSColumnCode + "WSJSCode", "");
			    		$this.set(item.WSColumnCode + "RegExp", "");
			    	}
				}
			});
			
			if (!this.entitySchema){
        		return false;
        	}
			
			if (columnsRegExp.length){
				isPatternsRights = true;
				$this.loadColumns(true, columnsRegExp);
			}
		},
		
		loadColumns: function(load, columnsRegExp){
        	var $this = this;
        	if (!this.entitySchema){
        		return false;
        	}
        	
        	var columns = this.entitySchema.columns;
        	var maskColumns = [], permitColumns = [];
        	
			var mask = jQuery(".hasmask");
			mask.each(function (index, element) {
				jQuery(this).inputmask('remove');
				jQuery(this).removeClass("hasmask");
			});
        	
        	var permit = jQuery(".haspermit");
			permit.each(function (index, element) {
				jQuery(this).off('change keyup input');
				jQuery(this).removeClass("haspermit");
			});
			
			if (columnsRegExp){
				$this.set("WSMaskRegExp", JSON.stringify(columnsRegExp));
			} else {
				if ($this.get("WSMaskRegExp") && ($this.get("WSMaskRegExp") != "[]")){
					columnsRegExp = JSON.parse($this.get("WSMaskRegExp"));
				}
			}
        	
        	//Перебор
        	if (columnsRegExp){
                columnsRegExp.forEach(function(columnitem){
                	//for (key in columns) {
                        if (/*columns[key].columnPath == */columnitem.WSColumnCode){
							$this.set(columnitem.WSColumnCode + "isHasMask",false);

							if (columnitem.WSMask || columnitem.WSPermitSymbols){
								var FilterResult = true;
								if ((columnitem.WSSerializedFilter)){
									if ((columnitem.WSSerializedFilter) != ""){
										if (JSON.stringify(JSON.parse((columnitem.WSSerializedFilter))) != "{}"){
											var FilterData = BPMSoft.deserialize(columnitem.WSSerializedFilter);
											if (FilterData.collection && FilterData.isEnabled){
												if (FilterData.collection.items){
													if (FilterData.collection.items.length){
														FilterResult = $this.getFilterCollectionResult(FilterData, $this);
													}
												}
											}
										}
									}
								}
								if (FilterResult){
									if (columnitem.WSMask){
										var maskColumnsData = {};
										maskColumnsData.columnPath = columnitem.WSColumnCode;
										maskColumns.push(maskColumnsData);
									}
									if (columnitem.WSPermitSymbols){
										var permitColumnsData = {};
										permitColumnsData.columnPath = columnitem.WSColumnCode;
										permitColumns.push(permitColumnsData);
									}
								}
							}
                        }
					//}
                });
        	}
        	
        	var columnsArray = [], permitColumnsArray = [];
        	
        	//Перебор
        	for (var k = 0; k<maskColumns.length; k++){
        		
        		var OriginalColumn, ColumnMask,columnCode;
        		
        		if (!maskColumns[k].WSLookupGuid){
					OriginalColumn = $this.get(maskColumns[k].columnPath);
					ColumnMask = $this.get(maskColumns[k].columnPath + "Mask");
					columnCode = maskColumns[k].columnPath;
        		} else {
        			OriginalColumn = $this.get(maskColumns[k].columnPath);
					ColumnMask = maskColumns[k].WSMask;
					columnCode = maskColumns[k].columnPath;
        		}
					
				var ColumnWithMask = "";
				
				var j = 0;
				
				if (OriginalColumn && ColumnMask){
					for(var i=0; i<ColumnMask.length; i++){
						if ( (ColumnMask[i] == "9") || (ColumnMask[i] == "a") || (ColumnMask[i] == "*")) {
							ColumnWithMask = ColumnWithMask + OriginalColumn[j];
							j++;
						} else {
							if (ColumnMask[i] != OriginalColumn[j]){
								ColumnWithMask = ColumnWithMask + ColumnMask[i];
							} else {
								ColumnWithMask = ColumnWithMask + OriginalColumn[j];
								j++;
							}
						}
					}
				}
				
				if ($this.get(columnCode)){
					//$this.set(columnCode,ColumnWithMask);
				}
				
				var columnData = {};
				columnData.columnCode = columnCode;
				columnData.ColumnMask = ColumnMask;
				
				if (ColumnMask){
					columnsArray.push(columnData);
				}
			}
			
			for (var z = 0; z<permitColumns.length; z++){
				
				var ColumnPermit, columnCode;
				
				if (!permitColumns[z].WSLookupGuid){
					ColumnPermit = $this.get(permitColumns[z].columnPath + "Permit");
					columnCode = permitColumns[z].columnPath;
        		} else {
					ColumnPermit = permitColumns[z].WSPermit;
					columnCode = permitColumns[z].columnPath;
        		}
				
				var columnData = {};
				columnData.columnCode = columnCode;
				columnData.ColumnPermit = ColumnPermit;
				
				if (ColumnPermit){
					permitColumnsArray.push(columnData);
				}
			}
			
			clearTimeout(maskTimeout);
			
			if (columnsArray.length || permitColumnsArray.length){
				$this.loadMask(columnsArray, permitColumnsArray);
			}
        },
        
        loadMask: function(columnsArray,permitArray){
        	
        	var $this = this;
        	
        	for (var k = 0; k<columnsArray.length; k++){
				
				var input = columnsArray[k].columnCode;
				var ColumnMask = columnsArray[k].ColumnMask;
				
				var mask = jQuery("input[id*='ST" + input + "ND']");
				
				mask.each(function (index, element) {
					if (!jQuery(this).hasClass("hasmask")){
						jQuery(this).inputmask(ColumnMask);
						jQuery(this).addClass("hasmask");
						$this.set(input + "isHasMask",true);
						columnsArray[k].isLoad = true;
					}
				});
        	}
        	
        	for (var z = 0; z<permitArray.length; z++){
        		
				const permitIndex = z;
				var permit = jQuery("input[id*='ST" + permitArray[permitIndex].columnCode + "ND']");
				permit.each(function (index, element) {
					if (!jQuery(this).hasClass("haspermit")){
						jQuery(this).on("change keyup input", function() {
							var re = new RegExp(permitArray[permitIndex].ColumnPermit, 'g');
							if (this.value.match(re)) {
								this.value = this.value.replace(re, '');
							}
						});
						jQuery(this).addClass("haspermit");
						permitArray[permitIndex].isLoad = true;
					}
				});
        	}
        	
        	var allLoads = true;
        	for (var k = 0; k<columnsArray.length; k++){
        		if (!columnsArray[k].isLoad){
        			allLoads = false;
        		}
        	}
        	
        	for (var z = 0; z<permitArray.length; z++){
        		if (!permitArray[z].isLoad){
        			allLoads = false;
        		}
        	}
        	
        	if (!allLoads){
	        	clearTimeout(maskTimeout);
	        	maskTimeout = setTimeout(function() {$this.loadMask(columnsArray, permitArray);}, 100);
        	}
		},
		
		checkPatternsBeforeSave: function(){
			if (this.entitySchema && this.get("usePatterns")){
				if (this.entitySchema.columns){
					var columns = this.entitySchema.columns, valid = true, captions = "", $this = this;
					for (key in columns) {
						if (!this.validateColumn(columns[key].columnPath) && ($this.get(columns[key].columnPath + "WSJSCode") || $this.get(columns[key].columnPath + "RegExp"))){
							valid = false;
							if (!captions){
								captions = "'" + columns[key].caption + "'";
							} else {
								captions = captions + ", '" + columns[key].caption + "'";
							}
						}
					}
					if (!valid){
						this.showInformationDialog(this.get("Resources.Strings.FieldValidationMessage") + " " + captions + " " + this.get("Resources.Strings.ValidationMessage"));
						return false;
					}
				}
			}
			return true;
		},
	});
	return BPMSoft.WSFieldManagementMixin;
});
