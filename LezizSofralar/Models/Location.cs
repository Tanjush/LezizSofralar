﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LezizSofralar.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public int ParentLocationID { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string FriendlyURI { get; set; }
        public bool IsVisible { get; set; }
        public System.DateTime VisibilityStartDate { get; set; }
        public System.DateTime VisibilityEndDate { get; set; }
        public bool ShowOnTopMenu { get; set; }
        public bool ShowFilters { get; set; }
        public int DisplayOrder { get; set; }
        public string DefaultSort { get; set; }
        public string DefaultSortArgumentCode { get; set; }
        public bool ShowProducts { get; set; }
        public bool ShowSubCategoryProducts { get; set; }
        public int ProductListingPageSize { get; set; }
        public bool IsOpenNewPage { get; set; }
        public bool IsVisibleOnMobile { get; set; }
        public bool ShowSubCategoryOnTopView { get; set; }
        public bool ShowOnProductFeed { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int CreateUserID { get; set; }

        public System.DateTime CreateTime { get; set; }

        public System.DateTime UpdateTime { get; set; }

        public int UpdateUserID { get; set; }

        public bool IsActive { get; set; }
    }
}