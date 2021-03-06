﻿using LezizSofralar.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LezizSofralar.ViewModels
{
    public class ProductStatusCodesListViewModel : ListViewModel
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Name = nameof(ProductStatusCodeResources.FieldName_Status), ResourceType = typeof(ProductStatusCodeResources))]
        public string Status { get; set; }
    }
}