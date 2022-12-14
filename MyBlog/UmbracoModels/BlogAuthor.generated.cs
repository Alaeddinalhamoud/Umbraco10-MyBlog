//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v10.2.1+25a20cf
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	/// <summary>Author</summary>
	[PublishedModel("blogAuthor")]
	public partial class BlogAuthor : PublishedContentModel, IPage
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		public new const string ModelTypeAlias = "blogAuthor";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<BlogAuthor, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public BlogAuthor(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Author Avatar
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("authorAvatar")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops AuthorAvatar => this.Value<global::Umbraco.Cms.Core.Models.MediaWithCrops>(_publishedValueFallback, "authorAvatar");

		///<summary>
		/// Author Details
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("authorDetails")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString AuthorDetails => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "authorDetails");

		///<summary>
		/// Author Name
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("authorName")]
		public virtual object AuthorName => this.Value(_publishedValueFallback, "authorName");

		///<summary>
		/// Social Media
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("socialMedia")]
		public virtual global::Umbraco.Cms.Core.Models.Blocks.BlockListModel SocialMedia => this.Value<global::Umbraco.Cms.Core.Models.Blocks.BlockListModel>(_publishedValueFallback, "socialMedia");

		///<summary>
		/// Author: meta Author
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("author")]
		public virtual string Author => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetAuthor(this, _publishedValueFallback);

		///<summary>
		/// Description: meta Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("description")]
		public virtual string Description => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetDescription(this, _publishedValueFallback);

		///<summary>
		/// Display on A to Z
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("displayOnAToZ")]
		public virtual bool DisplayOnAtoZ => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetDisplayOnAtoZ(this, _publishedValueFallback);

		///<summary>
		/// Display on Navbar: To display the page on the Navbar
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("displayOnNavbar")]
		public virtual bool DisplayOnNavbar => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetDisplayOnNavbar(this, _publishedValueFallback);

		///<summary>
		/// Display on Sitemap
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[ImplementPropertyType("displayOnSitemap")]
		public virtual bool DisplayOnSitemap => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetDisplayOnSitemap(this, _publishedValueFallback);

		///<summary>
		/// Keywords: Meta Keyword
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("keywords")]
		public virtual global::System.Collections.Generic.IEnumerable<string> Keywords => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetKeywords(this, _publishedValueFallback);

		///<summary>
		/// Open Graph Image: og:image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("ogImage")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops OgImage => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetOgImage(this, _publishedValueFallback);

		///<summary>
		/// Open Graph Type: og:type content type
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("ogtype")]
		public virtual string Ogtype => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetOgtype(this, _publishedValueFallback);

		///<summary>
		/// Page Banner: Page Banner
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("pageBanner")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops PageBanner => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetPageBanner(this, _publishedValueFallback);

		///<summary>
		/// Sub Title: Page Sub title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("subTitle")]
		public virtual string SubTitle => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetSubTitle(this, _publishedValueFallback);

		///<summary>
		/// Title: Page Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("title")]
		public virtual string Title => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetTitle(this, _publishedValueFallback);

		///<summary>
		/// Twitter Card: card  for Twitter
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "10.2.1+25a20cf")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("twitterCard")]
		public virtual string TwitterCard => global::Umbraco.Cms.Web.Common.PublishedModels.Page.GetTwitterCard(this, _publishedValueFallback);
	}
}
