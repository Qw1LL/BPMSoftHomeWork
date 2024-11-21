define("ESNFeedConfig", ["ext-base", "BPMSoft", "ESNFeedModuleResources", "LinkPreview"],
	function(Ext, BPMSoft, resources) {
		var createdByConfig = {
			className: "BPMSoft.Hyperlink",
			caption: {bindTo: "getCreatedByText"},
			href: {bindTo: "getCreatedUrlContact"},
			click: {bindTo: "onCreateByClick"},
			linkMouseOver: {bindTo: "linkMouseOver"},
			target: BPMSoft.controls.HyperlinkEnums.target.SELF,
			classes: {
				hyperlinkClass: ["createdBy", "label-url"]
			},
			tag: "CreatedBy",
			markerValue: "CreatedBy"
		};
		var createdByContainerConfig = {
			className: "BPMSoft.Container",
			classes: {wrapClassName: ["messageHeader"]},
			items: [
				{
					className: "BPMSoft.ImageView",
					imageSrc: {bindTo: "getCreatedByImage"},
					classes: {wrapClass: ["image32", "createdByImage", "label-link"]},
					click: {bindTo: "onCreateByClick"}
				},
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["createdByTo-wraper"]
					},
					items: [
						createdByConfig,
						{
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["createdByToEntity"]
						},
						items: [{
							className: "BPMSoft.Label",
							caption: {bindTo: "getCreatedToLabel"}
						}]
					}, {
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["entity-container"]
						},
						markerValue: {bindTo: "getEntityText"},
						items: [
							{
								className: "BPMSoft.Hyperlink",
								caption: {bindTo: "getEntityText"},
								href: {bindTo: "getCreatedPublishUrl"},
								click: {bindTo: "onEntityClick"},
								target: BPMSoft.controls.HyperlinkEnums.target.SELF,
								linkMouseOver: {bindTo: "linkMouseOver"},
								classes: {hyperlinkClass: ["entity", "label-url"]},
								tag: {columnName: "Entity"},
								markerValue: "Entity"
							}
						]
					}]
				}
			]
		};

		var messageConfig = {
			className: "BPMSoft.MultilineLabel",
			caption: {
				bindTo: "Message",
				bindConfig: {
					converter: function (value){
						if (BPMSoft.isCurrentUserSsp() &&
								BPMSoft.Features.getIsEnabled("UseNavigationServiceRedirect")) {
							while (value.match(/<(a)\s[^>]*data-link=\"mention\"[^>]*>/i)) {
								value = value.replace(/<(a)\s[^>]*data-link=\"mention\"[^>]*>/i, "<a>");
							}
						}
						return value;
					}
				}
			},
			classes: {
				multilineLabelClass: ["message"]
			},
			visible: {
				bindTo: "CommentVisible"
			},
			markerValue: "MessageText",
			showLinks: true
		};

		var linkPreviewConfig = {
			className: "BPMSoft.LinkPreview",
			linkPreviewInfo: {
				bindTo: "LinkPreviewData"
			},
			url: {
				bindTo: "UrlMessage"
			},
			visible: {
				bindTo: "getLinkPreviewVisible"
			},
			markerValue: "UrlMessageText"
		};

		var likeImageConfig = {
			className: "BPMSoft.Button",
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			imageConfig: {bindTo: "getLikeImage"},
			click: {bindTo: "onLikeClick"},
			visible: {bindTo: "LikeImageVisible"},
			classes: {
				imageClass: ["actionsButtonImage"],
				wrapperClass: ["actionsButtonWrap", "actionsColor", "likeButtonImageConfig"]
			},
			markerValue: {bindTo: "getLikeButtonMarkerValue"}
		};

		var likeTextConfig = {
			className: "BPMSoft.Button",
			visible: {bindTo: "getLikeTextVisible"},
			caption: {bindTo: "getLikeText"},
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			click: {bindTo: "onShowLikedUsers"},
			markerValue: {bindTo: "getUsersWhoLikeItMarkerValue"},
			classes: {
				textClass: ["actionsColor", "showLikedUsers"],
				wrapperClass: ["actionsButtonWrap", "actionsColor"]
			}
		};

		var postCommentEditConfig = {
			className: "BPMSoft.Button",
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			imageConfig: {bindTo: "getEditImage"},
			visible: {bindTo: "getPostCommentEditVisible"},
			click: {bindTo: "onPostCommentEditClick"},
			classes: {
				textClass: ["actionsColor", "editCaption", "postCommentEditDelete", "postCommentEditDeleteOpacity"],
				imageClass: ["postCommentEditDeleteOpacity"]
			},
			markerValue: "EditMessage"
		};

		var postCommentDeleteConfig = {
			className: "BPMSoft.Button",
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			imageConfig: {bindTo: "getDeleteImage"},
			visible: {bindTo: "getPostCommentDeleteVisible"},
			click: {bindTo: "onPostCommentDeleteClick"},
			classes: {
				textClass: ["actionsColor", "deleteCaption", "postCommentEditDelete", "postCommentEditDeleteOpacity"],
				imageClass: ["postCommentEditDeleteOpacity"]
			},
			markerValue: "DeleteMessage"
		};

		var commentEditConfig = {
			className: "BPMSoft.Button",
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			imageConfig: {bindTo: "getEditImage"},
			visible: {bindTo: "getPostCommentEditVisible"},
			click: {bindTo: "onPostCommentEditClick"},
			classes: {
				imageClass: ["actionsButtonImage"],
				wrapperClass: ["actionsButtonWrap", "actionsColor", "editButtonImageConfig"]
			},
			markerValue: "EditMessage"
		};

		var commentDeleteConfig = {
			className: "BPMSoft.Button",
			style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
			imageConfig: {bindTo: "getDeleteImage"},
			visible: {bindTo: "getPostCommentDeleteVisible"},
			click: {bindTo: "onPostCommentDeleteClick"},
			classes: {
				textClass: ["actionsColor", "editCaption", "postCommentEditDelete"]
			},
			markerValue: "DeleteMessage"
		};

		var remainsCommentsContainerConfig = {
			className: "BPMSoft.Container",
			visible: {bindTo: "RemainsCommentsContainerVisible"},
			classes: {
				wrapClassName: ["commentRemainsWrap"]
			},
			items: [
				{
					className: "BPMSoft.Button",
					caption: {bindTo: "getRemainsCommentsText"},
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					imageConfig: {
						source: BPMSoft.ImageSources.URL,
						url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.More)
					},
					click: {bindTo: "onShowCommentsClick"},
					classes: {
						imageClass: ["actionsButtonImage"],
						textClass: ["actionsButtonText"],
						wrapperClass: ["actionsButtonWrap", "actionsColor"]
					}
				}
			]
		};

		var newCommentContainerConfig = {
			className: "BPMSoft.Container",
			visible: {bindTo: "CommentPublishContainerVisible"},
			classes: {
				wrapClassName: ["comment-publish-wrap"]
			},
			items: [
				{
					className: "BPMSoft.ESNHtmlEdit",
					keydown: {bindTo: "onKeyDown"},
					value: {bindTo: "commentMessage"},
					placeholder: resources.localizableStrings.WriteComment,
					classes: {
						htmlEditClass: ["inlineTable", "wide", "editedCommentMessage", "placeholderOpacity"]
					},
					focus: {bindTo: "onNewCommentContainerFocus"},
					blur: {bindTo: "onNewCommentContainerBlur"},
					markerValue: "commentToEditESNHtmlEdit",
					height: "47px",
					prepareList: {bindTo: "prepareEntitiesExpandableList"},
					list: {bindTo: "entitiesList"},
					listViewItemRender: {bindTo: "onEntitiesListViewItemRender"},
					autoGrow: true,
					autoGrowMinHeight: 47
				},
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["inlineBlock", "wide", "commentPublish"]
					},
					items: [
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.Send,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							click: {bindTo: "onCommentPublishClick"},
							visible: {bindTo: "NewCommentButtonsVisible"},
							classes: {
								textClass: ["btn-public"]
							}
						},
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.Cancel,
							click: {bindTo: "onCancelClick"},
							visible: {bindTo: "NewCommentButtonsVisible"},
							classes: {
								textClass: ["btn-cancel"]
							}
						}
					]
				}
			]
		};

		var commentToEditContainerConfig = {
			className: "BPMSoft.Container",
			visible: {bindTo: "CommentToEditContainerVisible"},
			items: [
				{
					className: "BPMSoft.ESNHtmlEdit",
					keydown: {bindTo: "onKeyDown"},
					value: {bindTo: "commentMessage"},
					placeholder: resources.localizableStrings.WriteComment,
					classes: {
						htmlEditClass: ["inlineTable", "wide", "editedCommentMessage", "placeholderOpacity"]
					},
					focus: {bindTo: "onCommentToEditContainerFocus"},
					blur: {bindTo: "onCommentToEditContainerBlur"},
					markerValue: "commentToEditESNHtmlEdit",
					height: "47px",
					prepareList: {bindTo: "prepareEntitiesExpandableList"},
					list: {bindTo: "entitiesList"},
					listViewItemRender: {bindTo: "onEntitiesListViewItemRender"},
					autoGrow: true,
					autoGrowMinHeight: 47
				},
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["inlineBlock", "wide", "commentPublish"]
					},
					items: [
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.Send,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							click: {bindTo: "onCommentPublishClick"},
							classes: {
								textClass: ["btn-public"]
							},
							visible: {bindTo: "CommentToEditButtonsVisible"}
						},
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.Cancel,
							click: {bindTo: "onCancelClick"},
							classes: {
								textClass: ["btn-cancel"]
							},
							visible: {bindTo: "CommentToEditButtonsVisible"}
						}
					]
				}
			]
		};

		/**
		 * Comment configuration.
		 */
		var commentConfig = {
			className: "BPMSoft.Container",
			id: "commentItem-container",
			selectors: {wrapEl: "#commentItem-container"},
			classes: {wrapClassName: ["commentContainer"]},
			items: [
				{
					className: "BPMSoft.ImageView",
					imageSrc: {bindTo: "getCreatedByImage"},
					classes: {
						wrapClass: ["image32", "createdByImage", "label-link"]
					},
					click: {bindTo: "onCreateByClick"}
				},
				createdByConfig,
				commentToEditContainerConfig,
				messageConfig,
				linkPreviewConfig,
				{
					className: "BPMSoft.Container",
					classes: {wrapClassName: ["comment-actions"]},
					visible: {bindTo: "ActionsContainerVisible"},
					items: [
						{
							className: "BPMSoft.Label",
							caption: {bindTo: "getCreatedOnText"},
							classes: {
								labelClass: ["createdByDate", "unimportant"]
							}
						},
						likeTextConfig,
						likeImageConfig,
						{
							className: "BPMSoft.Container",
							classes: {
								wrapClassName: ["actions-right", "actionsEditDelete"]
							},
							items: [
								commentEditConfig,
								commentDeleteConfig
							]
						}
					]
				}
			]
		};

		var publishContainer = {
			className: "BPMSoft.Container",
			visible: {bindTo: "PublishContainerVisible"},
			items: [
				{
					className: "BPMSoft.ESNHtmlEdit",
					keydown: {bindTo: "onKeyDown"},
					value: {bindTo: "editedCommentMessage"},
					placeholder: resources.localizableStrings.WriteComment,
					classes: {
						htmlEditClass: ["inlineTable", "wide", "editedCommentMessage", "placeholderOpacity"]
					},
					focus: {bindTo: "onEditedCommentContainerFocus"},
					blur: {bindTo: "onEditedCommentContainerBlur"},
					markerValue: "postToEditESNHtmlEdit",
					height: "47px",
					prepareList: {bindTo: "prepareEntitiesExpandableList"},
					list: {bindTo: "entitiesList"},
					listViewItemRender: {bindTo: "onEntitiesListViewItemRender"},
					autoGrow: true,
					autoGrowMinHeight: 47
				},
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["inlineBlock", "wide", "commentPublish"]
					},
					items: [
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.Publish,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							click: {bindTo: "onCommentPublishClick"},
							visible: {bindTo: "EditedCommentContainerVisible"},
							classes: {
								textClass: ["btn-public"]
							},
							markerValue: "PublishMessage"
						},
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.Cancel,
							click: {bindTo: "onCancelClick"},
							visible: {bindTo: "EditedCommentContainerVisible"},
							classes: {
								textClass: ["btn-cancel"]
							}
						}
					]
				}
			]
		};

		/**
		 * Message configuration.
		 */
		var postConfig = {
			className: "BPMSoft.Container",
			id: "postItem-container",
			selectors: {wrapEl: "#postItem-container"},
			markerValue: {bindTo: "getMessageContainerMarkerValue"},
			classes: {
				wrapClassName: ["postContainer"]
			},
			items: [
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["parentPostContainer"]
					},
					items: [
						createdByContainerConfig,
						{
							className: "BPMSoft.Label",
							caption: {bindTo: "getCreatedOnText"},
							classes: {
								labelClass: ["createdByDate", "unimportant"]
							},
							markerValue: "CreatedOn"
						},
						messageConfig,
						linkPreviewConfig,
						publishContainer,
						{
							className: "BPMSoft.Container",
							classes: {
								wrapClassName: ["actions"]
							},
							visible: {bindTo: "ActionsContainerVisible"},
							items: [
								{
									className: "BPMSoft.Container",
									classes: {
										wrapClassName: ["comment-like-actions-actions-right"]
									},
									items: [
										{
											className: "BPMSoft.Button",
											caption: {bindTo: "getShowCommentsText"},
											visible: {bindTo: "getShowCommentsVisible"},
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											imageConfig: {
												source: BPMSoft.ImageSources.URL,
												url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Comment)
											},
											click: {bindTo: "onShowCommentsClick"},
											classes: {
												imageClass: ["actionsButtonImage", "comment-icon-action"],
												textClass: ["actionsButtonText"],
												wrapperClass: ["actionsButtonWrap", "actionsColor"]
											},
											markerValue: "Comments"
										},
										{
											className: "BPMSoft.Button",
											caption: {bindTo: "getToggleCommentsText"},
											visible: {bindTo: "getToggleCommentsVisible"},
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											imageConfig: {
												source: BPMSoft.ImageSources.URL,
												url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Comment)
											},
											click: {bindTo: "onToggleCommentsClick"},
											classes: {
												imageClass: ["actionsButtonImage"],
												textClass: ["actionsButtonText"],
												wrapperClass: ["actionsButtonWrap", "actionsColor", "direction-reverse"]
											},
											markerValue: {bindTo: "getToggleCommentsButtonMarkerValue"}
										},
										{
											className: "BPMSoft.Button",
											caption: {bindTo: "getShowCommentsText"},
											visible: {bindTo: "getHideCommentsVisible"},
											style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
											imageConfig: {
												source: BPMSoft.ImageSources.URL,
												url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Comment)
											},
											click: {bindTo: "onHideCommentsClick"},
											classes: {
												imageClass: ["actionsButtonImage", "comment-icon-action"],
												textClass: ["actionsButtonText"],
												wrapperClass: ["actionsButtonWrap", "actionsColor"]
											},
											markerValue: "Hide comments"
										},
										likeTextConfig,
										likeImageConfig,
										{
											className: "BPMSoft.Container",
											classes: {
												wrapClassName: ["actions-right"]
											},
											items: [
												postCommentEditConfig,
												postCommentDeleteConfig
											]
										}
								]}
							]
						}
					]
				},
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["commentsContainer"]
					},
					visible: {bindTo: "CommentsExpanded"},
					items: [
						remainsCommentsContainerConfig,
						{
							className: "BPMSoft.ContainerList",
							idProperty: "Id",
							collection: {bindTo: "LoadedComments"},
							defaultItemConfig: commentConfig,
							observableRowNumber: 5
						},
						newCommentContainerConfig
					]
				}
			]
		};

		return {
			postConfig: postConfig,
			commentConfig: commentConfig
		};
	});
