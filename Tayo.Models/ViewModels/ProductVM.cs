using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayo.Models.ViewModels
{
    public class ProductVM
    {
        public Product? Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? ProductSizeList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? ProductColorList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? CollectionList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
    }
}
